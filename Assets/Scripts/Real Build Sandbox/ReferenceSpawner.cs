using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceSpawner : MonoBehaviour
{
    [SerializeField] private SetOfTileItems _setOfTileItems;

    private void Awake()
    {
        
    }

    private void Start()
    {
        Instantiate(_setOfTileItems.Items[0].ModelItem.ContentModel);
    }
}
