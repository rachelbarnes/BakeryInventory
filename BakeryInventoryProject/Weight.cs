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
    
    public partial class Weight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Weight()
        {
            this.Ingredient = new HashSet<Ingredient>();
        }
    
        public int WeightId { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> ValueInOunces { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingredient> Ingredient { get; set; }
    }
}
