
using System;
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
    [SerializeField] private bool _convertContentToReference;
    private void Start()
    {
        /*GetAssetAddress();


        

        /*MultipleConvertTextureToAssetReference();*/

        if (_convertContentToReference) MultipleConvertGameobjectToAssetReference();
        if (_loadReference) LoadReference();
    }

    private void LoadReference()
    {
        for (int i = 0; i < _setOfTileItems.Items.Count; i++)
        {
            _references.Add(_setOfTileItems.Items[i].ModelItem.ModelReference);
        }

        StartCoroutine(LoadAndWaitUntilComplete());


       
            for (int i = 0; i < _setOfTileItems.Items.Count; i++)
            {
                _setOfTileItems.Items[i].ModelItem.Model =  _references[i].editorAsset as GameObject;
                if (_setOfTileItems.Items[i].ModelItem.Model != null) Instantiate(_setOfTileItems.Items[i].ModelItem.Model);
            }
    }
    private IEnumerator LoadAndWaitUntilComplete()
    {
        yield return AssetRefLoader.LoadAssetsAddToList(_references, _completedObj);
    }
    
    
    private IEnumerator LoadAndWaitUntilCompleteAlt()
    {
        yield return AssetRefLoader.LoadAssetsAddToList2(_references, _completedObj); //_references and _completedObj should have something in common
    }


    private void OnDestroy()
    {
        foreach (var reference in _references)
        {
            reference.ReleaseAsset();
        }

        for (int i = 0; i < _references.Count; i++)
        {
            _references[i].ReleaseInstance( _setOfTileItems.Items[i].ModelItem.Model);
        }
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


    
    
    private void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        // In a production environment, you should add exception handling to catch scenarios such as a null result.
       
    }
}
