using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ingredientDto
    {
        public int id { get; set; }
        public string CDescription { get; set; }
        public Nullable<double> RecommendedDoseMale { get; set; }
        public Nullable<double> RecommendedDoseFemale { get; set; }
        public Nullable<int> UnitCode { get; set; }
    }
}
