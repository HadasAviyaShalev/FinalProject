using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Google.OrTools.LinearSolver;
using static Google.OrTools.LinearSolver.Solver;

namespace Bl.Service
{
    public class menuService
    {
        public Dictionary<FoodDto,double> CalcRecomandedMenu( Dictionary<string, double> nutritionValuesDict, Dictionary<FoodDto, double[]> data)
        {
            Dictionary<FoodDto, double> resulnGrams = new Dictionary<FoodDto, double>();

          
            //Dictionary<string, int> nutritionValuesDict = GetAllNutritionValuesAsArray(nutritionValues);


           


                Solver solver = Solver.CreateSolver("GLOP");
                Objective objective = solver.Objective();

                int len = data.Count;
                Variable[] food = new Variable[len];

                int i = 0;
                foreach (var f in data)
                {
                    food[i] = solver.MakeNumVar(0.0, double.PositiveInfinity, f.Key.foodName);
                    objective.SetCoefficient((Variable)food[i++], 1);
                }
                objective.SetMinimization();

                //int[,] nutritionValueForFood = new int[len, nutritionValuesDict.Count];

                //Random rnd = new Random();
                //for (int k = 0; k < len; k++)
                //{
                //    for (int j = 0; j < nutritionValuesDict.Count; j++)
                //    {
                //        nutritionValueForFood[k, j] = rnd.Next(50);
                //    }
                //}


                Constraint[] constraints = new Constraint[nutritionValuesDict.Count];
                for (i = 0; i < nutritionValuesDict.Count; i++)
                {
                    constraints[i] = solver.MakeConstraint(nutritionValuesDict.ElementAt(i).Value, double.PositiveInfinity);
                    for (int j = 0; j < data.Count; j++)
                    {
                        constraints[i].SetCoefficient(food[j], data.ElementAt(j).Value[i]);

                    }
                }

                ResultStatus status = solver.Solve();
                i = 0;
              
                if (status == ResultStatus.OPTIMAL)
                    foreach (var item in food)
                    {
                        resulnGrams.Add(data.ElementAt(i++).Key,
                                        item.SolutionValue() * 100);
                        
                    }
            
            return resulnGrams;
                



        }

        public Dictionary<string, int> GetAllNutritionValuesAsArray(detailsDto nutritionValues)
        {
            Dictionary<string, int> nutritionValuesDict = new Dictionary<string, int>();
            PropertyInfo[] properties = typeof(detailsDto).GetProperties();

            for (int i = 2; i < properties.Length; i++)
            {
                nutritionValuesDict.Add(properties[i].Name, (int)((double)properties[i].GetValue(nutritionValues)));
            }
            return nutritionValuesDict;

        }


       // public List<Dictionary<FoodDto, double>> CalcAllMeals(Dictionary<string, vitamin> nutritionValuesDict)
        public resultDto CalcAllMeals(Dictionary<string, vitamin> nutritionValuesDict)

        {
            //breakfast:
            Dictionary<FoodDto, double[]> breakFast = new FoodService().GetFoodsNutritionValues(9);
            Dictionary<FoodDto, double[]> lunch = new FoodService().GetFoodsNutritionValues(10);
            Dictionary<FoodDto, double[]> dinner = new FoodService().GetFoodsNutritionValues(11);
            Dictionary<FoodDto, double[]> between = new FoodService().GetFoodsNutritionValues(5);


            Dictionary<string, double> nutritionValuesBreackfast = new Dictionary<string, double>();
            Dictionary<string, double> nutritionValuesLunch = new Dictionary<string, double>();
            Dictionary<string, double> nutritionValuesDinner = new Dictionary<string, double>();
            Dictionary<string, double> nutritionValuesBetween = new Dictionary<string, double>();

            Dictionary<string, List<int>> indexesToRemove = new Dictionary<string, List<int>>();
            indexesToRemove.Add("breakFast", new List<int>());
            indexesToRemove.Add("lunch", new List<int>());
            indexesToRemove.Add("dinner", new List<int>());
            indexesToRemove.Add("between", new List<int>());

            for (int i = 0; i < nutritionValuesDict.Count; i++)
            {
                int numMealsContainNutritionValue = 0;

                nutritionValuesDict.ElementAt(i).Value.MaxBreakfast = AmountInAllMeal(breakFast, i);
                if (nutritionValuesDict.ElementAt(i).Value.MaxBreakfast > 0)
                    numMealsContainNutritionValue++;
                nutritionValuesDict.ElementAt(i).Value.MaxLunch = AmountInAllMeal(lunch, i);
                if (nutritionValuesDict.ElementAt(i).Value.MaxLunch > 0)
                    numMealsContainNutritionValue++;
                nutritionValuesDict.ElementAt(i).Value.MaxDinner = AmountInAllMeal(dinner, i);
                if (nutritionValuesDict.ElementAt(i).Value.MaxDinner > 0)
                    numMealsContainNutritionValue++;
                nutritionValuesDict.ElementAt(i).Value.MaxBetween =AmountInAllMeal(between, i);
                if (nutritionValuesDict.ElementAt(i).Value.MaxBetween > 0)
                    numMealsContainNutritionValue++;




                double amountForMeal = nutritionValuesDict.ElementAt(i).Value.client / numMealsContainNutritionValue;
                if (nutritionValuesDict.ElementAt(i).Value.MaxBreakfast == 0)
                    indexesToRemove["breakFast"].Add(i);
                else nutritionValuesBreackfast.Add(nutritionValuesDict.ElementAt(i).Key, amountForMeal);
                if (nutritionValuesDict.ElementAt(i).Value.MaxLunch == 0)
                    indexesToRemove["lunch"].Add(i);
                else nutritionValuesLunch.Add(nutritionValuesDict.ElementAt(i).Key, amountForMeal);

                if (nutritionValuesDict.ElementAt(i).Value.MaxDinner == 0)
                    indexesToRemove["dinner"].Add(i);
                else nutritionValuesDinner.Add(nutritionValuesDict.ElementAt(i).Key, amountForMeal);

                if (nutritionValuesDict.ElementAt(i).Value.MaxBetween == 0)
                    indexesToRemove["between"].Add(i);
                else nutritionValuesBetween.Add(nutritionValuesDict.ElementAt(i).Key, amountForMeal);





                //if(numMealsContainNutritionValue==0)
                    //todo save the fact this cannot be in the meal



            }

           


            ///results!!!
            var breakFastRes = CalcRecomandedMenu(nutritionValuesBreackfast, RemoveIndexesFromDict(breakFast,indexesToRemove["breakFast"]));
            var lunchRes = CalcRecomandedMenu(nutritionValuesLunch, RemoveIndexesFromDict(lunch, indexesToRemove["lunch"]));
            var dinnerRes = CalcRecomandedMenu(nutritionValuesDinner, RemoveIndexesFromDict(dinner, indexesToRemove["dinner"]));
            var betweenRes = CalcRecomandedMenu(nutritionValuesBetween, RemoveIndexesFromDict(between, indexesToRemove["between"]));

            List<Dictionary<FoodDto, double>> result = new List<Dictionary<FoodDto, double>>();
            result.Add(breakFastRes);
            result.Add(lunchRes);
            result.Add(dinnerRes);
            result.Add(betweenRes);
            resultDto r = new resultDto();
            r.menuList = new List<menuList>();
            foreach (var i in breakFastRes)
            {
                r.menuList.Add(new menuList
                {
                    foodName = i.Key.foodName,
                    amount=i.Value,
                    meal=1,
                    type="gram"
              });
            }
            foreach (var i in lunchRes)
            {
                r.menuList.Add(new menuList
                {
                    foodName = i.Key.foodName,
                    amount = i.Value,
                    meal = 2,
                    type = "gram"
                });
            }
            foreach (var i in dinnerRes)
            {
                r.menuList.Add(new menuList
                {
                    foodName = i.Key.foodName,
                    amount = i.Value,
                    meal = 3,
                    type = "gram"
                });
            }
            foreach (var i in betweenRes)
            {
                r.menuList.Add(new menuList
                {
                    foodName = i.Key.foodName,
                    amount = i.Value,
                    meal = 4,
                    type = "gram"
                });
            }
            return r;
        }

        private double AmountInAllMeal(Dictionary<FoodDto, double[]> food,int index)
        {
            double sum = 0;
            foreach (var item in food)
            {
                sum += item.Value[index];
            }
            return sum;
        }

        private double[] RemoveIndexes(double[] numbers,List<int> indexesToRemove)
        {
            return numbers.Where((val, idx) => !indexesToRemove.Any(i=>i==idx)).ToArray();
        }

        private Dictionary<FoodDto,double[]> RemoveIndexesFromDict(Dictionary<FoodDto, double[]> dict,List<int> indexesToRemove)
        {
            for (int i = 0; i < dict.Count; i++)
            {
                var item = dict.ElementAt(i);
                dict[item.Key] = RemoveIndexes(item.Value, indexesToRemove);

            }
          
            return dict;
        }
      }
}
