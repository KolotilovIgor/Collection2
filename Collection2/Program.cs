using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите положительное целое число:");
        int targetSum;
        while (!int.TryParse(Console.ReadLine(), out targetSum) || targetSum <= 0)
        {
            Console.WriteLine("Не верный ввод! Введите положительное целое число:");
        }

        Random rand = new Random();
        int[] numbers = Enumerable.Range(1, 10).Select(i => rand.Next(1, 10)).ToArray();

        Console.WriteLine("Сгенерированный массив:");
        Console.WriteLine(string.Join(", ", numbers));

        if (!FindTripletsWithSum(numbers, targetSum))
        {
            Console.WriteLine("Тройка чисел с заданной суммой не найдена.");
        }
    }

    static bool FindTripletsWithSum(int[] numbers, int targetSum)
    {
        Array.Sort(numbers);
        bool found = false;

        for (int i = 0; i < numbers.Length - 2; i++)
        {
            int left = i + 1;
            int right = numbers.Length - 1;
            int currentNumber = numbers[i];

            while (left < right)
            {
                int currentSum = currentNumber + numbers[left] + numbers[right];

                if (currentSum == targetSum)
                {
                    Console.WriteLine($"Тройка чисел: {currentNumber}, {numbers[left]}, {numbers[right]}");
                    found = true;
                    left++;
                    right--;
                }
                else if (currentSum < targetSum)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }
        return found;
    }
}
