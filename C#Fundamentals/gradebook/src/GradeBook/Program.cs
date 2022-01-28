using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Add project to sln file 
            // =========================
            // A solution file keeps track of multiple project
            // dotnet new sln
            // dotnet sln add src/GradeBook/GradeBook.csproj
            // dotnet sln add test/GradeBook.Tests/GradeBook.Tests.csproj 
            // dotnet build
            // Console.WriteLine("Enter your name : ");

            // Run a specific project : dotnet run --project .\src\GradeBook\GradeBook.csproj

            // string name = Console.ReadLine();
            // try
            // {
            //     Console.WriteLine($"Hello {args[0]}!");
            // }
            // catch(Exception ex)
            // {
            //     Console.WriteLine($"{ex.Message}");
            // }
            // double x = 10.1;
            // double y = 12.6;
            
            // double[] numbers = new double[3];
            // var nums = new double[3];
            // var nums1 = new[] {0.3, 0.3, 0.5};

            // for (int i = 0; i < numbers.Length; i++)
            // {
            //     numbers[i]=i+1;
            // }
            */
            var book = new Book("Edward's Grade Book");

            // Invoke the GradeAdded event
            book.GradeAdded += onGradeAdded;

            // NB because GradeAdded is event we cannot do this:
            // We could do that for a pure delegate
            // book.GradeAdded = onGradeAdded;

            while (true)
            {
                Console.WriteLine("Enter a grade : or Enter q/Q to quit");
                var grade = Console.ReadLine();

                if (grade.ToLower() == "q")
                {
                    break;
                }
                try
                {
                    book.AddGrade(double.Parse(grade));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw; // re throws the exception for it to be catched elsewhere
                }

            }

            Console.WriteLine(book.Name);
            // book.Name = null;

            var result = book.getStatistics();
            Console.WriteLine($"The lowest grade is {result.Low}");
            Console.WriteLine($"The highest grade is {result.High}");
            Console.WriteLine($"The average grade is {result.Average}");
            Console.WriteLine($"The average letter grade is {result.Letter}");

        }

        // Delegate handeler
        static void onGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }

    }
}
