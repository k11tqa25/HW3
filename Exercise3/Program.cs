using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise3
{
    class Expense
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }

        public Expense(DateTime date, string desc, string cat, decimal amount)
        {
            Date = date;
            Description = desc;
            Category = cat;
            Amount = amount;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Amount: { Amount}");
            Console.WriteLine($"Description: {Description}");
        }
    }

    class HouseholdAccounts
    {
        private List<Expense> expenses = new List<Expense>();
        public int MaxStorage { get; } = 10000;
        public HouseholdAccounts()
        {

        }

        private int GetNextId()
        {
            if (expenses.Count > 0) return expenses[expenses.Count - 1].Id + 1;
            else return 0;
        }


        public void AddAnExpense(Expense exp)
        {
            if (expenses.Count < MaxStorage)
            {
                exp.Id = GetNextId();
                expenses.Add(exp);
                expenses.Sort((x, y) => x.Date.CompareTo(y.Date));
            }
            else
            {
                Console.WriteLine("The storage is full.");
            }
        }

        public void ShowExpenses(string category, DateTime from, DateTime to)
        {
            var filtered = expenses.Where(x => x.Category == category && x.Date >= from && x.Date <= to);
            if(filtered != null)
            {
                foreach (var v in filtered) v.Display();
            }
            else
            {
                Console.WriteLine("No record.");
            }
        }

        public void SearchCost(string text)
        {
            var filtered = expenses.Where(x => x.Description.Contains(text));
            if(filtered != null)
            {
                foreach (var v in filtered) v.Display();
            }
            else
            {
                Console.WriteLine("No record.");
            }
        }

        public void ModifyTab(int id)
        {
            var found = (List<Expense>)expenses.Where(x => x.Id == id);
            if(found != null)
            {
                found[0].Display();
                Console.WriteLine("Modify the amound: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                expenses[expenses.FindIndex(x => x.Id == id)].Amount = amount;
                Console.WriteLine("Modified.");
            }
            else
            {
                Console.WriteLine("No record.");
            }
        }

        public void SortAlphebatically()
        {
            expenses = (List<Expense>)expenses.OrderBy(x => x.Date).ThenBy(x => x.Description);
        }

        public void Delete(int id)
        {
            foreach(var e in expenses)
            {
                if(e.Id == id)
                {
                    expenses.Remove(e);
                }
                return;
            }

            Console.WriteLine("No matched ID.");
        }
    }

    class Program
    {
        static DateTime ReadDate()
        {
            string d = Console.ReadLine();
            return new DateTime(Convert.ToInt32(d.Substring(0, 4)), Convert.ToInt32(d.Substring(4, 2)), Convert.ToInt32(d.Substring(6, 2)));
        }

        static void ShowOptions()
        {
            Console.WriteLine("1: Add");
            Console.WriteLine("2: Modify");
            Console.WriteLine("3: Search by text");
            Console.WriteLine("4: Show expenses");
            Console.WriteLine("5: Sort");
            Console.WriteLine("6: Delete");
            Console.WriteLine("7: Quit");
        }

        static void Main(string[] args)
        {
            int option = 0;
            HouseholdAccounts ha = new HouseholdAccounts();
            while (option != 7)
            {
                ShowOptions();
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Date: ");
                        DateTime date = ReadDate();
                        Console.Write("Category: ");
                        string cat = Console.ReadLine();
                        Console.Write("Expense: ");
                        decimal exp = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Description:");
                        string desc = Console.ReadLine();

                        ha.AddAnExpense(new Expense(date, desc, cat, exp));
                        break;

                    case 2:
                        Console.Write("Modify Id: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        ha.ModifyTab(id);
                        break;

                    case 3:
                        Console.Write("Search text: ");
                        string text = Console.ReadLine();
                        ha.SearchCost(text);
                        break;

                    case 4:
                        Console.Write("Category: ");
                        string c = Console.ReadLine();
                        Console.Write("Start Date: ");
                        DateTime d1 = ReadDate();
                        Console.Write("End Date: ");
                        DateTime d2 = ReadDate();
                        ha.ShowExpenses(c, d1, d2);
                        break;

                    case 5:
                        ha.SortAlphebatically();
                        break;

                    case 6:
                        Console.Write("Delete Id: ");
                        int i = Convert.ToInt32(Console.ReadLine());
                        ha.Delete(i);
                        break;

                    default:
                        break;
                }
                
            }
        }
    }
}
