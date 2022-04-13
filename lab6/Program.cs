using System;
using System.Collections.Generic;

namespace lab6
{
    class Program
    {
        class Student:IComparable<Student>
        {
            public string Name { get; set; }
            public int Ects { get; set; }

            public int CompareTo(Student other)
            {
                if(Name.CompareTo(other.Name)==0)
                {
                    return Ects.CompareTo(other.Ects);

                }
                return Name.CompareTo(other.Name);
            }

            public override bool Equals(object obj)
            {
                Console.WriteLine("Student Equals");
                return obj is Student student &&
                       Name == student.Name &&
                       Ects == student.Ects;
            }

            public override int GetHashCode()
            {
                Console.WriteLine("Student HashCode");
                return HashCode.Combine(Name, Ects);
            }

            public override string ToString()
            {
                return $"Name={Name}, Ects={Ects}";
            }
        }
        static void Main(string[] args)
        {
            ICollection<string> names = new List<string>();
            names.Add("Ewa");
            names.Add("Karol");
            names.Add("Adam");
            names.Add("Adam");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine(names.Contains("Adam"));

            //
            ICollection<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Wojtek", Ects = 12 });
            students.Add(new Student() { Name = "Karol", Ects = 30 });
            students.Add(new Student() { Name = "Adam", Ects = 40 });
            students.Remove(new Student() { Name = "Adam", Ects = 17 });
            foreach (Student name in students)
            {
                Console.WriteLine(name.Name + " "+ name.Ects);
            }
            Console.WriteLine(students.Contains(new Student() { Name = "Adam", Ects = 40 }));
            List<Student> list = (List<Student>)students;
            Console.WriteLine(list[0]);
            list.Insert(1, new Student() { Name = "Robert", Ects = 45 });
            foreach (Student name in students)
            {
                Console.WriteLine(name.Name + " " + name.Ects);
            }
            int index = list.IndexOf(new Student() { Name = "Karol", Ects = 30 });
            Console.WriteLine("Karol ma pozycję " + index);
            list.RemoveAt(0);
            Console.WriteLine("--------------------------SET-------------------------------");
            ISet<string> set = new HashSet<string>();
            set.Add("Ewa");
            set.Add("Karol");
            set.Add("Adam");
            set.Add("Adam");
            foreach(string name in set)
            {
                Console.WriteLine(name);
            }
            ISet<Student> studentGroup = new HashSet<Student>();
            studentGroup.Add(new Student() { Name = "Wojtek", Ects = 12 });
            studentGroup.Add(new Student() { Name = "Karol", Ects = 30 });
            studentGroup.Add(new Student() { Name = "Adam", Ects = 40 });
            studentGroup.Add(new Student() { Name = "Adam", Ects = 40 });
            foreach (Student name in studentGroup)
            {
                Console.WriteLine(name.Name+" " +name.Ects);
            }
            studentGroup.Contains(new Student() { Name = "Adam", Ects = 17 });
            /*studentGroup.Remove(new Student() { Name = "Karol", Ects = 30 });*/
            studentGroup = new SortedSet<Student>(studentGroup);
            
            foreach (Student name in studentGroup)
            {
                Console.WriteLine(name.Name + " " + name.Ects);
            }

            studentGroup.Contains(new Student() { Name = "Adam", Ects = 40 });
            Dictionary<Student, string> phoneBook = new Dictionary<Student, string>();
            phoneBook[list[0]] = "234566789";
            phoneBook[list[1]] = "834566789";
            phoneBook[new Student() { Name = "Robert", Ects = 45 }] = "934566789";
            Console.WriteLine(phoneBook.Keys);
            if(phoneBook.ContainsKey(new Student() { Name="Ewa", Ects=12}))
            {
                Console.WriteLine("Jest telefon");
                
            }
            else
            {
                Console.WriteLine("Brak telefonu");
            }
            foreach(var item in phoneBook)
            {
                Console.WriteLine(item.Key + " "+ item.Value);
            }
            string[] arr = { "Adam", "Ewa", "Karol", "Ewa", "Ania", "Karol", "Adam", "Adam", "Ewa" };
            //oblicz ile razy wystepuje kazde z imion w tablicy arr
            Dictionary<string, int> counters = new Dictionary<string, int>();
            foreach(string name in arr)
            {
                if (counters.ContainsKey(name))
                {
                    counters[name] += 1;
                }else
                {
                    counters[name]=1;
                }
            }
            foreach(var item in counters)
            {
                Console.WriteLine(item.Key + "występuje" + item.Value);
            }
        }
    }
}
