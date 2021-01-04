using System;
using System.Collections.Generic;
using System.Text;


namespace MoviePlexProject
{
   
    class Guest
    {
        public static void main()
        {
            guestCentreheading();
            displayMovieShows();
            userInput();

        }

        private static void guestCentreheading()
        {
            Console.Clear();
            string drawstars = "**********************************";
            string welcomeText = "***Welcome to MoviePlex Theater***";

            Console.Write(new string(' ', (Console.WindowWidth - drawstars.Length) / 2));
            Console.WriteLine(drawstars);
            Console.Write(new string(' ', (Console.WindowWidth - welcomeText.Length) / 2));
            Console.WriteLine(welcomeText);
            Console.Write(new string(' ', (Console.WindowWidth - drawstars.Length) / 2));
            Console.WriteLine(drawstars);
        }

        private static void displayMovieShows()
        {
            int arrLength = Administrator.movieName.Length;
            Console.WriteLine($"There are {arrLength} movies playing today.Please choose from the following movies");
            for(int i = 0; i<arrLength; i++)
            {
                Console.WriteLine(i + 1 + ". " + Administrator.movieName[i] + " {" + Administrator.age[i] + "}");
            }
        }

        private static void userInput()
        {
            try
            {
                Console.WriteLine("\nWhich Movie Would You Like To Watch: ");
                int userMovieSelection = Convert.ToInt32(Console.ReadLine());
                
            
                if (userMovieSelection > 0 && userMovieSelection <= Administrator.movieName.Length)
                {
                    Console.WriteLine("Please Enter Your Age For Verification");
                    int userAge = Convert.ToInt32(Console.ReadLine());
                    int varForFetchingArray = userMovieSelection - 1;
                    string valAtAgeIndex = Administrator.age[varForFetchingArray].ToString();
                    bool isValidUserAge = userAgeValidation(userAge);
                    if (isValidUserAge)
                    {
                        if(validatingUserEntry(valAtAgeIndex.Trim(), userAge))
                        {
                            Console.WriteLine("Enjoy Your Movie");
                            mainMenuScreen();
                        }
                        else
                        {
                            Console.WriteLine("Can't Watch Movie. You are Under Age");
                            mainMenuScreen();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input.");
                        mainMenuScreen();

                    }
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                    userInput();
                }
            }
            
            
            catch (Exception)
            {
                Console.WriteLine("Invalid Input");
                Console.Clear();
                main();
            }

        }

        private static void mainMenuScreen()
        {
            Console.WriteLine("Press M to go back to the Guest Main Menu.\nPress S  to go back  to Start Page.");
            try
            {
                ConsoleKeyInfo userMenuOption = Console.ReadKey();
                
                if(userMenuOption.KeyChar == 'm' || userMenuOption.KeyChar == 'M')
                {
                    Guest.main();
                }else if(userMenuOption.KeyChar == 's' || userMenuOption.KeyChar =='S')
                {
                    Console.Clear();
                    Administrator.numberOfinvokes = 4;
                    step1.center_HeadingText();
                }
                else
                {
                    Console.WriteLine("Invalid Entry\n");
                    mainMenuScreen();
                }
            }
            catch
            {
               mainMenuScreen();
            }
        }

        private static bool validatingUserEntry(string valAtAgeIndex ,int userAge)
        {
            var ageRating = new Dictionary<string, int>();
            ageRating.Add("G", 0);
            ageRating.Add("PG", 10);
            ageRating.Add("PG-13" ,13);
            ageRating.Add("R",15);
            ageRating.Add("NC-17",17);
            

            valAtAgeIndex.ToUpper();
            int tryParseint = 0;
            bool parseSuccessForUsrEntry = int.TryParse(valAtAgeIndex , out tryParseint);

            if (!parseSuccessForUsrEntry && ageRating.TryGetValue(valAtAgeIndex, out int ageRatingValue))
            {
                
                    if (userAge >= ageRatingValue && userAge > 0 && userAge < 120)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
        
            }
            else 
            {
                if (userAge >= tryParseint)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            
        }

        private static bool userAgeValidation(int userAge)
        {
            if(userAge > 0 && userAge < 120 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
