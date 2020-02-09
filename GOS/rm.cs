using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GOS
{
    class rm
    {
        public static void remove(string rmPath)
        {
            if (rmPath.Contains(":\\"))
            {
                if (Directory.Exists(rmPath))
                {
                    Directory.Delete(rmPath);
                }
                else if (File.Exists(rmPath))
                {
                    File.Delete(rmPath);
                }
                else
                {
                    Kernel.error(rmPath + " doesn't exist");
                }
            }
            else
            {
                if (Directory.GetCurrentDirectory().EndsWith("\\"))
                {
                    if (Directory.Exists(Directory.GetCurrentDirectory() + rmPath))
                    {
                        Directory.Delete(Directory.GetCurrentDirectory() + rmPath);
                    }
                    else if (File.Exists(rmPath))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + rmPath);
                    }
                    else
                    {
                        Kernel.error(rmPath + " doesn't exist");
                    }
                }
                else
                {
                    if (Directory.Exists(Directory.GetCurrentDirectory() + "\\" + rmPath))
                    {
                        Directory.Delete(Directory.GetCurrentDirectory() + "\\" + rmPath);
                    }
                    else if (File.Exists(rmPath))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + "\\" + rmPath);
                    }
                    else
                    {
                        Kernel.error(rmPath + " doesn't exist");
                    }
                }
            }
        }
    }
}
