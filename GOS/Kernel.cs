using System;
using Sys = Cosmos.System;
using System.IO;
using Cosmos.System.Graphics;
using System.Drawing;

namespace GOS
{
    public class Kernel : Sys.Kernel
    {

        Canvas canvas;

        public ConsoleColor themeColor1;
        public ConsoleColor themeColor2;
        public ConsoleColor themeColor3;
        public ConsoleColor themeColor4;
        public int currentTheme;

        public string version = "dev1.0";

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

            canvas = FullScreenCanvas.GetFullScreenCanvas();

            //canvas.Clear(Color.White);
            Sys.MouseManager.ScreenWidth = (uint)canvas.Mode.Columns;
            Sys.MouseManager.ScreenHeight = (uint)canvas.Mode.Rows;
        }

        protected override void Run()
        {
            inputText();
            //Command.AcceptCmd();
            Pen pen = new Pen(Color.DimGray);
            canvas.DrawFilledRectangle(pen, 450, 450, 80, 60);
            //uint X = Sys.MouseManager.X;
            //uint Y = Sys.MouseManager.Y;
            canvas.DrawLine(pen, X, Y, X + 5, Y);
            canvas.DrawLine(pen, X, Y, X, Y - 5);
            canvas.DrawLine(pen, X, Y, X + 5, Y - 5);
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

        public void OSinit()
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

        public static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
    }
}
