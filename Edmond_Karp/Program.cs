using System;

namespace EdmondKarp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter path to file: ");
            var pathToFile = Console.ReadLine();
            try
            {
                var fileManager = new FileManager();
                var avlTree = fileManager.GetAVL(pathToFile);
                var startCity = "S";
                var endCity = "T";
                var edmondKarp = new EdmondKarp();
                var maxFlow = edmondKarp.GetMaxFlow(avlTree, startCity, endCity);

                Console.WriteLine($"maximum network flow: {maxFlow}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}