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
    class Program
    {
        static void Main(string[] args)
        {
            Degree degree = Degree.F;
            Console.WriteLine((int)degree);
            string[] vs = Enum.GetNames<Degree>();
            Console.WriteLine(string.Join(",", vs));
            Degree[] degrees = Enum.GetValues<Degree>();
           /* foreach(Degree d in degrees)
            {
                Console.WriteLine($"{d} {(int)}");
            }*/
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
        }
    }
}
