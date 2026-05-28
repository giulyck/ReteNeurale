using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("=== ESERCIZIO 1: DECISIONE CONCERTO ===");

        // Definiamo i pesi basati sui tuoi appunti
        float[] weights = { 0.7f, 0.6f, 0.5f, 0.3f, 0.4f };
        float bias = 0.0f;
        float threshold = 0.5f;

        string[] domande = {
            "L'artista è bravo?",
            "Il meteo è favorevole?",
            "Un amico viene?",
            "Viene servito cibo?",
            "Viene servito alcol?"
        };

        int[] inputUtente = new int[5];

        // Chiediamo i dati all'utente
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"{domande[i]} (1=Si, 0=No): ");
            inputUtente[i] = int.Parse(Console.ReadLine());
        }

        // Calcolo della somma 
        float z = bias;
        for (int i = 0; i < 5; i++)
        {
            z += inputUtente[i] * weights[i];
        }

        Console.WriteLine($"\nValore calcolato (z): {z}");
    
        if (z > threshold)
            Console.WriteLine("RISULTATO: Vai al concerto!");
        else
            Console.WriteLine("RISULTATO: Resta a casa!");

        Console.ReadKey();
    }
}