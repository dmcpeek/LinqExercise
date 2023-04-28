using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var sum = numbers.Sum(x => x);

            Console.Write("The sum of the numbers is: ");
            Console.WriteLine(sum);

            //TODO: Print the Average of numbers
            var avg = numbers.Average(x => x);

            Console.Write("The average of the numbers is: ");
            Console.WriteLine(avg);

            //TODO: Order numbers in ascending order and print to the console
            var order = numbers.OrderBy(x => x);
            Console.Write("The numbers in ascending order are: ");
            foreach (int i in order)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();

            //TODO: Order numbers in decsending order and print to the console
            var dOrder = numbers.OrderByDescending(x => x);
            Console.Write("The numbers in descending order are: ");
            foreach (int i in dOrder)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6
            var biggerThanSix = numbers.Where(x => x > 6);
            Console.Write("The numbers larger than six are: ");
            foreach (int i in biggerThanSix)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();

            //TODO: Order numbers in any order (acsending or desc)
            //but only print 4 of them **foreach loop only!**
            var fourNumbers = numbers.OrderByDescending(x => x).Take(4);
            Console.Write("Four numbers printed in descending order: ");

            foreach (int i in fourNumbers)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();

            //TODO: Change the value at index 4 to your age,
            //then print the numbers in decsending order
            numbers[4] = 57;
            var age = numbers.OrderByDescending(x => x);
            Console.Write("My age sorted descending with a bunch of youngins: ");

            foreach (int i in age)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName
            //starts with a C OR an S and order this in ascending order by FirstName.
            var worker = employees.Where(x => x.FirstName.StartsWith("S") || x.FirstName.StartsWith("C")).OrderBy(x => x.FirstName);

            Console.WriteLine("All employees where the first name begins with 'C' or 'S'");
            Console.WriteLine("---------------------------------------------------------");
            foreach (Employee emp in worker)
            {
                Console.WriteLine(emp.FullName);
            }
            Console.WriteLine();

            //return fullName(fname + lName);
            var concatName = employees.Select(x => x);

            Console.WriteLine("All employes with first name and last name concatenated");
            Console.WriteLine("-------------------------------------------------------");
            foreach (Employee emp in concatName)
            {
                Console.WriteLine(emp.FirstName + emp.LastName);
            }

            Console.WriteLine();

            //TODO: Print all the employees' FullName and Age who are over the
            //age 26 to the console and order this by Age first and then by FirstName in the same result.
            var hardlyWorkin = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);

            Console.WriteLine("All employees over 26, sorted by age first then by first name");
            Console.WriteLine("-------------------------------------------------------------");
            foreach (Employee emp in hardlyWorkin)
            {
                Console.WriteLine($"{emp.FullName} is {emp.Age} year old.");
                //Console.WriteLine(emp.Age);
            }
            Console.WriteLine();

            //TODO: Print the Sum and then the Average of the employees'
            //YearsOfExperience if their YOE is less than or equal to 10
            //AND Age is greater than 35.

            var experienceCounts = employees.Where(x => x.Age > 35 && x.YearsOfExperience <= 10);
            var average = experienceCounts.Average(x => x.YearsOfExperience);
            var sumOfAverage = experienceCounts.Sum(x => x.YearsOfExperience);

            Console.Write("The average of the sum of YOE is: ");
            Console.WriteLine(average);
            Console.Write("The sum of YOE is: ");
            Console.WriteLine(sumOfAverage);

            Console.WriteLine();

            //TODO: Add an employee to the end of the list without using employees.Add()
            var rumpled = new Employee()
            {
                YearsOfExperience = 40,
                FirstName = "Rumple", 
                LastName = "Stiltskin",
                Age = 99,
            };
            Console.WriteLine("New guy added to the list - this guy is golden!");
            Console.WriteLine("-----------------------------------------------");
            employees.Append(rumpled).ToList().ForEach(x => Console.WriteLine(x.FullName));

           Console.WriteLine();
           Console.ReadLine();
        }
        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
