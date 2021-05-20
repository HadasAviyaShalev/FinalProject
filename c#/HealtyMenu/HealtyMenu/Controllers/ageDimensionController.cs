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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ageDimensionController : ApiController
    {

        ageDimensionService service = new ageDimensionService();
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok(service.GetAgeDimensions());
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Ok(service.GetageDimension(id));
        }

        // POST api/<controller>
        public IHttpActionResult Post(ageDimensionDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PostAgeDimension(value);
            if (value == null)
            {
                return BadRequest("שמירה נכשלה");
            }
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(ageDimensionDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PostAgeDimension(value);
            if (value == null)
            {
                return BadRequest("עדכון נכשל");
            }
            return Ok(value);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(ageDimensionDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.RemoveAgeDimension(value);
            if (value == null)
            {
                return BadRequest("מחיקה נכשלה");
            }
            return Ok(value);
        }
    }
}
