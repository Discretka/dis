using System;

namespace FordBellman
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var fordBellmanAlgo = new FordBellmanAlgo();

                Console.Write("Enter path to file: ");

                var pathToFile = Console.ReadLine();

                Console.Write("From the city: ");

                var start = Console.ReadLine();

                Console.Write("To the city: ");

                var finish = Console.ReadLine();

                var (citiesName, coastFlight) = fordBellmanAlgo.GetPath(pathToFile, start, finish);

                var curCity = (string) start;

                double coastPath = 0;

                for (var i = citiesName.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine($"From {curCity} to {citiesName[i]}: {coastFlight[i]}");

                    coastPath += coastFlight[i];

                    curCity = citiesName[i];
                }

                Console.WriteLine($"Total cost: {coastPath}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}