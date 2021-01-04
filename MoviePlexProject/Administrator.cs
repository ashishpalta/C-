using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePlexProject
{
    public enum Counting
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Fifth = 5,
        Sixth = 6,
        Seventh = 7,
        Eighth = 8,
        Ninth = 9,
        Tength = 10

    }




    class Administrator
    {
        public static int numberOfinvokes = 4;
        public static int ctr = 0;
        public static int movieEnumCounter = 1;

        public static string[] movieName;
        public static object[] age;
       

        private static void administrationlogin()
        {

            string userPass = "ashish";


            Console.Write("Please Enter the Admin Password : ");
            string password = Console.ReadLine();

            passwordValidation(password.Trim(), userPass);

         
        }


        private static void administrationlogin(bool validationResult)
        {

            if (validationResult)
            {
                adminMovieManager();
            }
            else if (numberOfinvokes != 0 && !validationResult)
            {
                Console.WriteLine("You entered an Invalid password\nYou have {0} more attempts to enter the correct password OR Press B to go back to the previous screen\n\n", numberOfinvokes--);

                ConsoleKeyInfo backKey = Console.ReadKey(true);
                while (backKey.KeyChar == 'b' || backKey.KeyChar == 'B')
                {
                    Console.Clear();
                    numberOfinvokes = 4;
                    step1.center_HeadingText();
                }
                administrationlogin();
            }
            else
            {
                Console.Clear();
                numberOfinvokes = 4;
                step1.center_HeadingText();
                

            }
        }


        private static void passwordValidation(string password, string userPass)
        {
            password.Trim();
            bool TF = string.Equals(password, userPass);
            if (TF)
            {
                administrationlogin(true);
            }
            else
            {

                administrationlogin(false);

            }
        }

        public static void adminMovieManager()
        {

            Console.Clear();
            Console.Write("Welcome MoviePlex Administrator\n\nHow many Movies are Playing Today? :");
            try
            {

                int MovieCount = Convert.ToInt32(Console.ReadLine());

           
                if (MovieCount > 0 && MovieCount <= 10)
                {

                    movieRecordBook(MovieCount);
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                    adminMovieManager();
                }
            }
            catch
            {
                Console.WriteLine("Invalid Entry");
                Console.Clear();
                adminMovieManager();
            }
            
           
        }
        
        private static void movieRecordBook(int MovieCount)
        {
            List<string> movieRating = new List<string> { "G", "PG", "PG-13", "R", "NC-17" };
             movieName = new string[MovieCount];
             age = new object[MovieCount];


            for (int i = 0; i < MovieCount; i++)
            {
                Console.Write($"\n\nPlease Enter The {Enum.GetName(typeof(Counting), movieEnumCounter)} Movie Name : ");
                string movieNameTri = Console.ReadLine();
                movieNameTri.Trim();

                if (String.IsNullOrEmpty(movieNameTri))
                {
                    
                    movieEnumCounter = 1;
                    Console.Clear();
                    
                    adminMovieManager();
                    Console.WriteLine("You Can't Leave the Space Empty");

                }
                else
                {
                    movieName[i] = movieNameTri;
                }


                Console.Write($"Please Enter The Age Limit or Rating For The {Enum.GetName(typeof(Counting), movieEnumCounter)} Movie : ");
                string ageChecker = Console.ReadLine();
                ageChecker.ToUpper().Trim();
                int number = 0;
                bool parseSuccess = int.TryParse(ageChecker, out number);


                if (parseSuccess)
                {
                    int ageTesterVar = Convert.ToInt32(ageChecker);
                    if (ageTesterVar > 0 && ageTesterVar < 120)
                    {
                        age[i] = ageChecker.Trim();
                        movieEnumCounter++;
                    }
                    else
                    { 
                        Console.Clear();
                        
                        adminMovieManager();
                        Console.WriteLine("Invalid Last Entry. Age Should be between 0 to 120");
 }
                }
                else if (!parseSuccess)
                {
                    string rating = ageChecker.Trim().ToUpper();
                    bool has = movieRating.Contains(rating);
                    if (has)
                    {
                        age[i] = rating.ToUpper().Trim();
                        movieEnumCounter++;
                    }
                    else
                    {
                        
                        Console.Clear();
                        
                        adminMovieManager();
                        Console.WriteLine("That was not a valid rating");


                    }
                }
                else
                {
                       Console.WriteLine("wrong entry");
                    step1.center_HeadingText();
                    numberOfinvokes = 4;
                }
                /* }
                 catch (Exception)
                 {
                     Console.WriteLine("Please Enter Valid Age");
                 }*/


            }
            string[] ageInStr = Array.ConvertAll(age, x => x.ToString());
            
            displayMovieEntry(movieName, ageInStr);
        }

        
        public static string[,] displayMovieEntry(string[] movieName, string[] ageInstr)
        {
            string[,] guestDisplayArr = new string[movieName.Length,2];
            Console.Clear();
            for (int i = 0; i < movieName.Length; i++)
            { 
                Console.WriteLine( i + 1 + ". " + movieName[i] + " {" + ageInstr[i] +"}");
                for(int j = 0; j < 2; j++)
                {

                    if (i == j)
                    {
                        guestDisplayArr[i, j] = movieName[i];
                    }
                    else
                    {
                        guestDisplayArr[i, j] = ageInstr[i];
                    }
                }
            }
            adminSatisfaction();
            return guestDisplayArr;
    }


        private static void adminSatisfaction()
        {
            Console.WriteLine("Your Movies Playing Today Are Listed Above . Are you satisfies ? (Y/N) ?");
            string userFeedback = Console.ReadLine();
            userFeedback.ToUpper().Trim();
                if (userFeedback.ToUpper().Trim() == "Y" )
                {
                    Console.Clear();
                movieEnumCounter = 1;
                numberOfinvokes = 4;
                step1.center_HeadingText();
                }
                else if(userFeedback.ToUpper().Trim() == "N")
                {
                 Console.Clear();
                numberOfinvokes = 4;
                 movieEnumCounter = 1;
                 adminMovieManager();
                
                }
                else
                {
                    Console.WriteLine("Press Y or N for review?");
                    adminSatisfaction();
                }
            

        }

            public static void adminManager()
            {
                administrationlogin();
            }


        }
    } 

