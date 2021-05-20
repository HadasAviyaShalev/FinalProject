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
    public class IngredientController : ApiController
    {
        IngredientService service = new IngredientService();
        public IHttpActionResult Get()
        {
            return Ok(service.GetIngredients());
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            return Ok(service.GetIngredient(id));
        }

        // POST api/values
        [HttpPost]
        public IHttpActionResult Post(ingredientDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value= service.PostIngredient(value);
            if (value == null)
            {
                return BadRequest("שמירה נכשלה");
            }
            return Ok(value);
        }

        // PUT api/values/5
        public IHttpActionResult Put(ingredientDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PostIngredient(value);
            if (value == null)
            {
                return BadRequest("עדכון נכשל");
            }
            return Ok(value);
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(ingredientDto value)
        {
            if (value==null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.RemoveIngredient(value);
            if (value == null)
            {
                return BadRequest("מחיקה נכשלה");
            }
            return Ok(value);

        }
    }
}
