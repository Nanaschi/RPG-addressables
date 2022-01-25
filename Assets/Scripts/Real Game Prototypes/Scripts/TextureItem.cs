using System;
using UnityEngine;
using UnityEngine.AddressableAssets;


[Serializable]
public class TextureItem
{
    [HideInInspector] public Texture2D Texture;
    public AssetReferenceTexture2D AssetReferenceTexture2D;
    public int Rotation;
}
