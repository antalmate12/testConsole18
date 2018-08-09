using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace testConsoleApp
{
    internal struct F3
    {
        public int Id;
        public int Darab;
    }

    internal class Program
    {
        public static List<int> OraList = new List<int>();
        public static List<int> PercList = new List<int>();
        public static List<int> AzList = new List<int>();
        public static List<string> IranyList = new List<string>();
        //--
        public static List<int> Bentlevok = new List<int>();

        private static int _wantedUser;

        //--
        private static void Main()
        {
            F1();
            F2();
            F3();
            F4();
            F5();
            F6();
            F7();
            F8();
            Console.ReadLine();
        }

        private static void F1()
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

        private static void F2()
        {
            Console.WriteLine("2. Feladat");

            while (true) {
                var i = 0;
                if (IranyList[i] == "be")
                {
                    Console.WriteLine("Az első belépő: " + AzList[i]);
                    break;
                }
                // ReSharper disable once RedundantAssignment
                i++;
            }

            for (var i = AzList.Count - 1; i > 0; i--)
            {
                if (IranyList[i] == "ki")
                {
                    Console.WriteLine("Az utolsó kilépő: " + AzList[i]);
                    break;
                }
            }
        }

        private static void F3()
        {
            var ppl = new List<int>();
            for (var i = 0; i < AzList.Count; i++)
            {
                if (!(ppl.Contains(i)))
                {
                    ppl.Add(i);
                }
            }
            
            var data = new F3[ppl.Count];

            var sum = 0;
            foreach (var obj in AzList)
            {
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
            var mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (var outputFile = new StreamWriter(Path.Combine(mydocpath, "athaladas.txt"), true))
            {
                foreach (var a in data)
                {
                    outputFile.Write("azonosító: " + a.Id);
                    outputFile.WriteLine(" darab: " + a.Darab);
                }
            }            
        }

        private static void F4()
        {
            var stuff = new List<int>();
            for (var i = 0; i < AzList.Count; i++)
            {
                var a = AzList[i];
                if (IranyList[i]=="be")
                {
                    if (!(stuff.Contains(a)))
                    {
                        stuff.Add(a);
                    }
                }
                if (IranyList[i] == "ki")
                {
                    if (stuff.Contains(a))
                    {
                        stuff.Remove(a);
                    }
                }
            }
            Console.WriteLine("\n4. Feladat");
            Console.Write("A végén a társalgóban voltak: ");
            foreach (var a in stuff)
            {
                Console.Write(a + " ");
            }

        }

        private static void F5()
        {
            var be = 0;
            //feltöltjük
            foreach (var a in IranyList)
            {
                if (a=="be")
                {
                    be += 1;
                    Bentlevok.Add(be);
                } else if (a == "ki")
                {
                    be -= 1;
                    Bentlevok.Add(be);
                }
            }
            //kiválasztjuk a legnagyobbat
            var max = Bentlevok.Concat(new[] {0}).Max();
            //megkeressük az ID-ját
            for (var i = 0; i < Bentlevok.Count; i++)
            {
                if (Bentlevok[i]==max)
                {
                    max = i;
                }
            }
            //maximum ID-ja --> max
            //--
            Console.WriteLine("\n\n5.Feladat");
            Console.WriteLine("Például "+OraList[max]+":"+PercList[max]+"-kor voltak a legtöbben a társalgóban.\n");
            //--
        }

        private static void F6()
        {
            Console.WriteLine("6. Feladat");
            Console.Write("Adja meg a személy azonosítóját! ");
            _wantedUser = Convert.ToInt32(Console.ReadLine());
        }


        private static readonly List<int> Firsthour = new List<int>();
        private static readonly List<int> Firstmin = new List<int>();

        private static readonly List<int> Sechour = new List<int>();
        private static readonly List<int> Secmin = new List<int>();


        private static void F7()
        {
            Console.WriteLine("\n7. Feladat");

            for (var i = 0; i < AzList.Count; i++)
            {
                if (AzList[i] == _wantedUser)
                {
                    if (IranyList[i] == "be")
                    {
                        Firsthour.Add(OraList[i]);
                        Firstmin.Add(PercList[i]);
                    }
                    else
                    {
                        Sechour.Add(OraList[i]);
                        Secmin.Add(PercList[i]);
                    }
                }
            }

            var max = Firsthour.Count;
            if (Sechour.Count>max)
            {
                max = Sechour.Count;
            }

            for (var i = 0; i < max-1; i++)
            {
                Console.WriteLine(Firsthour[i] + ":" + Firstmin[i]+"-"+Sechour[i]+":"+Secmin[i]);
            }
            if (Firsthour.Count > Sechour.Count)
            {
                Console.WriteLine(Firsthour[max - 1] + ":" + Firstmin[max - 1] + "-");
            }
            else
            {
                Console.WriteLine(Firsthour[max-1] + ":" + Firstmin[max - 1] + "-" + Sechour[max - 1] + ":" + Secmin[max - 1]);
            }

        }

        private static void F8()
        {
            Console.WriteLine("\n8. Feladat");
            //hány perc? Megfigyelés: 09-15

            //Bepercek
            var bepercek = Firsthour.Select((t, i) => (t * 60) + Firstmin[i]).ToList();
            //Kipercek
            var kipercek = Sechour.Select((t, i) => (t * 60) + Secmin[i]).ToList();
            //--
            string msg;
            if (bepercek.Count > kipercek.Count)
            {
                kipercek.Add(900);
                msg = "a megfigyelés végén a társalgóban volt.";
            }
            else
            {
                msg = "a megfigyelés végén nem volt a társalgóban.";
            }
            //--
            var percek = bepercek.Select((t, i) => kipercek[i] - t).ToList();
            //--
            var perc= percek.Sum();
            Console.WriteLine("A(z) " + _wantedUser + ". személy összesen " + perc + " percet volt bent, " +msg);            
        }

        //---------------------------
        private static bool Bennevan(IList<F3> tomb, int elem)
        {
            var ans=false;

            for (var i = 0; i < tomb.Count; i++)
            {
                if (tomb[i].Id == elem)
                {
                    ans = true;
                }
            }
            return ans;
        }
        //--
        private static int WhatsMyId(IList<F3> tomb, int elem)
        {
            var id = 0;
            for (var i = 0; i < tomb.Count; i++)
            {
                if (tomb[i].Id == elem)
                {
                    id = i;
                }
            }
            return id;
        }
        //---------------------------
    }
}
