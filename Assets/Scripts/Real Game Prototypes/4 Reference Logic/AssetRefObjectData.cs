using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetRefObjectData : MonoBehaviour
{
    private List<AssetReference> _references = new List<AssetReference>();
    [SerializeField] private List<GameObject> _completedObj = new List<GameObject>();
    [SerializeField] private SetOfTileItems _setOfTileItems;
    [SerializeField] private int _index;
    [SerializeField] 
    private void Start()
    {
        for (int i = 0; i < _setOfTileItems.Items.Count; i++)
        {
            if (string.IsNullOrEmpty(_setOfTileItems.Items[i].ModelItem.ModelReference.AssetGUID)) continue;

            _references.Add(_setOfTileItems.Items[i].ModelItem.ModelReference);
            
        }
        StartCoroutine(LoadAndWaitUntilComplete());

    }

    private IEnumerator LoadAndWaitUntilComplete()
    {
        yield return AssetRefLoader.CreateAssetsAddToList(_references, _completedObj);
    }
}
