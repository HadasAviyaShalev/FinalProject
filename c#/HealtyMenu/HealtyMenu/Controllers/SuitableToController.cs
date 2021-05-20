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
    public class SuitableToController : ApiController
    {
        SuitableToService service = new SuitableToService();
        // GET api/<controller>/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int id)
        {
            return Ok(service.GetSuitableTo(id));
        }

        // POST api/<controller>
        public IHttpActionResult Post(suitableToDto value)
        {
            if (value == null)
                return BadRequest("לא נשלח מידע");
            value = service.PostSuitableTo(value);
            if (value == null)
                return BadRequest("שמירה נכשלה");
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(suitableToDto value)
        {
            if (value == null)
                return BadRequest("לא נשלח מידע");
            value = service.PutSuitableTo(value);
            if (value == null)
                return BadRequest("שמירה נכשלה");
            return Ok(value);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(suitableToDto value)
        {
            if (value == null)
                return BadRequest("לא נשלח מידע");
            value = service.RemoveSuitableTo(value);
            if (value == null)
                return BadRequest("שמירה נכשלה");
            return Ok(value);
        }
    }
}