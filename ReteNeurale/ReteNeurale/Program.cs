using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ReteNeurale
{
    internal class Program
    {
        public const int FEATURES = 5;
        public const float THRESHOLD = 0.5f;
        // Funzione di attivazione (step)
        static int Activation(float x)
        {
            if (x > THRESHOLD) return 1;
            else return 0;
        }
        static bool CaricaPesi(string filename, float[] weights, out float bias)
        {
            bias = 0;
            if (!File.Exists(filename))
            {
                Console.WriteLine($"Errore:file {filename} non trovato!");
                return false;
            }


            string[] righe = File.ReadAllLines(filename);

            try
            {
                for(int i = 0; i < FEATURES; i++)
                {
                    string[] parti = righe[i].Split(':');
                    weights[i] = float.Parse(parti[1].Trim());
                }

                string[] biasParti = righe[FEATURES].Split(':');
                bias = float.Parse(biasParti[1].Trim());
            }
            catch
            {
                Console.WriteLine("Errore nella lettura del file");
                return false;
            }            
            return true;
        }

        static int Prevendi(float[] weights, float bias, int[] input)
        {
            float somma = bias;
            for(int i = 0; i < FEATURES; i++)
            {
                somma += input[i] * weights[i];
            }
            return Activation(somma);
        }
        static void Main(string[] args)
        {
            float[] weights = new float[FEATURES];
            float bias;

            if(!CaricaPesi(@"C:\Users\giulia.cocka\Desktop\ReteNeurale\ReteNeurale\pesi_concerto.txt", weights, out bias))
            {
                return;
            }
            Console.WriteLine("Inserisci i dati");

            int[] input = new int[FEATURES];

            Console.WriteLine("Artista famoso? (1 = Si, 0 = No) : ");
            input[0] = int.Parse(Console.ReadLine());
            Console.WriteLine("Bel Meteo (1 = Si, 0 = No) : ");
            input[1] = int.Parse(Console.ReadLine());
            Console.WriteLine("Amici presenti? (1 = Si, 0 = No) : ");
            input[2] = int.Parse(Console.ReadLine());
            Console.WriteLine("Cibo buono? (1 = Si, 0 = No) : ");
            input[3] = int.Parse(Console.ReadLine());
            Console.WriteLine("Alcool Disponibile? (1 = Si, 0 = No) : ");
            input[4] = int.Parse(Console.ReadLine());

            int decisione = Prevendi(weights, bias, input);
            if(decisione == 1)
            {
                Console.WriteLine("\nVai al concerto");
                
            }
            else
            {
                Console.WriteLine("\nResta a casa");
            }
        }
    }
}