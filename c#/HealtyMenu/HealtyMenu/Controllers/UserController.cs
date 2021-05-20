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
    public class UserController : ApiController
    {
        UserService service = new UserService();
        // GET api/<controller>
        public IHttpActionResult Get()
        {
           // new menuService().CalcRecomandedMenu(new detailsDto { A=34,B1=49,B12=8,B2=4,B3=30,B4=9,B5=49}); 


            return Ok(service.GetUsers());
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(string password,string str)
        {
            UserDto user= service.GetUser(password,str);
            if (user != null)
                return Ok(user);
            return BadRequest("לא נמצא משתמש מתאים");
        }

        // POST api/<controller>
        public IHttpActionResult Post(UserDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PostUser(value);
            if (value == null)
            {
                return BadRequest("עדכון נכשל");
            }
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(UserDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PutUser(value);
            if (value == null)
            {
                return BadRequest("עדכון נכשל");
            }
            return Ok(value);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(UserDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.RemoveUser(value);
            if (value == null)
            {
                return BadRequest("עדכון נכשל");
            }
            return Ok(value);
        }
    }
}