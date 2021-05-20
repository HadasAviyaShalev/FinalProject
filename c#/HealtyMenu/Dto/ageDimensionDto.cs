using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ageDimensionDto
    {
        public int id { get; set; }
        public Nullable<int> statusCode { get; set; }
        public Nullable<int> UnitsOfMeasurementCode { get; set; }
        public Nullable<double> RecommendedDose { get; set; }
        public Nullable<double> MaxDose { get; set; }
        public Nullable<double> highMissing { get; set; }
    }
}
