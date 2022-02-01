using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectLogic : MonoBehaviour
{
    [SerializeField] private SetOfTileItems _setOfTileItems;
    [SerializeField] private int _objectIndex;
    [SerializeField] private Transform[] _pointsToInstantiate;
    private void Start()
    {
        CreateObject();
    }

    private void CreateObject()
    {
        for (int i = 0; i < _setOfTileItems.Items.Count; i++)
        {
            Instantiate(_setOfTileItems.Items[i].ModelItem.Model, _pointsToInstantiate[i]);
        }
    }
}
