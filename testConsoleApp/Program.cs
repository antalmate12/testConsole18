using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsoleApp
{
    class Program
    {
        public static List<string>ajtoList = new List<string>();

        private static void Main(string[] args)
        {
            F1();

            Console.ReadLine();
        }

        static void F1()
        {
            Console.WriteLine("1. Feladat");
            var reader = new StreamReader("C:\\Users\\antal\\Desktop\\ajto.txt");
            string line;
            Console.WriteLine("Adatok beolvasása folyamatban...");
            while ((line = reader.ReadLine()) != null)
            {
                ajtoList.Add(line);                
            }
            Console.WriteLine("Adatok beolvasva!\n");
        }

        static void F2()
        {
            
        }
    }
}
