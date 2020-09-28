using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immigration.Data
{
    public class Player
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public int Age { get; set; }

        public bool IsMinor { get; set; }
    }
}
