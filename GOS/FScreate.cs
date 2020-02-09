﻿using System.IO;

namespace GOS
{
    class FScreate
    {
        public static void makeDir(string mkdirPath)
        {
            if (mkdirPath.Contains(":\\"))
            {
                Directory.CreateDirectory(mkdirPath);
            }
            else
            {
                if (Directory.GetCurrentDirectory().EndsWith("\\"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + mkdirPath);
                }
                else
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\" + mkdirPath);
                }
            }
        }
    }
}
