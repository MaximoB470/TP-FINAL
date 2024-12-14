using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class injectableCommand : ICommand
{
    public string Name { get; set; }

    public List<string> Aliases { get; set; }

    public Action DoExecute;
    public Action<string[]> DoExecuteWithArgs;

    public injectableCommand(string name, Action doExecute, Action<string[]> doExecuteWithArgs)
    {
        Name = name;
        DoExecute = doExecute;
        DoExecuteWithArgs = doExecuteWithArgs;
    }

    public void Execute()
    {
        DoExecute?.Invoke();
    }

    public void Execute(string[] args)
    {
        DoExecuteWithArgs?.Invoke(args);
    }

    public void Setup(TextWriter writer)
    {
        throw new System.NotImplementedException();
    }
}
