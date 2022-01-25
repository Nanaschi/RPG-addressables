using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadWithReferencePrototypeIterator : MonoBehaviour
{
    [SerializeField] int _testingIndexID;
    
    AssetReference[] reference;
    AssetReference reference1;
    [SerializeField] private SetOfTileItems _setOfTileItems;
    
    // Start the load operation on start
    void Start()
    {
  
            Debug.Log("You are here");
            reference1 = _setOfTileItems.Items[_testingIndexID].ModelItem.ModelReference;
            AsyncOperationHandle handle = reference1.LoadAssetAsync<GameObject>();
            handle.Completed += Handle_Completed;
        
    }

    // Instantiate the loaded prefab on complete
    private void Handle_Completed(AsyncOperationHandle obj) {
        if (obj.Status == AsyncOperationStatus.Succeeded) {
            Instantiate(reference1.Asset, transform);
        } else {
            Debug.LogError($"AssetReference {reference1.RuntimeKey} failed to load.");
        }
    }


    // Release asset when parent object is destroyed
    private void OnDestroy() {
        reference1.ReleaseAsset();
    }
}
