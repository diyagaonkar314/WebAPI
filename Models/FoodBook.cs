//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FoodBook
    {
        public int FBookid { get; set; }
        public string Cid { get; set; }
        public Nullable<int> Fid { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Fprice { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Food Food { get; set; }
    }
}
