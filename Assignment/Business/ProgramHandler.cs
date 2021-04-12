using System;
using System.Collections.Generic;
using System.Text;
using Assignment.utility;
namespace Assignment.Business
{
    static class ProgramHandler
    {
        /// <summary>
        /// Takes input from user for filepath
        /// </summary>
        /// <returns></returns>
        public static String Fileinput()
        {
            String filepath = default;
            try {
                Console.WriteLine(Constants.Enterfilename);
                filepath = Console.ReadLine(); }
            catch(Exception e)
            {
                throw e;
            }
            return filepath;
        }
        /// <summary>
        /// Displays menu of functionality available and users can select the action he like to perform.
        /// </summary>
        /// <param name="obj"></param>
        public static void Runprogram(Business.ProcessEmployee obj)
        {

            int inputvalue = Getinput();// Displays menu of functionality available and users can select the action he like to perform.
            switch (inputvalue)
            {
                case 1:
                    obj.Display(); //display available data
                    break;
                case 2:
                    obj.Sortdata_name();    //sort data according to name
                    obj.Display();          //Display data
                    break;
                case 3:
                    obj.Sortdata_id();      //sort data according to id
                    obj.Display();          //display data
                    break;
                case 4:
                    int employeeid = Getidinput();  //get input from user
                    String managername = obj.GetMangerName(employeeid); //get manager name
                    Console.WriteLine("Direct reporting Manager is:" + managername);//display manager name
                    break;
                case 5:
                    int managerid = Getidinput();   //get manager id as input form user
                    obj.GetMembers(managerid);      //display all reporting members data
                    break;
                default:
                    break;
            }
            //below code make the program run again until user choose to exit.
            if (inputvalue != 6)
            {
                Console.WriteLine(Constants.Endlinedots);
                Runprogram(obj);
            }

            else
            {
                Console.WriteLine(Constants.Thankyoumessage); //Thankyou message and program exits}

            }
        }
        /// <summary>
        /// Takes employee id as input and returns int type id value.
        /// </summary>
        /// <returns></returns>
        public static int Getidinput()
        {
            int inputvalue = default;
            Console.WriteLine(Constants.EnterEmpId);
            try
            {
                inputvalue = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(Constants.InvalidEmpid);
                return Getidinput();
            }
            return inputvalue;

        }
        /// <summary>
        /// Displays Menu of options available and takes valid input from user and returns a valid input.
        /// </summary>
        /// <returns></returns>
        public static int Getinput()
        {
            Console.WriteLine(Constants.MenuDisplay);
            int inputvalue = default;
            try
            {
                inputvalue = Convert.ToInt32(Console.ReadLine());
                if (inputvalue > 6 || inputvalue < 1)
                {
                    Console.WriteLine(Constants.InvalidSelectOption);
                    return Getinput();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(Constants.InvalidInput);
                return Getinput();
            }
            return inputvalue;
        }

       
    }
}
