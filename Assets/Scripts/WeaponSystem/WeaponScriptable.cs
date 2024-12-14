using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFireType", menuName = "WeaponType")]
public class WeaponScriptable : ScriptableObject
{
    [Header("General Settings")]
    public float shootRate;
    public float shootTime;
}