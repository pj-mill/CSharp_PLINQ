using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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


        public static void Run()
        {
            PrintManager.PrintTitle("PLINQ - ITERATE DIRECTORIES");

            Task.Factory.StartNew(() => FileIteration01(@"C:\Apps\App Templates\Epona\Angular"))
                .ContinueWith((result) => FileIteration02(@"C:\Apps\App Templates\Epona\Angular"))
                .Wait();

        }

        private static void FileIteration01(string path)
        {
            int count = 0;
            string[] files = null;
            Stopwatch sw = Stopwatch.StartNew();

            // Grab files
            try
            {
                files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("You do not have permission to access one or more folders in this directory tree.");
                return;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"{path} not found");
            }


            var fileContents = from file in files.AsParallel()
                               let extension = Path.GetExtension(file)
                               where extension == ".txt" || extension == ".htm"
                               let text = File.ReadAllText(file)
                               select new FileResult { Text = text, FileName = file };             

            // Process files
            try
            {
                foreach (var item in fileContents)
                {
                    Console.WriteLine(Path.GetFileName(item.FileName) + ":" + item.Text.Length);
                    count++;
                }
            }
            catch (AggregateException ex)
            {
                ex.Handle((e) =>
                {
                    if (e is UnauthorizedAccessException)
                    {
                        Console.WriteLine(ex.Message);
                        return true;
                    }
                    return false;
                });
            }

            Console.WriteLine($"File Iteration 01 processed {count} files in {sw.ElapsedMilliseconds} milliseconds");
        }

        private static void FileIteration02(string path)
        {
            var count = 0;
            Stopwatch sw = Stopwatch.StartNew();

            // Grab files
            var fileNames = from dir in Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories)
                            select dir;

            var fileContents = from file in fileNames.AsParallel() // Use AsOrdered to preserve source ordering
                               let extension = Path.GetExtension(file)
                               where extension == ".txt" || extension == ".htm"
                               let Text = File.ReadAllText(file)
                               select new { Text, FileName = file };

            // Process files
            try
            {
                foreach (var item in fileContents)
                {
                    Console.WriteLine(Path.GetFileName(item.FileName) + ":" + item.Text.Length);
                    count++;
                }
            }
            catch (AggregateException ex)
            {
                ex.Handle((e) =>
                {
                    if (e is UnauthorizedAccessException)
                    {
                        Console.WriteLine(ex.Message);
                        return true;
                    }
                    return false;
                });
            }

            Console.WriteLine($"File Iteration 02 processed {count} files in {sw.ElapsedMilliseconds} milliseconds");
        }
    }
}
