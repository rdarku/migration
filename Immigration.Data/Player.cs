using System;
using System.Runtime.Remoting.Messaging;

namespace Immigration.Data
{
    public class Player
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public int Age
        {
            get
            {
                TimeSpan ageSpan = DateTime.Now - DateOfBirth;
                double totalAgeInYears = ageSpan.TotalDays / 365.25;
                return Convert.ToInt32(Math.Floor(totalAgeInYears));
            }
        }

        public bool IsMinor { get {
                return Age < 21;
            } 
        }

        public CountryOfOrigin countryOfOrigin { get; set; }

        // answers list
        // question => answer
        // 

    }
}
