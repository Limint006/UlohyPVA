using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a sequence of numbers separated by a space:");
        string input = Console.ReadLine();

        if (!IsValidInput(input))
        {
            Console.WriteLine("Invalid input. Please enter numbers separated by space.");
            Console.ReadKey();
            return;
        }

        int[] numbers = input.Split(' ').Select(int.Parse).ToArray();

        int count = 0;

        Console.Clear();

        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                int sum1 = 0;
                for (int k = i; k <= j; k++)
                {
                    sum1 += numbers[k];
                }

                for (int m = i + 1; m < numbers.Length; m++)
                {
                    for (int n = m + 1; n < numbers.Length; n++)
                    {
                        int sum2 = 0;
                        for (int k = m; k <= n; k++)
                        {
                            sum2 += numbers[k];
                        }

                        if (sum1 == sum2)
                        {
                            count++;
                        }
                    }
                }
            }
        }

        Console.WriteLine($"The number of pairs of mutually different intervals with the same sum: {count}");
        Console.ReadKey();
    }

    static bool IsValidInput(string input)
    {
        return Regex.IsMatch(input, @"^\d+(\s+\d+)*$");
    }
}