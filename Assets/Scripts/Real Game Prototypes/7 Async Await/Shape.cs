using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{

    [SerializeField] private int _secondsToRotate;
    public void BeginRotate()
    {
        StartCoroutine(RotateForSeconds(_secondsToRotate));
    }

    private IEnumerator RotateForSeconds(float duration)
    {
        var end = Time.time + duration;
        while (Time.time < end)
        {
            transform.Rotate(new Vector3(1,1) * Time.deltaTime *150);
            yield return null;
        }
    }
}
