using System;
using UnityEngine;
using UnityEngine.AddressableAssets;


[Serializable]
public class ModelItem
{
    public GameObject Model;
    public AssetReference ModelReference;
    public int Rotation;
    public float Scale = 1;
    public Vector3 Position;
}
