using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Convertion
{
    public class IngredientConvertion
    {

        //convert one ingredientDto to ingredient
        public static ingredient convert(ingredientDto Ingredient)
        {
            ingredient NewIngredient = new ingredient();
            NewIngredient.id = Ingredient.id;
            NewIngredient.CDescription = Ingredient.CDescription;
            NewIngredient.RecommendedDoseMale = Ingredient.RecommendedDoseMale;
            NewIngredient.RecommendedDoseFemale = Ingredient.RecommendedDoseFemale;
            NewIngredient.UnitCode = Ingredient.UnitCode;
            return NewIngredient;
        }

        //convert one ingredient to ingredientDto
        public static ingredientDto convert(ingredient Ingredient)
        {
            ingredientDto NewIngredient = new ingredientDto();
            NewIngredient.id = Ingredient.id;
            NewIngredient.CDescription = Ingredient.CDescription;
            NewIngredient.RecommendedDoseMale = Ingredient.RecommendedDoseMale;
            NewIngredient.RecommendedDoseFemale = Ingredient.RecommendedDoseFemale;
            NewIngredient.UnitCode = Ingredient.UnitCode;
            return NewIngredient;
        }

        //convert list of ingredient to ingredientDto
        public static List<ingredientDto> convert(List<ingredient> ingredient)
        {
            List<ingredientDto> Newingredient = new List<ingredientDto>();
            ingredient.ForEach(x => {
                Newingredient.Add(convert(x));
            });
            return Newingredient;

        }

        //convert list of ingredientDto to ingredient
        public static List<ingredient> convert(List<ingredientDto> ingredient)
        {
            List<ingredient> Newingredient = new List<ingredient>();
            ingredient.ForEach(x => {
                Newingredient.Add(convert(x));
            });
            return Newingredient;

        }
    }
}
