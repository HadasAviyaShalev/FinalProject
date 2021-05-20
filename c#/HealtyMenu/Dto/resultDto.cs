using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class resultDto
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string statusUser { get; set; }
        public string menuName { get; set; }
        public List<menuList> menuList { get; set; }
        public List<string> messages { get; set; }
    }
    public class menuList
    {

        public string foodName { get; set; }
        public double amount { get; set; }
        public string type { get; set; }
        public int meal { get; set; }
    }
    public class vitamin
    {

        public double client { get; set; }
        public double count { get; set; } 
        public double flag { get; set; } 
        public double max { get; set; } 
        public double? min { get; set; }
        public double MaxBreakfast { get; set; }
        public double MaxLunch { get; set; }
        public double MaxDinner { get; set; }
        public double MaxBetween { get; set; }

    }
}
