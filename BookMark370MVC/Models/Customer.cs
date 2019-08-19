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
    
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Book_Request = new HashSet<Book_Request>();
            this.Sales = new HashSet<Sale>();
            this.Sale_Line = new HashSet<Sale_Line>();
        }
    
        public int Customer_ID { get; set; }
        [Display(Name = "Customer Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Book title required")]
        public string Customer_Name { get; set; }
        [Display(Name = "Customer Surname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Customer surname required")]
        public string Customer_Surname { get; set; }
        [Display(Name = "Customer Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Customer email required")]
        public string Customer_Email { get; set; }
        public Nullable<int> Customer_Contact { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book_Request> Book_Request { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale_Line> Sale_Line { get; set; }
    }
}
