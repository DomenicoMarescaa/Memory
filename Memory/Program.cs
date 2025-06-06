﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int contatoreA = 0;
            int carta1 = 0;
            int carta2 = 0;
            int numeroCoppie = 0;
            int righe = 0;
            int colonne = 0;
            int difficolta = 0; // Impostato su "facile" di default
            int mode = 0;
            string immaginiX = " █";
            string[] immagini =
            {
                    "A♥","2♦","3♣","4♠","5♥","6♦","7♣","8♠","9♥","10♦","J♣","Q♠","K♥",
                    "A♦","2♥","3♦","4♦","5♦","6♥","7♦","8♦","9♦","10♥","J♦","Q♦","K♦",
                    "A♣","2♣","3♥","4♣","5♣","6♣","7♥","8♣","9♣","10♣","J♥","Q♣","K♣",
                    "A♠","2♠","3♠","4♥","5♠","6♠","7♠","8♥","9♠","10♠","J♠","Q♥","K♠"
                };

            MenuGame();

            Thread.Sleep(2000);//funzione per il ritardo di 2 secondo
            Console.WriteLine("premi un tasto per continuare...");
            Console.ReadKey();

            Console.Clear();


            while (mode != 1 && mode != 2 && mode != 3)
            {
                Console.WriteLine("Vuoi giocare contro un bot o player (in locale)");

                Console.WriteLine("1) Singleplayer");
                Console.WriteLine("2) Bot");
                Console.WriteLine("3) PvP");

                mode = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }

            Console.Clear();
            Thread.Sleep(500);//funzione per il ritardo di 2 secondo

            //bot mode
            if (mode != 1 && mode != 3)
            {
                //richiesta della difficoltà del bot        
                Console.WriteLine("Scegli la difficoltà del bot:");
                Console.WriteLine("1) Facile");
                Console.WriteLine("2) Medio");
                Console.WriteLine("3) Difficile");
                Console.WriteLine("4) Impossibile (non puoi vincere)");

                difficolta = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                //richiesta del numero di coppie
                while (numeroCoppie <= 1)
                {
                    Console.WriteLine("Con quante coppie di carte vuoi giocare? (min 2 / max 12)");
                    numeroCoppie = Convert.ToInt32(Console.ReadLine());

                    if (numeroCoppie > 1)
                        Console.WriteLine($"Hai scelto {numeroCoppie} coppie.");
                    else
                        Console.WriteLine("Input non valido. Riprova.");
                }
                //moltiplicazione delle carte per 2 per ottenere il numero totale di carte
                numeroCoppie *= 2;
                switch (numeroCoppie)
                {
                    case 4: righe = 2; colonne = 2; break;
                    case 6: righe = 2; colonne = 3; break;
                    case 8: righe = 2; colonne = 4; break;
                    case 10: righe = 2; colonne = 5; break;
                    case 12: righe = 3; colonne = 4; break;
                    case 16: righe = 4; colonne = 4; break;
                    case 18: righe = 3; colonne = 6; break;
                    case 20: righe = 4; colonne = 5; break;
                    case 22: righe = 5; colonne = 9; break;
                    case 24: righe = 4; colonne = 6; break;
                    default:
                        {
                            Console.WriteLine("Numero di coppie non valido.");
                            return;
                        }
                }

                //carte coperte
                bool[,] carteScoperte = new bool[righe, colonne];
                string[,] carte = new string[righe, colonne];

                DistribuisciCarte(carte, immagini, numeroCoppie / 2);
                StampaGriglia(carte, carteScoperte, immaginiX);

                //selta della funzione dell'AI in base alla difficoltà settata
                switch (difficolta)
                {
                    case 1:
                        AiFacile(ref carta1, ref carta2, ref contatoreA, carte, carteScoperte, immaginiX);
                        break;
                    case 2:
                        AiMedio(ref carta1, ref carta2, ref contatoreA, carte, carteScoperte, immaginiX);
                        break;
                    case 3:
                        AiDifficile(ref carta1, ref carta2, ref contatoreA, carte, carteScoperte, immaginiX);
                        break;
                    case 4:
                        AiImpossibile(ref carta1, ref carta2, ref contatoreA, carte, carteScoperte, immaginiX);
                        break;

                    default:
                        Console.WriteLine("Difficoltà non valida.");
                        break;
                }
            }

            // singleplayer
            else if (mode != 3 && mode != 2)
            {
                // richiesta del numero di coppie
                while (numeroCoppie <= 1)
                {
                    Console.WriteLine("Con quante coppie di carte vuoi giocare? (min 2 / max 12)");
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
                    case 18: righe = 3; colonne = 6; break;
                    case 20: righe = 4; colonne = 5; break;
                    case 22: righe = 4; colonne = 9; break;
                    case 24: righe = 4; colonne = 6; break;
                    case 26: righe = 4; colonne = 6; break;
                    default:
                        Console.WriteLine("Numero di coppie non valido.");
                        return;
                }

                // carte coperte e griglia carte
                bool[,] carteScoperte = new bool[righe, colonne];
                string[,] carte = new string[righe, colonne];

                DistribuisciCarte(carte, immagini, numeroCoppie / 2);
                SinglePlayerMode(carte, carteScoperte, immaginiX);
            }

            // pvp mode
            else if (mode != 1 && mode != 2)
            {
                // Scelta numero coppie
                while (numeroCoppie <= 1)
                {
                    Console.WriteLine("Con quante coppie di carte vuoi giocare? (min 2 / max 26)");
                    numeroCoppie = Convert.ToInt32(Console.ReadLine());
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
                    case 18: righe = 3; colonne = 6; break;
                    case 20: righe = 4; colonne = 5; break;
                    case 22: righe = 4; colonne = 9; break;
                    case 24: righe = 4; colonne = 6; break;
                    case 26: righe = 4; colonne = 6; break;
                    default:
                        Console.WriteLine("Numero di coppie non valido.");
                        return;
                }

                bool[,] carteScoperte = new bool[righe, colonne];
                string[,] carte = new string[righe, colonne];

                DistribuisciCarte(carte, immagini, numeroCoppie / 2);
                PvPLocale(carte, carteScoperte, immaginiX);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// funzione per giocare in giocatore singolo
        /// </summary>
        /// <param name="carte">carte da gioco</param>
        /// <param name="carteScoperte">carte scoperte</param>
        /// <param name="immaginiX">immagini</param>
        /// <summary>
        /// Modalità singleplayer semplificata
        /// </summary>
        static void SinglePlayerMode(string[,] carte, bool[,] carteScoperte, string immaginiX)
        {


            int puntiGiocatore = 0;
            int totaleCoppie = carte.Length / 2;



            // finché ci sono carte da scoprire
            while (!TutteScoperte(carteScoperte))
            {
                Console.Clear();
                Console.WriteLine("Modalità: SinglePlayer");
                Console.WriteLine($"Coppie trovate: {puntiGiocatore}/{totaleCoppie}");
                StampaGriglia(carte, carteScoperte, immaginiX);

                // input prima carta
                int r1, c1;
                while (true)
                {
                    Console.Write("Riga prima carta: ");
                    r1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Colonna prima carta: ");
                    c1 = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (!carteScoperte[r1, c1]) break;
                    Console.WriteLine("Carta già scoperta, riprova.");
                }

                carteScoperte[r1, c1] = true;
                Console.Clear();
                StampaGriglia(carte, carteScoperte, immaginiX);

                // input seconda carta
                int r2, c2;
                while (true)
                {
                    Console.Write("Riga seconda carta: ");
                    r2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Colonna seconda carta: ");
                    c2 = Convert.ToInt32(Console.ReadLine()) - 1;

                    if ((r1 != r2 || c1 != c2) && !carteScoperte[r2, c2]) break;
                    Console.WriteLine("Carta non valida o già scoperta, riprova.");
                }

                carteScoperte[r2, c2] = true;
                Console.Clear();
                StampaGriglia(carte, carteScoperte, immaginiX);

                // controlla se è una coppia
                if (carte[r1, c1] == carte[r2, c2])
                {
                    Console.WriteLine("Hai trovato una coppia!");
                    puntiGiocatore++;
                }
                else
                {
                    Console.WriteLine("Non è una coppia.");
                    Thread.Sleep(1000);
                    carteScoperte[r1, c1] = false;
                    carteScoperte[r2, c2] = false;
                }

                Console.WriteLine("Premi un tasto per continuare...");
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine("Hai completato il gioco!");
            Console.WriteLine($"Punti totali: {puntiGiocatore}");
            Console.WriteLine("Premi un tasto per uscire...");
            Console.ReadKey();
        }

        /// <summary>
        /// funzione per giocare in locale player vs player
        /// </summary>
        /// <param name="carte">carte da gioco</param>
        /// <param name="carteScoperte">carte scoperte</param>
        /// <param name="immaginiX">carte coperte</param>
        static void PvPLocale(string[,] carte, bool[,] carteScoperte, string immaginiX)
        {
            int punteggioGiocatore1 = 0;
            int punteggioGiocatore2 = 0;
            int giocatoreCorrente = 1;

            while (!TutteScoperte(carteScoperte))
            {
                Console.Clear();
                Console.WriteLine($"Modalità PvP - Turno Giocatore {giocatoreCorrente}");
                Console.WriteLine($"Punteggio - Giocatore I: {punteggioGiocatore1} | Giocatore II: {punteggioGiocatore2}");
                StampaGriglia(carte, carteScoperte, immaginiX);

                // Input prima carta
                int r1, c1;
                while (true)
                {
                    Console.Write("Inserisci riga prima carta: ");
                    r1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Inserisci colonna prima carta: ");
                    c1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (!carteScoperte[r1, c1]) break;
                    Console.WriteLine("Carta già scoperta, riprova.");
                }
                carteScoperte[r1, c1] = true;
                Console.Clear();
                Console.WriteLine($"Modalità PvP - Turno Giocatore {giocatoreCorrente}");
                Console.WriteLine($"Punteggio - Giocatore 1: {punteggioGiocatore1} | Giocatore 2: {punteggioGiocatore2}");
                StampaGriglia(carte, carteScoperte, immaginiX);

                // Input seconda carta
                int r2, c2;
                while (true)
                {
                    Console.Write("Inserisci riga seconda carta: ");
                    r2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Inserisci colonna seconda carta: ");
                    c2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    if ((r1 != r2 || c1 != c2) && !carteScoperte[r2, c2]) break;
                    Console.WriteLine("Carta non valida o già scoperta, riprova.");
                }
                carteScoperte[r2, c2] = true;
                Console.Clear();
                StampaGriglia(carte, carteScoperte, immaginiX);

                // Verifica corrispondenza
                if (carte[r1, c1] == carte[r2, c2])
                {
                    Console.WriteLine("Hai trovato una coppia!");
                    if (giocatoreCorrente == 1)
                        punteggioGiocatore1++;
                    else
                        punteggioGiocatore2++;
                }
                else
                {
                    Console.WriteLine("Non è una coppia.");
                    carteScoperte[r1, c1] = false;
                    carteScoperte[r2, c2] = false;
                    giocatoreCorrente = (giocatoreCorrente == 1) ? 2 : 1; // Cambia giocatore
                }

                Console.WriteLine("Premi un tasto per continuare...");
                Console.ReadKey();
            }

            // Risultato finale
            Console.Clear();
            Console.WriteLine("Tutte le carte sono state trovate!");
            Console.WriteLine();
            Console.WriteLine($"Punteggio finale - Giocatore 1: {punteggioGiocatore1} | Giocatore 2: {punteggioGiocatore2}");
            Console.WriteLine();
            if (punteggioGiocatore1 > punteggioGiocatore2)
                Console.WriteLine("Giocatore 1 ha vinto!");
            else if (punteggioGiocatore2 > punteggioGiocatore1)
                Console.WriteLine("Giocatore 2 ha vinto!");
            else
                Console.WriteLine("È un pareggio!");
            Console.WriteLine();
            Console.WriteLine("Premi un tasto per uscire...");
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
        /// <param name="contatoreG">Punteggio del giocatore, incrementato se trova una coppia.</param>
        /// <param name="carte">Matrice contenente le carte.</param>
        /// <param name="carteScoperte">Matrice booleana che indica quali carte sono scoperte.</param>
        /// <param name="immaginiX">Stringa usata per rappresentare le carte coperte.</param>
        static void AiFacile(ref int carta1, ref int carta2, ref int contatoreA, string[,] carte, bool[,] carteScoperte, string immaginiX)
        {
            Random r = new Random();
            int righe = carte.GetLength(0);
            int colonne = carte.GetLength(1);
            int contatoreG = 0;

            while (true)
            {
                int r1, c1, r2, c2;
                do
                {
                    r1 = r.Next(righe);
                    c1 = r.Next(colonne);
                } while (carteScoperte[r1, c1]);

                do
                {
                    r2 = r.Next(righe);
                    c2 = r.Next(colonne);
                } while ((r1 == r2 && c1 == c2) || carteScoperte[r2, c2]);

                carteScoperte[r1, c1] = true;
                carteScoperte[r2, c2] = true;

                Console.Clear();
                Console.WriteLine("Difficoltà : Facile");
                Console.WriteLine("Turno dell'AI:");

                Console.Write($"punteggio giocatore: {contatoreG} | ");
                Console.Write($"punteggio giocatore: {contatoreA}");
                Console.WriteLine(" ");


                StampaGriglia(carte, carteScoperte, immaginiX);

                System.Threading.Thread.Sleep(1000);

                if (carte[r1, c1] == carte[r2, c2])
                {
                    contatoreA++;
                    Console.WriteLine("AI ha trovato una coppia!");
                }
                else
                {
                    Console.WriteLine("AI ha sbagliato.");
                    carteScoperte[r1, c1] = false;
                    carteScoperte[r2, c2] = false;
                }


                Console.WriteLine("premi per un tasto continuare");
                Console.ReadKey();

                Console.Clear();


                Console.Write($"punteggio giocatore: {contatoreG} | ");
                Console.Write($"punteggio giocatore: {contatoreA}");
                Console.WriteLine(" ");


                StampaGriglia(carte, carteScoperte, immaginiX);

                // Verifica fine gioco
                if (TutteScoperte(carteScoperte))
                    break;

                Console.WriteLine("Tocca al giocatore! Inserisci le coordinate delle carte.");


                // tg
                int gr1, gc1, gr2, gc2;
                while (true)
                {
                    gr1 = 0;
                    gc1 = 0;

                    Console.Write("Riga prima carta: ");
                    gr1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Colonna prima carta: ");
                    gc1 = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (!carteScoperte[gr1, gc1]) break;
                    Console.WriteLine("Carta già scoperta. Riprova.");
                }

                carteScoperte[gr1, gc1] = true;
                Console.Clear();
                StampaGriglia(carte, carteScoperte, immaginiX);

                while (true)
                {
                    gr2 = 0;
                    gc2 = 0;
                    Console.Write("Riga seconda carta: ");
                    gr2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Colonna seconda carta: ");
                    gc2 = Convert.ToInt32(Console.ReadLine()) - 1;

                    if ((gr1 != gr2 || gc1 != gc2) && !carteScoperte[gr2, gc2]) break;
                    Console.WriteLine("Carta non valida o già scoperta. Riprova.");
                }

                carteScoperte[gr2, gc2] = true;
                Console.Clear();
                Console.WriteLine("Difficoltà : Facile");
                Console.WriteLine("Turno del giocatore:");
                StampaGriglia(carte, carteScoperte, immaginiX);

                if (carte[gr1, gc1] == carte[gr2, gc2])
                {
                    contatoreG++;
                    Console.WriteLine("Hai trovato una coppia!");
                }
                else
                {
                    Console.WriteLine("Non è una coppia.");
                    carteScoperte[gr1, gc1] = false;
                    carteScoperte[gr2, gc2] = false;
                }

                Console.WriteLine("premi per un tasto continuare");
                Console.ReadKey();

                // Verifica fine gioco
                if (TutteScoperte(carteScoperte))
                    break;
            }

            Console.Clear();
            Console.WriteLine("Partita terminata!");
            Console.WriteLine("");
            Console.Write($"Punteggio AI: {contatoreA} | ");
            Console.WriteLine($"Punteggio Giocatore: {contatoreG}");
            Console.WriteLine(" ");

            if (contatoreA > contatoreG)
                Console.WriteLine("Ha vinto l'AI!");
            else if (contatoreG > contatoreA)
                Console.WriteLine("Hai vinto!");
            else
                Console.WriteLine("Pareggio!");
            Console.WriteLine(" ");
            Console.WriteLine("Premi un tasto per uscire...");
            Console.ReadKey();
        }

        /// <summary>
        /// intelligenza artificiale di livello medio (35 percento, giuste resto sbaliate)
        /// </summary>
        /// <param name="carta1">righe</param>
        /// <param name="carta2">colonne</param>
        /// <param name="contatoreA"> punteggio dell'Ai, incrementato se trova una coppia </param>
        /// <param name="carte"> punteggio del giocatore, incrementato se trova una coppia </param>
        /// <param name="carteScoperte">carte scoperte</param>
        /// <param name="immaginiX">carte coperte</param>
        static void AiMedio(ref int carta1, ref int carta2, ref int contatoreA, string[,] carte, bool[,] carteScoperte, string immaginiX)
        {
            Random r = new Random();
            int righe = carte.GetLength(0);
            int colonne = carte.GetLength(1);
            int contatoreG = 0;

            // Turno dell'AI
            while (true)
            {
                int r1 = -1, c1 = -1, r2 = -1, c2 = -1;

                bool sceltaCorretta = r.Next(100) < 25; // 25% probabilità di scegliere una coppia corretta

                if (sceltaCorretta)
                {
                    // L'IA cerca una coppia corretta NON ancora scoperta
                    bool trovata = false;
                    for (int i1 = 0; i1 < righe && !trovata; i1++)
                    {
                        for (int j1 = 0; j1 < colonne && !trovata; j1++)
                        {
                            if (carteScoperte[i1, j1]) continue;

                            for (int i2 = 0; i2 < righe && !trovata; i2++)
                            {
                                for (int j2 = 0; j2 < colonne && !trovata; j2++)
                                {
                                    if ((i1 == i2 && j1 == j2) || carteScoperte[i2, j2]) continue;

                                    if (carte[i1, j1] == carte[i2, j2])
                                    {
                                        r1 = i1; c1 = j1;
                                        r2 = i2; c2 = j2;
                                        trovata = true;
                                    }
                                }
                            }
                        }
                    }
                }

                // Se non deve scegliere correttamente o non trova una coppia disponibile, sceglie a caso due carte diverse e coperte
                if (r1 == -1 || r2 == -1)
                {
                    do
                    {
                        r1 = r.Next(righe);
                        c1 = r.Next(colonne);
                    } while (carteScoperte[r1, c1]);

                    do
                    {
                        r2 = r.Next(righe);
                        c2 = r.Next(colonne);
                    } while ((r1 == r2 && c1 == c2) || carteScoperte[r2, c2]);
                }

                // Mostra scelta dell'AI
                carteScoperte[r1, c1] = true;
                carteScoperte[r2, c2] = true;

                Console.Clear();
                Console.WriteLine("Difficoltà : Media");
                Console.WriteLine("Turno dell'AI:");
                Console.WriteLine($"Punteggio Giocatore: {contatoreG} | Punteggio AI: {contatoreA}");
                StampaGriglia(carte, carteScoperte, immaginiX);

                Thread.Sleep(1000);

                if (carte[r1, c1] == carte[r2, c2])
                {
                    contatoreA++;
                    Console.WriteLine("AI ha trovato una coppia!");
                }
                else
                {
                    Console.WriteLine("AI ha sbagliato.");
                    carteScoperte[r1, c1] = false;
                    carteScoperte[r2, c2] = false;
                }

                Console.WriteLine("premi per un tasto continuare");
                Console.ReadKey();

                if (TutteScoperte(carteScoperte))
                    break;

                Console.Clear();
                Console.WriteLine($"Punteggio AI: {contatoreA} | Punteggio Giocatore: {contatoreG}");
                StampaGriglia(carte, carteScoperte, immaginiX);

                // TURNO GIOCATORE (come nel tuo codice)
                int gr1, gc1, gr2, gc2;

                while (true)
                {
                    gr1 = 0;
                    gc1 = 0;
                    Console.Write("Riga prima carta: ");
                    gr1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Colonna prima carta: ");
                    gc1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (!carteScoperte[gr1, gc1]) break;
                    Console.WriteLine("Carta già scoperta. Riprova.");
                }

                carteScoperte[gr1, gc1] = true;
                Console.Clear();
                StampaGriglia(carte, carteScoperte, immaginiX);

                while (true)
                {
                    gr2 = 0;
                    gc2 = 0;
                    Console.Write("Riga seconda carta: ");
                    gr2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Colonna seconda carta: ");
                    gc2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    if ((gr1 != gr2 || gc1 != gc2) && !carteScoperte[gr2, gc2]) break;
                    Console.WriteLine("Carta non valida o già scoperta. Riprova.");
                }

                carteScoperte[gr2, gc2] = true;
                Console.Clear();
                Console.WriteLine("Difficoltà : Media");
                Console.WriteLine("Turno del giocatore:");
                StampaGriglia(carte, carteScoperte, immaginiX);

                if (carte[gr1, gc1] == carte[gr2, gc2])
                {
                    contatoreG++;
                    Console.WriteLine("Hai trovato una coppia!");
                }
                else
                {
                    Console.WriteLine("Non è una coppia.");
                    carteScoperte[gr1, gc1] = false;
                    carteScoperte[gr2, gc2] = false;
                }

                Console.WriteLine("premi per un tasto continuare");
                Console.ReadKey();

                if (TutteScoperte(carteScoperte))
                    break;
            }

            Console.Clear();
            Console.WriteLine("Partita terminata!");
            Console.WriteLine("");
            Console.Write($"Punteggio AI: {contatoreA} | ");
            Console.WriteLine($"Punteggio Giocatore: {contatoreG}");
            Console.WriteLine(" ");

            if (contatoreA > contatoreG)
                Console.WriteLine("Ha vinto l'AI!");
            else if (contatoreG > contatoreA)
                Console.WriteLine("Hai vinto!");
            else
                Console.WriteLine("Pareggio!");
            Console.WriteLine(" ");
            Console.WriteLine("Premi un tasto per uscire...");
            Console.ReadKey();
        }

        /// <summary>
        /// intelligenza artificiale di livello Difficile (45 percento, giuste resto sbaliate)
        /// </summary>
        /// <param name="carta1">righe</param>
        /// <param name="carta2">colonne</param>
        /// <param name="contatoreA"> punteggio dell'Ai, incrementato se trova una coppia </param>
        /// <param name="carte"> punteggio del giocatore, incrementato se trova una coppia </param>
        /// <param name="carteScoperte">carte scoperte</param>
        /// <param name="immaginiX">carte coperte</param>
        static void AiDifficile(ref int carta1, ref int carta2, ref int contatoreA, string[,] carte, bool[,] carteScoperte, string immaginiX)
        {
            Random r = new Random();
            int righe = carte.GetLength(0);
            int colonne = carte.GetLength(1);
            int contatoreG = 0;

            // Turno dell'AI
            while (true)
            {
                int r1 = -1, c1 = -1, r2 = -1, c2 = -1;

                bool sceltaCorretta = r.Next(100) < 45; // crea un numero casuale da 0 a 99.

                if (sceltaCorretta)
                {
                    // L'IA cerca una coppia corretta NON ancora scoperta
                    bool trovata = false;

                    for (int i1 = 0; i1 < righe && !trovata; i1++)  // ciclo per le righe
                    {
                        for (int j1 = 0; j1 < colonne && !trovata; j1++) // ciclo per le colonne
                        {
                            if (carteScoperte[i1, j1]) continue; // Se la carta i1,j1 è già scoperta, la salta e passa alla prossima.

                            for (int i2 = 0; i2 < righe && !trovata; i2++) // ciclo per le righe della seconda carta
                            {
                                for (int j2 = 0; j2 < colonne && !trovata; j2++) // ciclo per le colonne della seconda carta
                                {
                                    if ((i1 == i2 && j1 == j2) || carteScoperte[i2, j2]) continue;//Se le due carte trovate sono uguali, allora:

                                    if (carte[i1, j1] == carte[i2, j2])
                                    {
                                        r1 = i1; c1 = j1;//salva le coordinate delle due carte (r1, c1, r2, c2)
                                        r2 = i2; c2 = j2;
                                        trovata = true;//imposta trovata = true per interrompere tutti i cicli esterni, perché ha trovato una coppia.
                                    }
                                }
                            }
                        }
                    }
                }

                // Se non deve scegliere correttamente o non trova una coppia disponibile, sceglie a caso due carte diverse e coperte
                if (r1 == -1 || r2 == -1)
                {
                    do
                    {
                        r1 = r.Next(righe); // sceglie una riga casuale
                        c1 = r.Next(colonne); // sceglie una colonna casuale
                    } while (carteScoperte[r1, c1]);

                    do
                    {
                        r2 = r.Next(righe);
                        c2 = r.Next(colonne);
                    } while ((r1 == r2 && c1 == c2) || carteScoperte[r2, c2]);
                }

                // Mostra scelta dell'AI
                carteScoperte[r1, c1] = true;
                carteScoperte[r2, c2] = true;

                Console.Clear();
                Console.WriteLine("Difficoltà : Impossibile");
                Console.WriteLine("Turno dell'AI:");
                Console.WriteLine($"Punteggio Giocatore: {contatoreG} | Punteggio AI: {contatoreA}");
                StampaGriglia(carte, carteScoperte, immaginiX);

                Thread.Sleep(1000);

                if (carte[r1, c1] == carte[r2, c2])
                {
                    contatoreA++;
                    Console.WriteLine("AI ha trovato una coppia!");
                }
                else
                {
                    Console.WriteLine("AI ha sbagliato.");
                    carteScoperte[r1, c1] = false;
                    carteScoperte[r2, c2] = false;
                }

                Console.WriteLine("premi per un tasto continuare");
                Console.ReadKey();

                if (TutteScoperte(carteScoperte))
                    break;

                Console.Clear();
                Console.WriteLine($"Punteggio AI: {contatoreA} | Punteggio Giocatore: {contatoreG}");
                StampaGriglia(carte, carteScoperte, immaginiX);

                // TURNO GIOCATORE (come nel tuo codice)
                int gr1, gc1, gr2, gc2;

                while (true)
                {
                    gr1 = 0;
                    gc1 = 0;
                    Console.Write("Riga prima carta: ");
                    gr1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Colonna prima carta: ");
                    gc1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (!carteScoperte[gr1, gc1]) break;
                    Console.WriteLine("Carta già scoperta. Riprova.");
                }

                carteScoperte[gr1, gc1] = true;
                Console.Clear();
                StampaGriglia(carte, carteScoperte, immaginiX);

                while (true)
                {
                    gr2 = 0;
                    gc2 = 0;
                    Console.Write("Riga seconda carta: ");
                    gr2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Colonna seconda carta: ");
                    gc2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    if ((gr1 != gr2 || gc1 != gc2) && !carteScoperte[gr2, gc2]) break;
                    Console.WriteLine("Carta non valida o già scoperta. Riprova.");
                }

                carteScoperte[gr2, gc2] = true;
                Console.Clear();
                Console.WriteLine("Difficoltà : Difficile");
                Console.WriteLine("Turno del giocatore:");
                StampaGriglia(carte, carteScoperte, immaginiX);

                if (carte[gr1, gc1] == carte[gr2, gc2])
                {
                    contatoreG++;
                    Console.WriteLine("Hai trovato una coppia!");
                }
                else
                {
                    Console.WriteLine("Non è una coppia.");
                    carteScoperte[gr1, gc1] = false;
                    carteScoperte[gr2, gc2] = false;
                }

                Console.WriteLine("premi per un tasto continuare");
                Console.ReadKey();

                if (TutteScoperte(carteScoperte))
                    break;
            }

            Console.Clear();
            Console.WriteLine("Partita terminata!");
            Console.WriteLine("");
            Console.Write($"Punteggio AI: {contatoreA} | ");
            Console.WriteLine($"Punteggio Giocatore: {contatoreG}");
            Console.WriteLine(" ");

            if (contatoreA > contatoreG)
                Console.WriteLine("Ha vinto l'AI!");
            else if (contatoreG > contatoreA)
                Console.WriteLine("Hai vinto!");
            else
                Console.WriteLine("Pareggio!");
            Console.WriteLine(" ");
            Console.WriteLine("Premi un tasto per uscire...");
            Console.ReadKey();
        }

        /// <summary>
        /// intelligenza artificiale di livello Impossibile (100 percento)
        /// </summary>
        /// <param name="carta1">carta riga</param>
        /// <param name="carta2">carta colonna</param>
        /// <param name="contatoreA">contatore Ai</param>
        /// <param name="carte">carte</param>
        /// <param name="carteScoperte">carte scoperte</param>
        /// <param name="immaginiX">carte di dorso</param>
        static void AiImpossibile(ref int carta1, ref int carta2, ref int contatoreA, string[,] carte, bool[,] carteScoperte, string immaginiX)
        {
            Random r = new Random();
            int righe = carte.GetLength(0);
            int colonne = carte.GetLength(1);
            int contatoreG = 0;

            // Turno dell'AI
            while (true)
            {
                int r1 = -1, c1 = -1, r2 = -1, c2 = -1;

                bool sceltaCorretta = r.Next(100) < 100; // 45% probabilità di scegliere una coppia corretta

                if (sceltaCorretta)
                {
                    // L'IA cerca una coppia corretta NON ancora scoperta
                    bool trovata = false;
                    for (int i1 = 0; i1 < righe && !trovata; i1++)
                    {
                        for (int j1 = 0; j1 < colonne && !trovata; j1++)
                        {
                            if (carteScoperte[i1, j1]) continue;

                            for (int i2 = 0; i2 < righe && !trovata; i2++)
                            {
                                for (int j2 = 0; j2 < colonne && !trovata; j2++)
                                {
                                    if ((i1 == i2 && j1 == j2) || carteScoperte[i2, j2]) continue;

                                    if (carte[i1, j1] == carte[i2, j2])
                                    {
                                        r1 = i1; c1 = j1;
                                        r2 = i2; c2 = j2;
                                        trovata = true;
                                    }
                                }
                            }
                        }
                    }
                }

                // Se non deve scegliere correttamente o non trova una coppia disponibile, sceglie a caso due carte diverse e coperte
                if (r1 == -1 || r2 == -1)
                {
                    do
                    {
                        r1 = r.Next(righe);
                        c1 = r.Next(colonne);
                    } while (carteScoperte[r1, c1]);

                    do
                    {
                        r2 = r.Next(righe);
                        c2 = r.Next(colonne);
                    } while ((r1 == r2 && c1 == c2) || carteScoperte[r2, c2]);
                }

                // Mostra scelta dell'AI
                carteScoperte[r1, c1] = true;
                carteScoperte[r2, c2] = true;

                Console.Clear();
                Console.WriteLine("Difficoltà : Impossibile");
                Console.WriteLine("Turno dell'AI:");
                Console.WriteLine($"Punteggio Giocatore: {contatoreG} | Punteggio AI: {contatoreA}");
                StampaGriglia(carte, carteScoperte, immaginiX);

                Thread.Sleep(1000);

                if (carte[r1, c1] == carte[r2, c2])
                {
                    contatoreA++;
                    Console.WriteLine("AI ha trovato una coppia!");
                }
                else
                {
                    Console.WriteLine("AI ha sbagliato.");
                    carteScoperte[r1, c1] = false;
                    carteScoperte[r2, c2] = false;
                }

                Console.WriteLine("premi per un tasto continuare");
                Console.ReadKey();

                if (TutteScoperte(carteScoperte))
                    break;

                Console.Clear();
                Console.WriteLine($"Punteggio AI: {contatoreA} | Punteggio Giocatore: {contatoreG}");
                StampaGriglia(carte, carteScoperte, immaginiX);

                // TURNO GIOCATORE (come nel tuo codice)
                int gr1, gc1, gr2, gc2;

                while (true)
                {
                    gr1 = 0;
                    gc1 = 0;
                    Console.Write("Riga prima carta: ");
                    gr1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Colonna prima carta: ");
                    gc1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (!carteScoperte[gr1, gc1]) break;
                    Console.WriteLine("Carta già scoperta. Riprova.");
                }

                carteScoperte[gr1, gc1] = true;
                Console.Clear();
                StampaGriglia(carte, carteScoperte, immaginiX);

                while (true)
                {
                    gr2 = 0;
                    gc2 = 0;
                    Console.Write("Riga seconda carta: ");
                    gr2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Colonna seconda carta: ");
                    gc2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    if ((gr1 != gr2 || gc1 != gc2) && !carteScoperte[gr2, gc2]) break;
                    Console.WriteLine("Carta non valida o già scoperta. Riprova.");
                }

                carteScoperte[gr2, gc2] = true;
                Console.Clear();
                Console.WriteLine("Difficoltà : Impossibile");
                Console.WriteLine("Turno del giocatore:");
                StampaGriglia(carte, carteScoperte, immaginiX);

                if (carte[gr1, gc1] == carte[gr2, gc2])
                {
                    contatoreG++;
                    Console.WriteLine("Hai trovato una coppia!");
                }
                else
                {
                    Console.WriteLine("Non è una coppia.");
                    carteScoperte[gr1, gc1] = false;
                    carteScoperte[gr2, gc2] = false;
                }

                Console.WriteLine("premi per un tasto continuare");
                Console.ReadKey();

                if (TutteScoperte(carteScoperte))
                    break;
            }

            Console.Clear();
            Console.WriteLine("Partita terminata!");
            Console.WriteLine("");
            Console.Write($"Punteggio AI: {contatoreA} | ");
            Console.WriteLine($"Punteggio Giocatore: {contatoreG}");
            Console.WriteLine(" ");

            if (contatoreA > contatoreG)
                Console.WriteLine("Ha vinto l'AI!");
            else if (contatoreG > contatoreA)
                Console.WriteLine("Hai vinto!");
            else
                Console.WriteLine("Pareggio!");
            Console.WriteLine(" ");
            Console.WriteLine("Premi un tasto per uscire...");
            Console.ReadKey();
        }

        /// <summary>
        /// Controlla se tutte le carte sono state scoperte.
        /// </summary>
        /// <param name="carteScoperte"></param>
        /// <returns> ritorna vero o falso in base a se sono scoperte o no. </returns>
        static bool TutteScoperte(bool[,] carteScoperte)
        {
            for (int i = 0; i < carteScoperte.GetLength(0); i++)// ripete le rige
            {
                for (int j = 0; j < carteScoperte.GetLength(1); j++) // ripete le colonne
                {
                    if (!carteScoperte[i, j]) // controlla se la carta è coperta
                    {
                        return false; // almeno una carta è ancora coperta
                    }
                }
            }
            return true; // tutte le carte sono scoperte
        }

        /// <summary>
        /// Distribuisce casualmente le coppie di carte nella griglia assicurandosi che ogni carta sia presente due volte
        /// </summary>
        /// <param name="carte">Matrice dove verranno posizionate le carte distribuite</param>
        /// <param name="immagini">Array contenente tutte le immagini disponibili per le carte</param>
        /// <param name="numeroCoppie">Numero di coppie da posizionare</param>
        static void DistribuisciCarte(string[,] carte, string[] immagini, int numeroCoppie)
        {

            int totaleCarte = numeroCoppie * 2;  // Calcola il numero totale di carte (ogni coppia è composta da 2 carte)

            string[] carteDaInserire = new string[totaleCarte]; // Crea un array temporaneo per contenere tutte le carte (con le coppie duplicate)

            for (int i = 0; i < numeroCoppie; i++)  // Inserisce le immagini nel vettore, creando le coppie
            {
                carteDaInserire[2 * i] = immagini[i];// Inserisce la prima carta della coppia
                carteDaInserire[2 * i + 1] = immagini[i];  // Inserisce la seconda carta della coppia
            }

            Random rand = new Random(); // Crea un oggetto Random per mescolare le carte
            for (int i = 0; i < totaleCarte; i++) // Mescola le carte nell'array usando l'algoritmo di Fisher-Yates
            {
                int j = rand.Next(i, totaleCarte); // Estrae un indice casuale da i a totaleCarte - 1
                (carteDaInserire[i], carteDaInserire[j]) = (carteDaInserire[j], carteDaInserire[i]);  // Scambia le carte nelle posizioni i e j
            }
            int k = 0;// Indice per scorrere le carte da inserire nella matrice


            for (int r = 0; r < carte.GetLength(0); r++) // Scorre le righe della matrice
            {

                for (int c = 0; c < carte.GetLength(1); c++) // Scorre le colonne della riga corrente
                {
                    // Inserisce una carta nella posizione [r, c] della matrice
                    carte[r, c] = carteDaInserire[k++];// Usa e incrementa k
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
            for (int i = 0; i < carte.GetLength(0); i++) // ripete le righe della matrice carte
            {
                for (int j = 0; j < carte.GetLength(1); j++) // ripete le colonne della matrice carte
                {
                    if (carteScoperte[i, j])
                    {
                        Console.Write(carte[i, j] + " ");
                        // stampa valore carta scoperta con uno spazio
                    }
                    else
                    {
                        Console.Write(immaginiX + " ");   // stampa simbolo carta coperta con uno spazio

                    }
                }

                Console.WriteLine(); // va a capo dopo ogni riga
                Console.WriteLine();
            }
        }

        /// <summary>
        /// funzione per stampare il menu di gioco iniziale.
        /// </summary>
        static void MenuGame()
        {
            Console.WriteLine(@"

     __  __ ______ __  __  ____  _____  __     __
    |  \/  |  ____|  \/  |/ __ \|  __ \ \ \   / /
    | \  / | |__  | \  / | |  | | |__) | \ \_/ /
    | |\/| |  __| | |\/| | |  | |  _  /   \   /  
    | |  | | |____| |  | | |__| | | \ \    | |  
    |_|  |_|______|_|  |_|\____/|_|  \_\   |_|  

    ┌────────┐ ┌────────┐ ┌────────┐ ┌────────┐
    │♠       │ │♥       │ │♦       │ │♣       │
    │        │ │        │ │        │ │        │
    │    A   │ │    A   │ │    A   │ │    A   │
    │        │ │        │ │        │ │        │
    │       ♠│ │       ♥│ │       ♦│ │       ♣│
    └────────┘ └────────┘ └────────┘ └────────┘


    ");
        }
    }
}