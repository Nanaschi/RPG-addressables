using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;


[Serializable]
public class ModelItem
{


    [SerializeField] private GameObject _model;
    [SerializeField] private AssetReference _modelReference;
    public GameObject Model
    {
        get
        {
            if(string.IsNullOrEmpty(_modelReference.AssetGUID))
            {
                throw new NullReferenceException($"Model reference with Guid {_modelReference} is empty");
            }
            else
            {
                /*var obj =Addressables.InstantiateAsync(_modelReference);*/
                AsyncOperationHandle handle = _modelReference.LoadAssetAsync<GameObject>();
                handle.Completed += Handle_Completed;
                return null;
            }
        }
        set { Debug.Log("Setting Model"); _model = value; }
    }
    private void Handle_Completed(AsyncOperationHandle obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            _model = _modelReference.Asset as GameObject;
            
            Debug.Log("Succeeded");
        } 
        else 
        {
            Debug.LogError($"AssetReference {_modelReference.RuntimeKey} failed to load.");
        }
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
