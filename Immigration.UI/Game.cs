using Immigration.Data;
using System;
using System.Threading;

namespace Immigration.UI
{
    public class Game
    {
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
            Console.WriteLine("Hello and welcome to The Green Card Game! Your character wants to get a green card. \n Can you help your character make the right choices to get the green card? \n You get to choose your character's marital status, age, and country of origin. \n The choices you make could affect \n whether your not you win the game! Let's get started -   \n Is your character Married or Single? You can type 1 for Married or 2 for Single. \n 1) Married \n 2) Single");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int mStatus))
            {

                switch (mStatus)
                {
                    case 1:
                        _gamePlayer.MaritalStatus = MaritalStatus.Married;
                        break;
                    case 2:
                        _gamePlayer.MaritalStatus = MaritalStatus.Single;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("That is not a valid answer. You must enter 1 for Married or 2 for Single. \n Do you want to try again?\n");
                        var retry = Console.ReadLine();
                        if (retry.ToLower() == "y")
                        {
                            GetPlayerProperties();
                        }
                        else
                        {
                            GameMenu();
                        }
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You must type a number, 1 or 2. \n" +
                    "Press any key to try again.");
                Console.ReadKey();
                Console.ResetColor();
                GetPlayerProperties();
            }

            SetPlayerDOB();

            SetPlayerCOO();


        }
        public void PresentOpportunities()
        {
            Console.WriteLine("Do you want to try to immigrate by family, skill, or some other way?\n" +
                "Choose 1, 2, or 3 below:\n" +
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You can only choose 1, 2 or 3");
                Console.ResetColor();
                PresentOpportunities();
            }
        }
        public void MigrateByFamily()
        {
            Console.WriteLine("You want to immigrate by family? Ok, do you have a spouse or parent who is a US citizen or Lawful Permanent Resident? Y or N?");
            var answer = Console.ReadLine();
            if (answer.ToLower() == "n")
            {
                Console.WriteLine("Sorry, you lost! You can't immigrate this way. Want to try another way? Hit any key to play again.");
                Console.ReadKey();
                Console.ResetColor();
                GameMenu();
            }
            else if (answer.ToLower() == "y")
            {
                UscLprMethod();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You can only choose y or n.");
                Console.ResetColor();
                MigrateByFamily();
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
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Congratulations!! You had a 1 in 100 chance of winning the green card lottery in this game. In real life, it's much less.");
                Console.WriteLine(WinnersText());
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Sorry!! You lost the green card lottery. \n You might win if you play again. Better luck next time.");
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
            Console.WriteLine("Enter the year the character was born:\n");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int dobYear))
            {
                if (dobYear > 1900 && dobYear <= DateTime.Now.Year)
                {
                    return dobYear;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"You must enter a year between 1900 and {DateTime.Now.Year}\nPlease press any key to continue...");
                    Console.ReadKey();
                    Console.ResetColor();
                    return GetDOBYear();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"You must enter a year between 1900 and {DateTime.Now.Year}\nPlease press any key to continue... ");
                Console.ReadKey();
                Console.ResetColor();
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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You must enter a Month number between 1 and 12\nPlease press any key to continue...");
                    Console.ReadKey();
                    Console.ResetColor();
                    return GetDOBMonth();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You must enter a Month number between 1 and 12\nPlease press any key to continue...");
                Console.ReadKey();
                Console.ResetColor();
                return GetDOBMonth();
            }
        }

        public int GetDOBDay()
        {
            Console.WriteLine("Enter the Day the character was born on:\n");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int dobDay))
            {
                if (dobDay > 0 && dobDay < 31)
                {
                    return dobDay;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You must enter a Day number between 1 and 31\nPlease press any key to continue...");
                    Console.ReadKey();
                    Console.ResetColor();
                    return GetDOBDay();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You must enter a Day number between 1 and 31\nPlease press any key to continue...");
                Console.ReadKey();
                Console.ResetColor();
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

        public void SetPlayerCOO()
        {

            Console.WriteLine("What is your character's country of origin? 1) India 2) Mexico 3) Phillipines 4) Other? \n Choose 1, 2, 3, or 4 below.");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int coo))
            {

                switch (coo)
                {
                    case 1:
                        _gamePlayer.countryOfOrigin = CountryOfOrigin.India;
                        break;
                    case 2:
                        _gamePlayer.countryOfOrigin = CountryOfOrigin.Mexico;
                        break;
                    case 3:
                        _gamePlayer.countryOfOrigin = CountryOfOrigin.Phillipines;
                        break;
                    case 4:
                        _gamePlayer.countryOfOrigin = CountryOfOrigin.Other;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You can only choose from 1, 2, 3, or 4.");
                        Console.ResetColor();
                        SetPlayerCOO();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You did not type an integer.");
                Console.ResetColor();
                SetPlayerCOO();
            }



        }
        public void UscLprMethod()

        {
            Console.WriteLine("Great, maybe you have a chance to immigrate through your spouse or parent. " +
                "Is your relative a US citizen(USC) or Lawful Permanent Resident(LPR)? Type USC or LPR.");
            var answer2 = Console.ReadLine();
            if (answer2.ToLower() == "usc" && _gamePlayer.IsMinor && (_gamePlayer.countryOfOrigin == CountryOfOrigin.Mexico || _gamePlayer.countryOfOrigin == CountryOfOrigin.Phillipines))
            {
                Console.WriteLine("Congratulations! You can get your green card after about 10-15 years of processing time. " +
                    "Don't plan the party too early.");
                Console.WriteLine(WinnersText());
                Console.ResetColor();
                PlayAgain();
            }
            else if (answer2.ToLower() == "usc" && _gamePlayer.Age > 21 && (_gamePlayer.countryOfOrigin != CountryOfOrigin.Mexico || _gamePlayer.countryOfOrigin == CountryOfOrigin.Phillipines))
            {
                Console.WriteLine("You can get your green card after about 3-4 years of processing time through your parent. " +
                    "If you’re married to a USC citizen, you might get your green card in as little as 90 days" +
                    "…or it might take a couple of years of processing time.");
                Console.WriteLine(WinnersText());
                PlayAgain();
            }
            else if (answer2.ToLower() == "usc" && _gamePlayer.IsMinor)
            {
                Console.WriteLine("This is one of the quickest ways to get a green card! Your processing time will probably take three months to; 1.5 years! " +
                    "Want to play again?");
                Console.WriteLine(WinnersText());
                Console.ResetColor();
                PlayAgain();
            }
            else if (answer2.ToLower() == "lpr" && _gamePlayer.IsMinor && _gamePlayer.MaritalStatus == MaritalStatus.Single)
            {
                Console.WriteLine("Single children under age 21 can apply! Your processing time could be 1-4 years, " +
                    "but be careful you don't have any inadmissibility issues, and don't get married unless your parent becomes a US citizen first! " +
                    "Play the inadmissiblity game later, coming soon, DLC only $500!");
                Console.WriteLine(WinnersText());
                Console.ResetColor();
                PlayAgain();
            }
            else if (answer2.ToLower() == "lpr" && _gamePlayer.IsMinor && _gamePlayer.MaritalStatus == MaritalStatus.Single && (_gamePlayer.countryOfOrigin == CountryOfOrigin.Mexico || _gamePlayer.countryOfOrigin == CountryOfOrigin.Phillipines))
            {
                Console.WriteLine("Single children over age 21 can apply! Your parent can petition for you. " +
                    "Your processing time could be 10-15 years or more. ");
                Console.WriteLine(WinnersText());
                Console.ResetColor();
                PlayAgain();
            }
            else if (answer2.ToLower() == "lpr" && _gamePlayer.Age > 21 && _gamePlayer.MaritalStatus == MaritalStatus.Single && (_gamePlayer.countryOfOrigin == CountryOfOrigin.India || _gamePlayer.countryOfOrigin == CountryOfOrigin.Other))
            {
                Console.WriteLine("Single children over age 21 can apply! Your parent can petition for you. " +
                    "Your processing time could be 5 years or more.");
                Console.WriteLine(WinnersText());
                Console.ResetColor();
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
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You must enter a valid answer.");
                Console.ResetColor();
                UscLprMethod();
            }



        }
        public string WinnersText()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string winnersText =@"
                                                                                                                     
                                                                                                                     
              |\     /|  (  ___  )  |\     /|    |\     /|  \__   __/  ( (    /|  ( )
              ( \   / )  | (   ) |  | )   ( |    | )   ( |     ) (     |  \  ( |  | |
               \ (_) /   | |   | |  | |   | |    | | _ | |     | |     |   \ | |  | |
                \   /    | |   | |  | |   | |    | |( )| |     | |     | (\ \) |  | |
                 ) (     | |   | |  | |   | |    | || || |     | |     | | \   |  (_)
                 | |     | (___) |  | (___) |    | () () |  ___) (___  | )  \  |   _ 
                 \_/     (_______)  (_______)    (_______)  \_______/  |/    )_)  (_)
                                                                                                                     
                                                                                                                     
                                                                                                                     
            ";
            return winnersText;
            
        }
    }
}

