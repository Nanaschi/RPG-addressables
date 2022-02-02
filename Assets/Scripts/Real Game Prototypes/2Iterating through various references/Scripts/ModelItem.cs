using System;
using System.Threading.Tasks;
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
    public AssetReference ModelReference
    {
        get => _modelReference;
        set => _modelReference = value;
    }
    
    public async Task<GameObject> InstantiateObjectFromReference()
    {

    
        var handle = Addressables.InstantiateAsync(_modelReference);
        _model = await handle.Task;
        return _model;
    }
    
    
    
    public async Task<GameObject> GetObjectFromReference()
    {
        var handle = Addressables.LoadAssetAsync<GameObject>(_modelReference);
        _model = await handle.Task;
        return _model;
    }
    

    public GameObject Model
    {
        get
        {
            Debug.Log("New get");
            return null;
        }

        set
        {
            
        }
    }
    
    
    
    /*
    protected async Task<GameObject> LoadInternal(AssetReference assetReference)
    {
        var handle = Addressables.LoadSceneAsync(assetReference);
        _model = await handle.Task;
        /*if (_model == null)
        {
            throw new NullReferenceException($"{typeof(T)} not loaded");
        }#1#

        return _model;
    }

    public Task<GameObject> Load()
    {
        return LoadInternal(_modelReference);
    }
    */
    
    
    
    
    
    
    
    



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
