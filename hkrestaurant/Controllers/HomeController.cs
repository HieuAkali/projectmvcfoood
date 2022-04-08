using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using hkrestaurant.Models;

namespace hkrestaurant.Controllers
{
    public class HomeController : Controller
    {
        
        DataClasses1DataContext objhKRESTAURANTEntities2 = new DataClasses1DataContext();
        public ActionResult Index()
        {
            if(Session["Taikhoan"] != null)
            {
                ViewBag.successLogin = "Đăng nhập thành công";
            }
            
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListLoai = objhKRESTAURANTEntities2.loais.ToList(); 
            objHomeModel.ListMonAn = objhKRESTAURANTEntities2.monans.ToList();
            return View(objHomeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        public ActionResult Detailll(int id)
        {

            var a = from monan in objhKRESTAURANTEntities2.monans
                    where monan.monan_ma == id
                    select monan;
            return View(a.Single());
        }
    }
}