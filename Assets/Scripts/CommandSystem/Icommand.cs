using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public interface ICommand
{
    void Setup(TextWriter writer);
    string Name { get; }
    void Execute();
    void Execute(string[] args);
    List<string> Aliases { get; }
}
public abstract class Command : ScriptableObject, ICommand
{
    [field: SerializeField] public List<string> Aliases { get; set; }
    public string Name => name;
    public abstract void Execute();
    public abstract void Execute(string[] args);
    public void Setup(TextWriter writer)
    {
        throw new NotImplementedException();
    }
    public IEnumerable<string> _Aliases => Aliases;

}