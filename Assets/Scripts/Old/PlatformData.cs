using System;
using UnityEngine;


[Serializable]
public struct PlatformData
{
    public PlatformType Type;
    public Vector2 RandomHeight;
    public Margin RandomMargin;
    public AdditionalObjectData AdditionalObjectData;
}
