using System;

namespace CSharpPLINQ.Utilities
{
    public class PrintUtility
    {
        #region PRINT METHODS
        public void PrintTitle(string title)
        {
            string divider = new String('*', 70);
            Console.WriteLine("");
            Console.WriteLine(divider);
            Console.WriteLine(title);
            Console.WriteLine(divider);
        }

        public void PrintSubTitle(string title)
        {
            string divider = new String('=', 70);
            Console.WriteLine("");
            Console.WriteLine(divider);
            Console.WriteLine(title);
            Console.WriteLine(divider);
        }

        public void PrintTime(double time)
        {
            string divider = new String('-', 70);
            Console.WriteLine(divider);
            Console.WriteLine($"Execution time = {time} seconds");
            Console.WriteLine(divider);
        }
        #endregion
    }
}
