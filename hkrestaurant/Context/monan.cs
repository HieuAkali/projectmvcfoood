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
    
    public partial class monan
    {
        public int monan_ma { get; set; }
        public Nullable<int> loai_ma { get; set; }
        public string monan_ten { get; set; }
        public string monan_hinh { get; set; }
        public double monan_gia { get; set; }
        public string monan_mota { get; set; }
    
        public virtual loai loai { get; set; }
    }
}
