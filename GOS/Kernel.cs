using System;
using Sys = Cosmos.System;
using System.IO;
using System.Collections.Generic;

namespace GOS
{
    public class Kernel : Sys.Kernel
    {
        ConsoleColor themeColor1;
        ConsoleColor themeColor2;
        ConsoleColor themeColor3;
        ConsoleColor themeColor4;
        int currentTheme;
        string version = "dev1.0";

        protected override void BeforeRun()
        {
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            if (!File.Exists("0:\\settings.ini"))
            {
                File.Create("0:\\settings.ini");
                using (StreamWriter writer = new StreamWriter("0:\\settings.ini"))
                {
                    currentTheme = 1;
                    writer.WriteLine("theme = " + currentTheme);
                }
            }
            string[] settings = File.ReadAllLines("0:\\settings.ini");

            string theme_settings = settings[0];
            var theme = theme_settings.Substring(theme_settings.Length - 1);
            Int32.TryParse(theme, out int x);
            currentTheme = x;

            OSinit();
        }

        protected override void Run()
        {
            inputText();
            var input = Console.ReadLine();
            string cmd = input.Split(" ")[0];
            switch (cmd)
            {
                case "shutdown":
                    Sys.Power.Shutdown();
                    break;

                case "reboot":
                    Sys.Power.Reboot();
                    break;

                case "ls":
                    string[] dirDirectories = Directory.GetDirectories(Directory.GetCurrentDirectory());
                    foreach (var dir in dirDirectories)
                    {
                        Console.WriteLine(dir + " | Directory");
                    }
                    string[] dirFiles = Directory.GetFiles(Directory.GetCurrentDirectory());
                    foreach (var file in dirFiles)
                    {
                        Console.WriteLine(file + " | File");
                    }
                    break;

                case "cd":
                    if (input.Contains(" "))
                    {
                        if (!input.EndsWith(" "))
                        {
                            var targetDir = input.Split(" ")[1];
                            cd.changedir(targetDir);
                        }
                        else
                        {
                            error("No path in argument. Usage: cd 'path'");
                        }
                    }
                    else
                    {
                        Directory.SetCurrentDirectory("0:\\");
                    }
                    break; 

                case "beep":
                    var targetFreqRaw = input.Remove(0, input.IndexOf(' ') + 1);
                    int targetFreq = int.Parse(targetFreqRaw);
                    if (targetFreq < 37 || targetFreq > 32767)
                    {
                        error("Frequency cant be less than 37hz or larger than 32767hz");
                    }
                    else
                    {
                        Console.Beep(targetFreq, 1000);
                    }
                    break;

                case "cat":
                    var targetCat = input.Remove(0, input.IndexOf(' ') + 1);
                    if (!File.Exists(targetCat))
                    {
                        Console.WriteLine("Could not find file");
                        break;
                    }
                    string[] lines = File.ReadAllLines(targetCat);

                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                    break;

                case "grep":
                    List<string> flags = new List<string>();
                    foreach (string x in input.Split(" "))
                    {
                        flags.Add(x);
                    }
                    if (flags.Count > 1)
                        if (flags[1] == "-h")
                        {
                            Console.WriteLine("gOS implementation of grep\nUsage: grep PATTERN FILENAME\n\nOptional switches:\n    -c Count each PATTERN instance\n    -w force PATTERN to match only whole words");
                            break;
                        }

                    if (flags.Count < 3)
                    {
                        Console.WriteLine("Too few arguments, excpected at least 2");
                        break;
                    }
                    Grep gp = new Grep();
                    gp.grep(flags[2], flags[1], flags);
                    break;

                case "mkdir":
                    if (input.Contains(" "))
                    {
                        if (input.EndsWith(" "))
                        {
                            error("no path specified");
                        }
                        else
                        {
                            var mkdirPath = input.Split(" ")[1];
                            FScreate.makeDir(mkdirPath);
                        }
                    }
                    else
                    {
                        error("no path specified");
                    }
                    var dirPath = input.Remove(0, input.IndexOf(' ') + 1);
                    Directory.CreateDirectory(dirPath);
                    break;

                case "touch":
                    var touchPath = input.Remove(0, input.IndexOf(' ') + 1);
                    File.Create(touchPath);
                    break;

                case "write":
                    var writePath = input.Split(" ")[1];
                    var writeText = input.Split(" ")[2];
                    if (File.Exists(writePath))
                    {
                        File.AppendAllText(writePath, writeText);
                    }
                    break;

                case "writeline":
                    var writelinePath = input.Split(" ")[1];
                    var writelineText = input.Split(" ")[2];
                    if (File.Exists(writelinePath))
                    {
                        File.AppendAllText(writelinePath, Environment.NewLine + writelineText);
                    }
                    break;

                case "rm":
                    if (input.Contains(" "))
                    {
                        if(input.EndsWith(" "))
                        {
                            error("no path specified");
                        }
                        else
                        {
                            var rmPath = input.Split(" ")[1];
                            rm.remove(rmPath);
                        }
                    }
                    else
                    {
                        error("no path specified");
                    }
                    break;

                case "clear":
                    Console.Clear();
                    break;

                case "reinit":
                    OSinit();
                    break;

                case "echo":
                    var echoMsg = input.Remove(0, input.IndexOf(' ') + 1);
                    Console.WriteLine(echoMsg);
                    break;

                case "info":
                    Console.ForegroundColor = themeColor1;
                    Console.WriteLine("gOS");
                    Console.WriteLine("Version: " + version);
                    Console.WriteLine("System Ram: " + Cosmos.Core.CPU.GetAmountOfRAM().ToString());
                    Console.WriteLine("Root Drive size: " + Sys.FileSystem.VFS.VFSManager.GetTotalSize("0") + " bytes");
                    Console.WriteLine("Root Drive Free Space: " + Sys.FileSystem.VFS.VFSManager.GetTotalFreeSpace("0") + " bytes");
                    break;

                case "help":
                    if (input.Contains(" "))
                    {
                        if (input.EndsWith(" "))
                        {
                            error("no page specified. select a page 1-3");
                        }
                        else
                        {
                            var helpPage = input.Split(" ")[1];
                            switch (helpPage)
                            {
                                case "1":
                                    Console.WriteLine("Power Commands\n--------------\nshutdown: Turns the OS and computer off.\n\nreboot: Reboots the computer.\n\nConsole Commands\n----------------\nreinit: Reinitializes the OS (pseudo-reboot).\n\nclear: Clears the console.\n\necho (message): Prints the specified message to the console.\n\ntheme (themeID): Changes the theme of the console.");
                                    break;

                                case "2":
                                    Console.WriteLine("Filesystem Commands\n-------------------\nls: Shows all subdirectories and files within current directory.\n\ncd (path): Changes current directory to specified path.\n\nrm (path): Removes specified directory or file.\n\nmkdir (path): Creates new directory in specified path.\n\ntouch (path): Creates new file in specified path.\n\ncat (path): Prints all the lines of specified file.\n\ngrep (pattern) (path): type grep -h for more information.");
                                    break;

                                case "3":
                                    Console.WriteLine("WIP filesystem commands\n-----------------------\nwrite (path) (text): Writes to specified text to specified file.\n\nwriteline (path) (text): Creates new line and writes specified text to a file.\n\nOther Commands\n--------------\nbeep (frequency): Plays a sound with the specified frequency.");
                                    break;

                                default:
                                    error(helpPage + " isnt a help page, select a page 1-3");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        error("no page specified. select a page 1-3");
                    }
                    break;

                case "theme":
                    var targetTheme = input.Remove(0, input.IndexOf(' ') + 1);
                    string[] theme_names = { "Ice (Default)", "Plain", "Inferno", "Sahara", "Magic", "Indian Hacker" };
                    Int32.TryParse(targetTheme, out currentTheme);

                    if ((currentTheme < 1) || (currentTheme > 6))
                    {
                        currentTheme = 1;
                        error(targetTheme + " is not recognized as a theme");
                        break;
                    }

                    lineChanger("theme = " + currentTheme, "0:\\settings.ini", 1);
                    Console.WriteLine("Switching to " + theme_names[currentTheme - 1] + " theme");
                    break;

                default:
                    if (string.IsNullOrWhiteSpace(input))
                        break;
                    else
                        error(cmd + " is not recognized as a command");
                    break;
            }
        }

        protected void inputText()
        {
            Console.ForegroundColor = themeColor4;
            Console.Write(Directory.GetCurrentDirectory() + ">");
            Console.ResetColor();
        }

        public static void error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        protected void ColorSettings(int theme)
        {
            theme = theme - 1;
            ConsoleColor[] theme_set1 = new ConsoleColor[4] { ConsoleColor.Cyan, ConsoleColor.Blue, ConsoleColor.DarkBlue, ConsoleColor.Blue };
            ConsoleColor[] theme_set2 = new ConsoleColor[4] { ConsoleColor.White, ConsoleColor.White, ConsoleColor.White, ConsoleColor.White };
            ConsoleColor[] theme_set3 = new ConsoleColor[4] { ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.DarkRed, ConsoleColor.Red };
            ConsoleColor[] theme_set4 = new ConsoleColor[4] { ConsoleColor.DarkGreen, ConsoleColor.DarkYellow, ConsoleColor.Yellow, ConsoleColor.Green };
            ConsoleColor[] theme_set5 = new ConsoleColor[4] { ConsoleColor.Magenta, ConsoleColor.DarkCyan, ConsoleColor.DarkMagenta, ConsoleColor.Red };
            ConsoleColor[] theme_set6 = new ConsoleColor[4] { ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.DarkGreen };
            ConsoleColor[][] all_theme_sets = new ConsoleColor[][] { theme_set1, theme_set2, theme_set3, theme_set4, theme_set5, theme_set6 };

            themeColor1 = all_theme_sets[theme][0];
            themeColor2 = all_theme_sets[theme][1];
            themeColor3 = all_theme_sets[theme][2];
            themeColor4 = all_theme_sets[theme][3];
        }

        protected void OSinit()
        {
            Console.Clear();
            ColorSettings(currentTheme);
            Console.ForegroundColor = themeColor1;
            Console.WriteLine("          ____  _____");
            Console.WriteLine("   ______/ __ \\/ ___/");
            Console.ForegroundColor = themeColor2;
            Console.WriteLine("  / __  / / / /\\__ \\ ");
            Console.WriteLine(" / /_/ / /_/ /___/ / ");
            Console.ForegroundColor = themeColor3;
            Console.WriteLine(" \\___ /\\____//____/  ");
            Console.WriteLine("/____/               ");
        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
    }
}
