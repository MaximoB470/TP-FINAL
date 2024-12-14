using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeBench : MonoBehaviour, Iinteractable
{
    public GameObject Menu;
    public void interaction()
    {
         Menu.SetActive(true);
    }
}
