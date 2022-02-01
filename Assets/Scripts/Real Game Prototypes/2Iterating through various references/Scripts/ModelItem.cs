using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;


[Serializable]
public class ModelItem
{


    [SerializeField] private GameObject _model;

    public GameObject Model
    {
        get { Debug.Log("Getting Model"); return _model; }
        set { Debug.Log("Setting Model"); _model = value; }
    }   
    
    

    public GameObject ModelOld
    {
        get
        {

            return _model;
        }
        set
        { 

        }
        
  
    }

    [SerializeField] [FormerlySerializedAs("ModelReference")] private AssetReference _modelReference;

    public AssetReference EmptyAssetReference { get; }
    public AssetReference ModelReference
    {
        get => _modelReference;
        set => _modelReference = value;
    }
    
    public GameObject ReferenceGameObject
    {
        get => _modelReference.Asset as GameObject;
        set => value = _modelReference.Asset as GameObject;
    }


    public int Rotation;
    public float Scale = 1;
    public Vector3 Position;
    
    public GameObject ModelAlt
    {
        get
        {
           
            var _asyncOperationHandle =Addressables.LoadAssetAsync<GameObject>(_model).WaitForCompletion();
            return _asyncOperationHandle.gameObject;
        }
        set
        { 

        }
        
  
    }   

}
