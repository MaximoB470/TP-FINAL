using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public  interface IScoreManager
{
    void incrementPoints();
}
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int value = 0;
    public int incrementalvalue = 10;
    public int commandValue = 9999999;

    private void Awake()
    {
        ServiceLocator.Instance.Register<ScoreManager>(this);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
       
    }
    public void incrementPoints()
    {
        value += incrementalvalue;
    }

}
