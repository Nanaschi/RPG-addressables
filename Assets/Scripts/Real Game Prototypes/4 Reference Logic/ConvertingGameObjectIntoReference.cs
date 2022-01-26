using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConvertingGameObjectIntoReference : MonoBehaviour
{
    private static Dictionary<string, Object> addressesToPrefabs;
    private static Dictionary<Object, string> prefabsToAddresses;
 
    public static void BuildAddressablesDictionary()
    {
        addressesToPrefabs = new Dictionary<string, Object>();
        prefabsToAddresses = new Dictionary<Object, string>();
 
        foreach (var group in UnityEditor.AddressableAssets.AddressableAssetSettingsDefaultObject.Settings.groups)
        {
            foreach (var entry in group.entries)
            {
                var address = entry.address;
                var prefab = entry.TargetAsset;
                addressesToPrefabs.Add(address, prefab);
                prefabsToAddresses.Add(prefab, address);
            }
        }
    }
 
    public static string GetAddressFromPrefab(Object target)
    {
        prefabsToAddresses.TryGetValue(target, out var address);
        return address;
    }
 
    public static Object GetPrefabFromAddress(string address)
    {
        addressesToPrefabs.TryGetValue(address, out var target);
        return target;
    }
    public static string GetAddressFromPrefabTest(Object target)
    {
        string path = AssetDatabase.GetAssetPath(target);
        string guid = AssetDatabase.AssetPathToGUID(path);
        var assetEntry = UnityEditor.AddressableAssets.AddressableAssetSettingsDefaultObject.Settings.FindAssetEntry(guid);
        return assetEntry.address;
    }
}
