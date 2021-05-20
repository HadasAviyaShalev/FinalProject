using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class userNutritionDto
    {

        public int id { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<System.DateTime> inserDate { get; set; }
        public string yourName { get; set; }

        public List<menuDto> menus { get; set; }
    }
}
