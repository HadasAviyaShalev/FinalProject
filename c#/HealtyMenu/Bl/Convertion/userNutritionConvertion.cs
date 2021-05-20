using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Convertion
{
    public class userNutritionConvertion
    {
        //convert one userNutritionDto to userNutrition
        public static userNutrition convert(userNutritionDto UserNutrition)
        {
            return new userNutrition()
            {
                id = UserNutrition.id,
                userId = UserNutrition.userId,
                yourName = UserNutrition.yourName,
                inserDate = UserNutrition.inserDate,
                menus = convert( UserNutrition.menus)
            };
        }

        //convert one userNutrition to userNutritionDto
        public static userNutritionDto convert(userNutrition UserNutrition)
        {
            return new userNutritionDto()
            {
                id = UserNutrition.id,
                userId = UserNutrition.userId,
                yourName = UserNutrition.yourName,
                inserDate = UserNutrition.inserDate,
                menus = convert(UserNutrition.menus.ToList())
            };
            
        }
        public static List<menuDto> convert(List<menu> Menues)
        {
            return Menues.Select(x => convert(x)).ToList();
        }
        public static menuDto convert(menu Menu)
        {
            return new menuDto()
            {
                id = Menu.id,
                amount= Menu.amount,
                foodCode= Menu.foodCode,
                suitableToId=Menu.suitableToId,
                userNutritionCode =Menu.userNutritionCode

            };

        }

        public static List<menu> convert(List<menuDto> Menues)
        {
            return Menues.Select(x => convert(x)).ToList();
        }
        public static menu convert(menuDto Menu)
        {
            return new menu()
            {
                id = Menu.id,
                amount = Menu.amount,
                foodCode = Menu.foodCode,
                suitableToId = Menu.suitableToId,
                userNutritionCode = Menu.userNutritionCode

            };

        }
    }
}

