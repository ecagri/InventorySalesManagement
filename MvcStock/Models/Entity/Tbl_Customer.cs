//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStock.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Customer()
        {
            this.Tbl_Sale = new HashSet<Tbl_Sale>();
        }
    
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter customer name!")]
        [StringLength(50, ErrorMessage = "Customer name cannot be longer than 50 characters!")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter customer surname!")]
        [StringLength(50, ErrorMessage = "Customer surname cannot be longer than 50 characters!")]
        public string CustomerSurname { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Sale> Tbl_Sale { get; set; }
    }
}
