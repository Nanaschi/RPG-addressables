using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetRefLoader
{
    public static async Task CreateAssetsAddToList<T>(List<AssetReference> references, List<T> completedObjs) 
        where T : Object
    {
        foreach (var reference in references)
        {
            if (!string.IsNullOrEmpty(reference.AssetGUID))
            {
                completedObjs.Add(await reference.InstantiateAsync().Task as T);
            }
        }
    }

    
    public static async Task LoadAssetsAddToList<T>(List<AssetReference> references, List<T> completedObjs) 
        where T : Object
    {
        foreach (var reference in references)
        {
            if (!string.IsNullOrEmpty(reference.AssetGUID))
            {
               completedObjs.Add(await reference.LoadAssetAsync<T>().Task);
            }
        }
    }    
    public static async Task LoadAssetsAddToList2<T>(List<AssetReference> references, List<T> completedObjs) 
        where T : Object
    {
        foreach (var reference in references)
        {
            if (!string.IsNullOrEmpty(reference.AssetGUID))
            {
               var gameObjectToAdd = await reference.LoadAssetAsync<T>().Task;
               AddingGameObjectToAList(gameObjectToAdd, completedObjs);
            }
        }
    }

    private static T AddingGameObjectToAList<T>(T gameObjectToAdd, List<T> completedObjs) where T : Object
    {
       completedObjs.Add(gameObjectToAdd);
       GameObject.Instantiate(gameObjectToAdd);
       return gameObjectToAdd;
    }
}
