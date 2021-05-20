using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Service
{
    public class statusService
    {

        //get all status from database
        public List<statusDto> GetStatuses()
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    return Convertion.statusConvertion.convert(db.statuses.ToList());
                }
                catch
                {
                    return null;
                }
            }
        }

        //get status by id from database
        public statusDto GetStatus(int id)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    status Status = db.statuses.FirstOrDefault(x => x.id == id);
                    if (Status == null)
                        return null;
                    return Convertion.statusConvertion.convert(Status);
                }
                catch
                {
                    return null;
                }
            }
        }

        //update status in database
        public statusDto PutStatus(statusDto StatusDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    status Status = db.statuses.FirstOrDefault(x => x.id == StatusDto.id);
                    if (Status == null)
                        return null;
                    Status.age = StatusDto.age;
                    Status.description = StatusDto.description;
                    Status.id = StatusDto.id;
                    return Convertion.statusConvertion.convert(Status);
                }
                catch
                {
                    return null;
                }
            }
        }

        //add status to database
        public statusDto PostStatus(statusDto StatusDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    status Status = db.statuses.Add(Convertion.statusConvertion.convert(StatusDto));
                    db.SaveChanges();
                    return Convertion.statusConvertion.convert(Status);
                }
                catch
                {
                    return null;
                }
            }
        }

        //remove status from database
        public statusDto RemoveStatus(statusDto StatusDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    status Status = db.statuses.Remove(Convertion.statusConvertion.convert(StatusDto));
                    db.SaveChanges();
                    return Convertion.statusConvertion.convert(Status);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
