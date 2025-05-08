using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int contatoreG = 0;
            int contatoreA = 0;
            int carta1 = 0;
            int carta2 = 0;

        }
        
        static int punteggioG(int contatoreG, int carta1, int carta2)
        {
            if (carta1 == carta2)
            {
                contatoreG += 1;
            }
            return contatoreG;
        }
        
        static int punteggioA(int contatoreA, int carta1, int carta2)
        {
            if (carta1 == carta2)
            {
                contatoreA += 1;
            }
            return contatoreA
        }
    }
}