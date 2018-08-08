using System;
using System.Collections.Generic;
using System.IO;

namespace testConsoleApp
{
    internal struct F3
    {
        public int Id;
        public int Darab;
    }
    
    class Program
    {
        public static List<int> OraList = new List<int>();
        public static List<int> PercList = new List<int>();
        public static List<int> AzList = new List<int>();
        public static List<string> IranyList = new List<string>();

        private static void Main()
        {
            F1();
            F2();
            F3();
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
                OraList.Add(Convert.ToInt32(formatline[0]));
                PercList.Add(Convert.ToInt32(formatline[1]));
                AzList.Add(Convert.ToInt32(formatline[2]));
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
                    // ReSharper disable once RedundantAssignment
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

        static void F3()
        {
            List<int> ppl = new List<int>();
            for (int i = 0; i < AzList.Count; i++)
            {
                if (ppl.Contains(AzList[i]))
                {

                }
                else
                {
                    ppl.Add(AzList[i]);
                }
            }
            
            //Console.WriteLine(Ppl.Count); --> 35
            
            F3[] data = new F3[ppl.Count];

            var sum = 0;
            for (int i = 0; i < AzList.Count; i++)
            {
                var obj = AzList[i];
                

                if (Bennevan(data, obj))
                {
                    data[WhatsMyId(data, obj)].Darab += 1;
                }
                else
                {
                    data[sum].Id = obj;
                    data[sum].Darab = 1;
                    sum += 1;
                }
            }
            
            // Set a variable to the My Documents path.
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "athaladas.txt"), true))
            {
                foreach (var a in data)
                {
                    outputFile.Write("azonosító: " + a.Id);
                    outputFile.WriteLine(" darab: " + a.Darab);
                }
            }            
        }

        static bool Bennevan(F3[] tomb, int elem)
        {
            bool ans=false;

            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i].Id == elem)
                {
                    ans = true;
                }
            }
            return ans;
        }

        static int WhatsMyId(F3[] tomb, int elem)
        {
            int id = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i].Id == elem)
                {
                    id = i;
                }
            }
            return id;
        }
    }
}
