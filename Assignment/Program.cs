using System;
using Assignment.utility;
namespace Assignment
{
    
    class Program
    {
        static void Main(string[] args)
        {
            try { 
            Console.WriteLine(Constants.Greetings);     //Display Greeting message
            Business.ProcessEmployee obj = Business.ProcessEmployee.getInstance();
                String filepath = Business.ProgramHandler.Fileinput();      //gets file path input from user
            obj.Readdata(filepath); //reads the file and load data to employee list
            obj.Display();          //displays the employee data loaded
            Business.ProgramHandler.Runprogram(obj);    //Displays available functionality and guide how to use them.
            }
            catch(Exception e)
            {
                Console.WriteLine(Constants.Errormessage1+ Constants.Errormessage3+e.Message+Constants.Errormessage4+e.StackTrace +utility.Constants.Errormessage2);
            }
        }

        
    }
}
