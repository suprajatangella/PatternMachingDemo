using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PatternMachingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PatternMaching();
            PatternMachingType();
        }

        public static void PatternMaching()
        {
            Object data = new Person { Name = "John", Age = 17 };

            if (data is Person { Age: >= 18 } person)
            {
                Console.WriteLine($"{person.Name} is an adult.");
            }
            else
            {
                Console.WriteLine("The person is either a minor or not a person.");
            }
            Console.ReadLine();
        }

        // Method to parse the input into different types
        static object ParseInput(string input)
        {
            if (int.TryParse(input, out int intResult))
                return intResult;
            if(double.TryParse(input, out double doubleResult))
                return doubleResult;
            return input;
        }

        public static void PatternMachingType()
        {
            Console.WriteLine("Please enter number or string");
            string input = Console.ReadLine();
            object result = ParseInput(input);

            // Use pattern matching to determine the type and display a message
            string message = result switch
            {
                int number when number > 0 => $"The input is Postive Number:{number}", 
                int number => $"The input is Negative Number:{number}", 
                double doubleValue => $"The input is Decimal Number:{doubleValue}",
                string text when !string.IsNullOrWhiteSpace(text)=> $"The input is string:{text}",
                null => $"The input is null",
                _ => "Unknown Type of input."
            };
            Console.WriteLine(message);
            Console.ReadLine();
        }

    }
}
