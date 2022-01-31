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
            completedObjs.Add(await reference.LoadAssetAsync<T>().Task);
    }
}
