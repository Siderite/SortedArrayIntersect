using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntersectSortedArrays
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var rnd = new Random();
            while (true)
            {
                var generator = new RandomGenerator(rnd.Next(0,1000000), rnd.Next(0, 1000000));
                generator.Spikes = rnd.Next(0,100);
                generator.Generate();

                Console.Clear();
                Console.WriteLine("Press any key to try another example, or Q to quit");
                Console.WriteLine($"m:{generator.Array1.Count} n:{generator.Array2.Count} spikes:{generator.Spikes}");

                var counter = new Counter();

                IIntersecter intersecter = new StandardIntersecter(counter.Reset());
                displayIntersect(intersecter, generator, "Standard search");
                var count = intersecter.Result.Count;
                var comparisons = intersecter.Comparisons;

                displayIntersect(new BinarySearchIntersecter(counter.Reset()), generator, "Binary search", count, comparisons);
                displayIntersect(new MiddleOutIntersecter(counter.Reset()), generator, "Middle out", count, comparisons);
                displayIntersect(new AcceleratingIntersecter(counter.Reset()), generator, "Accelerating", count, comparisons);
                displayIntersect(new DivideEtImperaIntersecter(counter.Reset()), generator, "Divide at impera", count, comparisons);
                displayIntersect(new PairSearchIntersecter(counter.Reset()), generator, "Pair search", count, comparisons);
                displayIntersect(new SmartChoiceIntersecter(counter.Reset()), generator, "Smart choice", count, comparisons);

                if (Console.ReadKey().Key == ConsoleKey.Q) break;
            }
        }

        private static void displayIntersect(IIntersecter intersecter, IGenerator generator, string text, int? count=null, int? comparisons=null)
        {
            intersecter.Intersect(generator.Array1, generator.Array2);

            Console.WriteLine($"{text} intersecter:");
            colorWrite($"Comparisons: {intersecter.Comparisons}", () =>
            {
                if (comparisons == null) return ConsoleColor.White;
                switch (intersecter.Comparisons.CompareTo(comparisons.Value))
                {
                    case -1:
                        return ConsoleColor.Green;
                    default:
                    case 0:
                        return ConsoleColor.White;
                    case 1:
                        return ConsoleColor.Red;
                }
            });
            if (comparisons == null)
            {
                Console.WriteLine();
            }
            else
            {
                var perc = 100 * (double)intersecter.Comparisons / comparisons.Value;
                Console.WriteLine($" ({perc:#.00}%)");
            }
            //Console.WriteLine($"Time: {intersecter.Time.TotalMilliseconds}");
            colorWrite($"Count: {intersecter.Result.Count}\r\n", () => count == null || intersecter.Result.Count == count ? ConsoleColor.White : ConsoleColor.Red);
        }

        private static void colorWrite(string text, Func<ConsoleColor> func)
        {
            var color = func();
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
