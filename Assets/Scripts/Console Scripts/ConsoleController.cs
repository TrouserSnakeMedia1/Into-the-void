/// <summary>
/// Handles parsing and execution of console commands, as well as collecting log output.
/// Copyright (c) 2014-2015 Eliot Lash
/// </summary>
using UnityEngine;

using System;
using System.Collections.Generic;
using System.Text;

public delegate void CommandHandler(string[] args);

public class ConsoleController
{

    #region Event declarations
    // Used to communicate with ConsoleView
    public delegate void LogChangedHandler(string[] log);
    public event LogChangedHandler logChanged;

    public delegate void VisibilityChangedHandler(bool visible);
    public event VisibilityChangedHandler visibilityChanged;
    #endregion

    /// <summary>
    /// Object to hold information about each command
    /// </summary>
    class CommandRegistration
    {
        public string command { get; private set; }
        public CommandHandler handler { get; private set; }
        public string help { get; private set; }

        public CommandRegistration(string command, CommandHandler handler, string help)
        {
            this.command = command;
            this.handler = handler;
            this.help = help;
        }
    }

    /// <summary>
    /// How many log lines should be retained?
    /// Note that strings submitted to appendLogLine with embedded newlines will be counted as a single line.
    /// </summary>
    const int scrollbackSize = 20;

    Queue<string> scrollback = new Queue<string>(scrollbackSize);
    List<string> commandHistory = new List<string>();
    Dictionary<string, CommandRegistration> commands = new Dictionary<string, CommandRegistration>();

    public string[] log { get; private set; } //Copy of scrollback as an array for easier use by ConsoleView

    const string repeatCmdName = "!!"; //Name of the repeat command, constant since it needs to skip these if they are in the command history

    public ConsoleController()
    {
        registerCommand("help", help, "Print this help.");
        registerCommand(repeatCmdName, repeatCommand, "Repeat last command.");
        registerCommand("log1", Log1, "View log #1");
        registerCommand("log2", Log2, "View log #2");
        registerCommand("log3", Log3, "View log #3");
        registerCommand("log4", Log4, "View log #4");
        registerCommand("log5", Log5, "View log #5");
        registerCommand("unlockdoor", SequenceCode, "Unlock the Door");
    }

    void registerCommand(string command, CommandHandler handler, string help)
    {
        commands.Add(command, new CommandRegistration(command, handler, help));
    }

    public void appendLogLine(string line)
    {
        Debug.Log(line);

        if (scrollback.Count >= ConsoleController.scrollbackSize)
        {
            scrollback.Dequeue();
        }
        scrollback.Enqueue(line);

        log = scrollback.ToArray();
        if (logChanged != null)
        {
            logChanged(log);
        }
    }

    public void runCommandString(string commandString)
    {
        appendLogLine("$ " + commandString);

        string[] commandSplit = parseArguments(commandString);
        string[] args = new string[0];
        if (commandSplit.Length < 1)
        {
            appendLogLine(string.Format("Unable to process command '{0}'", commandString));
            return;

        }
        else if (commandSplit.Length >= 2)
        {
            int numArgs = commandSplit.Length - 1;
            args = new string[numArgs];
            Array.Copy(commandSplit, 1, args, 0, numArgs);
        }
        runCommand(commandSplit[0].ToLower(), args);
        commandHistory.Add(commandString);
    }

    public void runCommand(string command, string[] args)
    {
        
        CommandRegistration reg = null;
        if (!commands.TryGetValue(command, out reg))
        {
            appendLogLine(string.Format("Unknown command '{0}', type 'help' for list.", command));
            GameObject.FindGameObjectWithTag("Terminal2").GetComponent<AudioSource>().Play();
        }
        else
        {
            if (reg.handler == null)
            {
                appendLogLine(string.Format("Unable to process command '{0}', handler was null.", command));
            }
            else
            {
                reg.handler(args);
            }
        }
    }

    static string[] parseArguments(string commandString)
    {
        LinkedList<char> parmChars = new LinkedList<char>(commandString.ToCharArray());
        bool inQuote = false;
        var node = parmChars.First;
        while (node != null)
        {
            var next = node.Next;
            if (node.Value == '"')
            {
                inQuote = !inQuote;
                parmChars.Remove(node);
            }
            if (!inQuote && node.Value == ' ')
            {
                node.Value = '\n';
            }
            node = next;
        }
        char[] parmCharsArr = new char[parmChars.Count];
        parmChars.CopyTo(parmCharsArr, 0);
        return (new string(parmCharsArr)).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    }

    #region Command handlers
    //Implement new commands in this region of the file.
    public GameObject Door;
    /// <summary>
    /// A test command to demonstrate argument checking/parsing.
    /// Will repeat the given word a specified number of times.
    /// </summary>

    void Log1(string[] args)
    {
        bool viewLogOne = GameObject.FindGameObjectWithTag("Player").GetComponent<terminalInteraction>().terminal1;
        if (viewLogOne == true)
        {
            appendLogLine("Works");
        }
        else
        {
            appendLogLine("Does not work");
        }

    }
    void Log2(string[] args)
    {
        bool viewLogTwo = GameObject.FindGameObjectWithTag("Player").GetComponent<terminalInteraction>().terminal2;
        if (viewLogTwo == true)
        {
            appendLogLine("Works");
        }
        else
        {
            appendLogLine("Does not work");
        }
    }
    void Log3(string[] args)
    {
        bool viewLogThree = GameObject.FindGameObjectWithTag("Player").GetComponent<terminalInteraction>().terminal3;
        if (viewLogThree == true)
        {
            appendLogLine("Works");
        }
        else
        {
            appendLogLine("Does not work");
        }
    }
    void Log4(string[] args)
    {
        bool viewLogFour = GameObject.FindGameObjectWithTag("Player").GetComponent<terminalInteraction>().terminal4;
        if (viewLogFour == true)
        {
            appendLogLine("Works");
        }
        else
        {
            appendLogLine("Does not work");
        }
    }
    void Log5(string[] args)
    {
        bool viewLogFive = GameObject.FindGameObjectWithTag("Player").GetComponent<terminalInteraction>().terminal5;
        if (viewLogFive == true)
        {
            appendLogLine("Works");
        }
        else
        {
            appendLogLine("Does not work");
        }
    }
    void SequenceCode(string[] args)
    {
        appendLogLine("Please enter access code for door");
        registerCommand("0000", UnlockDoor, "Unlocks the door");
    }
    public void UnlockDoor(string[] args)
    {
        Door = GameObject.FindGameObjectWithTag("Door");
        Door.GetComponent<AudioSource>().enabled = true;
        Door.SetActive(false);
        appendLogLine("Door is open");
    }
    void help(string[] args)
    {
        foreach (CommandRegistration reg in commands.Values)
        {
            appendLogLine(string.Format("{0}: {1}", reg.command, reg.help));
        }
    }

    void repeatCommand(string[] args)
    {
        for (int cmdIdx = commandHistory.Count - 1; cmdIdx >= 0; --cmdIdx)
        {
            string cmd = commandHistory[cmdIdx];
            if (String.Equals(repeatCmdName, cmd))
            {
                continue;
            }
            runCommandString(cmd);
            break;
        }
    }
    #endregion
}
