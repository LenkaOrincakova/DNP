using System;
using System.Collections.Generic;
using System.Text.Json;

namespace E01
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
            var peopleJson = JsonSerializer.Serialize(people, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(peopleJson);
        }
    }
}
