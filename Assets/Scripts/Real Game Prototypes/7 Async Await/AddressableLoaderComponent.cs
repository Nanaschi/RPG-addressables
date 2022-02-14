using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;

public static class AddressableLoaderComponent
{
    
    public static async Task<T> GetObjectFromReference<T>(AssetReference contentAssetReference) where T: Object
    {
        /*if (string.IsNullOrEmpty(contentAssetReference.AssetGUID)) Debug.LogError("AssetGUID of the referenced AssetReference is empty/ not assigned");*/
        var handle = Addressables.LoadAssetAsync<T>(contentAssetReference);
        var cachedModel = await handle.Task;
        return cachedModel;
    }
    
    
    
    

    public static void ReleasingTheHandle()
    {
        
    }
    
    public static async Task InitByNameOrLabel<T>(string assetNameOrLabel, List<T> createdObjs)
        where T : Object
    {
        var locations = await Addressables.LoadResourceLocationsAsync(assetNameOrLabel).Task;
        
        await CreateAssetsThenUpdateCollection(locations, createdObjs);
    }
    
    public static async Task IniByLoadedAddress<T>(IList<IResourceLocation> loadedLocations, List<T> createdObjs)
        where T : Object
    {
        await CreateAssetsThenUpdateCollection(loadedLocations, createdObjs);
    }

    private static async Task CreateAssetsThenUpdateCollection<T>(IList<IResourceLocation> locations, List<T> createdObjs)
        where T: Object
    {
        foreach (var location in locations)
            createdObjs.Add(await Addressables.InstantiateAsync(location).Task as T);
    }
}
