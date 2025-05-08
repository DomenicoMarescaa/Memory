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

            int numeroCoppie = 0;
            int righe = 0;
            int colonne = 0;

            // Vettore contenente le immagini delle carte
            string[] immagini = {
            " ________________\r\n|                |\r\n|                |\r\n|                |\r\n|                |\r\n|                |\r\n|                |\r\n|                |\r\n|                |\r\n|                |\r\n|________________|",
            " ________________\r\n|                |\r\n|                |\r\n|                |\r\n|    ,--./,-.    |\r\n|   / #      \\   |\r\n|  |          |  |\r\n|   \\        /   |\r\n|    `._,._,'    |\r\n|                |\r\n|________________|",
            " ________________\r\n|                |\r\n|                |\r\n|                |\r\n|     _ \\'-_,#   |\r\n|   _\\'--','`|   |\r\n|   \\`---`  /    |\r\n|    `----'``    |            \r\n|                |\r\n|                |\r\n|________________|",
            " ________________\r\n|                |\r\n|                |\r\n|                |\r\n|     .~~~~.     |\r\n|     i====i_    |\r\n|     |cccc|_)   |\r\n|     |cccc|     |\r\n|     `-==-'     |        \r\n|                |\r\n|                |\r\n|________________|",
            " ________________               \r\n|        _.-.    |\r\n|      ,'/ //\\   |\r\n|     /// // /)  |\r\n|    /// // //|  |\r\n|   (`: // ///   |\r\n|    `;`: ///    |\r\n|    / /:`:/     |\r\n|   / /  `'      |\r\n|  (_/           |      \r\n|________________|",
            " ________________               \r\n|                |\r\n|                |\r\n|       \\        |\r\n|      ()()      |\r\n|     ()()()     |\r\n|      ()()      |\r\n|       ()       |\r\n|                |\r\n|                |      \r\n|________________|",
            " ________________\r\n|                |\r\n|                |\r\n|                |\r\n|       ,+.      |   \r\n|      ((|))     |\r\n|       )|(      |  \r\n|      ((|))     |\r\n|       `-'      |\r\n|                |       \r\n|________________|",
            " ________________\r\n|       _        |\r\n|     _/-\\_      |\r\n|  .-`-:-:-`-.   |\r\n| /-:-:-:-:-:-\\  |\r\n| \\:-:-:-:-:-:/  |\r\n|  |`       `|   |\r\n|  |         |   | \r\n|  `\\       /'   |\r\n|    `-._.-'     |\r\n|       `        |\r\n|________________|",
            " ________________\r\n|                |\r\n|                |\r\n|        \\/_     |\r\n|       _/       |      \r\n|      (,;)      |\r\n|     (,.)       |    \r\n|      (,/       |  \r\n|     |/         |\r\n|                |\r\n|________________|",
            " ________________\r\n|                |\r\n|                |\r\n|       ,-.      |\r\n|     _(*_*)_    | \r\n|    (_  o  _)   |    \r\n|      / o \\     |\r\n|     (_/ \\_)    | \r\n|                |\r\n|                |\r\n|________________|",
            " ________________\r\n|                |\r\n|       ___      |\r\n|     .'o O'-._  |\r\n|    / O o_.-`|  |\r\n|   /O_.-'  O |  |\r\n|   | o   o .-`  |\r\n|   |o O_.-'     |\r\n|   '--`         |\r\n|                |     \r\n|________________|",
            " ________________\r\n|                |\r\n|                |\r\n|                |\r\n|      ,'\"`.     |\r\n|     /     \\    |\r\n|    :       :   |\r\n|    :       :   |\r\n|     `.___,'    |\r\n|                |\r\n|________________|",
            " ________________\r\n|                |\r\n|                |\r\n|      \\||/      |\r\n|      \\||/      |\r\n|    .<><><>.    |\r\n|   .<><><><>.   |\r\n|   '<><><><>'   |\r\n|    '<><><>'    |          \r\n|                |\r\n|________________|",
            " ________________\r\n|                |\r\n|        .-.     |\r\n|       /  |     |\r\n|   .'\\|.-; _    |\r\n|  /.-.;\\  |\\|   |\r\n|  '   |'._/ `   |\r\n|      |  \\      |\r\n|       \\  |     |\r\n|        '-'     |         \r\n|________________|",
            " ________________\r\n|                |\r\n|                |\r\n|                |   \r\n|     _o_    ;:;'|\r\n| ,-.'---`.__ ;  |\r\n|((j`=====',-'   |\r\n| `-\\     /      |\r\n|    `-=-'       |\r\n|                |\r\n|________________|",
            " ________________\r\n|       )  (     | \r\n|      (   ) )   |\r\n|       ) ( (    |\r\n|     _______)_  |\r\n|  .-'---------| | \r\n| ( C|/\\/\\/\\/\\/| |\r\n|  '-./\\/\\/\\/\\/| |\r\n|    '_________' |\r\n|     '-------'  |              \r\n|________________|",
            " ________________\r\n|   .            |\r\n|  / \\/     |    |\r\n| /   \\     |    |\r\n|/    /    _|_   |\r\n|\\   /    /\\ /\\  |\r\n| \\ /    /__v__\\ |\r\n|  '    |       ||\r\n|       |#.  .##||\r\n|       |#######||\r\n|________________|",
            " ________________\r\n|      . .       |\r\n|       ...      |\r\n|     \\~~~~~/    |\r\n|      \\   /     |\r\n|       \\ /      |\r\n|        V       |\r\n|        |       |\r\n|        |       |\r\n|       ---      |      \r\n|________________|",
            " ________________\r\n|        _       |\r\n|       {_}      |\r\n|       |(|      |\r\n|       |=|      |\r\n|      /   \\     |\r\n|      |.--|     |\r\n|      ||  |     |\r\n|      |'--|     |\r\n|      '-=-'     |\r\n|________________|\r\n"};

            Console.WriteLine(immagini[0]);
            while (numeroCoppie <= 1)
            {
                Console.WriteLine("Con quante coppi di carte vuoi giocare?(minimo 2 coppie)");
                numeroCoppie = Convert.ToInt32(Console.ReadLine());
                if (numeroCoppie <= 1)
                {
                    Console.WriteLine("Coppie troppo poche,rimetterle");
                }
            }

            numeroCoppie *= 2;

            if (numeroCoppie == 4)
            {
                righe = 2; colonne = 2;
            }
            else if (numeroCoppie == 6)
            {
                righe = 2; colonne = 3;
            }
            else if (numeroCoppie == 8)
            {
                righe = 2; colonne = 4;
            }
            else if (numeroCoppie == 10)
            {
                righe = 2; colonne = 5;
            }
            else if (numeroCoppie == 12)
            {
                righe = 3; colonne = 4;
            }
            else if (numeroCoppie == 14)
            {
                righe = 2; colonne = 7;

            }
            else if (numeroCoppie == 16)
            {
                righe = 4; colonne = 4;
            }
            else if (numeroCoppie == 18)
            {
                righe = 3; colonne = 6;
            }
            else if (numeroCoppie == 20)
            {
                righe = 4; colonne = 5;
            }
            else if (numeroCoppie == 22)
            {
                righe = 2; colonne = 11;
            }
            else if (numeroCoppie == 24)
            {
                righe = 4; colonne = 6;
            }
            else if (numeroCoppie == 26)
            {
                righe = 2; colonne = 13;
            }
            else if (numeroCoppie == 28)
            {
                righe = 4; colonne = 7;
            }
            else if (numeroCoppie == 30)
            {
                righe = 3; colonne = 10;
            }
            string[,] carte = new string[righe, colonne];
            PopolaGriglia(carte, immagini[0]);
            StampaGriglia(carte, immagini[0]);

            Console.ReadKey();

        }

        static void PopolaGriglia(string[,] carte, string immagine)
        {
            for (int i = 0; i < carte.GetLength(0); i++)
            {
                for (int j = 0; j < carte.GetLength(1); j++)
                {
                    carte[i, j] = "X";
                }
            }

        }

        static void StampaGriglia(string[,] carte, string immagine)
        {
            for (int i = 0; i < carte.GetLength(0); i++)
            {
                for (int j = 0; j < carte.GetLength(1); j++)
                {
                    Console.Write(carte[i,j] + "|");
                }

                Console.WriteLine();
            }

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
            return contatoreA;
        }
    }
}