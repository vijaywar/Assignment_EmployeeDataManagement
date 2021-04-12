using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataLayer
{
    class Employee
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
}
