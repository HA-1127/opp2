namespace ConsoleApp1
{
    class Account
    {
        public Account(string name, double balanse)
        {
            Name = name;
            Balanse = balanse;
        }

        public string Name { get; set; }
        public double Balanse { get; set; }
        public virtual bool Diposet(double amount)
        {
            if (amount > 0)
            {
                Balanse -= amount;
                return true;
            }
            return false;
        }
        public virtual bool WithDreaw(double amount)
        {
            if (amount > 0 && Balanse >= amount)
            {
                Balanse -= amount;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return ($"the balanse{Balanse}");
        }

    }
    class SavingAccount : Account
    {
        public SavingAccount(string name, double balanse, double intersetrate) : base(name, balanse)
        {
            Intersetrate = intersetrate;
        }

        public double Intersetrate { get; set; }
        public override bool WithDreaw(double amount)
        {
            return base.WithDreaw((amount * Intersetrate) + amount);
        }
        public override string ToString()
        {
            return $"{(base.ToString())}, rate:{Intersetrate}";
        }
    }

    class ChakingAccount : Account
    {
        public ChakingAccount(string name, double balanse) : base(name, balanse) { }
        public override bool WithDreaw(double amount)
        {
            double totalAmount = amount + 1.5;
            return base.WithDreaw(totalAmount);
        }
        public override string ToString()
        {
            return $"{base.ToString()},ther balanse: {Balanse}";
        }
    }

    class TurethAccount : SavingAccount
    {
        private double Maxwithdraw = 3;
        private int triesCounter = 0;
        private DateTime triesDate = DateTime.Now.Date;
        public TurethAccount(string name, double balanse, double intersetrate)
            : base(name, balanse, intersetrate) { }

        public override bool Diposet(double amount)
        {
            if (amount > 5000)
            {
                Balanse += 50;

            }
            return base.Diposet(amount);
        }
        public override bool WithDreaw(double amount)
        {
            if (DateTime.Now.Date > triesDate.AddYears(1))
            {
                triesDate = DateTime.Now.Date;
                triesCounter = 0;
            }
            if (Maxwithdraw <= triesCounter)
            {
                triesCounter++;
                base.WithDreaw(amount);
                return true;
            }
            return false;

        }
        public override string ToString()
        {
            return $"{base.ToString()} , balanse {Balanse}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Account> a = new List<Account>
            {
                new SavingAccount("hassan" ,10000,200),
                new ChakingAccount("ali",20000 ),
                new TurethAccount("elmasrey",30000,800)
            };
            for (int i = 0; i <= a.Count; i++)
            {
                Console.WriteLine(a[i].ToString());
                a[i].Diposet(200);
                a[i].WithDreaw(100);
                Console.WriteLine("After transactions:");
                Console.WriteLine(a[i].ToString());

            }
        }
    }
}
