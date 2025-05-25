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
            string immaginiX = "||";

            string[] immagini =
            {
                "A♥","2♥","3♥","4♥","5♥","6♥","7♥","8♥","9♥","10♥","J♥","Q♥","K♥",
                "A♦","2♦","3♦","4♦","5♦","6♦","7♦","8♦","9♦","10♦","J♦","Q♦","K♦",
                "A♣","2♣","3♣","4♣","5♣","6♣","7♣","8♣","9♣","10♣","J♣","Q♣","K♣",
                "A♠","2♠","3♠","4♠","5♠","6♠","7♠","8♠","9♠","10♠","J♠","Q♠","K♠"
            };

            Console.WriteLine($"Modalità di difficoltà: {difficolta} ");

            while (numeroCoppie <= 1)
            {
                Console.WriteLine("Con quante coppie di carte vuoi giocare? (minimo 2 coppie)");
                numeroCoppie = Convert.ToInt32(Console.ReadLine());

                if (numeroCoppie > 1)
                    Console.WriteLine($"Hai scelto {numeroCoppie} coppie.");
                else
                    Console.WriteLine("Input non valido. Riprova.");
            }

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

            bool[,] carteScoperte = new bool[righe, colonne];
            string[,] carte = new string[righe, colonne];

            DistribuisciCarte(carte, immagini, numeroCoppie / 2);
            StampaGriglia(carte, carteScoperte, immaginiX);

            Console.WriteLine("Scegli la difficoltà del bot (facile / media / difficile):");
            difficolta = Console.ReadLine();

            switch (difficolta.ToLower())
            {
                case "facile": 
                    AiFacile(ref carta1, ref carta2, ref contatoreA, carte, carteScoperte, immaginiX);

                case "medio":
                    AiFacile(ref carta1, ref carta2, ref contatoreA, carte, carteScoperte, immaginiX);

                case "difficile":
                    AiFacile(ref carta1, ref carta2, ref contatoreA, carte, carteScoperte, immaginiX);

                default:
                    AiFacile(ref carta1, ref carta2, ref contatoreA, carte, carteScoperte, immaginiX);
                    break;
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Esegue la logica dell'AI a difficoltà facile: seleziona due carte casuali non ancora scoperte.
        /// Se le carte sono uguali, le lascia scoperte e incrementa il punteggio dell'AI.
        /// Altrimenti, le ricopre dopo una breve attesa.
        /// </summary>
        /// <param name="carta1">Indice della prima carta scelta (non usato in questa versione).</param>
        /// <param name="carta2">Indice della seconda carta scelta (non usato in questa versione).</param>
        /// <param name="contatoreA">Punteggio dell'AI, incrementato se trova una coppia.</param>
        /// <param name="carte">Matrice contenente le carte.</param>
        /// <param name="carteScoperte">Matrice booleana che indica quali carte sono scoperte.</param>
        /// <param name="immaginiX">Stringa usata per rappresentare le carte coperte.</param>
        static void AiFacile(ref int carta1, ref int carta2, ref int contatoreA, string[,] carte, bool[,] carteScoperte, string immaginiX)
        {
            Random rand = new Random();
            int righe = carte.GetLength(0);
            int colonne = carte.GetLength(1);

            int r1, c1, r2, c2;
            do
            {
                r1 = rand.Next(righe);
                c1 = rand.Next(colonne);
            } while (carteScoperte[r1, c1]);

            do
            {
                r2 = rand.Next(righe);
                c2 = rand.Next(colonne);
            } while ((r1 == r2 && c1 == c2) || carteScoperte[r2, c2]);

            // Scopre temporaneamente
            carteScoperte[r1, c1] = true;
            carteScoperte[r2, c2] = true;

            Console.Clear();
            Console.WriteLine("L'AI ha scelto due carte:");
            StampaGriglia(carte, carteScoperte, immaginiX);
            System.Threading.Thread.Sleep(2000);

            if (carte[r1, c1] == carte[r2, c2])
            {
                contatoreA++;
                Console.WriteLine("AI ha trovato una coppia!");
            }
            else
            {
                Console.WriteLine("AI ha sbagliato.");
                System.Threading.Thread.Sleep(1000);
                carteScoperte[r1, c1] = false;
                carteScoperte[r2, c2] = false;
            }
            Console.Clear();

            Console.WriteLine("Stato dopo la mossa dell'AI:");
            StampaGriglia(carte, carteScoperte, immaginiX);
        }

        static void AiMedio(ref int carta1, ref int carta2, ref int contatoreA, string[,] carte, bool[,] carteScoperte, string immaginiX)
        {   
            if (carta1 == 0 a&& carta2 == 0)
            {
                AiFacile(ref carta1, ref carta2, ref contatoreA, carte, carteScoperte, immaginiX);
                return;
            }
            System.Threading.Thread.Sleep(2000);

            if (carte[r1, c1] == carte[r2, c2])
            {
                contatoreA++;
                Console.WriteLine("AI ha trovato una coppia!");
            }
            else
            {
                Console.WriteLine("AI ha sbagliato.");
                System.Threading.Thread.Sleep(1000);
                carteScoperte[r1, c1] = false;
                carteScoperte[r2, c2] = false;
            }
            Console.Clear();

            Console.WriteLine("Stato dopo la mossa dell'AI:");
            StampaGriglia(carte, carteScoperte, immaginiX);
        }

        static void AiDifficile(ref int carta1, ref int carta2, ref int contatoreA, string[,] carte, bool[,] carteScoperte, string immaginiX)
        {

        }

        /// <summary>
        /// Distribuisce casualmente le coppie di carte nella griglia, assicurandosi che ogni carta sia presente due volte.
        /// </summary>
        /// <param name="carte">Matrice dove verranno posizionate le carte distribuite.</param>
        /// <param name="immagini">Array contenente tutte le immagini disponibili per le carte.</param>
        /// <param name="numeroCoppie">Numero di coppie da posizionare (ogni coppia ha due carte uguali).</param>
        static void DistribuisciCarte(string[,] carte, string[] immagini, int numeroCoppie)
        {
            int totaleCarte = numeroCoppie * 2;
            string[] carteDaInserire = new string[totaleCarte];

            for (int i = 0; i < numeroCoppie; i++)
            {
                carteDaInserire[2 * i] = immagini[i];
                carteDaInserire[2 * i + 1] = immagini[i];
            }

            Random rand = new Random();
            for (int i = 0; i < totaleCarte; i++)
            {
                int j = rand.Next(i, totaleCarte);
                (carteDaInserire[i], carteDaInserire[j]) = (carteDaInserire[j], carteDaInserire[i]);
            }

            int k = 0;
            for (int r = 0; r < carte.GetLength(0); r++)
            {
                for (int c = 0; c < carte.GetLength(1); c++)
                {
                    carte[r, c] = carteDaInserire[k++];
                }
            }
        }

        /// <summary>
        /// Stampa la griglia delle carte sullo schermo, mostrando solo le carte scoperte.
        /// Le carte coperte vengono visualizzate con un simbolo segnaposto.
        /// </summary>
        /// <param name="carte">Matrice delle carte da stampare.</param>
        /// <param name="carteScoperte">Matrice booleana che indica quali carte devono essere visibili.</param>
        /// <param name="immaginiX">Simbolo utilizzato per le carte coperte (es. "||").</param>
        static void StampaGriglia(string[,] carte, bool[,] carteScoperte, string immaginiX)
        {
            Console.WriteLine();
            for (int i = 0; i < carte.GetLength(0); i++)
            {
                for (int j = 0; j < carte.GetLength(1); j++)
                {
                    Console.Write(carteScoperte[i, j] ? carte[i, j] + "\t" : immaginiX + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
