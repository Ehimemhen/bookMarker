//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookMarke370.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Return_Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Return_Sale()
        {
            this.Return_Sale_Line = new HashSet<Return_Sale_Line>();
        }
    
        public int Return_ID { get; set; }
        public Nullable<int> Inventory_ID { get; set; }
    
        public virtual Inventory Inventory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Return_Sale_Line> Return_Sale_Line { get; set; }
    }
}
