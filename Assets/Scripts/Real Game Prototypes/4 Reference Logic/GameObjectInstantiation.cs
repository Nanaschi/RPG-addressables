using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectInstantiation : MonoBehaviour
{
    [SerializeField] private AssetRefObjectData _assetRefObjectData;
    [SerializeField] private int _objectIndex;

    private void Start()
    {
        for (int i = 0; i < _assetRefObjectData._setOfTileItems.Items.Count; i++)
        {
            Instantiate(_assetRefObjectData._setOfTileItems.Items[i].ModelItem.Model);
        }

    }
}
