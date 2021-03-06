//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BakeryInventoryProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public int RecipeId { get; set; }
        public int IngredientTypeId { get; set; }
        public Nullable<decimal> MeasurementValue { get; set; }
        public int MeasurementTypeId { get; set; }
        public Nullable<decimal> WeightValue { get; set; }
        public Nullable<int> WeightId { get; set; }
        public Nullable<decimal> SellingPrice { get; set; }
        public Nullable<int> BrandId { get; set; }
    
        public virtual IngredientType IngredientType { get; set; }
        public virtual MeasurementType MeasurementType { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Weight Weight { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
