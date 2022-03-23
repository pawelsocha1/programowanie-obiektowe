using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = Person.OfName("Adam");
            Console.WriteLine(person);
            person.Equals(1);
            Console.WriteLine(person.Name==null?"NULL":"PERSON");
            Money? money = Money.Of(13, Currency.USD) ?? Money.Of(1, Currency.PLN);
            Console.WriteLine(money.Value);
            Money result = 5 * money;
            Console.WriteLine(result.Value);
            Console.WriteLine(money < Money.Of(5, Currency.USD));
            if (money == Money.Of(13, Currency.USD))
            {
                Console.WriteLine("Rowne");
            }
            else
            {
                Console.WriteLine("Różne");

            }
            int c= 5;
            long b= 5L;
            b = c; //niejawne
            c = (int)b; //jawne
            decimal cost = money;
            double price = (double)money;
            string str = (string)money;
            Console.WriteLine((string)money);
            Console.WriteLine("SORT");
            Money[] prices =
            {
                Money.Of(11,Currency.PLN),
                Money.Of(16,Currency.USD),
                Money.Of(13,Currency.PLN),
                Money.Of(10,Currency.EUR),
                Money.Of(3,Currency.USD),
                Money.Of(15,Currency.PLN),
            };
            Array.Sort(prices);
            foreach(var p in prices)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
    public enum Currency
    {
        PLN = 2,
        USD = 3,
        EUR = 1
    }
    public class Money:IComparable<Money>
    {
        private readonly decimal _value;
        private readonly Currency _currency;
        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }
        public static Money? Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);
        }
        public static Money? OfWithException(decimal value, Currency currency)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();

            }
            else
            {
                return new Money(value, currency);
            }
        }
        public decimal Value
        {
            get { return _value; }
        }
        public Currency Currency
        {
            get { return _currency; }
        }

      
        public static Money operator *(Money money, decimal factor)
        {
            return Money.OfWithException(money.Value * factor, money.Currency);
        }

        public static Money operator *(decimal factor, Money money)
        {
            return Money.OfWithException(money.Value * factor, money.Currency);
        }
        public static bool operator >(Money a, Money b)
        {
            IsSameCurrencies(a, b);
            return a.Value > b.Value;
        }

      

        public static bool operator <(Money a, Money b)
        {
            IsSameCurrencies(a, b);
            return a.Value < b.Value;
        }

        private static void IsSameCurrencies(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentException("Diffrent curriencies!");
            }
        }
        public static implicit operator decimal(Money money)
        {
            return money.Value;
        }
        public static explicit operator double(Money money)
        {
            return (double)money.Value;
        }
        public static explicit operator string(Money money)
        {
            return $"{money.Value} {money.Currency}";
        }

        public override string ToString()
        {
            return $"Value: {_value}, Currency: {_currency}";
        }

        public int CompareTo(Money other)
        {
           int currencyCon= Currency.CompareTo(other.Currency);
            if (currencyCon == 0)
            {
                return Value.CompareTo(other.Value);
            }
            else
            {
                return currencyCon;
            }
        }
    }


    class Person:IEquatable<Person>
    {
        private string _name;
        public int ects { get; set; }
        
     
        private Person(string name)
        {
            _name = name;
        }

        public static Person OfName(String name)
        {
            if(name!=null && name.Length >=2)
            {
                return new Person(name);

            }
            else
            {
                throw new ArgumentOutOfRangeException("Imię zbyt krótkie");
            }
        }

       

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value !=null && value.Length >= 2)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Imię jest za krótkie");
                }
            }
        }
        public override string ToString()
        {
            return $"Name: { _name}";
        }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   ects == person.ects &&
                   Name == person.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ects, Name);
        }

           public bool Equals(Person other)
           {
               return other._name.Equals(_name)&& other.ects==ects;
           }
   


    }

}
