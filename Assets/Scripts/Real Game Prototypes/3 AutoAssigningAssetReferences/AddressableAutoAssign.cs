using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
 
public class AddressableAutoAssign : MonoBehaviour
{
    [MenuItem("Tools/Auto Assign Addressables")]
    public static void AutoAssignAddressables()
    {
        MonoBehaviour[] sceneActive = GameObject.FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour mono in sceneActive)
        {
            // Retrieve the fields from the mono instance
            FieldInfo[] objectFields = mono.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Default | BindingFlags.NonPublic);
            for (int i = 0; i < objectFields.Length; i++)
            {
                if (Attribute.GetCustomAttribute(objectFields[i], typeof(Attribute)) != null)
                {
                    // with this attribute we grab the field from above
                    UnityEngine.Object source = objectFields[i - 1].GetValue(mono) as UnityEngine.Object;
                    AssetDatabase.TryGetGUIDAndLocalFileIdentifier(source, out var guid, out long _);
                    objectFields[i].SetValue(mono, new AssetReference(guid));
                }
            }
        }
    }
}