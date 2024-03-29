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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Sales = new HashSet<Sale>();
        }
    
        public int Employee_ID { get; set; }
        public Nullable<int> User_ID { get; set; }
        [Display(Name = "Employee Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Employee name required")]
        public string Employee_Name { get; set; }
        [Display(Name = "Employee Surname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Employee surname required")]
        public string Employee_Surname { get; set; }
        [Display(Name = "Employee Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Employee address required")]
        public string Employee_Address { get; set; }
        [Display(Name = "Employee Phone")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Employee phone required")]
        public Nullable<int> Emp_Phone { get; set; }
        [Display(Name = "Employee Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Employee email required")]
        public string Emp_Email { get; set; }
        public Nullable<long> ID_Number { get; set; }
        public Nullable<int> EmpTitle_ID { get; set; }
        public Nullable<int> EmpGender_ID { get; set; }
        public byte[] ImageData { get; set; }
    
        public virtual Employee_Gender Employee_Gender { get; set; }
        public virtual Employee_Title Employee_Title { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
