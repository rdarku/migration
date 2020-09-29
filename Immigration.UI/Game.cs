using Immigration.Data;
using System;
using System.Threading;

namespace Immigration.UI
{
    public class Game
    {

        //we can put the data for the questions in here, an array of numbers
        //we can put the 
        //put a string array of all the text of the questions, that has to match the enum (an object) and the answer list - like "questionTextListString"

        //and maybe a FlowArray |[ ] , [ ] , | - a multidimensional array - That tells them where they are on the flowchart. They will
        //always come in at 0 on the FlowArray |[ 0, 1, 50] , [ 3, 4, 40 ] , [6 , 3, 33 ]

        public readonly Player _gamePlayer = new Player();

        public void Play()
        {
            GameStart();
            GameMenu();
        }

        private void GameStart()
        {
            string titleText = @"
                                                                                                                     
                                                                                                                     
  ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______ 
 /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/ 
                                                                                                                     
                                                                                                                     
      ________                              _________                  .___   ________                               
     /  _____/______   ____   ____   ____   \_   ___ \_____ _______  __| _/  /  _____/_____    _____   ____          
    /   \  __\_  __ \_/ __ \_/ __ \ /    \  /    \  \/\__  \\_  __ \/ __ |  /   \  ___\__  \  /     \_/ __ \         
    \    \_\  \  | \/\  ___/\  ___/|   |  \ \     \____/ __ \|  | \/ /_/ |  \    \_\  \/ __ \|  Y Y  \  ___/         
     \______  /__|    \___  >\___  >___|  /  \______  (____  /__|  \____ |   \______  (____  /__|_|  /\___  >        
            \/            \/     \/     \/          \/     \/           \/          \/     \/      \/     \/         
                                                                                                                     
                                                                                                                     
  ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______ 
 /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/ 
                                                                                                                     
                                                                                                                     
                                                                                                                     
";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(titleText);
            Console.ResetColor();
        }

        public void GameMenu()
        {
            GameStart();

            GetPlayerProperties();

            PresentOpportunities();

            Console.ReadKey();

        }

        public void GetPlayerProperties()
        {
            Console.WriteLine("What is your character Married or Single? \n 1) Married \n 2) Single");
            string maritalSatus = Console.ReadLine();
            var mStatus = Convert.ToInt32(maritalSatus);

            switch (mStatus)
            {
                case 1:
                    _gamePlayer.MaritalStatus = MaritalStatus.Married;
                    break;
                case 2:
                    _gamePlayer.MaritalStatus = MaritalStatus.Single;
                    break;
                default:
                    Console.WriteLine("Hey! You did not give us the right answer.\n Do you want to change the answwer?\n");
                    var retry = Console.ReadLine();
                    if(retry.ToLower() =="y")
                    {
                        GetPlayerProperties();
                    }
                    else
                    {
                        GameMenu();
                    }
                    break;
            }

            SetPlayerDOB();

            Console.WriteLine("What is your character's Country of Origin? 1) India 2) Mexico 3) Phillipines 4) Other");
            string coo = Console.ReadLine();

            switch (coo)
            {
                case "1":
                    _gamePlayer.countryOfOrigin = CountryOfOrigin.India;
                    break;
                case "2":
                    _gamePlayer.countryOfOrigin = CountryOfOrigin.Mexico;
                    break;
                case "3":
                    _gamePlayer.countryOfOrigin = CountryOfOrigin.Mexico;
                    break;
                default:
                    _gamePlayer.countryOfOrigin = CountryOfOrigin.Other;
                    break;
            }
        }

        public void PresentOpportunities()
        {
            Console.WriteLine("Hi, Player You have the opportunity to immigrate by family, skill, or some other way.\n" +
                " Choose 1, 2, or 3 below:\n" +
                "1) Family\n" +
                "2) Skill\n" +
                "3) Some other way\n");

            var answer = Console.ReadLine();
            if (answer == "1")
            {
                MigrateByFamily();
            }
            else if (answer == "2")
            {
                MigrateBySkill();
            }
            else if (answer == "3")
            {
                RollTheDice();
            }
            else
            {
                Console.WriteLine("You need to choose 1, 2 or 3");
                PresentOpportunities();
            }
        }

        public void MigrateByFamily()
        {
            Console.WriteLine("You want to immigrate by family? Ok, do you have a spouse or parent who is a US citizen or Lawful Permanent Resident? Y or N?");
            var answer = Console.ReadLine();
            if (answer.ToLower() == "n")
            {
                Console.WriteLine("Sorry, you lost! You can't immigrate this way. Want to try another way?");
                Console.ReadKey();
                GameMenu();
            }
            else if (answer.ToLower() == "y")
            {
                Console.WriteLine("Great, maybe you have a chance to immigrate through your spouse or parent. " +
                    "Is your relative a US citizen(USC) or Lawful Permanent Resident(LPR)? Type USC or LPR.");
                var answer2 = Console.ReadLine();
                if (answer2.ToLower() == "usc" && _gamePlayer.IsMinor && (_gamePlayer.countryOfOrigin == CountryOfOrigin.Mexico || _gamePlayer.countryOfOrigin == CountryOfOrigin.Phillipines))
                {
                    Console.WriteLine("Congratulations! You can get your green card after about 10-15 years of processing time. " +
                        "Don't plan the party too early.");
                    PlayAgain();
                }
                else if (answer2.ToLower() == "usc" && _gamePlayer.Age > 21 && (_gamePlayer.countryOfOrigin != CountryOfOrigin.Mexico || _gamePlayer.countryOfOrigin == CountryOfOrigin.Phillipines))
                {
                    Console.WriteLine("You can get your green card after about 3-4 years of processing time through your parent. " +
                        "If you’re married to a USC citizen, you might get your green card in as little as 90 days" +
                        "…or it might take a couple of years of processing time.");
                    PlayAgain();
                }
                else if (answer2.ToLower() == "usc" && _gamePlayer.IsMinor)
                {
                    Console.WriteLine("This is one of the quickest ways to get a green card! Your processing time will probably take three months to; 1.5 years! " +
                        "Want to play again?");
                    PlayAgain();
                }
                else if (answer2.ToLower() == "lpr" && _gamePlayer.IsMinor && _gamePlayer.MaritalStatus == MaritalStatus.Single)
                {
                    Console.WriteLine("Single children under age 21 can apply! Your processing time could be 1-4 years, " +
                        "but be careful you don't have any inadmissibility issues, and don't get married unless your parent becomes a US citizen first! " +
                        "Play the inadmissiblity game later, coming soon, DLC only $500!");
                    PlayAgain();
                }
                else if (answer2.ToLower() == "lpr" && _gamePlayer.IsMinor && _gamePlayer.MaritalStatus == MaritalStatus.Single && (_gamePlayer.countryOfOrigin == CountryOfOrigin.Mexico || _gamePlayer.countryOfOrigin == CountryOfOrigin.Phillipines))
                {
                    Console.WriteLine("Single children over age 21 can apply! Your parent can petition for you. " +
                        "Your processing time could be 10-15 years or more. ");
                    PlayAgain();
                }
                else if (answer2.ToLower() == "lpr" && _gamePlayer.Age > 21 && _gamePlayer.MaritalStatus == MaritalStatus.Single && (_gamePlayer.countryOfOrigin == CountryOfOrigin.India || _gamePlayer.countryOfOrigin == CountryOfOrigin.Other))
                {
                    Console.WriteLine("Single children over age 21 can apply! Your parent can petition for you. " +
                        "Your processing time could be 5 years or more.");
                    PlayAgain();
                }
                else if (answer2.ToLower() == "lpr" && _gamePlayer.MaritalStatus == MaritalStatus.Married)
                {
                    Console.WriteLine("Your LPR spouse can petition for you to qualify this way. Your parent can't petition for you. " +
                        "Your processing time could be 1-15 years, but be careful you don't have any inadmissibility issues! " +
                        "Play the inadmissiblity game later, coming soon, DLC only $500! ");
                    PlayAgain();
                }
                else
                    Console.WriteLine("You must choose Y or N.");
            }


        }

        public void MigrateBySkill()
        {
            Console.WriteLine("You can immigrate this way in real life, but not in this game! " +
                "Check back soon for an exciting expansion pack, only $500  for extra downloadable content!");
            PlayAgain();
        }

        public void RollTheDice()
        {
            int luck = 67;
            Random karma = new Random();

            if (karma.Next(100) == luck)
            {
                Console.WriteLine("Congratulations!! You had a 1 in 100 chance of winning the green card lottery in this game. In real life, it's much less.");
            }
            else
            {
                Console.WriteLine("Sorry!! You lost the green card lottery."); 
            }

            PlayAgain();

        }

        public void PlayAgain()
        {
            Console.WriteLine("\nWant to play again? Y or N");
            var answer = Console.ReadLine();
            if (answer.ToLower() == "y")
                GameMenu();
            else SayGoodBye(); 
        }

        public void SayGoodBye()
        {
            GameStart();
            Console.WriteLine("Thank you for playing!\n" +
                "Please come back soon.\n");
            Thread.Sleep(5000);

        }

        public int GetDOBYear()
        {
            Console.WriteLine("Enter the Year the character was born in:\n");
            string input = Console.ReadLine();
            if(int.TryParse(input, out int dobYear))
            {
                if (dobYear > 1900 && dobYear <= DateTime.Now.Year)
                {
                    return dobYear;
                }
                else
                {
                    Console.WriteLine($"You must enter a year between 1900 and {DateTime.Now.Year}\nPlease press any key to continue...");
                    Console.ReadKey();
                    return GetDOBYear();
                }
            }
            else
            {
                Console.WriteLine($"You must enter a year between 1900 and {DateTime.Now.Year}\nPlease press any key to continue... ");
                Console.ReadKey();
                return GetDOBYear();
            }
        }

        public int GetDOBMonth()
        {
            Console.WriteLine("Enter the Month the character was born in:\n");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int dobMonth))
            {
                if (dobMonth > 0 && dobMonth < 13)
                {
                    return dobMonth;
                }
                else
                {
                    Console.WriteLine("You must enter a Month number between 1 and 12\nPlease press any key to continue...");
                    Console.ReadKey();
                    return GetDOBMonth();
                }
            }
            else
            {
                Console.WriteLine("You must enter a Month number between 1 and 12\nPlease press any key to continue...");
                Console.ReadKey();
                return GetDOBMonth();
            }
        }

        public int GetDOBDay()
        {
            Console.WriteLine("Enter the Day the character was born on:\n");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int dobDay))
            {
                if (dobDay > 0 && dobDay < 13)
                {
                    return dobDay;
                }
                else
                {
                    Console.WriteLine("You must enter a Day number between 1 and 31\nPlease press any key to continue...");
                    Console.ReadKey();
                    return GetDOBDay();
                }
            }
            else
            {
                Console.WriteLine("You must enter a Day number between 1 and 31\nPlease press any key to continue...");
                Console.ReadKey();
                return GetDOBDay();
            }
        }

        public void SetPlayerDOB()
        {
            Console.WriteLine("What is your character's Date of Birth?");

            // GET DOB Year
            int dobYear = GetDOBYear();

            // Get DOB Month
            int dobMonth = GetDOBMonth();

            // Get DOB Day
            int dobDay = GetDOBDay();

            // Set player's DOB 
            _gamePlayer.DateOfBirth = new DateTime(dobYear, dobMonth, dobDay);
        }
    }
}

