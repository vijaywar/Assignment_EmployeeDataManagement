using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            employee obj = employee.getInstance();
            obj.Readdata("./data.csv");
            obj.Display();
            Runprogram(obj);
           
        }

        public static void Runprogram(employee obj)
        {
            
            int inputvalue = getinput();
            switch (inputvalue)
            {
                case 1:
                    obj.Display();
                    break;
                case 2:
                    obj.Sortdata_name();
                    obj.Display();
                    break;
                case 3:
                    obj.Sortdata_id();
                    obj.Display();
                    break;
                case 4:
                    Console.WriteLine(obj.GetMangerName(getidinput()));
                    break;
                case 5:
                    obj.GetMembers(getidinput());
                    break;
                default:
                    break;
            }
            if (inputvalue != 6) {
                Console.WriteLine("................................................*..................................."); 
                Runprogram(obj); }
            else { Console.WriteLine("...............................Thank You!...................."); }

        }
        public static int getidinput()
        {
            int inputvalue = default;
            Console.WriteLine("Enter Employee id: ");
            try
            {
                inputvalue = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input enter employee id, try again!");
                return getidinput();
            }
            return inputvalue;
           
        }
        public static int getinput()
        {
            Console.WriteLine("Press 1 to display data of all employees\nPress 2 to sort data with names\nPress 3 to sort data with id" +
                "\nPress 4 to get Manager name of a employee\nPress 5 to know all the employees reporting to a manager\nPress 6 to Exit!");
            int inputvalue = default;
            try { inputvalue=Convert.ToInt32( Console.ReadLine()); 
            if(inputvalue>6 || inputvalue < 1)
                {
                    Console.WriteLine("Invalid input select form the menu above!");
                    return getinput();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid input try again!");
                return getinput();
            }
            return inputvalue;
        }
    }
}
