using System.Collections.Generic;

namespace FordBellman
{
    public class Converter
    {
        public City[] ConvertToAdjacencyMatrix(List<(string, string, string, string)> flightsInfo)
        {
            var tree = GetTree(flightsInfo);

            var cities = GetCities(flightsInfo, tree);

            Sort(cities, 0, cities.Length - 1);

            return cities;
        }

        private AVLTree<string, City> GetTree(List<(string, string, string, string)> flightsInfo)
        {
            var comparer = new StrComparer();

            var tree = new AVLTree<string, City>(comparer);

            foreach (var flightInfo in flightsInfo)
            {
                AddCity(flightInfo.Item1, tree);

                AddCity(flightInfo.Item2, tree);
            }

            return tree;
        }

        private void AddCity(string cityName, AVLTree<string, City> tree)
        {
            try
            {
                tree.Find(cityName);
            }
            catch
            {
                var city = new City
                {
                    Name = cityName,
                    Id = tree.Count
                };

                tree.Insert(city.Name, city);
            }
        }

        private City[] GetCities(List<(string, string, string, string)> flightsInfo, AVLTree<string, City> tree)
        {
            var cities = tree.GetItems();

            var inf = double.MaxValue;

            foreach (var city in cities)
            {
                city.Edges = new double[tree.Count];

                for (var i = 0; i < tree.Count; i++)
                {
                    city.Edges[i] = inf;
                }
            }

            foreach (var flightInfo in flightsInfo)
            {
                var city1 = tree.Find(flightInfo.Item1);

                var city2 = tree.Find(flightInfo.Item2);

                AddEdge(flightInfo.Item3, city2, city1);

                AddEdge(flightInfo.Item4, city1, city2);
            }

            return cities;
        }

        private void AddEdge(string weight, City cityTo, City cityFrom)
        {
            if (weight == "N/A")
            {
                cityFrom.Edges[cityTo.Id] = double.MaxValue;

                return;
            }

            cityFrom.Edges[cityTo.Id] = double.Parse(weight);
        }

        private int Partition(City[] cities, int start, int end)
        {
            City temp;

            var marker = start;

            for (var i = start; i < end; i++)
            {
                if (cities[i].Id < cities[end].Id)
                {
                    temp = cities[marker];
                    cities[marker] = cities[i];
                    cities[i] = temp;
                    marker++;
                }
            }

            temp = cities[marker];
            cities[marker] = cities[end];
            cities[end] = temp;
            return marker;
        }

        private void Sort(City[] cities, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = Partition(cities, start, end);
            Sort(cities, start, pivot - 1);
            Sort(cities, pivot + 1, end);
        }
    }
}