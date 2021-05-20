using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Service
{
    public class SuitableToService
    {
        //get SuitableTo by id from database
        public suitableToDto GetSuitableTo(int id)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    suitableTo SuitableTo = db.suitableToes.FirstOrDefault(x => x.id == id);
                    if (SuitableTo == null)
                        return null;
                    return Convertion.SuitableToConvertion.convert(SuitableTo);
                }
                catch
                {
                    return null;
                }
            }
        }

        //update SuitableTo in database
        public suitableToDto PutSuitableTo(suitableToDto SuitableToDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    suitableTo SuitableTo = db.suitableToes.FirstOrDefault(x => x.id == SuitableToDto.id);
                    if (SuitableTo == null)
                        return null;
                    SuitableTo.id = SuitableToDto.id;
                    SuitableTo.statusDescription = SuitableToDto.statusDescription;
                    return Convertion.SuitableToConvertion.convert(SuitableTo);
                }
                catch
                {
                    return null;
                }
            }
        }

        //add SuitableTo to database
        public suitableToDto PostSuitableTo(suitableToDto SuitableToDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    suitableTo SuitableTo = db.suitableToes.Add(Convertion.SuitableToConvertion.convert(SuitableToDto));
                    db.SaveChanges();
                    return Convertion.SuitableToConvertion.convert(SuitableTo);
                }
                catch
                {
                    return null;
                }
            }
        }

        //remove SuitableTo from database
        public suitableToDto RemoveSuitableTo(suitableToDto SuitableToDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {

                    suitableTo SuitableTo = db.suitableToes.Remove(Convertion.SuitableToConvertion.convert(SuitableToDto));
                    db.SaveChanges();
                    return Convertion.SuitableToConvertion.convert(SuitableTo);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
