using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = System.Random;

public class GameObjectInstantiation : MonoBehaviour
{
    [SerializeField] private SetOfTileItems _setOfTileItems;
    [SerializeField] private Transform[] _pointsToInstantiate;


    [SerializeField] [ItemCanBeNull] private List<GameObject>  _gameObject;


    public async void CreateObject()
    {
        
         
        for (int i = 0; i < _setOfTileItems.Items.Count; i++)
        {

            

            /*var newGameObject = await AddressableLoaderComponent.GetObjectFromReference<GameObject>(_setOfTileItems.Items[i].ModelItem.ModelReference);*/
            
            /*var newGameObject = await _setOfTileItems.Items[i].ModelItem.GetObjectFromReference();
            var smth = Instantiate(newGameObject, _pointsToInstantiate[i]);*/

           var go = Instantiate(await _setOfTileItems.Items[i].ModelItem.GetObjectFromReference());
           
           
           
           

           /*print(_setOfTileItems.Items[i].ModelItem.AsyncOperationHandle);
           Addressables.Release(_setOfTileItems.Items[i].ModelItem.AsyncOperationHandle);

           print(_setOfTileItems.Items[i].ModelItem.AsyncOperationHandle);*/
           /*
           await Task.WhenAll(_assetRefObjectData._setOfTileItems.Items[i].ModelItem.GetObjectFromReference());*/
        }
    }

    public void Release()
    {
        for (int i = 0; i < _gameObject.Count; i++)
        {
            _setOfTileItems.Items[0].ModelItem.ReleaseInstantiateObjectFromReference();
        }
     

    }
}
