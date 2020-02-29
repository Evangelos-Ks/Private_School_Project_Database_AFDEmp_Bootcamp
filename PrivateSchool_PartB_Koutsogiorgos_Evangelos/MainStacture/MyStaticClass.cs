using System;

namespace MainStacture
{
    public static class MyStaticClass
    {

        //Input Date, check and return Date. If go to catch the date that returned is 1/1/0001.----------------------------------------------------
        public static DateTime InputDate()
        {
            string inputDate = Console.ReadLine();
            DateTime date = new DateTime();

            try
            {
                date = DateTime.Parse(inputDate);
                return date;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tPlease give the right form of date.");
                Console.ForegroundColor = ConsoleColor.White;
                return date;
            }
        }

        //Press a key to continue-------------------------------------------------------------------------------------------------------
        public static void PressKeyToContinue()
        {

            Console.WriteLine();
            Console.Write("\tPress a key to go back in menu : ");
            Console.ReadKey();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t=================================================================================\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Ask a string and try to Convert to int-------------------------------------------------------------------------------------------
        public static int InputTryToConvertToInt()
        {
            bool notSuccededAdd;
            int userInput;

            do
            {
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                    notSuccededAdd = false;
                }
                catch (Exception)
                {
                    notSuccededAdd = true;
                    userInput = 0;
                }

            } while (notSuccededAdd);

            return userInput;
        }
       
    }
}
