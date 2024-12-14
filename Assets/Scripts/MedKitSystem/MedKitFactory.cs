using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitFactory
{
    private readonly Dictionary<int, MedKit> medKitPool = new Dictionary<int, MedKit>();
    void Start()
    {
        ServiceLocator.Instance.Register(new MedKitFactory());
    }

    public MedKit GetMedKit(int healAmount)
    {
        if (!medKitPool.ContainsKey(healAmount))
        {
            medKitPool[healAmount] = new MedKit(healAmount);
        }
        return medKitPool[healAmount];
    }
}
