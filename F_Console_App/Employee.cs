using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Console_App
{
    public class Employee
    {
        
        private static int counter = 1000;

        
        public string Id { get; } 
        public string FullName { get; set; } 
        public string Position { get; set; } 
        public decimal Salary { get; set; } 
        public Department Department { get; } 
        public EmployeeType EmployeeType { get; } 

        
        public Employee(string fullName, string position, decimal salary, Department department, EmployeeType employeeType)
        {
            
            if (string.IsNullOrEmpty(fullName) || fullName.Split().Length < 2 || fullName.Any(char.IsDigit) || fullName.Any(char.IsSymbol))
            {
                throw new ArgumentException("Ad ve Familiya duzgun daxil edilmeyib");
            }

            if (string.IsNullOrEmpty(position) || position.Length < 2)
            {
                throw new ArgumentException("ISCININ VEZIFESI DUZGUN DAXIL EDILMEYIB");
            }

            if (salary < 250)
            {
                throw new ArgumentException("Ischinin maashi duzgun daxil edilmeyin");
            }

            if (department == null)
            {
                throw new ArgumentNullException("Shobe swcillmelidir!");
            }

            FullName = fullName;
            Position = position;
            Salary = salary;
            Department = department;
            EmployeeType = employeeType;

            Id = department.ToString().Substring(0, 2).ToUpper() + (++counter).ToString("D4");
        }


        public void PrintInfo()
        {
            Console.WriteLine($"Nomre: {Id}");
            Console.WriteLine($"Ad ve Familia: {FullName}");
            Console.WriteLine($"Vezife: {Position}");
            Console.WriteLine($"Maash: {Salary}");
            Console.WriteLine($"Shobe: {Department.ToString()}");
            Console.WriteLine($"Tip: {EmployeeType}");
        }
    }
}
