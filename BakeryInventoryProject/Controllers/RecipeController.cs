using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryInventoryProject.Controllers;
using BakeryInventoryProject.Models;
namespace BakeryInventoryProject.Controllers {
    public class RecipeController : Controller {
        //GET: Recipe
        static int RecipeIdInputStatic; 
        //ActionMethods
        public ActionResult Recipe() {
            ViewBag.RecipeDetails = GetAllRecipes();
            ViewBag.RecipeTypes = GetAllRecipeTypes();
            return View();
        }
        public ActionResult ViewRecipesInRecipeTypes(int RecipeTypeIdInput) {
            ViewBag.RecipeTypeRecipes = GetAllRecipesForRecipeType(RecipeTypeIdInput);
            ViewBag.RecipeType = GetRecipeType(RecipeTypeIdInput);
            ViewBag.RecipeTypes = GetAllRecipesForRecipeTypeView(RecipeTypeIdInput);
            return View("RecipesInRecipeTypes");
        }
        public ActionResult RecipeIngredients(int RecipeIdInput) {
            var IngController = new BakeryInventoryProject.Controllers.IngredientController();
            ViewBag.RecipeInfo = GetRecipeInfo(RecipeIdInput); 
            ViewBag.RecIngs = IngController.RecipeIngredients(RecipeIdInput);
            ViewBag.RecipeDetails = GetRecipeInfo(RecipeIdInput);
            ViewBag.AllMeasurementTypes = IngController.GetAllMeasurementType();
            ViewBag.AllIngredientTypes = IngController.GetAllIngredientTypes();
            return View("RecipeIngredients");
        }
        //RetrieveDataMethods
        public List<vw_RecipeDetails> GetAllRecipes() {
            var db = new BakeryInventoryEntities();
            var rec = db.vw_RecipeDetails;
            var recDets = (from r in rec orderby r.RecipeTypeName, r.RecipeName select r).ToList();
            return recDets;
        }
        public List<Recipe> GetAllRecipesPlain() {
            var db = new BakeryInventoryEntities();
            var rec = db.Recipe;
            var recs = (from r in rec orderby r.Name select r).ToList();
            return recs;
        }
        public List<RecipeType> GetAllRecipeTypes() {
            var db = new BakeryInventoryEntities();
            var rTypes = db.RecipeType;
            var recipeTypes = (from rt in rTypes orderby rt.Name select rt).ToList();
            return recipeTypes;
        }
        public vw_RecipeDetails GetRecipeInfo(int RecipeIdInput) {
            var db = new BakeryInventoryEntities();
            var rec = db.vw_RecipeDetails;
            var recDets = (from r in rec where r.RecipeId == RecipeIdInput select r).First();
            return recDets;
        }
        public List<Recipe> GetAllRecipesForRecipeType(int RecipeTypeIdInput) {
            var db = new BakeryInventoryEntities();
            var rec = db.Recipe;
            var listOfRecs = (from r in rec where r.RecipeTypeId == RecipeTypeIdInput select r).ToList();
            return listOfRecs;
        }
        public List<vw_RecipeDetails> GetAllRecipesForRecipeTypeView(int RecipeTypeIdInput) {
            var db = new BakeryInventoryEntities();
            var rec = db.vw_RecipeDetails;
            var recDets = (from r in rec where r.RecipeTypeId == RecipeTypeIdInput select r).ToList();
            return recDets;
        }
        public RecipeType GetRecipeType(int RecipeTypeIdInput) {
            var db = new BakeryInventoryEntities();
            var recType = db.RecipeType;
            var recTypeList = (from rt in recType where rt.RecipeTypeId == RecipeTypeIdInput select rt).First();
            return recTypeList;
        }
        //InsertMethods
        public ActionResult InsertRecipe(string RecipeNameInput, int YieldInput, int RecipeTypeIdInput) {
            var db = new BakeryInventoryEntities();
            var rec = db.Recipe;
            var ins = new Recipe {
                Name = RecipeNameInput,
                Yield = YieldInput,
                RecipeTypeId = RecipeTypeIdInput
            };
            db.Recipe.Add(ins);
            db.SaveChanges();
            return RedirectToAction("Recipe");
        }
        public ActionResult InsertIngredientForRecipe(int RecipeIdInputIns, string NameInput, string MeasurementValueInput,int MeasurementTypeIdInput, int IngredientTypeIdInput) {
            var db = new BakeryInventoryEntities();
            var ing = db.Ingredient;
            RecipeIdInputStatic = RecipeIdInputIns; 
            var ins = new Ingredient {
                Name = NameInput,
                RecipeId = RecipeIdInputIns,
                MeasurementValue = System.Convert.ToDecimal(MeasurementValueInput),
                MeasurementTypeId = MeasurementTypeIdInput, //hardcoded temporarily
                IngredientTypeId = IngredientTypeIdInput //harcoded temporarily
            };
            db.Ingredient.Add(ins);
            db.SaveChanges();
            return RedirectToAction("RecipeIngredients", new { RecipeIdInput = RecipeIdInputStatic });
        }
        //update the recipe yield 
        public ActionResult UpdateRecipeYield(int RecipeIdInput, string YieldMultiplierInput) {
            RecipeIdInputStatic = RecipeIdInput; 
            var db = new BakeryInventoryEntities();
            var rec = db.Recipe;
            var recToUpdate = (from r in rec where r.RecipeId == RecipeIdInput select r).First();
            var yieldAdjustmentCalculations = new YieldCalculations();
            var yieldMultiplier = 0m; 
            if (YieldMultiplierInput.Contains('/')) { //if the value is a fraction, then convert it to a rounded decimal
                var parseFractionToDecimal = new ParseFractionToDecimal();
                yieldMultiplier = parseFractionToDecimal.CalculateFractionToDecimal(YieldMultiplierInput); 
            }
            else { yieldMultiplier = System.Convert.ToDecimal(YieldMultiplierInput); }
            if (recToUpdate.Yield == 0) {
                recToUpdate.Yield = yieldAdjustmentCalculations.RoundToInteger(yieldMultiplier);
            }
            recToUpdate.Yield = yieldAdjustmentCalculations.RoundToInteger(recToUpdate.Yield * yieldMultiplier);
            db.SaveChanges();
            return RedirectToAction("RecipeIngredients", new { RecipeIdInput = RecipeIdInputStatic });
        }
    }
}