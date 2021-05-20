using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
  public class menuDto
    {
        public int id { get; set; }
        public Nullable<int> userNutritionCode { get; set; }
        public Nullable<int> foodCode { get; set; }
        public Nullable<double> amount { get; set; }
        public Nullable<int> suitableToId { get; set; }

        //public string ingredientsName { get; set; }


    }
}
