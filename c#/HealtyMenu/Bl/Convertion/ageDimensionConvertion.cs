using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Convertion
{
    public class ageDimensionConvertion
    {
        //convert one ageDimensionDto to ageDimension
        public static ageDimension convert(ageDimensionDto AgeDimension)
        {
            ageDimension NewageDimension = new ageDimension();
            NewageDimension.id = AgeDimension.id;
            NewageDimension.statusCode = AgeDimension.statusCode;
            NewageDimension.UnitsOfMeasurementCode = AgeDimension.UnitsOfMeasurementCode;
            NewageDimension.RecommendedDose = AgeDimension.RecommendedDose;
            NewageDimension.MaxDose = AgeDimension.MaxDose;
            NewageDimension.highMissing = AgeDimension.highMissing;
            return NewageDimension;

        }

        //convert one ageDimension to ageDimensionDto
        public static ageDimensionDto convert(ageDimension AgeDimension)
        {
            ageDimensionDto NewageDimension = new ageDimensionDto();
            NewageDimension.id = AgeDimension.id;
            NewageDimension.statusCode = AgeDimension.statusCode;
            NewageDimension.UnitsOfMeasurementCode = AgeDimension.UnitsOfMeasurementCode;
            NewageDimension.RecommendedDose = AgeDimension.RecommendedDose;
            NewageDimension.MaxDose = AgeDimension.MaxDose;
            NewageDimension.highMissing = AgeDimension.highMissing;
            return NewageDimension;

        }

        //convert list of ageDimension to ageDimensionDto
        public static List<ageDimensionDto> convert(List<ageDimension> AgeDimension)
        {
            List<ageDimensionDto> NewAgeDimension = new List<ageDimensionDto>();
            AgeDimension.ForEach(x => {
                NewAgeDimension.Add(convert(x));
            });
            return NewAgeDimension;

        }
        //convert list of ageDimensionDto to ageDimension
        public static List<ageDimension> convert(List<ageDimensionDto> AgeDimension)
        {
            List<ageDimension> NewAgeDimension = new List<ageDimension>();
            AgeDimension.ForEach(x => {
                NewAgeDimension.Add(convert(x));
            });
            return NewAgeDimension;

        }
    }
}
