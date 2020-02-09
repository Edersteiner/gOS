using System.IO;

namespace GOS
{
    class cd
    {
        public static void changedir(string targetDir)
        {
            if (Directory.Exists(targetDir))
            {
                if (!targetDir.Contains("0:\\"))
                {
                    if (!Directory.GetCurrentDirectory().EndsWith("\\"))
                    {
                        Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + "\\" + targetDir);
                    }
                    else
                    {
                        Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + targetDir);
                    }
                }
                else
                {
                    Directory.SetCurrentDirectory(targetDir);
                }

            }
            else
            {
                Kernel.error(targetDir + " doesn't exist");
            }
        }
    }
}
