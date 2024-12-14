using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandButton : MonoBehaviour
{
    [SerializeField] private string commandAlias; 
    [SerializeField] private string arguments; 

    public void OnClick()
    {
        var commandConsoleService = FindObjectOfType<CommandConsoleService>();

        if (commandConsoleService != null)
        {
            string[] args = string.IsNullOrWhiteSpace(arguments) ? new string[0] : arguments.Split(' ');
            commandConsoleService.ExecuteCommand(commandAlias, args);
        }
        else
        {
            Debug.LogWarning("CommandConsoleService not found in the scene.");
        }
    }
}