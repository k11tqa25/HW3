using System;

namespace Exercise5
{
    class ComplexNumber{

        public int Real { get; set; }
        public int Imaginary { get; set; }
        public ComplexNumber(int r, int i)
        {
            Real = r;
            Imaginary = i;
        }

        public void SetImaginary(int i)
        {
            Imaginary = i;
        }

        public double GetMagnitude()
        {
            return Math.Sqrt(Real * Real + Imaginary * Imaginary);
        }

        public void Add(ComplexNumber c2)
        {
            Real += c2.Real;
            Imaginary += c2.Imaginary;
        }

        public override string ToString()
        {
            return $"({Real},{Imaginary})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool debug = false;

            ComplexNumber number = new ComplexNumber(5, 2);
            Console.WriteLine("Number is: " + number.ToString());

            number.SetImaginary(-3);
            Console.WriteLine("Number is: " + number.ToString());

            Console.Write("Magnitude is: ");
            Console.WriteLine(number.GetMagnitude());

            ComplexNumber number2 = new ComplexNumber(-1, 1);
            number.Add(number2);
            Console.Write("After adding: ");
            Console.WriteLine(number.ToString());

            if (debug)
                Console.ReadLine();
            Console.ReadKey();

        }
    }
}
