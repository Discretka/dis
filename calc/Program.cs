﻿using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string infixNotation = Console.ReadLine();

            Stack<Actions> actions;

            Stack<string> operands;

            try
            {
                string reverseNotation =
                    new StringParser().GetReverseNotation(infixNotation, out actions, out operands);

                Console.WriteLine($"Reverse notation: {reverseNotation}");

                double result = new Calculator().Calculate(actions, operands, reverseNotation);

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}