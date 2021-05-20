using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class FoodDto
    {
        public int id { get; set; }
        public string foodName { get; set; }
        public string picture { get; set; }
        public Nullable<int> suitableToID { get; set; }
        public string cosher { get; set; }
        public string category { get; set; }
    }
}
