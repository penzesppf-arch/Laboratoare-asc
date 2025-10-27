using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator2
{   //Converteste un nr cu virgula dintr o baza in alta
    internal class Program
    {
        static void Main(string[] args)
        {
             string[] n; int b1, b2;
            n = Console.ReadLine().ToUpper().Split('.');
            b1 = Convert.ToInt32(Console.ReadLine());
            b2 = Convert.ToInt32(Console.ReadLine());
            
            //b1=>10
            float rez = 0;
            for (int i = 0; i < n[0].Length; i++)
            {
                char c = n[0][n[0].Length - 1 - i];
                if (c >= '0' && c <= '9')
                    rez += (c - '0') * (int)Math.Pow(b1, i);
                else
                    rez += (c - 'A' + 10) * (int)Math.Pow(b1, i);
            }
            for (int i = 0; i < n[1].Length; i++)
            {
                char c = n[1][i];
                if (c >= '0' && c <= '9')
                    rez += (c - '0') * (float)1 / (int)Math.Pow(b1, i + 1);
                else
                    rez += (c - 'A' + 10) * (float)1 / (int)Math.Pow(b1, i + 1);
            }

            //b2<=10
            string s = "0123456789ABCDEF";
            int parteInt = (int)Math.Floor(rez);
            float parteFract = rez - parteInt;
            string rezInt = "";
            if (parteInt == 0)
                rezInt = "0";
            else
            {
                while (parteInt > 0)
                {
                    rezInt = s[(int)(parteInt % b2)] + rezInt;
                    parteInt /= b2;
                }
            }
            string rezFract = "";
            while (parteFract - Math.Floor(parteFract) != 0)
            {
                parteFract *= b2;
                int cifra = (int)Math.Floor(parteFract);
                rezFract+= s[cifra];
                parteFract -= cifra;
            }
            Console.WriteLine($"{rezInt}.{rezFract}");
        }
    }
}