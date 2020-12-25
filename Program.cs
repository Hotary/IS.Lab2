using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static GeneticAlgorithm GA = new GeneticAlgorithm();

        static void Main(string[] args)
        {
            //Задаем функцию
            GA.Func = (x) => { return x * x + 4; };
            //Инициализируем Генетический Алгоритм
            GA.Init();
            //Работа генетического алгоритма
            var result = GA.Work();
            //Вывод результата
            Console.WriteLine("Iteration: {0}", GA.Step);
            Console.WriteLine("Result: x = {0}; y = {1}.", result.X, result.Y);
            Console.ReadLine();
            Console.ReadLine();
        }
    }


}
