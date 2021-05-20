using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Service
{
    public class userNutritionService
    {
        Dictionary<string, vitamin> unit;
        //get userNutrition by id from database
        public userNutritionDto GetUserNutrition(int id)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    userNutrition UserNutrition = db.userNutritions.FirstOrDefault(x => x.id == id);
                    if (UserNutrition == null)
                        return null;
                    return Convertion.userNutritionConvertion.convert(UserNutrition);
                }
                catch
                {
                    return null;
                }
            }
        }

        //update userNutrition in database
        public userNutritionDto PutUserNutrition(userNutritionDto UserNutritionDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    userNutrition UserNutrition = db.userNutritions.FirstOrDefault(x => x.id == UserNutritionDto.id);
                    if (UserNutrition == null)
                        return null;
                    UserNutrition.id = UserNutritionDto.id;
                    UserNutrition.userId = UserNutritionDto.userId;
                    UserNutrition.yourName = UserNutritionDto.yourName;
                    UserNutrition.inserDate = UserNutritionDto.inserDate;
                    return Convertion.userNutritionConvertion.convert(UserNutrition);
                }
                catch
                {
                    return null;
                }
            }

           
        }
        public Dictionary<string, vitamin> unitfunc(detailsDto UserNutritionDto)
        {
            Dictionary<string, vitamin> keyValuePairs = new Dictionary<string, vitamin>();
            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                foreach (PropertyInfo t in UserNutritionDto.GetType().GetProperties())
                {
                    ageDimension a = db.ageDimensions.FirstOrDefault(x => x.statusCode == UserNutritionDto.myStatus && x.ingredient.CDescription == t.Name);
                    if (a != null)
                    keyValuePairs.Add(t.Name, new vitamin()
                    {
                        client = Convert.ToDouble(t.GetValue(UserNutritionDto)),
                        count = (double)a.RecommendedDose,
                        flag= (double)a.RecommendedDose,
                        max= (double)a.MaxDose,
                        min= a.highMissing
                    });

                }
                return keyValuePairs;
            }
        }
        public Dictionary<int, menuList> food()
        {
            Dictionary<int, menuList> keyValuePairs = new Dictionary<int, menuList>();
            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                var foods = db.Foods.Where(x => x.suitableToID == 1);
                //int d= unit.FirstOrDefault(x=>x.Value.count==   unit.Max(f => f.Value.count)).Key;
                // foods.Select(x =>x.ingredientsInProes.ingredientsId)
                //keyValuePairs.Add();
                return keyValuePairs.OrderBy(k => k.Key).ToDictionary(k => k.Key, k => k.Value);

            }
        }
        public resultDto PostUserNutrition(detailsDto UserNutritionDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                //try
                //{
                   // Dictionary<int, menuList> food;
                   
                unit = this.unitfunc(UserNutritionDto);
                //foreach (var item in unit)
                //{
                //    item.Value.client = item.Value.client / 3;
                //}

               
                  resultDto r= new menuService().CalcAllMeals(unit);
                   

                return r;
               // }
                //catch(Exception e)
                //{
                //    return null;
                //}
            }
        }
        public userNutritionDto PostUserNutrition(userNutritionDto UserNutritionDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    userNutrition UserNutrition = db.userNutritions.Add(Convertion.userNutritionConvertion.convert(UserNutritionDto));
                    db.SaveChanges();
                    return Convertion.userNutritionConvertion.convert(UserNutrition);
                }
                catch
                {
                    return null;
                }
            }
        }


        //remove UserNutrition from database
        public userNutritionDto RemoveUserNutrition(userNutritionDto UserNutritionDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    userNutrition UserNutrition = db.userNutritions.Remove(Convertion.userNutritionConvertion.convert(UserNutritionDto));
                    db.SaveChanges();
                    return Convertion.userNutritionConvertion.convert(UserNutrition);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
