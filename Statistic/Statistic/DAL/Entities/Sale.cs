//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Statistic.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        public int SaleId { get; set; }
        public int Manager { get; set; }
        public int Product { get; set; }
        public int AmountForSale { get; set; }
        public double CostPerUnit { get; set; }
        public System.DateTime DateOfSale { get; set; }
    
        public virtual Manager Manager1 { get; set; }
        public virtual Product Product1 { get; set; }
    }
}
