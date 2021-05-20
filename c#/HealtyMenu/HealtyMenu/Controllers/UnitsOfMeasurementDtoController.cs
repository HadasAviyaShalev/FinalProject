using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dto;
using Bl.Service;
using System.Web.Http.Cors;

namespace HealtyMenu.Controllers
{
    public class UnitsOfMeasurementDtoController : ApiController
    {
        UnitsOfMeasurementService service = new UnitsOfMeasurementService();
        // GET api/<controller>/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int id)
        {
            return Ok(service.GetUnitsOfMeasurement(id));
        }

        // POST api/<controller>
        public IHttpActionResult Post(UnitsOfMeasurementDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PostUnitsOfMeasurement(value);
            if (value == null)
            {
                return BadRequest("מחיקה נכשלה");
            }
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(UnitsOfMeasurementDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PutUnitsOfMeasurement(value);
            if (value == null)
            {
                return BadRequest("מחיקה נכשלה");
            }
            return Ok(value);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(UnitsOfMeasurementDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.RemoveUnitsOfMeasurement(value);
            if (value == null)
            {
                return BadRequest("מחיקה נכשלה");
            }
            return Ok(value);
        }
    }
}