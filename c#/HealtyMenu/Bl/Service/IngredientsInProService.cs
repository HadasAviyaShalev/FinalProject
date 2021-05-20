using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Service
{
    public class IngredientsInProService
    {
        //get all ingredientInPro from database
        public List<ingredientsInProDto> GetIngredientsInProes()
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    return Convertion.IngredientsInProConvertion.convert(db.ingredientsInProes.ToList());
                }
                catch
                {
                    return null;
                }
            }
        }

        //get one ingredientInPro by id from database
        public ingredientsInProDto GetIngredientsInPro(int id)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    ingredientsInPro IngredientsInPro = db.ingredientsInProes.FirstOrDefault(x => x.id == id);
                    if (IngredientsInPro == null)
                        return null;
                    return Convertion.IngredientsInProConvertion.convert(IngredientsInPro);
                }
                catch
                {
                    return null;
                }
            }
        }

        //update ingredientInPro in database
        public ingredientsInProDto PutIngredientsInPro(ingredientsInProDto IngredientsInProDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    ingredientsInPro IngredientsInPro = db.ingredientsInProes.FirstOrDefault(x => x.id == IngredientsInProDto.id);
                    if (IngredientsInPro == null)
                        return null;
                    IngredientsInPro.id = IngredientsInProDto.id;
                    IngredientsInPro.foodID = IngredientsInProDto.foodID;
                    IngredientsInPro.ingredientsId = IngredientsInProDto.ingredientsId;
                    IngredientsInPro.countFor100gr = IngredientsInProDto.countFor100gr;
                    return Convertion.IngredientsInProConvertion.convert(IngredientsInPro);
                }
                catch
                {
                    return null;
                }
            }
        }

        //add ingredientInPro to database
        public ingredientsInProDto PostIngredientInPro(ingredientsInProDto IngredientsInProDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    ingredientsInPro IngredientsInPro = db.ingredientsInProes.Add(Convertion.IngredientsInProConvertion.convert(IngredientsInProDto));
                    db.SaveChanges();
                    return Convertion.IngredientsInProConvertion.convert(IngredientsInPro);
                }
                catch
                {
                    return null;
                }
            }
        }

        //remove ingredientInPro from database
        public ingredientsInProDto RemoveIngredientsInPro(ingredientsInProDto IngredientsInProDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    ingredientsInPro IngredientsInPro = db.ingredientsInProes.Remove(Convertion.IngredientsInProConvertion.convert(IngredientsInProDto));
                    db.SaveChanges();
                    return Convertion.IngredientsInProConvertion.convert(IngredientsInPro);
                }
                catch
                {
                    return null;
                }
            }
        }

        public void FillIngrediantsInPro(int foodId)
        {
            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                var allIngredients = db.ingredients.ToList();
                foreach (var item in allIngredients)
                {
                    if (!item.ingredientsInProes.Any(i => i.foodID == foodId))
                        db.ingredientsInProes.Add(new ingredientsInPro { foodID=foodId,ingredientsId=item.id,countFor100gr=0});
                }
                db.SaveChanges();

                   
            }
        }

        public void FillIngrediantsInProRandom(int foodId)
        {
            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                Random rnd = new Random();
                var allIngredients = db.ingredients.ToList();
                foreach (var item in allIngredients)
                {
                    if (!item.ingredientsInProes.Any(i => i.foodID == foodId))
                        db.ingredientsInProes.Add(new ingredientsInPro { foodID = foodId, ingredientsId = item.id, countFor100gr = rnd.Next(10,100) });
                }
                db.SaveChanges();


            }
        }

    }
}
