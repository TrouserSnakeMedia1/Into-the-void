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
        //When adding commands, you must add a call below to registerCommand() with its name, implementation method, and help text.
        //registerCommand("babble", babble, "Example command that demonstrates how to parse arguments. babble [word] [# of times to repeat]");
        //registerCommand("echo", echo, "echoes arguments back as array (for testing argument parser)");
        registerCommand("help", help, "Print this help.");
        //registerCommand("hide", hide, "Hide the console.");
        registerCommand(repeatCmdName, repeatCommand, "Repeat last command.");
        registerCommand("log1", Log1, "View log #1");
        registerCommand("log2", Log2, "View log #2");
        registerCommand("log3", Log3, "View log #3");
        registerCommand("log4", Log4, "View log #4");
        registerCommand("log5", Log5, "View log #5");
        //registerCommand("reload", reload, "Reload game.");
        //registerCommand("resetprefs", resetPrefs, "Reset & saves PlayerPrefs.");
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

    /// <summary>
    /// A test command to demonstrate argument checking/parsing.
    /// Will repeat the given word a specified number of times.
    /// </summary>
    /*void babble(string[] args)
    {
        if (args.Length < 2)
        {
            appendLogLine("Expected 2 arguments.");
            return;
        }
        string text = args[0];
        if (string.IsNullOrEmpty(text))
        {
            appendLogLine("Expected arg1 to be text.");
        }
        else
        {
            int repeat = 0;
            if (!Int32.TryParse(args[1], out repeat))
            {
                appendLogLine("Expected an integer for arg2.");
            }
            else
            {
                for (int i = 0; i < repeat; ++i)
                {
                    appendLogLine(string.Format("{0} {1}", text, i));
                }
            }
        }
    }*/

    /*void echo(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        foreach (string arg in args)
        {
            sb.AppendFormat("{0},", arg);
        }
        sb.Remove(sb.Length - 1, 1);
        appendLogLine(sb.ToString());
    }*/
    //public string LogEntry1;

    void Log1(string[] args)
    {
        appendLogLine("Technician Login: James Stevenson: ");
        appendLogLine("I’m not too sure what is going on here. I was called in for a routine virus/bug check-up this morning, but something seems to have gone very wrong. After I was done with my checkup and ready to logout, I realized that my logout function has been disabled. I am starting to worry at this point, because I have been trapped in this system for hours now. Also, I have been noticing extreme signs of system corruption the more I look around. I will keep looking around and report what I have learned in a little bit.");
    }
    void Log2(string[] args)
    {
        appendLogLine("Technician Login: Thomas Klein");
        appendLogLine("I am not sure what exactly it is, but there is something completely wrong with this system. It was just fine when I logged in a few hours ago, but it has been getting progressively worse. On top of that, my basic logout function seems to not be working and I cannot figure out why. I have never seen such extreme system corruption in all of my years as a technician, and I do not believe that I can do anything to stop it at this point. I need to get out of this system very soon because corruption of this magnitude will cause the system to become extremely unstable. When this happens there will be no way to block access from any number of harmful viruses, and I would be in grave danger. I must keep searching and find the source of the corruption before it is too late….");
    }
    void Log3(string[] args)
    {
        appendLogLine("Technician Name: John Loomis");
        appendLogLine("Somebody needs to get me out of here now!! The system has gone completely haywire and has been infected by countless viruses and bugs. They are getting more advanced and violent by the second, and they are even starting to attack! I know this sounds completely insane, but I am telling you that these are not normal viruses and bugs. They are extremely advanced and will not hesitate to engage violently once they sense your presence. I have retreated into this room after my partner and I encountered a group of these hostile viruses, but unfortunately my partner did not make it. All I heard was his scream for a second and then I heard nothing. I can’t believe this is happening. I’m so scared. My partner said he had discovered a hidden room just down the hall. Maybe that would be the best place to hide and figure out my next move.");
    }
    void Log4(string[] args)
    {
        appendLogLine("Technician Name: John Loomis");
        appendLogLine("I didn’t sign up for this!! This was never supposed to be part of the job!! I just want to get out of this damn nightmare and go home!! Those damn things out there have trapped me in this room, and it is only a matter of time before they get to me. Why is this happening? I know that me and my partner were not the first ones sent here, because I passed by many other bodies while running away from those things! How could there be other people in this system? Me and my partner were the only ones assigned to this job, but yet I know what I saw. Those bastards will break through that door any minute now. If anyone happens to find this, please tell my wife and kids that I love them and I’m very sorry for leaving them so soon...");
    }
    void Log5(string[] args)
    {
        appendLogLine("Technician Login: Wayan Seymour");
        appendLogLine("*****ATTENTION POTENTIAL VICTIMS OF THIS HELLSCAPE*****");
        appendLogLine("It’s obvious that, for whatever asinine reason, VSI isn’t going to stop sending people here. It’s also possible that there are living people in here that I just haven’t found yet. In either case, if you’re reading this, I’d like to inform you that any messages, notes, or reports you types into the text program on these terminals is NOT visible or retrievable to anyone on the outside. No one is going to datamine this system and find any readable form of what you’ve written, even if they knew to look for it, which they almost certainly don’t. There are better ways to use these terminals than wailing your despair into the void. There’s got to be a backdoor or something. A way to get to the locked user options. And we should be able to find a way to it through these terminals. I’m close to finding a way to get the command window working again on the terminal in the keycard room. If I can get it running and manage to unlock the user controls, then I guess this message is pointless. But if you are reading this, and you want to get out of here alive, I suggest you stop pleading through a text document no one will read, head over to that room, and contribute to your one chance of getting out of here alive.");
    }
    void help(string[] args)
    {
        foreach (CommandRegistration reg in commands.Values)
        {
            appendLogLine(string.Format("{0}: {1}", reg.command, reg.help));
        }
    }

    /*void hide(string[] args)
    {
        if (visibilityChanged != null)
        {
            visibilityChanged(false);
        }
    }*/

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

    /*void reload(string[] args)
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void resetPrefs(string[] args)
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }*/

    #endregion
}
