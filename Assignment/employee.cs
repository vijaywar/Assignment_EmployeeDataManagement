using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    class employee
    {
        static employee obj=null;
        private employee()
        {

        }
        public static employee getInstance()
        {
            obj = new employee();
            
            return obj;
        }
        struct Employee
        {
            int employee_id; int? reporting_manager_id;
            String name, email_id;
            public Employee(int id, String name, int? mid, String email)
            {
                this.employee_id = id;
                this.reporting_manager_id = mid;
                this.name = name;
                this.email_id = email;
            }

            public int Employee_id
            {
                get { return employee_id; }
                set { employee_id = value; }
            }

            public int? Reporting_manager_id
            {
                get { return reporting_manager_id; }
                set { reporting_manager_id = value; }
            }
            public String Name
            {
                get { return name; }
                set { name = value; }
            }
            public String Email_id
            {
                get { return email_id; }
                set { email_id = value; }
            }
        }
        
        private static List<Employee> employeedata = new List<Employee>();
        private static Dictionary<int, int?> All_emp_mid = new Dictionary<int, int?>();


        public  void Readdata(String filename)
        {
            string line;
            System.IO.StreamReader file = null;
            try { file = new System.IO.StreamReader(filename);
            }
            catch (Exception e) { Console.WriteLine(e); }
            //check for file status.
            if (file != null)
            {
                while ((line = file.ReadLine()) != null)
                {
                    String[] arr = line.Split(",");
                    // check for format 
                    if (arr.Length == 4)
                        Adddata(arr);
                    else
                        Console.WriteLine("Error in data format!" + "ID :" + arr[1] + " ,name " + arr[1]);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Error in file opening check the path and read write access.............\n\n\n\n Exit program and check the file path and run again!\n\n.");
            }
        }
        //this funciton is used by readdata function to add data to employee collection
        private static void Adddata(String[] arr)
        {
            try
            {
                int employee_id = Convert.ToInt32(arr[0]);
                //check for duplicate check and if manager is available or null
                if (!All_emp_mid.ContainsKey(employee_id) && arr[2] != "null")
                {
                    All_emp_mid.Add(employee_id, Convert.ToInt32(arr[2]));
                    employeedata.Add(new Employee(employee_id, arr[1], Convert.ToInt32(arr[2]), arr[3]));

                }

                else if (!All_emp_mid.ContainsKey(Convert.ToInt32(arr[0])) && arr[2] == "null")
                {
                    All_emp_mid.Add(employee_id, null);
                    employeedata.Add(new Employee(employee_id, arr[1], null, arr[3]));

                }

                else
                    throw new RecordDuplicateException("ID :" + arr[1] + " ,name " + arr[1]);
            }
            catch (Exception e)
            {
                if (!(e is RecordDuplicateException))
                    Console.WriteLine("Error in data" + arr[0] + " " + arr[2] + e);
            }
        }
        //this function is used to sort with id
        public void Sortdata_id()
        {
            employeedata.Sort((a, b) => a.Employee_id.CompareTo(b.Employee_id));

        }
        //this function is used to sort with name
        public void Sortdata_name()
        {
            employeedata.Sort((a, b) => a.Name.CompareTo(b.Name));

        }
        //this funcitn is used to display data
        public  void Display()
        {
            foreach (Employee i in employeedata)
            {
                Console.WriteLine(i.Employee_id + " " + i.Name + " " + i.Email_id);
            }
            Console.WriteLine("........*.........*.........*......\n");
        }
        //this function is used to list all the members report to a given manager.
        public  void GetMembers(int id, int sub = 0)
        {
            if (emp_exists(id)) { 
            String dash;
            foreach (Employee emp in employeedata)
            {
                dash = "--- ";
                int i = sub;
                if (emp.Reporting_manager_id == id)
                {
                    while (i > 0) { dash += dash; i--; }
                    Console.WriteLine(dash + ">" + emp.Employee_id + " " + emp.Name);
                
                    GetMembers(emp.Employee_id, sub + 1);

                }
            }
            }
            else
            {
                Console.WriteLine("Sorry Employee Doesn't Exists please check the id!");
            }
        }
        //This function is used to get the manager name of the given employee
        public string GetMangerName(int id)
        {
            if (emp_exists(id))
                return employeedata.Find(x => x.Employee_id == employeedata.Find(i => i.Employee_id == id).Reporting_manager_id).Name;
            else
                return "Sorry Check employee id , Provided id employee not exists!";
        }

        private static bool emp_exists(int id)
        {
            return All_emp_mid.ContainsKey(id);
        }
    }

    public class RecordDuplicateException : Exception
    {
        public RecordDuplicateException(string message) : base(message)
        {
            Console.WriteLine("Data Duplicated ..... " + message);
        }
    }
}

