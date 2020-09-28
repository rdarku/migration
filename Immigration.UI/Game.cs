using Immigration.Data;
using System;

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
  ________                              _________                  .___   ________                       
 /  _____/______   ____   ____   ____   \_   ___ \_____ _______  __| _/  /  _____/_____    _____   ____  
/   \  __\_  __ \_/ __ \_/ __ \ /    \  /    \  \/\__  \\_  __ \/ __ |  /   \  ___\__  \  /     \_/ __ \ 
\    \_\  \  | \/\  ___/\  ___/|   |  \ \     \____/ __ \|  | \/ /_/ |  \    \_\  \/ __ \|  Y Y  \  ___/ 
 \______  /__|    \___  >\___  >___|  /  \______  (____  /__|  \____ |   \______  (____  /__|_|  /\___  >
        \/            \/     \/     \/          \/     \/           \/          \/     \/      \/     \/ 
                                                                                                         
                                                                                                         
                                                                                                         
                                                                                                         
                                                                                                         
                                                                                                         
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
                    Console.WriteLine("Hey! you did not give us the right answer.\n Do you want to change the answwer?\n");
                    GameMenu();
                    break;
            }


            Console.WriteLine("What is your character's Date of Birth? \nEnter the Year\n");
            int dobYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the month");
            int dobMonth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the day");
            int dobDay = Convert.ToInt32(Console.ReadLine());
            _gamePlayer.DateOfBirth = new DateTime(dobYear, dobMonth, dobDay);


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
                Console.WriteLine("Check back for this exciting new feature");
                GameMenu();
            }
            else if (answer == "3")
            {
                RollTheDice();
            }
            else
            {
                Console.WriteLine("You need to chose 1, 2 or 3");
                GameMenu();
            }
        }
        Player player = new Player();
        public void MigrateByFamily()
            
        {
            Console.WriteLine("You want to immigrate by family? Ok, do you have a spouse or parent who is /n" +
                "a US citizen or Lawful Permanent Resident? Y or N?");
            var answer = Console.ReadLine();
            if (answer == "N")
            {
                Console.WriteLine("Sorry, you lost! You can't immigrate this way. Want to try another way?");
                GameMenu();
            }
            else if (answer == "Y");
            {
                Console.WriteLine("Great, maybe you have a chance to immigrate through your spouse or parent. /n" +
                    "Is your relative a US citizen(USC) or Lawful Permanent Resident(LPR)? Type USC or LPR.");
                    var answer1 = Console.ReadLine();
                if (answer == "USC" && player.Age > 21 && (player.countryOfOrigin == CountryOfOrigin.Mexico || player.countryOfOrigin == CountryOfOrigin.Phillipines))
                {
                    Console.WriteLine("Congratulations! You can get your green card after about 10-15 years of processing time. Don't plan the party too early. Want to play again?");
                    GameMenu();
                }
                else if (answer == "USC" && player.Age > 21 && (player.countryOfOrigin != CountryOfOrigin.Mexico || player.countryOfOrigin == CountryOfOrigin.Phillipines))
                {
                    Console.WriteLine("You can get your green card after about 3-4 years of processing time through your parent. If you’re married to a USC citizen, you might get your green card in as little as 90 days…or it might take a couple of years of processing time. Want to play again ?");
                }

                else if (answer == "USC" && player.Age < 21) ;
                    {
                        Console.WriteLine("This is one of the quickest ways to get a green card! Your processing time will probably take three months to; 1.5 years!");
                    }
                }

                
            }
            //else 
            
                //Console.WriteLine("You must choose Y or N.");
        }

           

        public void MigrateBySkill()
        {

        }

        public void RollTheDice()
        {
            int luck = 67;
            Random karma = new Random();

            if(karma.Next(100) == luck)
            {
                Console.WriteLine("Congratulations!!");
            }
            else
            {
                Console.WriteLine("Sorry!!\n Lost. Play again");
                GameMenu();
            }

            Console.ReadKey();
        }
    }
}
