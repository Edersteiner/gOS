using System;
using Sys = Cosmos.System;
using System.IO;

namespace GOS
{
    public class Kernel : Sys.Kernel
    {
        ConsoleColor themeColor1;
        ConsoleColor themeColor2;
        ConsoleColor themeColor3;
        ConsoleColor themeColor4;
        int currentTheme;

        bool applicationMode = false;
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
            if (settings[0] == "theme = 1")
            {
                currentTheme = 1;
            }
            if (settings[0] == "theme = 2")
            {
                currentTheme = 2;
            }
            if (settings[0] == "theme = 3")
            {
                currentTheme = 3;
            }
            if (settings[0] == "theme = 4")
            {
                currentTheme = 4;
            }
            if (settings[0] == "theme = 5")
            {
                currentTheme = 5;
            }
            if (settings[0] == "theme = 6")
            {
                currentTheme = 6;
            }
            OSinit();
        }

        protected override void Run()
        {
            if (applicationMode == false)
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
                    case "dir":
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
                        var targetDir = input.Remove(0, input.IndexOf(' ') + 1);
                        if (Directory.Exists(targetDir))
                        {
                            Directory.SetCurrentDirectory(targetDir);
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
                        string[] lines = File.ReadAllLines(targetCat);

                        foreach (string line in lines)
                        {
                            Console.WriteLine(line);
                        }
                        break;
                    case "mkdir":
                        var dirPath = input.Remove(0, input.IndexOf(' ') + 1);
                        Directory.CreateDirectory(dirPath);
                        break;
                    case "del":
                        var delTarget = input.Remove(0, input.IndexOf(' ') + 1);
                        if (File.Exists(delTarget))
                        {
                            File.Delete(delTarget);
                        }
                        else if (Directory.Exists(delTarget))
                        {
                            Directory.Delete(delTarget);
                        }
                        else
                        {
                            error("File or Directory does not exist / isn't valid");
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
                    case "run":
                        var targetApplication = input.Remove(0, input.IndexOf(' ') + 1);
                        switch(targetApplication)
                        {
                           
                        }
                        break;
                    case "theme":
                        var targetTheme = input.Remove(0, input.IndexOf(' ') + 1);
                        switch (targetTheme)
                        {
                            case "1":
                                currentTheme = 1;
                                lineChanger("theme = " + currentTheme, "0:\\settings.ini", 1);
                                Console.WriteLine("Switching to Ice(Default) theme");
                                break;
                            case "2":
                                currentTheme = 2;
                                lineChanger("theme = " + currentTheme, "0:\\settings.ini", 1);
                                Console.WriteLine("Switching to Plain theme");
                                break;
                            case "3":
                                currentTheme = 3;
                                lineChanger("theme = " + currentTheme, "0:\\settings.ini", 1);
                                Console.WriteLine("Switching to Inferno theme");
                                break;
                            case "4":
                                currentTheme = 4;
                                lineChanger("theme = " + currentTheme, "0:\\settings.ini", 1);
                                Console.WriteLine("Switching to Sahara theme");
                                break;
                            case "5":
                                currentTheme = 5;
                                lineChanger("theme = " + currentTheme, "0:\\settings.ini", 1);
                                Console.WriteLine("Switching to Magic theme");
                                break;
                            case "6":
                                currentTheme = 6;
                                lineChanger("theme = " + currentTheme, "0:\\settings.ini", 1);
                                Console.WriteLine("Switching to Indian Hacker theme");
                                break;
                            default:
                                error(targetTheme + " is not recognized as a theme");
                                break;
                        }
                        break;
                    default:
                        if (input == "" || input == " ")
                        {
                            break;
                        }
                        else
                        {
                            error(cmd + " is not recognized as a command");
                        }
                        break;
                }
            }
         
        }

        protected void inputText()
        {
            Console.ForegroundColor = themeColor4;
            Console.Write(Directory.GetCurrentDirectory() + ">");
            Console.ResetColor();
        }

        protected void error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        protected void OSinit()
        {
            switch (currentTheme)
            {
                case 1:
                    themeColor1 = ConsoleColor.Cyan;
                    themeColor2 = ConsoleColor.Blue;
                    themeColor3 = ConsoleColor.DarkBlue;
                    themeColor4 = ConsoleColor.Blue;
                    break;
                case 2:
                    themeColor1 = ConsoleColor.White;
                    themeColor2 = ConsoleColor.White;
                    themeColor3 = ConsoleColor.White;
                    themeColor4 = ConsoleColor.White;
                    break;
                case 3:
                    themeColor1 = ConsoleColor.Yellow;
                    themeColor2 = ConsoleColor.Red;
                    themeColor3 = ConsoleColor.DarkRed;
                    themeColor4 = ConsoleColor.Red;
                    break;
                case 4:
                    themeColor1 = ConsoleColor.DarkGreen;
                    themeColor2 = ConsoleColor.DarkYellow;
                    themeColor3 = ConsoleColor.Yellow;
                    themeColor4 = ConsoleColor.Green;
                    break;
                case 5:
                    themeColor1 = ConsoleColor.Magenta;
                    themeColor2 = ConsoleColor.DarkCyan;
                    themeColor3 = ConsoleColor.DarkMagenta;
                    themeColor4 = ConsoleColor.Red;
                    break;
                case 6:
                    themeColor1 = ConsoleColor.Green;
                    themeColor2 = ConsoleColor.Green;
                    themeColor3 = ConsoleColor.Green;
                    themeColor4 = ConsoleColor.Green;
                    break;
            }           
            Console.Clear();
            Console.ForegroundColor = themeColor1;
            Console.WriteLine("  ____  ___  ____  ");
            Console.WriteLine(" / ___|/ _ \\/ ___| ");
            Console.ForegroundColor = themeColor2;
            Console.WriteLine("| |  _| | | \\___ \\ ");
            Console.WriteLine("| |_| | |_| |___) |");
            Console.ForegroundColor = themeColor3;
            Console.WriteLine(" \\____|\\___/|____/ ");
        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        public void ApplicationMode(bool trueorfalse)
        {
            applicationMode = trueorfalse;
        }
    }
}
