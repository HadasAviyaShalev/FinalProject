using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Service
{
  public  class FoodService
    {
        //get all foods from database
        public List<FoodDto> GetFoods()
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    return Convertion.FoodConvetrtion.convert(db.Foods.ToList());
                }
                catch
                {
                    return null;
                }
                           }
        }



        public Dictionary<FoodDto,double[]> GetFoodsNutritionValues(int sutableTo)
        {
            Dictionary<FoodDto, double[]> foodsNutritionValues = new Dictionary<FoodDto, double[]>();
            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                int numIngridiants = db.ingredients.Count();
                //todo Check if food is good for user
                //לחלק את הכמויות בין הארוחות וכל פעם לשלוף רק את המאכלים שמתאימים לארוחה
                foreach (var food in db.Foods.Where(f=>f.suitableToID==sutableTo))
                {
                    foodsNutritionValues.Add(
                     Convertion.FoodConvetrtion.convert(food),
                     food.ingredientsInProes.OrderBy(i => i.ingredient.CDescription).Select(i => i.countFor100gr.Value).ToFixedLength(numIngridiants)
                    );
                }
            }
            return foodsNutritionValues;
        }

        //get food by id from database
        public FoodDto GetFood(int id)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try { 
               Food food =   db.Foods.FirstOrDefault(x=>x.id==id);
                if (food == null)
                    return null;
                return Convertion.FoodConvetrtion.convert(food);
                }
                catch
                {
                    return null;
                }
            }
        }

        //update food in database
        public FoodDto PutFood(FoodDto foodDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    Food food = db.Foods.FirstOrDefault(x => x.id == foodDto.id);
                    if (food == null)
                        return null;
                    food.cosher = foodDto.cosher;
                    food.foodName = foodDto.foodName;
                    food.id = foodDto.id;
                    food.picture = foodDto.picture;
                    food.suitableToID = foodDto.suitableToID;
                    food.category = foodDto.category;
                    return Convertion.FoodConvetrtion.convert(food);
                }
                catch
                {
                    return null;
                }
            }
        }

        //add food to database
        public FoodDto PostFood(FoodDto foodDto)
        {

            using(HealthyMenuEntities db=new HealthyMenuEntities())
            {
                try { 
                Food food = db.Foods.Add(Convertion.FoodConvetrtion.convert(foodDto));
                db.SaveChanges();
                return Convertion.FoodConvetrtion.convert(food);
                }
                catch
                {
                    return null;
                }
            }
        }

        //remove food from database
        public FoodDto RemoveFood(FoodDto foodDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try { 
                Food food = db.Foods.Remove(Convertion.FoodConvetrtion.convert(foodDto));
                db.SaveChanges();
                return Convertion.FoodConvetrtion.convert(food);}
                catch
                {
                    return null;
                }
            }
        }
    }
}
