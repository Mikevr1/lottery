using System.Security.Cryptography.X509Certificates;

namespace lottery
{
    internal class Program
    {

        private static int Range ;// the numbers that the user will pick
        private static int Total ;//the numbers that can be entered by the user


        private static int[] TotalNumbersArray = new int[Total];// numbers selected by user
        private static int[] RangeNumbersArray = new int[Range];// numbers to select from
        private static int[] SortedRangeNumbersArray = new int[Range];// sorted numbers to select from
        private static int[] UserPickedNumbersArray = new int[Total];// numbers picked by user
        private static int[] SystemPickedNumbersArray = new int[Total];// numbers picked by System
        private static int[] MatchedNumbersArray = new int[Total];// numbers matched by user and system 
        private static Random ScrambeledEggs = new Random();// random number generator


        static void Main(string[] args)
        {




            //BannerTitle();
            //Instructions();
            Play();
            Results();


        }
        // display banner title ASCII art
        //https://www.asciiart.eu/
        public static void BannerTitle()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"          _          _   _                         
        __/\__ | |    ___ | |_| |_ ___ _ __ _   _  __/\__
        \    / | |   / _ \| __| __/ _ \ '__| | | | \    /
        /_  _\ | |__| (_) | |_| ||  __/ |  | |_| | /_  _\
          \/   |_____\___/ \__|\__\___|_|   \__, |   \/  
                                            |___/         ");

            Console.ForegroundColor = ConsoleColor.Green;



        }

        // display instructions
        public static void Instructions()
        {
            Console.WriteLine(@"
        *********************************************
        *  Choose Numbers When prompted.            *
        *  The Program Will Generate Random Numbers.* 
        *  Any matches that the program finds       *
        *  Will be displayed to you.                *
        *********************************************");


        }


        // display results
        public static void Results()
        {
            Console.WriteLine();

            int Matches = 0;
            for (int i = 0; i < Total; i++)
            {

                if (UserPickedNumbersArray[i] == SystemPickedNumbersArray[i])
                {
                    MatchedNumbersArray[i] = UserPickedNumbersArray[i];
                    Matches++;
                }

            }
            switch (Matches)
            {

                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You got 1 Numbers");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You got 2 Numbers");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You got 3 Numbers");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You got 4 Numbers");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You got 5 numbers");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You got 6 Numbers");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No numbers match");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Matched Numbers");
            foreach (int i in MatchedNumbersArray)
            {
                if (i != 0)
                {
                    Console.Write(" " + i);
                    Console.Write("");
                }
            }

            Console.WriteLine();
        }

        public static bool BinnarySearch(int[] array, int value)
        {
             
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (array[mid] == value)
                {
                    return true; // Value found 
                }
                else if (array[mid] < value)
                {
                    left = mid + 1; // Search in the right half
                }
                else
                {
                    right = mid - 1; // Search in the left half
                }
            }
            return false; // Value not found 
        }


        //linear search to find if a value is in array

        public static bool LinearSearch(int[] array, int value)
        {
            foreach (int item in array)
            {
                if (item == value)
                {
                    return true; // Value found in the array
                }
            }
            return false; // Value not found in the array
        }

        

        // main game play method
        public static void Play()
        {


            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter RANGE of Numbers To select from");
            while (!int.TryParse(Console.ReadLine(), out Range) || Range <= 0)
            {
             Console.ForegroundColor = ConsoleColor.Red;
             Console.WriteLine("ERROR enter a value");
             Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("Enter TOTAL of Numbers To Enter");
            while (!int.TryParse(Console.ReadLine(), out Total) || Total <= 0)
            {
             Console.ForegroundColor = ConsoleColor.Red;
             Console.WriteLine("ERROR Enter a value");
             Console.ForegroundColor = ConsoleColor.White;
            }
            TotalNumbersArray = new int[Total];
            RangeNumbersArray = new int[Range];
            SortedRangeNumbersArray = new int[Range];
            UserPickedNumbersArray = new int[Total];
            SystemPickedNumbersArray = new int[Total];
            MatchedNumbersArray = new int[Total];

            for (int i = 0; i < Range; i++)
            {
                RangeNumbersArray[i] = i + 1;
                SortedRangeNumbersArray[i] = i + 1;
            }


            Console.Clear();
            Console.WriteLine("Range of Numbers ");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (int i in SortedRangeNumbersArray)
            {
            Console.Write(" " + i);
            Console.Write("");

            }
            Console.WriteLine();


            ScrambeledEggs.Shuffle(RangeNumbersArray);//randomize the array numbers

            // system picked numbers first numbers of the randomized array so no duplicates
            int Temp;
            for (int i = 0; i < Total; i++)
            {
                Temp =RangeNumbersArray[i];
                SystemPickedNumbersArray[i]= Temp;
            }


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Range of Numbers Randomized in Bucket");
            Console.ForegroundColor = ConsoleColor.White;
            
            foreach (int i in RangeNumbersArray)
            {
            Console.Write(" " + i);
            Console.Write("");

            }
            Console.WriteLine();
            
               
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine($"Enter {Total} Numbers bettween 1 and {Range}");

            for (int i = 0; i < Total; i++)
            {

                //  validate user input using
                //   check if number is in range and not already picked

                int userInput;
                //while (!int.TryParse(Console.ReadLine(), out userInput) || userInput <= 0
                //                || (!LinearSearch(RangeNumbersArray, userInput)) ||
                //                (LinearSearch(UserPickedNumbersArray, userInput)))


                while (!int.TryParse(Console.ReadLine(), out userInput) || userInput <= 0
                        || (!BinnarySearch(SortedRangeNumbersArray,userInput)) 
                        || (LinearSearch(UserPickedNumbersArray, userInput)))


                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Please enter a valid number.");
                Console.ForegroundColor = ConsoleColor.White;
                }
             

                UserPickedNumbersArray[i] = userInput;// numbers picked by user

                
            }
            Console.ForegroundColor = ConsoleColor.Cyan; 
            Console.WriteLine("user picked numbers");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (int i in UserPickedNumbersArray)
            {
                
                Console.Write(" " + i);
                Console.Write("");

            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();   
            Console.WriteLine("System picked numbers");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (int i in SystemPickedNumbersArray)
            {
             Console.Write(" " + i);
             Console.Write("");

            }





        }


       

    }

        

         



}



        
        

































































































