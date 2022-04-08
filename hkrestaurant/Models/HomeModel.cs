using hkrestaurant.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hkrestaurant.Models
{
    public class HomeModel
    {
        public List<loai> ListLoai { get; set; }
        public List<monan>ListMonAn {get;set;}
        public monan Monan { get; set; }
        public List<acckh> acckhs { get; set; }
    }
}