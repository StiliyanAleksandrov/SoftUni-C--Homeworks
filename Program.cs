using System;
using System.Collections.Generic;
using System.Linq;

namespace _15._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cities = new Dictionary<string, List<int>>();

            string text = "";

            while ((text = Console.ReadLine()) != "Sail")
            {
                string[] inputData = text.Split("||");

                string city = inputData[0];
                int population = int.Parse(inputData[1]);
                int gold = int.Parse(inputData[2]);

                if (!cities.ContainsKey(city))
                {
                    cities[city] = new List<int>{ 0, 0};
                }
                cities[city][0] += population;
                cities[city][1] += gold;
            }

            while ((text = Console.ReadLine()) != "End")
            {
                string[] events = text.Split("=>");

                string occurrence = events[0];
                string city = events[1];

                if (occurrence == "Plunder")
                {
                    int population = int.Parse(events[2]);
                    int gold = int.Parse(events[3]);

                    cities[city][0] -= population;
                    cities[city][1] -= gold;

                    Console.WriteLine($"{city} plundered! {gold} gold stolen, {population} citizens killed.");

                    if (cities[city][0] == 0 || cities[city][1] == 0)
                    {
                        cities.Remove(city);
                        Console.WriteLine($"{city} has been wiped off the map!");
                    }
                }
                else
                {
                    int gold = int.Parse(events[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[city][1] += gold;

                        Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {cities[city][1]} gold.");
                    }
                }
            }

            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var city in cities.OrderByDescending(gold => gold.Value[1]).ThenBy(n => n.Key))
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
                }
            }
        }
    }
}
