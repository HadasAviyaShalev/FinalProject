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
    public class statusController : ApiController
    {
        statusService service = new statusService();
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok(service.GetStatuses());
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Ok(service.GetStatus(id));
        }

        // POST api/<controller>
        public IHttpActionResult Post(statusDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PostStatus(value);
            if (value == null)
            {
                return BadRequest("שמירה נכשלה");
            }
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(statusDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PutStatus(value);
            if (value == null)
            {
                return BadRequest("עדכון נכשל");
            }
            return Ok(value);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(statusDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.RemoveStatus(value);
            if (value == null)
            {
                return BadRequest("מחיקה נכשלה");
            }
            return Ok(value);
        }
    }
}
