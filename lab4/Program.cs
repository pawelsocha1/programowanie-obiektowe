using System;

namespace lab4
{
    enum Degree
    {
        A=50,
        B=45,
        C=40,
        D=35,
        E=30,
        F=20
    }

    record Student (string Name,int Ects, bool Egzam);
    class ClassStudent
    {
        public string Name { get; init; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Degree degree = Degree.F;
            Console.WriteLine((int)degree);
            string[] vs = Enum.GetNames<Degree>();
            Console.WriteLine(string.Join(",", vs));
            Degree[] degrees = Enum.GetValues<Degree>();
            foreach(Degree d in degrees)
            {
                Console.WriteLine($"{d} {(int)d}");
            }
            Console.WriteLine("Wpisz ocenę");
            string str = Console.ReadLine();
            try
            {
                Degree studentDegree = Enum.Parse<Degree>(str);
                Console.WriteLine("Wpisałeś" + studentDegree);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("Wpisałeś nieznaną ocenę");
            }
            double ocena = degree switch
            {
                Degree.A => 5.0,
                Degree.B => 4.5,
                Degree.C or Degree.D => 4.0,
                _ => 3.0
            };
            Console.WriteLine(ocena);
            Student student = new Student("Karol", 12, true);
            Console.WriteLine(student);
            if (student== new Student("Karol", 12, true))
            {
                Console.WriteLine("Identyczni");
            }
            else
            {
                Console.WriteLine("Różni");
            }
            Student[] students =
            {
            new Student("Karol", 12, true),
            new Student("Ewa", 17, false),
            new Student("Maciek", 18, true),
            new Student("Ania", 15, false)
            };

            foreach(Student st in students)
            {
                Console.WriteLine(
                    st.Name +
                    st switch
                    {
                        { Ects:>=17, Egzam:true} => "Zaliczył",
                        _ => "Nie zaliczył"
                    }
                    );

                
            }
        }
    }
}
