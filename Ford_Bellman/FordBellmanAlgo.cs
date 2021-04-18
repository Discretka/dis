using System;
using System.Collections.Generic;

namespace FordBellman
{
    public class FordBellmanAlgo
    {
        public (List<string>, List<double>) GetPath(string pathToFile, string startCity, string endCity)
        {
            var fileHandler = new FileHandler();

            var flightInfo = fileHandler.FlightsInformation(pathToFile);

            var converter = new Converter();

            var cities = converter.ConvertToAdjacencyMatrix(flightInfo);

            var (startIndex, endIndex) = GetStartAndEndCityIndex(startCity, endCity, cities);

            var path = GetPath(cities, startIndex);

            return GetCityAndCoast(cities, endIndex, path, startIndex);
        }

        private (int, int) GetStartAndEndCityIndex(string startCity, string endCity, City[] cities)
        {
            var startIndex = -1;

            var endIndex = -1;

            foreach (var city in cities)
            {
                if (city.Name == startCity)
                {
                    startIndex = city.Id;
                }

                if (city.Name == endCity)
                {
                    endIndex = city.Id;
                }
            }

            return (startIndex, endIndex);
        }

        private int[] GetPath(City[] cities, int startIndex)
        {
            var n = cities.Length;

            var d = new double[n];

            var path = new int[n];

            const double inf = double.MaxValue;

            for (var i = 0; i < n; i++)
            {
                d[i] = inf;

                path[i] = -1;
            }

            d[startIndex] = 0;

            for (var i = 0; i < n - 1; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (d[j] < inf)
                    {
                        for (var q = 0; q < n; q++)
                        {
                            if (cities[j].Edges[q] < double.MaxValue)
                            {
                                if (d[q] > d[j] + cities[j].Edges[q])
                                {
                                    d[q] = d[j] + cities[j].Edges[q];

                                    path[q] = j;
                                }
                            }
                        }
                    }
                }
            }

            return path;
        }

        private (List<string>, List<double>) GetCityAndCoast(City[] cities, int endIndex, int[] path, int startIndex)
        {
            if (path[endIndex] == -1 && startIndex != endIndex)
            {
                throw new Exception("There is no way");
            }

            var citiesName = new List<string>();

            var coasts = new List<double>();

            var curCity = endIndex;

            while (path[curCity] != -1)
            {
                citiesName.Add(cities[curCity].Name);

                var coast = cities[path[curCity]].Edges[curCity];

                coasts.Add(coast);

                curCity = path[curCity];
            }

            return (citiesName, coasts);
        }
    }
}