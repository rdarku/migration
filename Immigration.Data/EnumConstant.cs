using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immigration.Data
{
    class EnumConstant
    {
        // - OR we could use a dictionary, key value pairs - 

        //Put an Enum of all the questions as one Enum. If we need another Enum we can make it in here. Enum properties can't have spaces. They are an object. The Enum is determining the placement on everything. 
        ImmBy = 0,
        USCvLPR = 1,
        SomeOtherWay = 3,

        SPorParent = 4,
        NoSporParent = 5

    }
}
