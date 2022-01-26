using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public enum TypeOfLoading2
{
    Single,
    Multiple
}

public class LoadWithReferencePrototypeIterator2 : MonoBehaviour
{
    [Range(0, 100)][SerializeField] int _testingIndexID;
    [SerializeField] private TypeOfLoading2 _typeOfLoading;
    AssetReference[] multipleReference;
    AssetReference singleReference;
    [SerializeField] private SetOfTileItems _setOfTileItems;
    
    // Start the load operation on start
    void Start()
    {
       if (_typeOfLoading == TypeOfLoading2.Single) StartOperationHandle();
       if (_typeOfLoading == TypeOfLoading2.Multiple) StartMultipleOperationHandle();
    }

    
    
    
    private void StartMultipleOperationHandle()
    {
        for (int i = 0; i < _setOfTileItems.Items.Count; i++)
        {
            singleReference = _setOfTileItems.Items[i].ModelItem.ModelReference;
            AsyncOperationHandle handle = singleReference.LoadAssetAsync<GameObject>();
            /*Addressables.LoadAssetsAsync()*/
            handle.Completed += MultipleHandle_Completed;    
        }
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


    // Release asset when parent object is destroyed
    private void OnDestroy() {
        singleReference.ReleaseAsset();
    }
}
