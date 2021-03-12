using System;
using System.Collections.Generic;
using System.IO;

namespace tesztverseny
{
    class Program
    {
        static List<int> pont = new List<int>();
        static List<string> azon = new List<string>();  //index koti ossze a 3 listat  
        static List<string> valasz = new List<string>();

        static string ValaszEll(string helyesv, string megadottv)
        {
            string result = "";
            for (int i = 0; i < helyesv.Length; i++)
            {
                if( helyesv[i] == megadottv[i])
                {
                    result += "+"; // "alma" + "fa" = "almafa"
                }
                else
                {
                    result += " ";
                }
            }
            return result;
        }

        static void Eredmenyh(int adottpont, int helyezes)
        {
            for (int i = 0; i < pont.Count; i++)
            {
                if (adottpont == pont[i])
                {
                    Console.WriteLine($"{helyezes}. díj ({pont[i]} pont): {azon[i]}");
                }
            }
        }
        static int Maxpont(int kisebbmint)
        {
            int legnagyobb = -1;
            for (int i = 0; i < pont.Count; i++)
            {
                if (legnagyobb < pont[i] && pont[i] < kisebbmint)
                {
                    legnagyobb = pont[i];
                }
            }
            return legnagyobb;
        }
        static void Main(string[] args)
        {
            int versenyzo = 0;    // mindig = az azon/valasz.Count
            
            #region Beolvasás
            StreamReader file = new StreamReader(@"..\..\..\valaszok.txt");  //megnyit olvasasra
            bool readLineSuccesful = true;
            string helyesvalasz = file.ReadLine();
            while (readLineSuccesful)
            {
                string line = file.ReadLine();
                if (line == null)
                {
                    readLineSuccesful = false;
                    break;
                }
                //adatmentes a listaba
                string[] tordeltsor = line.Split(' ');
                azon.Add(tordeltsor[0]);
                valasz.Add(tordeltsor[1]);
                // versenyzok szam+
                versenyzo += 1;
            }
            file.Close();
            #endregion
            #region 2.feladat
            Console.Write($"2. feladat: A vetélkedőn {versenyzo} versenyző indult.");
            Console.Write("\n");
            #endregion 
            #region 3.feladat
            Console.Write("3. feladat: A versenyző azonosítója = ");
            string adottazon = Console.ReadLine();
            int hanyadik = 0; // hanyadik versenyzo azonositojat adtak meg 
            for (int i = 0; i < azon.Count; i++)
            {
                if (adottazon == azon[i])
                {
                    hanyadik = i;
                    break;
                }
            }
            Console.Write($"{valasz[hanyadik]} (a versenyző válasza)");
            Console.Write("\n");
            #endregion 
            #region 4.feladat
            Console.WriteLine("4. feladat:");
            Console.WriteLine($"{helyesvalasz}   (a helyes megoldás)");
            Console.WriteLine($"{ValaszEll(helyesvalasz, valasz[hanyadik])}   (a versenyző helyes válaszai)");
            Console.Write("\n");
            #endregion
            #region 5.feladat
            Console.Write("5. feladat: A feladat sorszáma = ");
            string feladatszambetu = Console.ReadLine();
            int feladatszam = Convert.ToInt32(feladatszambetu);
            //ValaszEll(helyesvalasz, valasz[]);
            int helyesdb = 0;
            for (int i = 0; i < valasz.Count; i++)
            {
                if (helyesvalasz[feladatszam - 1] == valasz[i][feladatszam - 1])
                {
                    helyesdb += 1;
                }
            }
            Console.WriteLine($"A feladatra {helyesdb} fő, a versenyzők {Math.Round(((helyesdb / (float)versenyzo) * 100), 2)}%-a adott helyes választ.");
            Console.Write("\n");
            #endregion
            #region 6.feladat
            Console.Write("6. feladat: A versenyzők pontszámának meghatározása");
            Console.Write("\n");
            for (int i = 0; i < valasz.Count; i++)
            {
                int versenyzopont = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (helyesvalasz[j] == valasz[i][j])
                    {
                        versenyzopont = versenyzopont + 3;
                    }
                }
                for (int j = 5; j < 10; j++)
                {
                    if (helyesvalasz[j] == valasz[i][j])
                    {
                        versenyzopont = versenyzopont + 4;
                    }
                }
                for (int j = 10; j < 13; j++)
                {
                    if (helyesvalasz[j] == valasz[i][j])
                    {
                        versenyzopont = versenyzopont + 5;
                    }
                }
                if (helyesvalasz[13] == valasz[i][13])
                {
                    versenyzopont = versenyzopont + 6;
                }
                pont.Add(versenyzopont);
            }
            StreamWriter mentes = new StreamWriter(@"..\..\..\pontok.txt");
            for (int i = 0; i < azon.Count; i++)
            {
                mentes.WriteLine(azon[i] + " " + pont[i]);
            }
            mentes.Close();
            #endregion
            #region 7.feladat
            int elsopont = Maxpont(10000);
            int masodikpont = Maxpont(elsopont);
            int harmadikpont = Maxpont(masodikpont);
            
                
            Console.WriteLine("7. feladat: A verseny legjobbjai:");
            Eredmenyh(elsopont, 1);
            Eredmenyh(masodikpont, 2);
            Eredmenyh(harmadikpont, 3);
            #endregion
        }


    }
}