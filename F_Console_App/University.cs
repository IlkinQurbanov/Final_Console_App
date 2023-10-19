using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Console_App
{
    public class University
    {
        
        public string Name { get; } 
        public int WorkerLimit { get; } 
        public decimal SalaryLimit { get; } 
        public List<Employee> Employees { get; } 
        public List<Student> Students { get; } 

        
        public University(string name, int workerLimit, decimal salaryLimit)
        {
            
            if (string.IsNullOrEmpty(name) || name.Length < 2)
            {
                throw new ArgumentException("Universitetin adin duzgun daxil edin");
            }

            if (workerLimit < 1)
            {
                throw new ArgumentException("Universitetde ishcilerin maksimum sayı duzgun deyil");
            }

            if (salaryLimit < 250)
            {
                throw new ArgumentException("Yanlish Emek haqqi");
            }

            
            Name = name;
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;

            
            Employees = new List<Employee>();
            Students = new List<Student>();
        }

        
        public decimal CalcSalaryAverage()
        {
            if (Employees.Count == 0) return 0; 

            return Employees.Average(e => e.Salary); 
        }
        


        public double CalcStudentsAverage(string groupNo)
        {
            
            if (string.IsNullOrEmpty(groupNo) || groupNo.Length != 4 || !groupNo.Substring(1).All(char.IsDigit))
            {
                throw new ArgumentException("Qrupun nomresi duzgun deyil");
            }

            
            var studentsInGroup = Students.Where(s => s.GroupNo == groupNo).ToList();

            if (studentsInGroup.Count == 0) return 0; 

            return studentsInGroup.Average(s => s.Point); 
        }



        
        public void AddEmployee(Employee employee)
        {
            
            if (employee == null)
            {
                throw new ArgumentNullException("Ischi null ola bilmez");
            }

            if (Employees.Count >= WorkerLimit)
            {
                throw new InvalidOperationException("Universitet personal limitine chatdi");
            }

            if (Employees.Sum(e => e.Salary) + employee.Salary > SalaryLimit)
            {
                throw new InvalidOperationException("Universitet maash limitine chatdi");
            }

            
            Employees.Add(employee);
        }

        



        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Telebe sifir ola bilmez");
            }

            
            Students.Add(student);
        }

        
        public void UpdateEmployee(string id, string position, decimal salary)
        {
            
            if (string.IsNullOrEmpty(id) || id.Length != 6 || !id.Substring(2).All(char.IsDigit))
            {
                throw new ArgumentException("tELEBENIN NOMRESI DUZGUN DEYIL");
            }

            if (string.IsNullOrEmpty(position) || position.Length < 2)
            {
                throw new ArgumentException("Yanlıs ishci vezifesi ");
            }

            if (salary < 250)
            {
                throw new ArgumentException("Maash sef daxil edilib");
            }

            
            var employee = Employees.Find(e => e.Id == id);

            if (employee == null)
            {
                throw new KeyNotFoundException("Bu nomre ile ischi tapilmadi");
            }

            
            employee.Position = position;
            employee.Salary = salary;
        }

        
        public void UpdateStudent(string fullName, double point)
        {
            
            if (string.IsNullOrEmpty(fullName) || fullName.Split().Length < 2 || fullName.Any(char.IsDigit) || fullName.Any(char.IsSymbol))
            {
                throw new ArgumentException("telebenin tam adi duzgun deyil");
            }

            if (point < 0 || point > 100)
            {
                throw new ArgumentException("Telebenin bali duzgun daxil edilmiyibler");
            }

            
            var student = Students.Find(s => s.FullName == fullName);

            if (student == null)
            {
                throw new KeyNotFoundException("Bu ad ile yoxdur");
            }

            
            student.Point = point;
        }

        
        public void RemoveEmployee(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Length != 6 || !id.Substring(2).All(char.IsDigit))
            {
                throw new ArgumentException("Ischinin nomresin duzgun dacil et");
            }

            
            var employee = Employees.Find(e => e.Id == id);

            if (employee == null)
            {
                throw new KeyNotFoundException("BU NOMRE ILE ISCHI YPILMADI");
            }

            
            Employees.Remove(employee);
        }

        public void RemoveStudent(string fullName)
        {
            
            if (string.IsNullOrEmpty(fullName) || fullName.Split().Length < 2 || fullName.Any(char.IsDigit) || fullName.Any(char.IsSymbol))
            {
                throw new ArgumentException("TELEBENIN TAM ADI YANLISFIR");
            }

            
            var student = Students.Find(s => s.FullName == fullName);

            if (student == null)
            {
                throw new KeyNotFoundException("BU ADLA TELEBE TAPILMADI");
            }

            
            Students.Remove(student);
        }
    }
}
