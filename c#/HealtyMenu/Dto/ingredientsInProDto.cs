using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ingredientsInProDto
    {
        public int id { get; set; }
        public Nullable<int> foodID { get; set; }
        public Nullable<int> ingredientsId { get; set; }
        public Nullable<double> countFor100gr { get; set; }
    }
}
