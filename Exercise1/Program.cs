using System;

namespace Exercise1
{
    abstract class Shape1
    {

        protected float R, L, B;

        //Abstract methods can have only declarations
        public abstract float Area();
        public abstract float Circumference();

    }

    class Rectangle : Shape1
    {
        public Rectangle(float len, float br)
        {
            L = len;
            B = br;
        }

        public override float Area() => L * B;

        public override float Circumference() => 2 * (L + B);
    }

    class Circle : Shape1
    {
        public Circle(float radius)
        {
            R = radius;
        }

        public override float Area() =>(float)Math.PI * R * R;

        public override float Circumference() => 2 * (float)Math.PI * R;
    }

    class Program
    {
        static void Calculate(Shape1 S)
        {
            Console.WriteLine("Area : {0}", S.Area());
            Console.WriteLine("Circumference : {0}", S.Circumference());

        }

        static void Main(string[] args)
        {
            Console.Write("Enter Length: ");
            float rl = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter Breadth: ");
            float rb = Convert.ToSingle(Console.ReadLine());
            Rectangle r = new Rectangle(rl, rb);
            Calculate(r);

            Console.Write("Enter Radius: ");
            float cr = Convert.ToSingle(Console.ReadLine());
            Circle c= new Circle(cr);
            Calculate(c);
        }
    }
}
