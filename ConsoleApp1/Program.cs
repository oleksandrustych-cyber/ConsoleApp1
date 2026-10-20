using System;
using System.Text;

namespace Lab04
{
    internal class Program
    {
        private static bool TryParseSide(string input, out decimal value)
        {
            var parsed = decimal.TryParse(input, out value);
            return parsed && value > 0;
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Визначення типу трикутника");
            Console.Write("Сторона a: ");
            var aInput = Console.ReadLine();
            Console.Write("Сторона b: ");
            string bInput;
            bInput = Console.ReadLine();
            Console.Write("Сторона c: ");
            var cInput = Console.ReadLine();
            if (!TryParseSide(aInput, out decimal a) ||
                !TryParseSide(bInput, out decimal b) ||
                !TryParseSide(cInput, out decimal c))
            {
                Console.WriteLine("Помилка: кожна сторона має бути додатним числом.");
            }
            
            else if (a + b <= c || a + c <= b || b + c <= a)
            {
                Console.WriteLine("Такого трикутника не існує.");
            }
            else
            {
                string sidesType;
                if (a == b && b == c)
                {
                    sidesType = "рівносторонній";
                }
                else if (a == b || a == c || b == c)
                {
                    sidesType = "рівнобедрений";
                }
                else
                {
                    sidesType = "різносторонній";
                }

                // 4. Прямокутність: гіпотенузою може бути будь-яка сторона
                bool isRight = a * a + b * b == c * c ||
                               a * a + c * c == b * b ||
                               b * b + c * c == a * a;

                // 5. Периметр і площа (формула Герона)
                var perimeter = a + b + c;
                var p = perimeter / 2;
                var area = Math.Sqrt((double)(p * (p - a) * (p - b) * (p - c)));

                Console.WriteLine($"Тип за сторонами: {sidesType}");
                Console.WriteLine($"Прямокутний: {(isRight ? "так" : "ні")}");
                Console.WriteLine($"Периметр: {perimeter:F2}");
                Console.WriteLine($"Площа: {area:F2}");
                var category = area switch
                {
                    < 10 => "малий трикутник",
                    >= 10 and < 100 when isRight => "середній прямокутний трикутник",
                    >= 10 and < 100 => "середній трикутник",
                    _ => "великий трикутник"
                };

                Console.WriteLine($"Категорія за площею: {category}");
            }
        }
    }
}