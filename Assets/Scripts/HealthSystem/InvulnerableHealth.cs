using UnityEngine;

public class InvulnerableHealth : IHealth
{ 
    private IHealth original;
    public InvulnerableHealth(IHealth original)
    {
        this.original = original;
    }
    public int Life
    {
        get => original.Life;
        set => original.Life = value;
    }
    public void Awake()
    {
        original.Awake();
    }
    public void GetDamage(int value)
    {
        Debug.Log($"Skipped damage since I'm invulnerable.");
    }
}