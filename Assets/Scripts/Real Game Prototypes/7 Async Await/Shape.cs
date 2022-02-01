using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Shape : MonoBehaviour
{

    [SerializeField] private int _secondsToRotate;
    [SerializeField] private GameObject[] _objectsToRotate;
    public async void BeginRotate()
    {
        for (int i = 0; i < _objectsToRotate.Length; i++)
        {
           await RotateForSeconds(_secondsToRotate, _objectsToRotate[i].transform);
        }
            
    }

    /*private IEnumerator RotateForSeconds(float duration)
    {
        var _rotationAngle = new Vector3(1, 1);
        var end = Time.time + duration;
        while (Time.time < end)
        {
            transform.Rotate( _rotationAngle* Time.deltaTime *150);
            yield return null;
        }
    }   */ 
    
    private async Task RotateForSeconds(float duration, Transform objectToRotate) //Task gives us the information about the performed actions
    {
        var _rotationAngle = new Vector3(1, 1);
        var end = Time.time + duration;
        while (Time.time < end)
        {
            objectToRotate.Rotate( _rotationAngle * Time.deltaTime *150);
            await Task.Yield();
        }
    }
}
