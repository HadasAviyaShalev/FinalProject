using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class UnitsOfMeasurementDto
    {
        public int id { get; set; }
        public string unitName { get; set; }
        public Nullable<double> ratioToGram { get; set; }
    }
}
