using System;
using UnityEngine;


[Serializable]
public struct AdditionalObjectData
{
    public AdditionalObjectType Type;
    [Range(0, 100)] public int CreationProbability;
}
