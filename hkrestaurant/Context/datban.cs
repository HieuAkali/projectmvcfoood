//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hkrestaurant.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class datban
    {
        public int datban_ma { get; set; }
        public Nullable<int> kh_ma { get; set; }
        public Nullable<System.DateTime> ngaythang { get; set; }
        public string loaiban { get; set; }
    
        public virtual acckh acckh { get; set; }
        public virtual chitietdatban chitietdatban { get; set; }
    }
}
