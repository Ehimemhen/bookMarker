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
    
    public partial class Purchase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Purchase()
        {
            this.Purchase_Line = new HashSet<Purchase_Line>();
        }
    
        public int Purchase_ID { get; set; }
        public Nullable<int> Purchase_Amount { get; set; }
        public Nullable<int> Purchase_Date { get; set; }
        public Nullable<int> BookSupplier_ID { get; set; }
    
        public virtual Book_Supplier Book_Supplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase_Line> Purchase_Line { get; set; }
    }
}
