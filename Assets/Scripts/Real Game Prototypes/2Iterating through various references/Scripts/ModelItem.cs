using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;


[Serializable]
public class ModelItem
{


    [SerializeField] [FormerlySerializedAs("Model")] private GameObject _model;

    public GameObject Model
    {
        get => _model;
        set => _model = value;
    }

    [SerializeField] [FormerlySerializedAs("ModelReference")] private AssetReference _modelReference;
    public AssetReference ModelReference
    {
        get => _modelReference;
        set => _modelReference = value;
    }
    
    
    
    
    public int Rotation;
    public float Scale = 1;
    public Vector3 Position;
}
