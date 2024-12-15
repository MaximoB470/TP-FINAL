using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Commands/Shop")]
public class OpenShop : Command
{
    [SerializeField] private GameObject ShopMenu;
    public override void Execute()
    {
        ShopMenu.SetActive(true);
        Debug.Log("ShopOpened");
    }
    public override void Execute(string[] args)
    {
        ShopMenu.SetActive(true);
        Debug.Log("ShopOpened");
    }
}
