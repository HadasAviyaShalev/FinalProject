using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Convertion
{
    public class IngredientsInProConvertion
    {

        //convert one ingredientsInPro to ingredientsInProDto
        public static ingredientsInProDto convert(ingredientsInPro IngredientInPro)
        {
            ingredientsInProDto NewIngredientInPro = new ingredientsInProDto();
            NewIngredientInPro.id = IngredientInPro.id;
            NewIngredientInPro.foodID = IngredientInPro.foodID;
            NewIngredientInPro.ingredientsId = IngredientInPro.ingredientsId;
            NewIngredientInPro.countFor100gr = IngredientInPro.countFor100gr;
            return NewIngredientInPro;
        }

        //convert one ingredientsInProDto to ingredientsInPro
        public static ingredientsInPro convert(ingredientsInProDto IngredientInPro)
        {
            ingredientsInPro NewIngredientInPro = new ingredientsInPro();
            NewIngredientInPro.id = IngredientInPro.id;
            NewIngredientInPro.foodID = IngredientInPro.foodID;
            NewIngredientInPro.ingredientsId = IngredientInPro.ingredientsId;
            NewIngredientInPro.countFor100gr = IngredientInPro.countFor100gr;
            return NewIngredientInPro;
        }


        //convert list of ingredientsInPro to ingredientsInProDto
        public static List<ingredientsInProDto> convert(List<ingredientsInPro> ingredientsInPro)
        {
            List<ingredientsInProDto> NewingredientsInPro = new List<ingredientsInProDto>();
            ingredientsInPro.ForEach(x => {
                NewingredientsInPro.Add(convert(x));
            });
            return NewingredientsInPro;

        }

        //convert list of ingredientsInProDto to ingredientsInPro
        public static List<ingredientsInPro> convert(List<ingredientsInProDto> ingredientsInPro)
        {
            List<ingredientsInPro> NewingredientsInPro = new List<ingredientsInPro>();
            ingredientsInPro.ForEach(x => {
                NewingredientsInPro.Add(convert(x));
            });
            return NewingredientsInPro;

        }
    }
}
