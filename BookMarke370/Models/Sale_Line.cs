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
    
    public partial class Sale_Line
    {
        public int Sale_ID { get; set; }
        public int Inventory_ID { get; set; }
        public int Customer_ID { get; set; }
        public Nullable<int> Quanity { get; set; }
        public Nullable<double> Sale_Total { get; set; }
        public Nullable<System.DateTime> Sale_Date { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
