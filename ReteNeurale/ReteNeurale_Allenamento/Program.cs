using System;
using System.IO;
using System.Globalization;

namespace EsercizioPercettroneConcerto
{
    class Program
    {
        // Numero di caratteristiche (i 500 pesi che hai nel file)
        const int FEATURES = 500;
        const float THRESHOLD = 0.5f;

        static void Main(string[] args)
        {
            Console.WriteLine("=== ESERCIZIO: PERCETTRONE CONCERTO (500 PESI) ===\n");

            float[] weights = new float[FEATURES];
            float bias = 0;

            // 1. LETTURA DEI 500 PESI DAL FILE
            string fileName = @"C:\Users\giulia.cocka\Desktop\ReteNeurale\ReteNeurale\dataset_concerto_500.txt"; // Assicurati che il file sia nella cartella dell'eseguibile

            if (File.Exists(fileName))
            {
                try
                {
                    string[] linee = File.ReadAllLines(fileName);

                    // Carichiamo i 500 pesi
                    for (int i = 0; i < FEATURES; i++)
                    {
                        // Estrae il valore dopo i due punti "Peso X: valore"
                        string val = linee[i].Split(':')[1].Trim();
                        weights[i] = float.Parse(val, CultureInfo.InvariantCulture);
                    }

                    // Carichiamo il Bias (ultima riga del file)
                    string biasVal = linee[FEATURES].Split(':')[1].Trim();
                    bias = float.Parse(biasVal, CultureInfo.InvariantCulture);

                    Console.WriteLine("File caricato con successo!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore durante la lettura del file: {ex.Message}");
                    return;
                }
            }
            else
            {
                Console.WriteLine($"Errore: Il file {fileName} non esiste!");
                return;
            }

            // 2. INPUT DATI
            // Dato che inserire 500 valori a mano è impossibile, 
            // chiediamo solo i primi 5 (Artista, Meteo, Amici, Cibo, Alcool)
            // e impostiamo gli altri 495 a 0 (o casuali).

            int[] input = new int[FEATURES];
            Console.WriteLine("\nInserisci i dati per i criteri principali (1=Si, 0=No):");

            Console.Write("L'artista è bravo? "); input[0] = int.Parse(Console.ReadLine());
            Console.Write("Il meteo è bello? "); input[1] = int.Parse(Console.ReadLine());
            Console.Write("Vengono gli amici? "); input[2] = int.Parse(Console.ReadLine());
            Console.Write("C'è cibo? "); input[3] = int.Parse(Console.ReadLine());
            Console.Write("C'è alcool? "); input[4] = int.Parse(Console.ReadLine());
            Console.Write("SEI STANCA? "); input[5] = int.Parse(Console.ReadLine());

            // Gli altri input (dal 6 al 499) li lasciamo a 0 per semplicità
            for (int i = 6; i < FEATURES; i++) { input[i] = 0; }

            // 3. CALCOLO DELLA PREVISIONE
            float sum = bias;
            for (int j = 0; j < FEATURES; j++)
            {
                sum += weights[j] * input[j];
            }

            // Funzione di attivazione
            int output = (sum > THRESHOLD) ? 1 : 0;

            // 4. RISULTATO FINALE
            Console.WriteLine("\n--- ANALISI COMPLETATA ---");
            Console.WriteLine($"Somma pesata finale (z): {sum:F6}");

            if (output == 1)
            {
                Console.WriteLine("RISULTATO: Il Percettrone dice... VAI AL CONCERTO!");
            }
            else
            {
                Console.WriteLine("RISULTATO: Il Percettrone dice... RESTA A CASA.");
            }

            Console.WriteLine("\nPremi un tasto per chiudere...");
            Console.ReadKey();
        }
    }
}