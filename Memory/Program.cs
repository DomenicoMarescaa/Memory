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
            //wao

            string[] carte = {
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

            // prova stampa carte
            Console.WriteLine(carte[0]);
            Console.WriteLine();
            Console.WriteLine(carte[2]);
            Console.WriteLine();
            Console.WriteLine(carte[5]);
            Console.WriteLine();
            Console.WriteLine(carte[9]);
            Console.WriteLine();
            Console.WriteLine(carte[11]);
            Console.WriteLine();

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