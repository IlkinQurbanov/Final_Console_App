using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Console_App
{
    public class Student
    {
        
        public string FullName { get; set; } 
        public GroupType GroupType { get; } 
        public string GroupNo { get; } 
        public double Point { get; set; } 

        public Student(string fullName, GroupType groupType, string groupNo, double point)
        {
    
            if (string.IsNullOrEmpty(fullName) || fullName.Split().Length < 2 || fullName.Any(char.IsDigit) || fullName.Any(char.IsSymbol))
            {
                throw new ArgumentException("Tələbənin tam adı yanlıshdır");
            }

            if (string.IsNullOrEmpty(groupNo) || groupNo.Length != 4 || groupNo[0] != groupType.ToString()[0] || !groupNo.Substring(1).All(char.IsDigit))
            {
                throw new ArgumentException("Telebenin qrup nomresi duzgun deyil");
            }

            if (point < 0 || point > 100)
            {
                throw new ArgumentException("Telebenin bali duzgun deyil");
            }

            
            FullName = fullName;
            GroupType = groupType;
            GroupNo = groupNo;
            Point = point;
        }

        
        public void PrintInfo()
        {
            Console.WriteLine($"Tam Ad: {FullName}");
            Console.WriteLine($"Qrupun Tipi: {GroupType}");
            Console.WriteLine($"Qrupun Nomresi: {GroupNo}");
            Console.WriteLine($"Ball: {Point}");
        }
    }
}
