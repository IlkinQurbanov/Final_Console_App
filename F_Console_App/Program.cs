


using F_Console_App;

class Program
{
    static void Main(string[] args)
    {
        
        University university = new University("ADA", 100, 1000000);

       

        
        //Console.WriteLine($"Universitetin adi: {university.Name}");
        //Console.WriteLine($"Ischilerin limiyi: {university.WorkerLimit}");
        //Console.WriteLine($"Massh limiti: {university.SalaryLimit}");
        //Console.WriteLine($"Ischileriin sayi: {university.Employees.Count}");
        //Console.WriteLine($"Telebelerin sayi: {university.Students.Count}");
        //Console.WriteLine($"Ischilerin orta maaashi: {university.CalcSalaryAverage()}");
        //Console.WriteLine($"Butun tekebelerin orta nali: {university.CalcStudentsAverage("")}");

        
        Console.WriteLine("Emeliyyati sechin:");
        Console.WriteLine("1.1 - Studentlerin siyahisini gostermek (groupno isteniler biler)");
        Console.WriteLine("1.2 – Telebe elave etmek");
        Console.WriteLine("1.3 - Telebeye deyisiklik etmek");
        Console.WriteLine("1.4 - Telebelerin orta bali");
        Console.WriteLine("2.1 - Iscilerin siyahisi");
        Console.WriteLine("2.2 - Ischilerin sayini gostermek Departmen uzre");
        Console.WriteLine("2.3 - Ischi elave et");
        Console.WriteLine("2.4 - Ischiye deyisiklik et");
        Console.WriteLine("2.5 - Ischini silmek ");
        Console.WriteLine("3 - Cixis");

        
        while (true)
        {
            
            string input = Console.ReadLine();

            
            switch (input)
            {
                case "1.1": 
                    ShowStudents(university); 
                    break;
                case "1.2": 
                    CreateStudent(university); 
                    break;
                case "1.3": 
                    UpdateStudent(university); 
                    break;
                case "1.4": 
                    ShowStudentsAverage(university); 
                    break;
                case "2.1": 
                    ShowEmployees(university); 
                    break;
                case "2.2": 
                    ShowEmployeesByDepartment(university); 
                    break;
                case "2.3": 
                    AddEmployee(university); 
                    break;
                case "2.4": 
                    UpdateEmployee(university); 
                    break;
                case "2.5": 
                    RemoveEmployee(university); 
                    break;
                case "3": 
                    return; 
                default: 
                    Console.WriteLine("Duzgun sechim deyil, Yeniden cehd edin"); 
                    break;
            }
        }
    }




    
    static void ShowStudents(University university)
    {
        Console.WriteLine("Hansisa qrupun telebelrin gormek isteyirsiz? (y/n)"); 

        string answer = Console.ReadLine(); 

        if (answer == "y") 
        {
            Console.WriteLine("Grupun nomresin daxil et:"); 

            string groupNo = Console.ReadLine(); 

            var studentsInGroup = university.Students.Where(s => s.GroupNo == groupNo).ToList(); 

            if (studentsInGroup.Count == 0) 
            {
                Console.WriteLine("Bu qrupda telebe yoxdur"); 
            }
            else 
            {
                Console.WriteLine($"Bu qrupdaki telebe sayi {groupNo}:"); 

                foreach (var student in studentsInGroup) 
                {
                    student.PrintInfo(); 
                    Console.WriteLine(); 
                }
            }
        }
        else if (answer == "n") 
        {
            if (university.Students.Count == 0) 
            {
                Console.WriteLine("Universitetde telebe yoxdur"); 
            }
            else 
            {
                Console.WriteLine("Butun telebelerin siyahisi:"); 

                foreach (var student in university.Students) 
                {
                    student.PrintInfo(); 
                    Console.WriteLine(); 
                }
            }
        }
        else 
        {
            Console.WriteLine("Duzgun cavab deyil yeniden daxil edin"); 
        }
    }

    
    static void CreateStudent(University university)
    {
        Console.WriteLine("Telebenin tam adin daxil edin:"); 

        string fullName = Console.ReadLine(); 

        Console.WriteLine("Telebenin qrup tinin sechin:"); 

        foreach (var groupType in Enum.GetValues(typeof(GroupType))) 
        {
            Console.WriteLine(groupType); 
        }

        string groupTypeInput = Console.ReadLine(); 

        GroupType groupTypeParam; 

        if (!Enum.TryParse(groupTypeInput, out groupTypeParam)) 
        {
            Console.WriteLine("Qrupun tipi duzgun deyil"); 
            return; 
        }

        Console.WriteLine("Telebeninin qrupun daxil edin:"); 

        string groupNo = Console.ReadLine(); 

        Console.WriteLine("Telebenin balin daxil edin:"); 

        string pointInput = Console.ReadLine(); 

        double point; 

        if (!double.TryParse(pointInput, out point)) 
        {
            Console.WriteLine("Bali duzgun daxil edin"); 
            return; 
        }

        try 
        {
            Student student = new Student(fullName, groupTypeParam, groupNo, point); 

            university.AddStudent(student); 

            Console.WriteLine("Telebe uqurla elave olunub"); 
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message); 
        }
    }

    
    static void UpdateStudent(University university)
    {
        Console.WriteLine("Deyishmek istediyiniz telebenin tam adin daxil edin:"); 

        string fullName = Console.ReadLine(); 

        var student = university.Students.Find(s => s.FullName == fullName); 

        if (student == null) 
        {
            Console.WriteLine("Bu adda telebe tapilmadi"); 
            return; 
        }

        Console.WriteLine("Telebenin yeni balin yazin:"); 

        string pointInput = Console.ReadLine(); 

        double point; 

        if (!double.TryParse(pointInput, out point)) 
        {
            Console.WriteLine("Duzgun ball deyil , yeniden cehd edin"); 
            return; 
        }

        try 
        {
            university.UpdateStudent(fullName, point); 

            Console.WriteLine("Telebe uqurla elave olundu"); 
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message); 
        }
    }


    
    static void ShowStudentsAverage(University university)
    {
        Console.WriteLine("Hansisa qrupunun telebelerin ortalama balin gormek isteyirsiz ? (y/n)"); 

        string answer = Console.ReadLine(); 

        if (answer == "y") 
        {
            Console.WriteLine("Qrupun nomresin daxil et:"); 

            string groupNo = Console.ReadLine(); 

            double average = university.CalcStudentsAverage(groupNo); 

            Console.WriteLine($"Bu qrupdaki ortalama bal {groupNo}: {average}"); 
        }
        else if (answer == "n") 
        {
            double average = university.CalcStudentsAverage(""); 

            Console.WriteLine($"Butun telebelrin orta bali: {average}"); 
        }
        else 
        {
            Console.WriteLine("Cavab duzgun deyil yeniden cehd"); 
        }
    }

    
    static void ShowEmployees(University university)
    {
        if (university.Employees.Count == 0) 
        {
            Console.WriteLine("Universitetde ishci yoxdur"); 
        }
        else 
        {
            Console.WriteLine("Butun ishcilerin siyahisi:"); 

            foreach (var employee in university.Employees) 
            {
                employee.PrintInfo(); 
                Console.WriteLine(); 
            }
        }
    }

    
    static void ShowEmployeesByDepartment(University university)
    {
        Console.WriteLine("Shobenin nomresin daxil et:"); 

        string departmentInput = Console.ReadLine(); 

        Department department; 

        if (!Enum.TryParse(departmentInput, out department)) 
        {
            Console.WriteLine("Shobenin adi duzgun deyil"); 
            return; 
        }

        var employeesInDepartment = university.Employees.Where(e => e.Department == department).ToList(); 

        if (employeesInDepartment.Count == 0) 
        {
            Console.WriteLine("Bu shoebede ishiler yoxdur"); 
        }
        else 
        {
            Console.WriteLine($"Bu sobekedeki ishilerin sayi {department}:"); 

            foreach (var employee in employeesInDepartment) 
            {
                employee.PrintInfo(); 
                Console.WriteLine(); 
            }
        }
    }

    
    static void AddEmployee(University university)
    {
        Console.WriteLine("Ishinin ad Familiyadin daxil edin:"); 

        string fullName = Console.ReadLine(); 

        Console.WriteLine("Ishinin Vezifesin daxil edin:"); 

        string position = Console.ReadLine(); 

        Console.WriteLine("Ishinin maashin secin:"); 

        string salaryInput = Console.ReadLine(); 

        decimal salary; 

        if (!decimal.TryParse(salaryInput, out salary)) 
        {
            Console.WriteLine("Maash dzugun deyil yeniden daxil edin"); 
            return; 
        }

        Console.WriteLine("Ishinin shobesin secin:"); 

        foreach (var department in Enum.GetValues(typeof(Department))) 
        {
            Console.WriteLine(department); 
        }

        string departmentInput = Console.ReadLine(); 

        Department departmentParam; 

        if (!Enum.TryParse(departmentInput, out departmentParam)) 
        {
            Console.WriteLine("Duzgun shobe deyil , yeniden cehd edin"); 
            return;
        }

        Console.WriteLine("Ischinin tipin sechin:"); 

        foreach (var employeeType in Enum.GetValues(typeof(EmployeeType))) 
        {
            Console.WriteLine(employeeType); 
        }

        string employeeTypeInput = Console.ReadLine(); 

        EmployeeType employeeTypeParam; 

        if (!Enum.TryParse(employeeTypeInput, out employeeTypeParam)) 
        {
            Console.WriteLine("DUZGUN TIP DEYIL , YENIDEN DAXIL EDIL EDIN"); 
            return; 
        }

        try 
        {
            Employee employee = new Employee(fullName, position, salary, departmentParam, employeeTypeParam); 

            university.AddEmployee(employee); 

            Console.WriteLine("ISHCI UQURLA ELAVE EDILDI"); 
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message); 
        }
    }

    
    static void UpdateEmployee(University university)
    {
        Console.WriteLine("DEYISHMEK ISTEDIYINIZ ISCHINI DAXIL EDIN:"); 

        string id = Console.ReadLine(); 

        var employee = university.Employees.Find(e => e.Id == id); 

        if (employee == null) 
        {
            Console.WriteLine("Bu nomre ile ischi tapilmadi"); 
            return; 
        }

        Console.WriteLine("Yeni vezifeni daxil edin:"); 

        string position = Console.ReadLine();

        Console.WriteLine("Yeni maaashi daxil edin:"); 

        string salaryInput = Console.ReadLine(); 

        decimal salary; 

        if (!decimal.TryParse(salaryInput, out salary)) 
        {
            Console.WriteLine("Maash duzgun deyil, Yeniden cehd edin"); 
            return; 
        }

        try 
        {
            university.UpdateEmployee(id, position, salary); 

            Console.WriteLine("Ischi uqurla deyisildi"); 
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message); 
        }
    }

    
    static void RemoveEmployee(University university)
    {
        Console.WriteLine("Silmek istediyiniz iscinin nomresin yazin:"); 

        string id = Console.ReadLine(); 

        var employee = university.Employees.Find(e => e.Id == id); 

        if (employee == null) 
        {
            Console.WriteLine("Bu nomre ile ischi tapilmadi"); 
            return; 
        }

        try 
        {
            university.RemoveEmployee(id); 

            Console.WriteLine("Ichi ugurla silindi"); 
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message); 
        }
    }
}

