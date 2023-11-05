using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;

namespace StaticCodeAnalysis
{
    // Klasė, skirta gauti Person klasės pavyzdį su duomenimis
    public class PersonSample                          // Pervardinta klasė Class1 -> PersonSample
    {
        public void WriteInfo(string input)            // Pervardintas metodas ShouldUseVar -> WriteInfo
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                    throw new ArgumentException("input");

                Person person = GetSample();
                Console.Write($"{person.Name} is {person.Age} years old");
                Console.WriteLine("His parent is [1]", person.Parent.Name, person.Parent.Parent.Age);
                Console.WriteLine($"His blog is {person.Blog}");
            }
            catch (Exception ex)
            {
            }
        }

        public static void NewDispose()         // Pervardinta klasė TryUsingDisposableWithoutDisposing -> NewDispose
        {
            var toDispose = new ToDispose();
            toDispose.Write("test");
        }

        public Person GetSample()                  // Pervardinta klasė GetJim -> GetSample
        {
            Person person = new Person { };
            person.Age = 42;
            person.Name = "John";
            person.Parent = null;
            return person;
        }
    }

    // Klasė, nusakanti informaciją apie žmogų
    public class Person
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Person Parent { get; set; }

        public int Age { get; set; }

        
        // Metodas, kuris nustato, ar žmogus gali balsuoti
        public bool CanVote(int minAge)
        {
            if (Age > VotingAge)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        int VotingAge = 18;
        public Uri Blog { get; } = new Uri("thinqlinq");

        public bool IsPrime()
        {
            int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            return primes.Where(p => p == Age).Any();
        }

// KODAS PERŽIŪRĖTAS IKI ČIA

        public bool IsFibber()
        {
            if (Age == 2)
            {
                return true;
            }
            else if (Age == 3)
            {
                return true;
            }
            else if (Age == 5)
            {
                return true;
            }
            else if (Age == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string SayHello()
        {
            var unused = "I can be removed";
            var hello = "Hello";
            for (int i = 0; i < 20; i++)
            {
                hello += "Hello";
            }
            return hello;
        }
    }

    public class ToDispose : IDisposable
    {
        private StringWriter sw = new StringWriter();
        public ToDispose()
        {

        }
        public void Write(string value)
        {
            sw.Write(value);
        }
        public void Dispose()
        {
            
            sw.Dispose();
        }
    }
}
