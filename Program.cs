using System;
using System.Globalization;

namespace _13._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string input = "";

            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] commands = input.Split(">>>");
                string currentCommand = commands[0];

                if (currentCommand == "Contains")
                {
                    string substring = commands[1];

                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (currentCommand == "Flip")
                {
                    string upperOrLower = commands[1];
                    int startIndex = int.Parse(commands[2]);
                    int endIndex = int.Parse(commands[3]);
                    int length = endIndex - startIndex;

                    if (upperOrLower == "Upper")
                    {
                        string oldSubstring = activationKey.Substring(startIndex, length);
                        string newSubstring = activationKey.Substring(startIndex, length).ToUpper();

                        activationKey = activationKey.Replace(oldSubstring, newSubstring);
                    }
                    else
                    {
                        string oldSubstring = activationKey.Substring(startIndex, length);
                        string newSubstring = activationKey.Substring(startIndex, length).ToLower();

                        activationKey = activationKey.Replace(oldSubstring, newSubstring);
                    }

                    Console.WriteLine(activationKey);
                }
                else
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    int length = endIndex - startIndex;

                    activationKey = activationKey.Remove(startIndex, length);

                    Console.WriteLine(activationKey);
                }
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
