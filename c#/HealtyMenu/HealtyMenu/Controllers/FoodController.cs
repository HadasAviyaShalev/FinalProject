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
    public class FoodController : ApiController
    {
        FoodService service = new FoodService();
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok(service.GetFoods());
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Ok(service.GetFood(id));
        }

        // POST api/<controller>
        public IHttpActionResult Post(FoodDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PostFood(value);
            if (value == null)
            {
                return BadRequest("שמירה נכשלה");
            }
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(FoodDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PostFood(value);
            if (value == null)
            {
                return BadRequest("עדכון נכשל");
            }
            return Ok(value);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(FoodDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.RemoveFood(value);
            if (value == null)
            {
                return BadRequest("מחיקה נכשלה");
            }
            return Ok(value);
        }
    }
}