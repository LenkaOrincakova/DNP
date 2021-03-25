using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace E02

{
    class Program
    {
        static void Main(string[] args)
        {
            var Lenka = new Person
            {
                FirstName = "Lenka",
                LastName = "Orincakova",
                Age = 20,
                Height = 159,
                IsMarried = false,
                Sex = 'f',
                Hobbies = new string[] { "gym, studying" }
            };
            var Jano = new Person
            {
                FirstName = "jano",
                LastName = "lishak",
                Age = 20,
                Height = 179,
                IsMarried = false,
                Sex = 'm',
                Hobbies = new string[] { "programming, dron" }
            };

            var Whatever = new Person
            {
                FirstName = "llell",
                LastName = "lllll",
                Age = 34,
                Height = 390,
                IsMarried = false,
                Sex = 'm',
                Hobbies = new string[] { "njn, kmik" }
            };

            var people = new List<Person> { Lenka, Jano, Whatever };
            StoreObjects(people);
            ReadObjects();
        }
        private static void StoreObjects(List<Person> people)
        {
            File.WriteAllText("people.Json", JsonSerializer.Serialize(people));

        }
        private static void ReadObjects()
        {
            var people = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText("people.json"));
        }
    }
}
    

