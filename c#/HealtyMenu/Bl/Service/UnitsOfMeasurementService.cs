using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Service
{
    public class UnitsOfMeasurementService
    {
        //get UnitsOfMeasurement by id from database
        public UnitsOfMeasurementDto GetUnitsOfMeasurement(int id)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    UnitsOfMeasurement unitsOfMeasurement = db.UnitsOfMeasurements.FirstOrDefault(x => x.id == id);
                    if (unitsOfMeasurement == null)
                        return null;
                    return Convertion.UnitsOfMeasurementConvertion.convert(unitsOfMeasurement);
                }
                catch
                {
                    return null;
                }
            }
        }

        //update UnitsOfMeasurement in database
        public UnitsOfMeasurementDto PutUnitsOfMeasurement(UnitsOfMeasurementDto unitsOfMeasurementDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    UnitsOfMeasurement unitsOfMeasurement = db.UnitsOfMeasurements.FirstOrDefault(x => x.id == unitsOfMeasurementDto.id);
                    if (unitsOfMeasurement == null)
                        return null;
                    unitsOfMeasurement.id = unitsOfMeasurementDto.id;
                    unitsOfMeasurement.unitName = unitsOfMeasurementDto.unitName;
                    unitsOfMeasurement.ratioToGram = unitsOfMeasurementDto.ratioToGram;
                    return Convertion.UnitsOfMeasurementConvertion.convert(unitsOfMeasurement);
                }
                catch
                {
                    return null;
                }
            }
        }

        //add UnitsOfMeasurement to database
        public UnitsOfMeasurementDto PostUnitsOfMeasurement(UnitsOfMeasurementDto unitsOfMeasurementDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    UnitsOfMeasurement unitsOfMeasurement = db.UnitsOfMeasurements.Add(Convertion.UnitsOfMeasurementConvertion.convert(unitsOfMeasurementDto));
                    db.SaveChanges();
                    return Convertion.UnitsOfMeasurementConvertion.convert(unitsOfMeasurement);
                }
                catch
                {
                    return null;
                }
            }
        }

        //remove UnitsOfMeasurement from database
        public UnitsOfMeasurementDto RemoveUnitsOfMeasurement(UnitsOfMeasurementDto unitsOfMeasurementDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    UnitsOfMeasurement unitsOfMeasurement = db.UnitsOfMeasurements.Remove(Convertion.UnitsOfMeasurementConvertion.convert(unitsOfMeasurementDto));
                    db.SaveChanges();
                    return Convertion.UnitsOfMeasurementConvertion.convert(unitsOfMeasurement);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
