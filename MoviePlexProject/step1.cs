using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePlexProject
{
    class step1
    {
        public static void center_HeadingText()
        {
            string drawstars = "**********************************";
            string welcomeText = "***Welcome to MoviePlex Theater***";

            Console.Write(new string(' ', (Console.WindowWidth - drawstars.Length) / 2));
            Console.WriteLine(drawstars);
            Console.Write(new string(' ', (Console.WindowWidth - welcomeText.Length) / 2));
            Console.WriteLine(welcomeText);
            Console.Write(new string(' ', (Console.WindowWidth - drawstars.Length) / 2));
            Console.WriteLine(drawstars);
             Console.WriteLine("\n\nPlease Select From Following Options:\n1: Administrator\n2: Guests");
            userSelection();
        }

        public static void userSelection()
        {
           
            Console.Write("\n\nSelection:");
            try
            {
                int selection = Convert.ToInt32(Console.ReadLine());

                if (selection == 1)
                {
                    Administrator.adminManager();
                }
                else if (selection == 2)
                {
                    if(Administrator.movieName == null)
                    {
                        
                        Console.WriteLine("NO SHOWS BECAUSE OF CORONA VIRUS");
                        userSelection();

                    }
                    else
                    {
                        Guest.main();
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid selection");
                    userSelection();
                }
            }
            catch (Exception)
            {
                Console.WriteLine( "Please Enter a Valid Entry");
                userSelection();
            }
        }
    }
}
