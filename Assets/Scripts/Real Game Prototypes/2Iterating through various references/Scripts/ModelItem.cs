using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;


[Serializable]
public class ModelItem
{
    public GameObject Model;
    public AssetReference ModelReference;
    public Object ModelReferenceProperty
    {
        get { return ModelReference.Asset;}
        set {  }
    }
    public int Rotation;
    public float Scale = 1;
    public Vector3 Position;
}
