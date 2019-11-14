using System;
using Sys = Cosmos.System;
using System.IO;

namespace GOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            OSinit();
        }

        protected override void Run()
        {
            String userInput = Console.ReadLine();;

            string[] dir = Directory.GetDirectories(Directory.GetCurrentDirectory());
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());

            switch (userInput)
            {
                case "help":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Showing all commands:");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("help - shows this screen");
                    Console.WriteLine("shutdown - powers off the OS");
                    Console.WriteLine("reeboot - reboots the OS");
                    Console.WriteLine("beep - plays beep through PC Speaker");
                    Console.WriteLine("reinit - Reinitializes the console (pseudo-reboot)");
                    Console.WriteLine("clear - Clears the console");
                    Console.WriteLine("info - shows the GOS version info");
                    Console.WriteLine("cd - changes current directory");
                    Console.WriteLine("dir - shows all files in current directory");
                    Console.WriteLine("read - Reads a text file(*.txt)");
                    Console.ResetColor();
                    kernelText();
                     break;
                case "shutdown":
                    Sys.Power.Shutdown();
                    break;
                case "reboot":
                    Sys.Power.Reboot();
                    break;
                case "beep":
                    Sys.PCSpeaker.Beep();
                    kernelText();    
                    break;
                case "reinit":
                    OSinit();
                    break;
                case "clear":
                    Console.Clear();
                    kernelText();  
                    break;
                case "info":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string sysRam = Cosmos.Core.CPU.GetAmountOfRAM().ToString();
                    Console.WriteLine("GOS operating system");
                    Console.WriteLine("Version: dev1.0");
                    Console.WriteLine("System RAM: " + sysRam + "mb");
                    kernelText();
                    break;
                case "dir":
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    foreach (string name in dir)
                    {
                        Console.WriteLine(name + " | Directory");
                    }
                    foreach (string name in files)
                    {
                        Console.WriteLine(name + " | File");
                    }
                    Console.ResetColor();
                    kernelText();
                    break;
                case "cd":
                    Console.Write("Enter cd path: ");
                    string cdpath = Console.ReadLine();
                    if (Directory.Exists(cdpath))
                    {
                        Directory.SetCurrentDirectory(cdpath);
                    }    
                    else if (cdpath == "root")
                    {
                        Directory.SetCurrentDirectory("0:\\");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("directory dosent exist / isn't valid");
                    }
                    kernelText();
                    break;
                    case "read":
                    Console.Write("Enter the text file you would like to read: ");                    
                    string readPath = Console.ReadLine();
                    String line;
                    try
                    {
                        StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\" + readPath);
                        if (Directory.Exists(readPath))
                        {
                            line = sr.ReadLine();

                            while (line != null)
                            {
                                Console.WriteLine(line);
                                line = sr.ReadLine();
                            }
                        }                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    kernelText();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(userInput + " not recognized as a command, type help to see a list of all commands ");
                    kernelText();
                    break;
            }
        }

        public void OSinit()
        {
            Sys.KeyboardManager.GetKeyLayout();
            Directory.CreateDirectory("0:\\Applications");
            File.Create("0:\\Applications\\ApplicationsInfo.txt");
            File.WriteAllText("0:\\Applications\\ApplicationsInfo.txt", "This folder is for all of your applications");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" _______  _______  _______ ");
            Console.WriteLine("|       ||       ||       |");
            Console.WriteLine("|    ___||   _   ||  _____|");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("|   | __ |  | |  || |_____ ");
            Console.WriteLine("|   ||  ||  |_|  ||_____  |");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("|   |_| ||       | _____| |");
            Console.WriteLine("|_______||_______||_______|");
            Console.ResetColor();
            kernelText();
        }

        protected void kernelText()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Directory.GetCurrentDirectory() + ">");
            Console.ResetColor();
        }
    }
}
