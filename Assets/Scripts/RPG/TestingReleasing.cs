using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TestingReleasing : MonoBehaviour
{
    [SerializeField] private string _label;
    
    private List<GameObject> Assets { get; } = new List<GameObject>();
 
    private void Start()
    {
        CreateAndWaitUntilCompleted();
    }

    private async Task CreateAndWaitUntilCompleted()
    {
        await AddressableLoaderComponent.InitByNameOrLabel(_label, Assets);

        foreach (var asset in Assets)
        {
            //OBJS LOADED PERFORM ADDITIONAL ACTIONS
            Debug.Log(asset.name);
        }

        await Task.Delay(TimeSpan.FromSeconds(2));
        ClearAssets(Assets);
    }

    private void ClearAssets(List<GameObject> gos)
    {
        foreach (var go in gos)
        {
            Debug.Log("Released: " + go.name);
            Addressables.Release(go);
        }
    }
}
