using System;
using System.Collections.Generic;

namespace HuffmanCode
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var algo = new AlgorithmHuffman();
                Console.WriteLine("\t\tHuffman's algorithm\n");
                Console.Write("enter the message which you want to encode: ");

                var text = Console.ReadLine();
                var codeTree = algo.GetHuffmanTree(text);
                var symbols = codeTree.GetAllSymbol();
                var sum = GetSum(symbols);
                var sourceSize = text.Length * 8;
                var compressionRatio = sum / (double) sourceSize * 100;

                Console.WriteLine("\n\n\\symbol//\t\\amount//\t\\coding//\t");

                for (var i = 0; i < symbols.Count; i++)
                {
                    Console.WriteLine($"  {symbols[i].Item1}\t\t  {symbols[i].Item3}\t\t  {symbols[i].Item2}");
                }

                Console.WriteLine($"amount of source message's memory: = {sourceSize}");
                Console.WriteLine($"amount of encoded massage's memory = {sum}");
                Console.WriteLine($"compression ratio = {compressionRatio}%");

                var code = GetCode(text, symbols);

                Console.WriteLine($"resultingencoded text: {code}");

                Console.WriteLine("\nenter encoded text:");

                var codeText = Console.ReadLine();

                var sourceText = GetText(codeText, symbols);

                Console.WriteLine($"decoded source message: {sourceText}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static string GetText(string codeText, List<(string, string, int)> symbols)
        {
            var code = "";

            var text = "";

            for (var i = 0; i < codeText.Length; i++)
            {
                code += codeText[i];

                var symbol = GetSymbol(symbols, code);

                if (symbol != null)
                {
                    text += symbol;
                    code = "";
                }
            }

            return text;
        }

        static int GetSum(List<(string, string, int)> symbols)
        {
            var sum = 0;

            foreach (var symbol in symbols)
            {
                sum += (symbol.Item3 * symbol.Item2.Length);
            }

            return sum;
        }

        static string GetCode(string text, List<(string, string, int)> symbols)
        {
            var code = "";

            for (var i = 0; i < text.Length; i++)
            {
                var symbolCode = GetSymbolCode(text[i], symbols);

                code += symbolCode;
            }

            return code;
        }

        static string GetSymbol(List<(string, string, int)> symbols, string code)
        {
            for (var i = 0; i < symbols.Count; i++)
            {
                if (code == symbols[i].Item2)
                {
                    return symbols[i].Item1;
                }
            }

            return null;
        }

        static string GetSymbolCode(char symbol, List<(string, string, int)> symbols)
        {
            for (var i = 0; i < symbols.Count; i++)
            {
                if (symbols[i].Item1 == symbol.ToString())
                {
                    return symbols[i].Item2;
                }
            }

            throw new Exception("symbol not found");
        }
    }
}