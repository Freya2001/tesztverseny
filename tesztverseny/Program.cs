using System;
using System.Collections.Generic;
using System.IO;

namespace tesztverseny
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader("valaszok.txt");  //megnyit olvasasra
            int versenyzo = 0;    // mindig = az azon/valasz.Count
            bool readLineSuccesful = true;
            string helyesvalasz = file.ReadLine();
            List<string> azon = new List<string>();  //index koti ossze a ket listat  o-i-o
            List<string> valasz = new List<string>();
            
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
            #endregion 
        }
    }
}