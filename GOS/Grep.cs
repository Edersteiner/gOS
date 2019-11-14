using System;
using Sys = Cosmos.System;
using System.IO;
using System.Collections.Generic;

namespace GOS
{
    public class Grep
    {
        public bool find(string to_find, List<string> list)
        {
            foreach (string x in list)
            {
                if (x == to_find)
                    return true;
            }
            return false;
        }

        public void grep(string file, string to_find, List<string> flags)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine("File could not be found");
                return;
            }
            string[] lines = File.ReadAllLines(file);
            int instances = 0;
            bool flag = false;

            foreach (string line in lines)
            {
                if (find("-c", flags))
                {
                    flag = true;
                    if (line.Contains(to_find))
                        instances++;
                }

                if (find("-w", flags))
                {
                    flag = true;
                    if (line == to_find)
                        Console.WriteLine(line);
                    return;
                }

                if (flag == false)
                    if (line.Contains(to_find))
                        Console.WriteLine(line);
            }
            if (find("-c", flags))
                Console.WriteLine(instances);
        }
    };
}