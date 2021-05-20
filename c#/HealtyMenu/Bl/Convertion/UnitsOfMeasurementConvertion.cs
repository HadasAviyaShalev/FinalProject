using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Convertion
{
    public class UnitsOfMeasurementConvertion
    {

        //convert one UnitsOfMeasurementDto to UnitsOfMeasurement
        public static UnitsOfMeasurement convert(UnitsOfMeasurementDto unitsOfMeasurement)
        {
            UnitsOfMeasurement NewUnitsOfMeasurement = new UnitsOfMeasurement();
            NewUnitsOfMeasurement.id = unitsOfMeasurement.id;
            NewUnitsOfMeasurement.unitName = unitsOfMeasurement.unitName;
            NewUnitsOfMeasurement.ratioToGram = unitsOfMeasurement.ratioToGram;
            return NewUnitsOfMeasurement;
        }

        //convert one UnitsOfMeasurement to UnitsOfMeasurementDto
        public static UnitsOfMeasurementDto convert(UnitsOfMeasurement unitsOfMeasurement)
        {
            UnitsOfMeasurementDto NewUnitsOfMeasurement = new UnitsOfMeasurementDto();
            NewUnitsOfMeasurement.id = unitsOfMeasurement.id;
            NewUnitsOfMeasurement.unitName = unitsOfMeasurement.unitName;
            NewUnitsOfMeasurement.ratioToGram = unitsOfMeasurement.ratioToGram;
            return NewUnitsOfMeasurement;
        }
    }
}
