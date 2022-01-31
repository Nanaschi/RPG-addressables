
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetRefObjectData : MonoBehaviour
{
    private List<AssetReference> _references = new List<AssetReference>();
    [SerializeField] private List<GameObject> _completedObj = new List<GameObject>();
    [SerializeField] public SetOfTileItems _setOfTileItems;
    [SerializeField] private int _index;
    [SerializeField] private bool _loadReference;
    private void Start()
    {
        /*GetAssetAddress();


        MultipleConvertGameobjectToAssetReference();*/

        /*MultipleConvertTextureToAssetReference();*/


        if (_loadReference) LoadReference();
    }

    private void LoadReference()
    {
        for (int i = 0; i < _setOfTileItems.Items.Count; i++)
        {
            //TODOD here should be converting from gameobjects into assetReferences


            if (string.IsNullOrEmpty(_setOfTileItems.Items[i].ModelItem.ModelReference.AssetGUID)) continue;

            _references.Add(_setOfTileItems.Items[i].ModelItem.ModelReference);
        }

        StartCoroutine(LoadAndWaitUntilComplete());
    }

    private void ConvertGameobjectToAssetReference()
    {
        _setOfTileItems.Items[_index].ModelItem.ModelReference
            .SetEditorAsset(_setOfTileItems.Items[_index].ModelItem.Model);
    }
    private void MultipleConvertGameobjectToAssetReference()
    {
        for (int i = 0; i < _setOfTileItems.Items.Count; i++)
        {
            _setOfTileItems.Items[i].ModelItem.ModelReference
                .SetEditorAsset(_setOfTileItems.Items[i].ModelItem.Model);
        }
    }
    
    private void MultipleConvertTextureToAssetReference()
    {
        for (int i = 0; i < _setOfTileItems.Items.Count; i++)
        {
            var iteration = _setOfTileItems.Items[i];
            iteration.PreviewTexture.AssetReferenceTexture2D.SetEditorAsset(_setOfTileItems.Items[i].PreviewTexture.Texture);
            iteration.TGHTexture.AssetReferenceTexture2D.SetEditorAsset(_setOfTileItems.Items[i].TGHTexture.Texture);
            iteration.InteractiveMap.AssetReferenceTexture2D.SetEditorAsset(_setOfTileItems.Items[i].InteractiveMap.Texture);
        }
    }

    private string GetAssetAddress()
    {
        var assetAddress =
            ConvertingGameObjectIntoReference.GetAddressFromPrefabTest(_setOfTileItems.Items[_index].ModelItem.Model);
        print(ConvertingGameObjectIntoReference.GetAddressFromPrefabTest(_setOfTileItems.Items[_index].ModelItem.Model));
        return assetAddress;
    }

    private IEnumerator LoadAndWaitUntilComplete()
    {
        yield return AssetRefLoader.CreateAssetsAddToList(_references, _completedObj);
    }
    
    
    private void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        // In a production environment, you should add exception handling to catch scenarios such as a null result.
       
    }
}
