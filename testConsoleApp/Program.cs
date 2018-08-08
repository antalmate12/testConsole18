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
        public static List<string> OraList = new List<string>();
        public static List<string> PercList = new List<string>();
        public static List<string> AzList = new List<string>();
        public static List<string> IranyList = new List<string>();

        private static void Main(string[] args)
        {
            F1();
            F2();
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
                var formatline = line.Split(' ');
                OraList.Add(formatline[0]);
                PercList.Add(formatline[1]);
                AzList.Add(formatline[2]);
                IranyList.Add(formatline[3]);
            }
            Console.WriteLine("Adatok beolvasva!\n");
        }

        static void F2()
        {
            Console.WriteLine("2. Feladat");

            while (true) {
                int i = 0;
                if (IranyList[i] == "be")
                {
                    Console.WriteLine("Első belépő azonosítója: " + AzList[i]);
                    break;
                }
                else
                {
                    i++;
                }
            }

            for (int i = AzList.Count - 1; i > 0; i--)
            {
                if (IranyList[i] == "ki")
                {
                    Console.WriteLine("Utoljára távozó azonosítója: " + AzList[i]);
                    break;
                }
            }
        }

    }
}
