using Immigration.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Yay!");


            GameMenu();
        }

        public void GameMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Green Card Game!");

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
                Console.WriteLine("You chose path One");
            }
            else if (answer == "2")
            {
                Console.WriteLine("Check back for thi exciting new feature");
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

        public void MigrateByFamily()
        {

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
