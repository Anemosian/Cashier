//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cashier
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblProduct()
        {
            this.TblTransactionItems = new HashSet<TblTransactionItem>();
        }
    
        public int ProductId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Description { get; set; }
        public int ProductType { get; set; }
        public byte[] Image { get; set; }
    
        public virtual TblProductType TblProductType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblTransactionItem> TblTransactionItems { get; set; }
    }
}