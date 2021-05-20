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
{ [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class userNutritionController : ApiController
    {
        userNutritionService service = new userNutritionService();

        // GET api/<controller>/5
       [HttpGet]
        public IHttpActionResult Get(int id)
        {
            userNutritionDto d = service.GetUserNutrition(id);
                if(d!=null)
            return Ok(d);
            return BadRequest("המידע לא נמצא");
        }
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post(userNutritionDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PostUserNutrition(value);
            if (value == null)
            {
                return BadRequest("עדכון נכשל");
            }
            return Ok(value);
        }
        [HttpPost]
        [Route("api/getNut")]
        public IHttpActionResult Post(detailsDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            resultDto r=service.PostUserNutrition(value);
            if (r == null)
            {
                return BadRequest("עדכון נכשל");
            }
            return Ok(r);
        }
        // PUT api/<controller>/5
        public IHttpActionResult Put(userNutritionDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PutUserNutrition(value);
            if (value == null)
            {
                return BadRequest("עדכון נכשל");
            }
            return Ok(value);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(userNutritionDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.RemoveUserNutrition(value);
            if (value == null)
            {
                return BadRequest("עדכון נכשל");
            }
            return Ok(value);
        }
    }
}