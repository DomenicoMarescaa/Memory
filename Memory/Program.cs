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
        static int punteggio(int contatore,int carta1,int carta2)
        {
            if(carta1=carta2)
            {
                contatore += 1;
            }
            else
            {
                Console.WriteLine("hai sbagliato. tocca all'avversario ");
            }
            return contatore;
        }
    }
}
