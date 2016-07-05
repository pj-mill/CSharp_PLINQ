using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPLINQ.Examples
{
    public class G_IterateDirectories : Z_ExampleBase
    {
        struct FileResult
        {
            public string Text;
            public string FileName;
        }

        private static Stopwatch stopWatch = new Stopwatch();

        public static void Run()
        {
            PrintManager.PrintTitle("PLINQ - ITERATE DIRECTORIES");
        }

        private static void FileIteration01(string path)
        {

        }

        private static void FileIteration02(string path)
        {

        }
    }
}
