using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Person person = new() { };
            person.Age = 42;
            person.Name = "John";
            person.Parent = null;
            return person;
        }
    }

    // Klasė, nusakanti informaciją apie žmogų
    public class Person
    {
        public string Name { get; set; }
        public Person? Parent { get; set; }
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

        readonly int VotingAge = 18;
        public Uri Blog { get; } = new Uri("thinqlinq");

        public bool IsPrime()
        {
            int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            return primes.Where(p => p == Age).Any();
        }

        /* Kelias if sąlygas galima sujungti į vieną
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
        }*/

        public bool IsFibber()
        {
            if (Age == 2 || Age == 3 || Age == 5 || Age == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Visos funkcijos kodą galima pakeisti viena paprasta eilute
        public string SayHello()
        {
            var unused = "I can be removed";
            var hello = "Hello";
            for (int i = 0; i < 20; i++)
            {
                hello += "Hello";
            }
            return hello;
        }*/

        public static string SayHello()
        {
            return string.Concat(Enumerable.Repeat("Hello", 20)); ;
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
