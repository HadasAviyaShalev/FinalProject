using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Service
{
    public class IngredientService
    {
        //get all ingredients from database
        public List<ingredientDto> GetIngredients()
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    return Convertion.IngredientConvertion.convert(db.ingredients.ToList());
                }
                catch
                {
                    return null;
                }
            }
        }

        //get one ingredients by id from database
        public ingredientDto GetIngredient(int id)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    ingredient Ingredient = db.ingredients.FirstOrDefault(x => x.id == id);
                    if (Ingredient == null)
                        return null;
                    return Convertion.IngredientConvertion.convert(Ingredient);
                }
                catch
                {
                    return null;
                }
            }
        }

        //update ingredient in database
        public ingredientDto PutIngredient(ingredientDto IngredientDto, ref string f)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    ingredient Ingredient = db.ingredients.FirstOrDefault(x => x.id == IngredientDto.id);
                    if (Ingredient == null)
                    {
                        f = "לא קיים";
                        return null;
                    }

                    Ingredient.id = IngredientDto.id;
                    Ingredient.CDescription = IngredientDto.CDescription;
                    Ingredient.RecommendedDoseMale = IngredientDto.RecommendedDoseMale;
                    Ingredient.RecommendedDoseFemale = IngredientDto.RecommendedDoseFemale;
                    Ingredient.UnitCode = IngredientDto.UnitCode;
                    return Convertion.IngredientConvertion.convert(Ingredient);
                }
                catch
                {
                    return null;
                }
            }
        }

        //add ingredient to database
        public ingredientDto PostIngredient(ingredientDto IngredientDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    ingredient Ingredient = db.ingredients.Add(Convertion.IngredientConvertion.convert(IngredientDto));
                    db.SaveChanges();
                    return Convertion.IngredientConvertion.convert(Ingredient);
                }
                catch
                {
                    return null;
                }
            }
        }

        //remove ingredient to database
        public ingredientDto RemoveIngredient(ingredientDto IngredientDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    ingredient Ingredient = db.ingredients.Remove(Convertion.IngredientConvertion.convert(IngredientDto));
                    db.SaveChanges();
                    return Convertion.IngredientConvertion.convert(Ingredient);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
