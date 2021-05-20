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
    public class ingredientsInProController : ApiController
    {
        
        IngredientsInProService service = new IngredientsInProService();
        // GET api/<controller>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            
            return Ok(service.GetIngredientsInProes());
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            service.FillIngrediantsInProRandom(id);
            return Ok(service.GetIngredientsInPro(id));
        }

        // POST api/<controller>
        public IHttpActionResult Post(ingredientsInProDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PostIngredientInPro(value);
            if (value == null)
            {
                return BadRequest("שמירה נכשלה");
            }
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(ingredientsInProDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.PostIngredientInPro(value);
            if (value == null)
            {
                return BadRequest("עדכון נכשל");
            }
            return Ok(value);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(ingredientsInProDto value)
        {
            if (value == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            value = service.RemoveIngredientsInPro(value);
            if (value == null)
            {
                return BadRequest("מחיקה נכשלה");
            }
            return Ok(value);
        }
    }
}