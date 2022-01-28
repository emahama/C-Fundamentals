using System;
using System.Collections.Generic;

namespace GradeBook
{
    // Delegate for demonstration events
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    // Defining a class
    public class Book : NamedObject
    {
        /* 
        Todo: Defining Fields to store states 
        NB : fields are by defualt private (they can be access by code within the class)
        */
        private List<double> _grades;

        // Readonly field
        // NB : their value can be set at initialisation or set in a constructor only
        readonly string category = "Sience";

        // Const Fields
        // const field cannot be change any where
        const string FIELD1 = "Science";

        // public const feilds are treated as static members
        // They are accessed via the type name outside the class : Book.Feild2
        public const string FIELD2 = "Science";

        // By convention Field declared as public are capitalized
        // private string name;

        // Defining properties
        /*
        This is one way of definining properties
        This implementation requires a backing field that sits behind the
        property whereyou can store incoming vaules: private string name;
        */
        // public string Name
        // {
        //     get
        //     {
        //         return name;
        //     }
        //     set
        //     {
        //         if (!String.IsNullOrEmpty(value))
        //         {
        //             name = value;
        //         }
        //         else
        //         {
        //             throw new ArgumentNullException($"You passed a null value: {nameof(name)}");
        //         }

        //     }
        // }

        // Autogenerated property example
        /*
        The compiler will dyname creat the backing field and the getters and setters for us
        */

        // Defining event which is invoked when grade is added
        public event GradeAddedDelegate GradeAdded;

        // public string Name
        // {
        //     get;
        //     set; // you can prevent settng name outside class using private keyword
        // }

        // Todo: Define explicit constructor
        public Book(string name) : base(name)
        {
            _grades = new List<double>();
            // this.Name = name;
            // Name = name;

            // Example of setting readonly value in constructor

            category = "";
        }
        /* 
        Todo : defining behavior/methods
        NB: methods are define as public (We want code outside the class to be able to access them)
        */

        /*
        NB : Method overloading
        - public void  AddGrade(char letter)
        - public void AddGrade(double grade)
        - Method with different signatures can be overloaded
        - Signature consist of method name & input types
        */
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);

                if (GradeAdded != null)
                {
                    /*If someone has subscribed the GradeAdded event*/
                    GradeAdded(this, new EventArgs());

                }
            }
            else
            {
                // nameof return the string representation of grade onject
                throw new ArgumentException($"Invalid grade at {nameof(grade)}");
            }

        }
        public Statistics getStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;


            foreach (var grade in _grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }
            result.Average /= _grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;

            }
            return result;

        }
    }
}