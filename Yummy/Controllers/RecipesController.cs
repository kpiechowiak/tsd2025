using Microsoft.AspNetCore.Mvc;
using Yummy.Models;
using System.Text.Encodings.Web;

namespace Yummy.Controllers
{
    public class RecipesController : Controller
    {

        /*public static List<Recipe> _recipes = new List<Recipe>
        {
            new Recipe { ID = 1, Name = "Spaghetti Carbonara", Time = "20 minutes", Difficulty = "Medium", NumberOfLikes = 5, Ingredients = "Pasta, Eggs, Pancetta" , Process = "Boil pasta, cook pancetta, mix with eggs and cheese", TipsAndTricks = "Use fresh eggs" },
            new Recipe { ID = 2, Name = "Classic Cheeseburger", Time = "25 minutes", Difficulty = "Easy", NumberOfLikes = 3, Ingredients = "Ground beef, Cheese, Buns" , Process = "Grill beef, melt cheese on top, assemble burger", TipsAndTricks = "Toast the buns for extra crunch" }

        };*/
        public static List<Recipe> _recipes = new List<Recipe>
        {
            new Recipe
            {
                ID = 1,
                Name = "Serniczek",
                Time = "1 hour",
                Difficulty = "Medium",
                NumberOfLikes = 10,
                Ingredients = "Cottage cheese, eggs, sugar, butter, biscuits",
                Process = "Blend all ingredients, pour the mixture into a baking form, bake for 60 minutes at 180°C",
                TipsAndTricks = "Add a bit of lemon zest for extra flavor"
            },
            new Recipe
            {
                ID = 2,
                Name = "Jab³eczniczek",
                Time = "1 hour 20 minutes",
                Difficulty = "Easy",
                NumberOfLikes = 7,
                Ingredients = "Apples, flour, butter, sugar, cinnamon",
                Process = "Cook apples with cinnamon, prepare shortcrust dough, layer the apples and bake for 45 minutes",
                TipsAndTricks = "Dust with powdered sugar after baking"
            }
        };



        public IActionResult Index()
        {
            return View(_recipes);
        }

        public IActionResult Details(int id)
        {
            var recipe = _recipes.FirstOrDefault(r => r.ID == id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.ID = _recipes.Max(r => r.ID) + 1; // Simple ID assignment for our in-memory list
                _recipes.Add(recipe);
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        public IActionResult Edit(int id)
        {
            var recipe = _recipes.FirstOrDefault(r => r.ID == id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Recipe recipe)
        {
            if (id != recipe.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var recipeIndex = _recipes.FindIndex(r => r.ID == id);
                if (recipeIndex != -1)
                {
                    _recipes[recipeIndex] = recipe; // Update the recipe
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            return View(recipe);
        }

        public IActionResult Delete(int id)
        {
            var recipe = _recipes.FirstOrDefault(r => r.ID == id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var recipe = _recipes.FirstOrDefault(r => r.ID == id);
            if (recipe != null)
            {
                _recipes.Remove(recipe);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}