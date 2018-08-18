using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryInventoryProject.Models;
using BakeryInventoryProject.Controllers;

namespace BakeryInventoryProject.Controllers {
    public class IngredientController : Controller {
        // GET: Ingredient
        //ActionMethods
        public ActionResult Ingredient() {
            var recController = new RecipeController();
            ViewBag.AllIngredientDetails = GetIngredientDetails();
            ViewBag.AllRecipes = recController.GetAllRecipesPlain();
            ViewBag.AllWeights = GetAllWeight();
            ViewBag.AllMeasurementTypes = GetAllMeasurementType();
            ViewBag.AllIngredientTypes = GetAllIngredientTypes(); 
            return View();
        }
        //RetrieveDataMethods
        public List<vw_IngredientDetails> RecipeIngredients(int RecipeIdInput) {
            var parse = new ParseDecimalToFraction(); 
            var db = new BakeryInventoryEntities();
            var ings = db.vw_IngredientDetails;
            var ingDets = (from i in ings where i.RecipeId == RecipeIdInput orderby i.IngredientTypeName, i.Measurement select i).ToList();
            return ingDets;
        }
        public ActionResult IngredientDetails(int IngredientIdInput) {
            ViewBag.ingDetails = GetSingleIngredientDetails(IngredientIdInput);
            return View("IngredientDetails"); 
        }
        public vw_IngredientDetails GetSingleIngredientDetails(int IngredientIdInput) {
            var db = new BakeryInventoryEntities();
            var ings = db.vw_IngredientDetails;
            var ingDets = (from i in ings where i.IngredientId == IngredientIdInput select i).First();
            return ingDets; 
        }
        public List<Ingredient> GetAllIngredients() {
            var db = new BakeryInventoryEntities();
            var ings = db.Ingredient;
            var allIngs = (from i in ings select i).ToList();
            return allIngs;
        }
        public List<IngredientType> GetAllIngredientTypes() {
            var db = new BakeryInventoryEntities();
            var types = db.IngredientType;
            var allTypes = (from t in types orderby t.TypeName select t).ToList();
            return allTypes; 
        }
        public List<vw_IngredientDetails> GetIngredientDetails() {
            var db = new BakeryInventoryEntities();
            var ingDets = db.vw_IngredientDetails;
            var allIngDets = (from iD in ingDets orderby iD.RecipeName, iD.IngredientTypeName, iD.Measurement select iD).ToList();
            return allIngDets;
        }
        public List<Weight> GetAllWeight() {
            var db = new BakeryInventoryEntities();
            var weight = db.Weight;
            var allWeight = (from w in weight orderby w.Name select w).ToList();
            return allWeight;
        }
        public List<MeasurementType> GetAllMeasurementType() {
            var db = new BakeryInventoryEntities();
            var measType = db.MeasurementType;
            var allMT = (from mt in measType orderby mt.Name select mt).ToList();
            return allMT;
        }
        //InsertMethods
        public ActionResult InsertIngredient(int RecipeIdInput, string NameInput, string WeightValueInput, int WeightIdInput, string MeasurementValueInput, int MeasurementTypeIdInput, int IngredientTypeIdInput) {
            var db = new BakeryInventoryEntities();
            var rec = db.Recipe;
            ViewBag.AllRecipes = (from r in rec select r).ToList();
            var intTypes = db.IngredientType;
            ViewBag.AllIngredientTypes = (from it in intTypes select it).ToList();
            var measTypes = db.MeasurementType;
            ViewBag.AllMeasurementTypes = (from mt in measTypes select mt).ToList();
            var wType = db.Weight;
            ViewBag.AllWeights = (from w in wType select w).ToList();
            var ingDets = db.vw_IngredientDetails;
            ViewBag.AllIngredientDetails = (from id in ingDets select id).ToList(); 
            var ing = db.Ingredient;
            var ins = new Ingredient {
                Name = NameInput,
                RecipeId = RecipeIdInput,
                WeightValue = System.Convert.ToDecimal(WeightValueInput),
                WeightId = WeightIdInput,
                MeasurementValue = System.Convert.ToDecimal(MeasurementValueInput),
                MeasurementTypeId = MeasurementTypeIdInput,
                IngredientTypeId = IngredientTypeIdInput
            };
            db.Ingredient.Add(ins); 
            db.SaveChanges();
            return View("Ingredient");
        }
        //public ActionResult UpdateIngredient(int IngredientIdInput, string NameInput, string WeightValueInput, int WeightIdInput, string MeasurementValueInput, int MeasurementTypeIdInput, int IngredientTypeIdInput) {
        //    var db = new BakeryInventoryEntities();
        //    var ing = db.Ingredient;
        //    var rec = db.Recipe;
        //    ViewBag.AllRecipes = (from r in rec select r).ToList();
        //    var intTypes = db.IngredientType;
        //    ViewBag.AllIngredientTypes = (from it in intTypes select it).ToList();
        //    var measTypes = db.MeasurementType;
        //    ViewBag.AllMeasurementTypes = (from mt in measTypes select mt).ToList();
        //    var wType = db.Weight;
        //    ViewBag.AllWeights = (from w in wType select w).ToList();
        //    var ingDets = db.vw_IngredientDetails;
        //    ViewBag.AllIngredientDetails = (from id in ingDets select id).ToList();
        //    var ingToUpdate = (from i in ing where i.IngredientId == IngredientIdInput select i).First();
        //    ingToUpdate.Name = NameInput;
        //    ingToUpdate.WeightValue = System.Convert.ToDecimal(WeightValueInput);
        //    ingToUpdate.WeightId = WeightIdInput;
        //}
    }
}