using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth 
{
    int Life { get; set; }
    void GetDamage(int value);
    void Awake();
}
