namespace Pinatas;

using System;
using System.Collections.Generic;

public static class Pinatas
{
    static int GetMaxCandies(int left, int right, List<int> arr)
    {
        if (left > right) return 0;

        int Candies = 0;

        for (int i = left; i <= right; i++)
        {
            int Candy = arr[left - 1] * arr[i] * arr[right + 1];

            int leftPinata = GetMaxCandies(left, i - 1, arr);
            int rightPinata = GetMaxCandies(i + 1, right, arr);

            Candies = Math.Max(Candies, Candy + leftPinata + rightPinata);
        }

        return Candies;
    }

    static int Candies(List<int> arr)
    {

        int n = arr.Count;
        arr.Insert(0, 1);
        arr.Add(1);

        return GetMaxCandies(1, n, arr);
    }

    static int AmountOfPinatas()
    {
        int Pinatas = 0;

        do
        {
            Console.WriteLine("Enter the amount of pinatas (>=1): ");

            if (int.TryParse(Console.ReadLine(), out Pinatas))
            {
                if (Pinatas >= 1)
                {
                    return Pinatas;
                }
		else
		{
                   Console.WriteLine("You must enter a number 1 or greater. Try again.");
		}
            }
            else
            {
                Console.WriteLine("Invalid input format. Please enter an integer.");
            }
        } while (true);
    }

    private static List<int> ArraysOfNums(int Pinatas)
    {
        List<int> NumPinata;

        do
        {
            Console.WriteLine($"\nEnter {Pinatas} numbers, separated by spaces or tabs:");
            string? input = Console.ReadLine();

            try
            {
                if (input is null)
                {
                    throw new Exception("input is null");
                }
                
                NumPinata = input
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                if (NumPinata.Count != Pinatas)
                {
                    Console.WriteLine($"You must enter exactly {Pinatas} numbers. Try again.");
                    continue;
                }

                return NumPinata;
            }
            catch (FormatException)
            {
                Console.WriteLine("Coordinates must be integers. Try again.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"One or more numbers are too large/small for the integer type.");
            }
            catch (Exception)
            {
                Console.WriteLine("An unknown error occurred while reading the coordinates. Try again.");
            }
        } while (true);
    }


    static void Main()
    {
        int Pinatas = AmountOfPinatas();
        Console.WriteLine($"Amount of Pinatas: {Pinatas}");

        List<int> NumPinata = ArraysOfNums((Pinatas));
        Console.WriteLine($"Entered numbers for Pinatas: {string.Join(", ", NumPinata)}");
        Console.WriteLine($"Max amount of candies: {Candies(NumPinata)}");
    }
}
