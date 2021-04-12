using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.utility
{
    static class Constants
    {
        static public String Greetings = "Hello World!";
        static public String Errormessage1 = "\nError Occured!";
        static public String Errormessage3 = "\n\nException Name :   ";
        static public String Errormessage4 = "\n\nException path :  ";
        static public String Errormessage2 = "\n\nAbove error occured!";

        static public String Enterfilename = "Enter file path to read data :";
        static public String Endlinedots = "................................................*...................................";
        static public String Thankyoumessage = "...............................Thank You!....................";
        static public String EnterEmpId = "Enter Employee id: ";
        static public String InvalidEmpid = "Enter Employee id: ";
        static public String MenuDisplay = "Press 1 to display data of all employees\n" +
            "Press 2 to sort data with names\n" +
            "Press 3 to sort data with id" +
            "\nPress 4 to get Manager name of a employee\n" +
            "Press 5 to know all the employees reporting to a manager\n" +
            "Press 6 to Exit!";
        static public String InvalidSelectOption = "Invalid input select form the menu above!";
        static public String InvalidInput = "Invalid input try again!";


        static public String InvalidDataFormat="Error in data format line: ";
        static public String Invlidpath = "Error in file opening check the path and read write access.............\n\n\n\n Exit program and check the file path and run again!\n\n.";
        static public String NoManger = "null";
        static public String NoEmpRecord = "Sorry Employee Doesn't Exists please check the id!";
        static public String DataDuplicate = "Data Duplicated of employee error handled and only one copy of data is loaded to database ..... ";

        static public String DataDisplayHead = "Employee ID | Employee Name | Manager ID ";
    }
}
