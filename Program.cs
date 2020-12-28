using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reflection
{
    public class importantAttribute : Attribute
    {

    }

    public class Human
    {
        [important]
        public string name { get; set; }
        [important]
        public string surname { get; set; }

        public int age { get; }

        public Human(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }
    }

    class Program
    {
        static async void AddNumAsync(List<int> mas, int num)
        {
            await Task.Run(() => mas.Add(num));
        }

        static void Main(string[] args)
        {
            Type t1 = typeof(int);
            Type t2 = typeof(byte);

            Console.WriteLine("1. Exploration");
            Console.WriteLine("1.1. " + typeof(int).Assembly.FullName);
            Console.WriteLine("1.2. " + typeof(byte).Attributes);
            Console.WriteLine("1.3. " + t1.IsAssignableFrom(t2));
            Console.WriteLine("     " + t2.IsAssignableFrom(t1) + "\n" +
                "     ex1.IsAssignableFrom(ex2) IsAssignableFrom проверяет может ли к переменной типа ex1 присвоить переменную типа ex2" +
                "       Как видно из примера переменой типа int нельзя присвоить значение переменной типа byte и наоборот");

            Console.WriteLine("2. Attribute");

            List<MemberInfo> info = typeof(Human).GetMembers().Where(attribute => Attribute.IsDefined(attribute, typeof(importantAttribute))).ToList();
            foreach (var important in info)
            {
                Console.WriteLine("     " + important.Name);
            }

            Console.WriteLine("3. Vandalism");

            List<int> nums = new List<int> { 1, 2, 3 };

            List<MemberInfo> infoList = typeof(List<int>).GetMembers(BindingFlags.NonPublic).ToList();
            foreach (var infoL in infoList)
            {
                Console.WriteLine("3.2. " + infoL.Name);
            }

            Console.ReadKey();

            AddNumAsync(nums, 4);
            foreach(int num in nums)
            {
                Console.WriteLine("     " + num);
            }

            Console.ReadKey();
        }
    }
}

