using System;
using System.Collections.Generic;
using System.Linq;

namespace lab8
{
    class Program
    {
        record Student(int Id, string Name, int Ects);
        static void Main(string[] args)
        {
            
            int[] ints = { 4, 6, 7, 3, 2, 8, 9 };
            IEnumerable<int> evenNumbers = from n in ints
                                           where n % 2 == 0
                                           select n;
            Console.WriteLine(string.Join(",", evenNumbers));
            //zapisz LINQ ktore zwroci liczby wieksze od 5
            Predicate<int> intPredicate = n =>
            {
                Console.WriteLine("Wywołanie predykatu dla" + n);
                return n % 2 == 0;
            };

            evenNumbers =
                from n in ints
                where intPredicate.Invoke(n)
                select n;

            evenNumbers =
            from n in evenNumbers
            where n > 5
            select n * 2;

            Console.WriteLine("wywołanie ewaulacji wyrażenia LINQ");
            Console.WriteLine(string.Join(", ", evenNumbers));
            Console.WriteLine(evenNumbers.Sum());
            Console.WriteLine(evenNumbers.Average());
            Console.WriteLine(evenNumbers.Max());
            Console.WriteLine(evenNumbers.Min());
            Console.WriteLine(evenNumbers.Count());

            Student[] students =
            {
            new Student(1, "Ewa", 67),
            new Student(2, "Ewa", 67),
            new Student(3, "Ewa", 67),
            new Student(4, "Ewa", 67),
            new Student(5, "Ewa", 67),
            new Student(6, "Ewa", 67)
            };
            Console.WriteLine("**************************");
            IEnumerable<string> enumerable = from s in students
            orderby s.Name descending orderby s.Ects
                select s.Name + " " + s.Ects;
            Console.WriteLine(string.Join("\n", enumerable));
            Console.WriteLine(string.Join(", ",
                from i in ints
                orderby i descending
                select i
                ));

            Console.WriteLine(string.Join(", ", ints.OrderByDescending(i => i)));
           
            Console.WriteLine(string.Join(", ", students.OrderBy(s => s.Name).ThenBy(s => s.Ects)));
            //Grupowanie 
            IEnumerable<IGrouping<string, Student>> studentNameGroup =
                from s in students
                group s by s.Name;
            foreach(var item in studentNameGroup)
            {
                Console.WriteLine(item.Key + " " + string.Join(", ", item));
            }
            IEnumerable<(string Key, int)> NameCounters = from s in students
            group s by s.Name into groupItem
            select (groupItem.Key, groupItem.Count());
            Console.WriteLine("-------------------");
            string str = "Ala ma kota Ala lubi koty Karol lubi psy";
            Console.WriteLine(string.Join(", ", str.Split().Count()));

            evenNumbers = ints.Where(i => i % 2 == 0).Select(i => i + 2);
            (int Id, string Name) p = students
                .Where(s => s.Ects > 20)
                .OrderBy(s => s.Id)
                .Select(s => (s.Id, s.Name))
                .FirstOrDefault(s => s.Name.StartsWith("A"));
            Console.WriteLine(p);
            int[] powerInts =Enumerable
                .Range(0, ints.Length)
                .Select(i => ints[i] * ints[i])
                .ToArray();
            Console.WriteLine(string.Join(", ", powerInts));
            Random random = new Random();
            random.Next(5); // zwraca losowa liczbe od 0 do 4
            //Wygreneruj tablice 100 liczb od 0 do 9
            int[] randomInts = Enumerable
                .Range(0, 100)
                .Select(i => random.Next(10))
                .ToArray();
            Console.WriteLine(string.Join(", ", randomInts));
            int page = 0;
            int size = 3;
            List<Student> pageStudent = students.Skip(page * size).Take(size).ToList();
            Console.WriteLine(string.Join(", ", pageStudent));
                


        }
    }
}

