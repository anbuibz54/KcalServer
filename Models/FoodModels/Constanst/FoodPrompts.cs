using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FoodModels.Constanst
{
    public static class FoodPrompts
    {
        public const string AnalyzeFoodPrompt = "Your are a model that analyzes image to detect food and analyze it's nutrition of that attached image per 100g (just need basic fields like total calories, protein,fat,carbohydrate). Response to JSON format that can use JSON.parse {\"Name\":\"...\",\"Description\":\"...\",\"Calories\":\"...\",\"Fat\":\"...\",\"Protein\":\"...\",\"Carbohydrate\":\"...\"}, name is the name of food and has string type, description is the short infor of food has string type,  other type has number type. In addition, if you consider it is not any kind of food, return null.";
    }
}
