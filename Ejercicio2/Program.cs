using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var depositos = new List<Deposito>()
            {
                new Deposito("Ana", 50),
                new Deposito("Paco", 10),
                new Deposito("Ana", 20),
                new Deposito("Jorge", 55),
                new Deposito("Laura", 75),
                new Deposito("Laura", 3),
                new Deposito("Laura", 50),
            };

            var grupos = from d in depositos
                         group d by d.Titular into g
                         where g.Count() > 1 && g.Average(d => d.Monto) > 50
                         select new
                         {
                             Titular = g.Key,
                             Minimo = g.Min(d => d.Monto),
                             Maximo = g.Max(d => d.Monto),
                             Cantidad = g.Count(),
                             Promedio = g.Average(d => d.Monto),
                         };

            foreach (var grupo in grupos)
            {
                Console.WriteLine($"Titular: {grupo.Titular}");
                Console.WriteLine($"Monto mínimo: {grupo.Minimo}");
                Console.WriteLine($"Monto máximo: {grupo.Maximo}");
                Console.WriteLine($"Cantidad de depósitos: {grupo.Cantidad}");
                Console.WriteLine($"Promedio de depósitos: {grupo.Promedio}");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

    class Deposito
    {
        public string Titular { get; set; }
        public decimal Monto { get; set; }

        public Deposito(string titular, decimal monto)
        {
            Titular = titular;
            Monto = monto;
        }
    }
}
