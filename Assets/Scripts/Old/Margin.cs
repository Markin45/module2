using System;
using UnityEngine;


[Serializable]
public struct Margin
{
    [Range(0.0f, 5.0f)] public float Min;
    [Range(0.0f, 5.0f)] public float Max;
}
