using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Convertion
{
   public class FoodConvetrtion
    {

        //convert one FoodDto to Food
        public static Food convert(FoodDto food)
        {
            Food NewFood = new Food();
            NewFood.cosher = food.cosher;
            NewFood.foodName = food.foodName;
            NewFood.id = food.id;
            NewFood.picture = food.picture;
            NewFood.suitableToID = food.suitableToID;
            NewFood.category = food.category;
            return NewFood;

        }

        //convert one Food to FoodDto
        public static FoodDto convert(Food food)
        {
            FoodDto NewFood = new FoodDto();
            NewFood.cosher = food.cosher;
            NewFood.foodName = food.foodName;
            NewFood.id = food.id;
            NewFood.picture = food.picture;
            NewFood.suitableToID = food.suitableToID;
            NewFood.category = food.category;
            return NewFood;

        }

        //convert list of Food to FoodDto
        public static List<FoodDto> convert(List<Food> food)
        {
            List<FoodDto> NewFood = new List<FoodDto>();
            food.ForEach(x=> {
                NewFood.Add(convert(x));
            });
            return NewFood;

        }
        //convert list of FoodDto to Food
        public static List<Food> convert(List<FoodDto> food)
        {
            List<Food> NewFood = new List<Food>();
            food.ForEach(x => {
                NewFood.Add(convert(x));
            });
            return NewFood;

        }

    }
}
