using System;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.UI;
public class CommandConsoleService : MonoBehaviour
{
    [SerializeField] private List<Command> commands; 
    private Dictionary<string, ICommand> commandDictionary = new();

    private void Awake()
    {
        ServiceLocator.Instance.Register<CommandConsoleService>(this);
        foreach (var command in commands)
        {
            AddCommand(command);
        }
    }
    public void AddCommand(ICommand command)
    {
        foreach (var alias in command.Aliases)
        {
            if (!commandDictionary.TryAdd(alias, command))
            {
                Debug.LogWarning($"Alias '{alias}' already exists");
            }
        }
    }
    public void RemoveCommand(ICommand command)
    {
        foreach (var alias in command.Aliases)
        {
            commandDictionary.Remove(alias);
        }
    }
    public void ExecuteCommand(string alias, params string[] args)
    {
        if (commandDictionary.TryGetValue(alias, out var command))
        {
            command.Execute(args);
        }
        else
        {
            Debug.LogWarning($"No alias: {alias}");
        }
    }
}