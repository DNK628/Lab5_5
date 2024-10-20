using System;

namespace UnifiedProgram
{
    public interface IEmployee
    {
        string Name { get; set; }
        int Stag_Rob { get; set; }
        void Role();
        double Zarplata();
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Stag_Rob { get; set; }

        public Employee(string name, int stagRob)
        {
            Name = name;
            Stag_Rob = stagRob;
        }
    }

    public class Official : Employee, IEmployee
    {
        public Official(string name, int stagRob) : base(name, stagRob) { }

        public void Role()
        {
            Console.WriteLine("Посада: Службовець");
        }

        public double Zarplata()
        {
            return 5000 + (Stag_Rob * 200); 
        }
    }

    public class Worker : Employee, IEmployee
    {
        public Worker(string name, int stagRob) : base(name, stagRob) { }

        public void Role()
        {
            Console.WriteLine("Посада: Робітник");
        }

        public double Zarplata()
        {
            return 4000 + (Stag_Rob * 150); 
        }
    }

    public interface IAccount
    {
        void Noviy_Rahunok();
        void Vydalyty_Rahunok();
    }

    public class BankAccount : IAccount
    {
        public string AccountNumber { get; set; }
        public double Balance { get; protected set; }

        public BankAccount(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0;
        }

        public void Noviy_Rahunok()
        {
            Console.WriteLine($"Новий рахунок {AccountNumber} створено.");
        }

        public void Vydalyty_Rahunok()
        {
            Console.WriteLine($"Рахунок {AccountNumber} видалено.");
        }
    }

    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(string accountNumber) : base(accountNumber) { }

        public void PopovnytyRahunok(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Рахунок {AccountNumber} поповнено на {amount}. Баланс: {Balance}");
        }

        public void ZnyatyZRahunku(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"З рахунку {AccountNumber} знято {amount}. Баланс: {Balance}");
            }
            else
            {
                Console.WriteLine($"Недостатньо коштів на рахунку {AccountNumber}");
            }
        }
    }

    
    public class DepositAccount : BankAccount
    {
        public DepositAccount(string accountNumber) : base(accountNumber) { }

        public void PopovnytyRahunok(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Депозитний рахунок {AccountNumber} поповнено на {amount}. Баланс: {Balance}");
        }

        public void ZnyatyZRahunku(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"З депозитного рахунку {AccountNumber} знято {amount}. Баланс: {Balance}");
            }
            else
            {
                Console.WriteLine($"Недостатньо коштів на депозитному рахунку {AccountNumber}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Official official = new Official("Іван Іванов", 5);
            Worker worker = new Worker("Петро Петров", 3);

            official.Role();
            Console.WriteLine($"Ім'я: {official.Name}, Стаж: {official.Stag_Rob}, Зарплата: {official.Zarplata()}");

            worker.Role();
            Console.WriteLine($"Ім'я: {worker.Name}, Стаж: {worker.Stag_Rob}, Зарплата: {worker.Zarplata()}");

            CurrentAccount current = new CurrentAccount("12345");
            current.Noviy_Rahunok();
            current.PopovnytyRahunok(1000);
            current.ZnyatyZRahunku(500);
            current.Vydalyty_Rahunok();

            DepositAccount deposit = new DepositAccount("54321");
            deposit.Noviy_Rahunok();
            deposit.PopovnytyRahunok(5000);
            deposit.ZnyatyZRahunku(1000);
            deposit.Vydalyty_Rahunok();

            Console.ReadKey();
        }
    }
}

