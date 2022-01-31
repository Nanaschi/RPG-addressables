using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameObjectInstantiation : MonoBehaviour
{
    [SerializeField] private AssetRefObjectData _assetRefObjectData;
    [SerializeField] private int _objectIndex;
    [SerializeField] private Transform[] _pointsToInstantiate;
    private void Start()
    {
        for (int i = 0; i < _assetRefObjectData._setOfTileItems.Items.Count; i++)
        {
            Instantiate(_assetRefObjectData._setOfTileItems.Items[i].ModelItem.Model, _pointsToInstantiate[UnityEngine.Random.Range(0, _pointsToInstantiate.Length)]);
        }

    }
}
