using System;

namespace Dreaming_of_Electric_Sheep
{
    interface ICountable
    {
        void IncrementCount();
        void ResetCount();
        int GetCount();
        string GetCountString();
    }

    interface IClonable
    {
        public Sheep Clone();
    }
    
    class Alligator : ICountable
    {
        int Count;
        public void IncrementCount()
        {
            Count++;
        }
        public void ResetCount()
        {
            Count = 0;
        }
        public int GetCount()
        {
            return Count;
        }
        public string GetCountString()
        {
            return $"{Count} alligator";
        }
    }

    class Sheep : ICountable , IClonable
    {
        int Count;
        string Name;

        public Sheep(string Name)
        {
            this.Count = 0;
            this.Name = Name;
        }

        public void IncrementCount()
        {
            Count++;
        }
        public void ResetCount()
        {
            Count = 0;
        }
        public int GetCount()
        {
            return Count;
        }
        public string GetCountString()
        {
            return $"{Count} {Name}";
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string Name)
        {
            this.Name = Name;
        }
        public Sheep Clone()
        {
            return new Sheep(Name);
        }
    }

    class CountUtil
    {
        public static void Count(ICountable c, int countUntil)
        {
            for (int i = 1; i <= countUntil; i++)
            {
                c.IncrementCount();
                Console.WriteLine(c.GetCountString());
            }
            Console.WriteLine();
            c.ResetCount();
        }
    }

    class CountTestApp
    {
        public void countAlliagtor()
        {
            Alligator alligator = new Alligator();
            CountUtil.Count(alligator, 3);
        }
        public void countSheep()
        {
            Sheep sheep = new Sheep("Blackie");
            CountUtil.Count(sheep, 2);
            Sheep sheep2 = sheep.Clone();
            sheep2.SetName("Dolly");
            CountUtil.Count(sheep2, 3);
            CountUtil.Count(sheep, 1);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CountTestApp tester = new CountTestApp();
            Console.WriteLine("Counting Alligators...");
            Console.WriteLine();
            tester.countAlliagtor();
            Console.WriteLine("Counting Sheep...");
            Console.WriteLine();
            tester.countSheep();
        }
    }
}
