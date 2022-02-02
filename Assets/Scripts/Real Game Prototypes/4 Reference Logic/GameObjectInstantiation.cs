using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = System.Random;

public class GameObjectInstantiation : MonoBehaviour
{
    [SerializeField] private AssetRefObjectData _assetRefObjectData;
    [SerializeField] private Transform[] _pointsToInstantiate;

    [SerializeField] private LocalAssetLoader _localAssetLoader; 
    private void Start()
    {
       CreateObject();
    }

    private async void CreateObject()
    {
        for (int i = 0; i < _assetRefObjectData._setOfTileItems.Items.Count; i++)
        {
            
            
            
            
            var newGameObject = await _assetRefObjectData._setOfTileItems.Items[i].ModelItem.GetObjectFromReference();
            Instantiate(newGameObject, _pointsToInstantiate[i]);
 
            
            
            
            
                 await Task.WhenAll(_assetRefObjectData._setOfTileItems.Items[i].ModelItem.GetObjectFromReference());
        }
    }
}
