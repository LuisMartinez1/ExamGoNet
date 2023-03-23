using System;

namespace Fibonacci
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingresa un número entero: ");
            string input = Console.ReadLine();

            int n;
            if (!int.TryParse(input, out n))
            {
                Console.WriteLine("El valor ingresado no es un número entero válido.");
                return;
            }
            int result = Fibonacci(n);
            Console.WriteLine("Fib({0}) = {1}", n, result);
        }

        static int Fibonacci(int n)
        {
            int[] memo = new int[n + 1];
            return Fibonacci(n, memo);
        }

        static int Fibonacci(int n, int[] memo)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            if (memo[n] == 0)
            {
                memo[n] = Fibonacci(n - 1, memo) + Fibonacci(n - 2, memo);
            }

            return memo[n];
        }
    }
}
