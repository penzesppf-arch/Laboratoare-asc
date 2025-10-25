using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator1
{
    class Program
    {
        static void Main(string[] args)
        {   
            // Converteste un numar dintr-o baza intr-alta
            int b1, b2; string n;
            n = Console.ReadLine().ToUpper();
            b1 = Convert.ToInt32(Console.ReadLine());
            b2 = Convert.ToInt32(Console.ReadLine());
           

            //baza=>10
            int r1 = 0;
            for (int i = 0; i < n.Length; i++)
            {
                char c = n[n.Length - 1 - i];
                if (c >= '0' && c <= '9')
                    r1+= (c - '0') * (int)Math.Pow(b1, i);
                else
                    r1 += (c - 'A' + 10) * (int)Math.Pow(b1, i);

            }

            //baza<=10
            string s = "0123456789ABCDEF";
            string r2 = "";
            if (r1 == 0)
                r2 = "0";
            else
            {
                while (r1 > 0)
                {
                    r2 = s[r1 % b2] + r2;
                    r1 /= b2;
                }
            }

            Console.WriteLine(r2);
        }
    }
}
