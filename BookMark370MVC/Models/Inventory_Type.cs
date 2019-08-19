//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookMark370MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Inventory_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory_Type()
        {
            this.Inventories = new HashSet<Inventory>();
        }
    
        public int InventoryType_ID { get; set; }
        [Display(Name = "Inventory Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Inventory type name required")]
        public string InventoryType_Name { get; set; }
        [Display(Name = "Inventory Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Inventory type description required")]
        public string InventoryType_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
