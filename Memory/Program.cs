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
            string difficolta = "facile"; // Impostato su "facile" di default

            string[] immagini = {
                " ________________\r\n|                |\r\n|                |\r\n|                |\r\n|                |\r\n|                |\r\n|                |\r\n|                |\r\n|                |\r\n|________________|",
                " ________________\r\n|                |\r\n|                |\r\n|                |\r\n|    ,--./,-.    |\r\n|   / #      \\   |\r\n|  |          |  |\r\n|   \\        /   |\r\n|    `._,._,'    |\r\n|                |\r\n|________________|",
                " ________________\r\n|                |\r\n|                |\r\n|                |\r\n|     _ \\'-_,#   |\r\n|   _\\'--','`|   |\r\n|   \\`---`  /    |\r\n|    `----'``    |\r\n|                |\r\n|                |\r\n|________________|",
                " ________________\r\n|                |\r\n|                |\r\n|                |\r\n|     .~~~~.     |\r\n|     i====i_    |\r\n|     |cccc|_)   |\r\n|     |cccc|     |\r\n|     `-==-'     |\r\n|                |\r\n|                |\r\n|________________|",
                // Aggiungi altre immagini se necessario
            };

            Console.WriteLine("Modalità di difficoltà: Facile");

            // Richiesta di numero di coppie
            while (numeroCoppie <= 1)
            {
                Console.WriteLine("Con quante coppie di carte vuoi giocare? (minimo 2 coppie)");
                numeroCoppie = Convert.ToInt32(Console.ReadLine());

                if ( numeroCoppie > 1)
                {
                    Console.WriteLine($"Hai scelto {numeroCoppie} coppie.");
                }
                else
                {
                    Console.WriteLine("Input non valido. Riprova.");
                }
            }

            // Calcola il numero di righe e colonne
            numeroCoppie *= 2;
            switch (numeroCoppie)
            {
                case 4: righe = 2; colonne = 2; break;
                case 6: righe = 2; colonne = 3; break;
                case 8: righe = 2; colonne = 4; break;
                case 10: righe = 2; colonne = 5; break;
                case 12: righe = 3; colonne = 4; break;
                case 16: righe = 4; colonne = 4; break;
                default:
                    Console.WriteLine("Numero di coppie non valido.");
                    return;
            }
            //stampa la scelta della difficolta dell'AI
            Console.WriteLine("scegliere la difficolta del bot (facile / media / difficile)");
            // imposta la variabile difficolta con quella inserita dall'utente
            difficolta = Console.ReadLine();

            // Gestione della difficoltà
            switch (difficolta.ToLower())
            {
                case "facile":
                    AiFacile(ref carta1, ref carta2, ref contatoreA);
                    break;
                case "media":
                    AiFacile(ref carta1, ref carta2, ref contatoreA);
                    break;
                case "difficile":
                    AiFacile(ref carta1, ref carta2, ref contatoreA);
                    break;
                default:
                    AiFacile(ref carta1, ref carta2, ref contatoreA);
                    break;
            }

            string[,] carte = new string[righe, colonne];

            DistribuisciCarte(carte, immagini, numeroCoppie / 2);
            StampaGriglia(carte);

            

            Console.ReadKey();
        }

        /// <summary>
        /// Funzione che simula il comportamento dell'AI facile.
        /// L'AI sceglie due carte casualmente e verifica se sono uguali.
        /// </summary>
        /// <param name="carta1">Riferimento alla prima carta selezionata dall'AI.</param>
        /// <param name="carta2">Riferimento alla seconda carta selezionata dall'AI.</param>
        /// <param name="contatoreA">Contatore delle giocate dell'AI.</param>
        static void AiFacile(ref int carta1, ref int carta2, ref int contatoreA)
        {
            Random rand = new Random();

            carta1 = rand.Next(0, 8);
            carta2 = rand.Next(0, 8);

            if (carta1 == carta2)
            {
                contatoreA++;
                Console.WriteLine("AI ha trovato una coppia!");
            }
            else
            {
                Console.WriteLine("AI ha sbagliato.");
            }
        }

        /// <summary>
        /// Funzione che distribuisce le carte nella griglia.
        /// Le carte vengono distribuite in modo casuale.
        /// </summary>
        /// <param name="carte">La griglia di carte dove verranno distribuite.</param>
        /// <param name="immagini">L'array delle immagini delle carte.</param>
        /// <param name="numeroCoppie">Il numero di coppie da distribuire.</param>
        static void DistribuisciCarte(string[,] carte, string[] immagini, int numeroCoppie)
        {
            int totaleCarte = numeroCoppie * 2;
            string[] carteDaInserire = new string[totaleCarte];

            int k = 0;
            for (int i = 0; i < numeroCoppie; i++)
            {
                carteDaInserire[k++] = immagini[i];
                carteDaInserire[k++] = immagini[i];
            }

            Random rand = new Random();
            for (int i = 0; i < totaleCarte; i++)
            {
                int j = rand.Next(i, totaleCarte);
                string temp = carteDaInserire[i];
                carteDaInserire[i] = carteDaInserire[j];
                carteDaInserire[j] = temp;
            }

            k = 0;
            for (int r = 0; r < carte.GetLength(0); r++)
            {
                for (int c = 0; c < carte.GetLength(1); c++)
                {
                    carte[r, c] = carteDaInserire[k++];
                }
            }
        }

        /// <summary>
        /// Funzione che stampa la griglia di carte.
        /// Mostra la disposizione delle carte nel terminale.
        /// </summary>
        /// <param name="carte">La griglia di carte da stampare.</param>
        static void StampaGriglia(string[,] carte)
        {
            for (int i = 0; i < carte.GetLength(0); i++)
            {
                for (int j = 0; j < carte.GetLength(1); j++)
                {
                    Console.Write(carte[i, j] + "|");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Funzione che mantiene e aggiorna il punteggio del giocatore.
        /// </summary>
        /// <param name="punteggioG">punteggio del giocatore</param>
        /// <return>mi ritorna il punteggio del giocatore</return>
        static int punteggioG(int contatoreG, int carta1, int carta2)
        {
            if (carta1 == carta2)
            {
                contatoreG += 1;
            }
            return contatoreG;
        }

        /// <summary>
        /// Funzione che mantiene e aggiorna il punteggio dell'Ai.
        /// </summary>
        /// <param name="punteggioA">punteggio dell'Ai</param>
        /// <return>mi ritorna il punteggio dell'Ai</return>
        static int punteggioA(int contatoreA, int carta1, int carta2)
        {
            if (carta1 == carta2)
            {
                contatoreA += 1;
            }
            return contatoreA;
        }

        ///<summary>
        /// seleziona il player che inizia
        /// </summary>
        /// <param name="player">il primo giocatore</param>
        /// <param name="player2">il secondo player</param>
        /// <return>mi ritorna il giocatore che inizia</return>
        static int PlayerIniziale(int player1, int player2)
        {
            Random random = new Random();
            while (player1 == player2)
            {
                player1 = random.Next(1, 7);
                player2 = random.Next(1, 7);
            }
            if (player1 > player2)
            {
                return player1;
            }
            else
            {
                return player2;
            }
        }
    }
}