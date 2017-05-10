using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithDb
{
    class RecipesDB
    {
        public void working_With_Recipes_DB()
        {
            using (RecipesEntities context = new RecipesEntities())
            {
                // 1. using id properties
                Category categoty = context.Categories.FirstOrDefault(c => c.Name == "Breakfast");
                context.Recipes.Add(new Recipe { Name = "eggs", CategoryId = categoty.Id });

                // 2. recipe.category navigation property
                Category categoty2 = context.Categories.FirstOrDefault(c => c.Name == "Lunch");
                context.Recipes.Add(new Recipe { Name = "Pizza", Category = categoty2 });

                // 3. category.recpe navigation property
                Category categoty3 = context.Categories.FirstOrDefault(c => c.Name == "Lunch");
                categoty3.Recipes.Add(new Recipe { Name = "Soup" });

                //query
                Category category4 = context.Categories.FirstOrDefault(c => c.Name == "Lunch");
                List<Recipe> recipes = category4.Recipes.ToList();
                recipes.ForEach(r => Console.WriteLine(r.Name));

                Recipe recipe = context.Recipes.FirstOrDefault(r => r.Name == "Pizza");
                Console.WriteLine(recipe.Category.Name);

            }
        }
    }
}
