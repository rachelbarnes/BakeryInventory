using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryInventoryProject.Models {
    public class IngredientDetails 
        {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string IngredientTypeName { get; set; }
        public string RecipeName { get; set; }
        public string Measurement { get; set; }
        public string Weight { get; set; }
        public decimal Price { get; set; }
    }
}