using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LocalAssetLoader: MonoBehaviour
{

    private GameObject _cachedGameObject;

    public async Task<GameObject> LoadInternal(AssetReference assetReference)
    {
        var handle = Addressables.InstantiateAsync(assetReference);
        _cachedGameObject = await handle.Task;
        return _cachedGameObject;
    }

}
