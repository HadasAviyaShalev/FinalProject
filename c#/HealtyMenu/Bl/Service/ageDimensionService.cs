using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Service
{
    public class ageDimensionService
    {
        //get all ageDimension from database
        public List<ageDimensionDto> GetAgeDimensions()
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    return Convertion.ageDimensionConvertion.convert(db.ageDimensions.ToList());
                }
                catch
                {
                    return null;
                }
            }
        }

        //get ageDimension by id from database
        public ageDimensionDto GetageDimension(int id)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    ageDimension AgeDimension = db.ageDimensions.FirstOrDefault(x => x.id == id);
                    if (AgeDimension == null)
                        return null;
                    return Convertion.ageDimensionConvertion.convert(AgeDimension);
                }
                catch
                {
                    return null;
                }
            }
        }

        //update ageDimension in database
        public ageDimensionDto PutAgeDimension(ageDimensionDto AgeDimensionDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    ageDimension AgeDimension = db.ageDimensions.FirstOrDefault(x => x.id == AgeDimensionDto.id);
                    if (AgeDimension == null)
                        return null;
                    AgeDimension.id = AgeDimensionDto.id;
                    AgeDimension.statusCode = AgeDimensionDto.statusCode;
                    AgeDimension.UnitsOfMeasurementCode = AgeDimensionDto.UnitsOfMeasurementCode;
                    AgeDimension.RecommendedDose = AgeDimensionDto.RecommendedDose;
                    AgeDimension.MaxDose = AgeDimensionDto.MaxDose;
                    AgeDimension.highMissing = AgeDimensionDto.highMissing;
                    
                    return Convertion.ageDimensionConvertion.convert(AgeDimension);
                }
                catch
                {
                    return null;
                }
            }
        }

        //add ageDimension to database
        public ageDimensionDto PostAgeDimension(ageDimensionDto AgeDimensionDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    ageDimension AgeDimension = db.ageDimensions.Add(Convertion.ageDimensionConvertion.convert(AgeDimensionDto));
                    db.SaveChanges();
                    return Convertion.ageDimensionConvertion.convert(AgeDimension);
                }
                catch
                {
                    return null;
                }
            }
        }

        //remove ageDimension from database
        public ageDimensionDto RemoveAgeDimension(ageDimensionDto AgeDimensionDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    ageDimension AgeDimension = db.ageDimensions.Remove(Convertion.ageDimensionConvertion.convert(AgeDimensionDto));
                    db.SaveChanges();
                    return Convertion.ageDimensionConvertion.convert(AgeDimension);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
