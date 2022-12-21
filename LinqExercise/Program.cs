using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

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

            //TODO: Print the Sum of numbers   [*]
            Console.WriteLine("The Sum of the 'Numbers' array: ");
            Console.WriteLine("--------------------------------");
                        
            Console.WriteLine($"The sum is : {numbers.Sum()}");
            Console.WriteLine();

            //TODO: Print the Average of numbers   [*]
            Console.WriteLine("The Average of the 'Numbers' array: ");
            Console.WriteLine("------------------------------------");
                        
            Console.WriteLine($"The average is : {numbers.Average()}");
            Console.WriteLine();

            //TODO: Order numbers in ascending order and print to the console   [*]
            Console.WriteLine("'Numbers' array in ascending order: ");
            Console.WriteLine("-------------------------------------");

            numbers.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            //TODO: Order numbers in decsending order and print to the console   [*]
            Console.WriteLine("'Numbers' array in descending order: ");
            Console.WriteLine("-------------------------------------");
                        
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6   [*]
            Console.WriteLine("Contents of the 'Numbers' array that are > 6: ");
            Console.WriteLine("-------------------------------------");

            numbers.Where(x => x > 6).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**   [*]
            Console.WriteLine("The first 4 in 'Numbers', ascending: ");
            Console.WriteLine("-------------------------------------");
                        
            numbers.OrderBy(x => x).Take(4).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();    
           
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order   [*]
            Console.WriteLine("'Numbers' at index[4] changed to my age, then 'Numbers' descending: ");
            Console.WriteLine("------------------------------------------------------------------");
            numbers.SetValue(38, 4);
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("---");
            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("Employee full names in ascending order by first name, excluding any that do not start with 'C' or 'S': ");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            employees.Where(employee => employee.FirstName.StartsWith("C") || employee.FirstName.StartsWith("S"))
                .OrderBy(employee => employee.FirstName).ToList().ForEach(employee => Console.WriteLine(employee.FullName));

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine();
            Console.WriteLine("Employees over 26, full names and ages : ");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            employees.Where(employee => employee.Age > 26).OrderBy(employee => employee.Age).ThenBy(employee=> employee.FullName).ToList()
                .ForEach(employee => Console.WriteLine($"{employee.Age}, {employee.FullName}"));

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine();
            Console.WriteLine("Sum of and Average of employees' Years of Experience: ");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            int sumOfYOE = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35).Sum(yoe => yoe.YearsOfExperience);
            double avgOfYOE = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35).Average(yoe => yoe.YearsOfExperience);
            Console.WriteLine($"{sumOfYOE}, {avgOfYOE}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine();
            Console.WriteLine("Added new employee to end of the list : ");
            Console.WriteLine("----------------------------------------");
            //Console.WriteLine(string.Join(",", employees.Append("Super Mario")));
            employees.Append(new Employee("Super", "Mario", 33, 14)).ToList().ForEach(x=> Console.WriteLine($"{ x.FullName}, {x.Age}, {x.YearsOfExperience} "));
            

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
