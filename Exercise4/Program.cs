using System;

namespace Exercise4
{
    class Person
    {
        protected int age;

        public Person()
        {
            SayHello();
        }

        public void SayHello()
        {
            Console.WriteLine("Hello");
        }

        public void SetAge(int n)
        {
            age = n;
        }

    }

    class Student: Person
    {
        public Student(int age): base()
        {
            SetAge(age);

        }

        public void GoToClasses()
        {
            Console.WriteLine("I'm going to class.");
        }
        public void ShowAge()
        {
            Console.WriteLine($"My age is: {age} years old");
        }
    }

    class Teacher: Person
    {
        private string subject;

        public Teacher(int age, string subject): base()
        {
            SetAge(age);
            this.subject = subject;
        }

        public void Explain()
        {
            Console.WriteLine("Explanation begins.");
        }

    }
    class StudentAndTeacherTest
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            Student s1 = new Student(21);
            s1.ShowAge();
            Teacher t1 = new Teacher(30, "English");
            t1.Explain();
        }
    }
}
