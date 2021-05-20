using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Convertion
{
    public class SuitableToConvertion
    {

        //convert suitableTo to suitableToDto
        public static suitableToDto convert(suitableTo SuitableTo)
        {
            suitableToDto NewSuitableTo = new suitableToDto();
            NewSuitableTo.id = SuitableTo.id;
            NewSuitableTo.statusDescription = SuitableTo.statusDescription;
            return NewSuitableTo;
        }

        //convert suitableToDto to suitableTo
        public static suitableTo convert(suitableToDto SuitableTo)
        {
            suitableTo NewSuitableTo = new suitableTo();
            NewSuitableTo.id = SuitableTo.id;
            NewSuitableTo.statusDescription = SuitableTo.statusDescription;
            return NewSuitableTo;
        }
    }
}
