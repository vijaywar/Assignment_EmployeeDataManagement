using System;
using System.Collections.Generic;
using System.Text;
using Assignment.utility;
namespace Assignment.Business
{
    class ProcessEmployee
    {
            static ProcessEmployee obj = null;
            //private constructor 
            private ProcessEmployee()
            {

            }
            //only one object is created and refernce to that object is provided by this funciton
            public static ProcessEmployee getInstance()
            {
                if(obj==null)
                obj = new ProcessEmployee();

                return obj;
            }

            private static List<DataLayer.Employee> employeedata = new List<DataLayer.Employee>();
            private static Dictionary<int, int?> All_emp_mid = new Dictionary<int, int?>();


        /// <summary>
        /// takes file path as input and reads the file provided and add data to datamodel employee
        /// </summary>
        /// <param name="filename"></param>
            public void Readdata(String filename)
            {
                string line;
                System.IO.StreamReader file = null;
                try
                {
                    file = new System.IO.StreamReader(filename);
                }
                catch (Exception e) { throw e; }
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
                            Console.WriteLine(Constants.InvalidDataFormat +line );
                    }
                    file.Close();
                }
                else
                {
                    Console.WriteLine(Constants.Invlidpath);
                }
            }


        /// <summary>
        /// this funciton is private used by readdata function to add data to employee collection
        /// </summary>
        /// <param name="arr"></param>
        private static void Adddata(String[] arr)
            {
                try
                {
                    int employee_id = Convert.ToInt32(arr[0]);
                    //check for duplicate check and if manager is available or null
                    if (!All_emp_mid.ContainsKey(employee_id) && arr[2] != Constants.NoManger)
                    {
                        All_emp_mid.Add(employee_id, Convert.ToInt32(arr[2]));
                        employeedata.Add(new DataLayer.Employee(employee_id, arr[1], Convert.ToInt32(arr[2]), arr[3]));

                    }

                    else if (!All_emp_mid.ContainsKey(Convert.ToInt32(arr[0])) && arr[2] == Constants.NoManger)
                    {
                        All_emp_mid.Add(employee_id, null);
                        employeedata.Add(new DataLayer.Employee(employee_id, arr[1], null, arr[3]));

                    }

                    else
                        throw new RecordDuplicateException("ID :" + arr[1] + " ,name " + arr[1]); //error throw if duplicate data is passed
                }
                catch (Exception e)
                {
                    if (!(e is RecordDuplicateException))
                        Console.WriteLine("Error in data" + arr[0] + " " + arr[2] + e);
                }
            }
            /// <summary>
            /// This function sorts the data of employees available according to id.
            /// </summary>
            public void Sortdata_id()
            {
                employeedata.Sort((a, b) => a.Employee_id.CompareTo(b.Employee_id));

            }
        /// <summary>
        ///  This function sorts the data of employees available according to name.
        /// </summary>
        public void Sortdata_name()
            {
                employeedata.Sort((a, b) => a.Name.CompareTo(b.Name));

            }
        
        /// <summary>
        /// this funcitn is used to display data
        /// </summary>
        public void Display()
            {
            Console.WriteLine(Constants.DataDisplayHead);
                foreach (DataLayer.Employee i in employeedata)
                {
                    Console.WriteLine(i.Employee_id + " | " + i.Name + " | " + i.Email_id);
                }
                Console.WriteLine(Constants.Endlinedots);
            }
        /// <summary>
        /// this function is used to list all the members report to a given manager.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sub"></param>
        public void GetMembers(int id, int sub = 0)
            {
                if (emp_exists(id))
                {
                    String dash;
                    foreach (DataLayer.Employee emp in employeedata)
                    {
                        dash = "--- ";  //used so the data is displayed correctly 
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
                    Console.WriteLine(Constants.NoEmpRecord);
                }
            }
        
        /// <summary>
        /// This function is used to get the manager name of the given employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetMangerName(int id)
            {
            if (emp_exists(id))
                return employeedata.Find(x => x.Employee_id == employeedata.Find(i => i.Employee_id == id).Reporting_manager_id).Name;
            else
                return Constants.NoEmpRecord;
            }

            private static bool emp_exists(int id)
            {
                return All_emp_mid.ContainsKey(id);
            }
        

       
    }
    /// <summary>
    /// This class handles the Exception if data is duplicated in a file.
    /// </summary>
    public class RecordDuplicateException : Exception
    {
        public RecordDuplicateException(string message) : base(message)
        {
            Console.WriteLine(Constants.DataDuplicate+ message);
        }
    }
}
