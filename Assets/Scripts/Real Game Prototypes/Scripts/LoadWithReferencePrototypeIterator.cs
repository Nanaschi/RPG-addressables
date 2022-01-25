using System.Collections;
using System.Collections.Generic;
using Scripts.Gameplay.Tiles;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public enum TypeOfLoading
{
    Single,
    Multiple
}

public class LoadWithReferencePrototypeIterator : MonoBehaviour
{
    [Range(0, 100)][SerializeField] int _testingIndexID;
    [SerializeField] private TypeOfLoading _typeOfLoading;
    AssetReference[] multipleReference;
    AssetReference singleReference;
    [SerializeField] private SetOfTileItems _setOfTileItems;
    [SerializeField] private int timeToSelfDestruct;

    private AsyncOperationHandle<IList<GameObject>> loadWithIResourceLocations;
    private AsyncOperationHandle<GameObject> _asyncOperationHandle;
    
    // Start the load operation on start
    void Start()
    {
       if (_typeOfLoading == TypeOfLoading.Single) StartOperationHandle();
       if (_typeOfLoading == TypeOfLoading.Multiple) StartMultipleOperationHandle();
       Invoke(nameof(SelfDestruction), 0);
       
    }

    private void SelfDestruction()
    {
        Destroy(gameObject, timeToSelfDestruct);
    }
    
    
    
    private void StartMultipleOperationHandle()
    {
        for (int i = 0; i < _setOfTileItems.Items.Count; i++)
        {
            var modelReference = _setOfTileItems.Items[i].ModelItem.ModelReference; 
            if (string.IsNullOrEmpty(modelReference.AssetGUID)) continue;
            loadWithIResourceLocations =
                Addressables.LoadAssetsAsync<GameObject>(modelReference,
                    obj =>
                    {
                       
                            //Gets called for every loaded asset
                            Debug.Log(obj.name);
                            /*_asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(modelReference);*/
                            Addressables.InstantiateAsync(modelReference);

                    });
        }
        
    }
    
    // Release asset when parent object is destroyed
    private void OnDestroy() 
    {
        print(loadWithIResourceLocations);
            Addressables.ReleaseInstance(loadWithIResourceLocations);

    }  
    

    private void MultipleHandle_Completed(AsyncOperationHandle obj) {
        if (obj.Status == AsyncOperationStatus.Succeeded) {
            Instantiate(singleReference.Asset, transform);
        } else {
            Debug.LogError($"AssetReference {singleReference.RuntimeKey} failed to load.");
        }
    }
    

  
    
    
    
    
    
    
    
    
    
    
    private void StartOperationHandle()
    {
        
        singleReference = _setOfTileItems.Items[_testingIndexID].ModelItem.ModelReference;
        AsyncOperationHandle handle = singleReference.LoadAssetAsync<GameObject>();
        handle.Completed += Handle_Completed;
    }

    // Instantiate the loaded prefab on complete
    private void Handle_Completed(AsyncOperationHandle obj) {
        if (obj.Status == AsyncOperationStatus.Succeeded) {
            Instantiate(singleReference.Asset, transform);
        } else {
            Debug.LogError($"AssetReference {singleReference.RuntimeKey} failed to load.");
        }
    }


}
