using hkrestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hkrestaurant.Controllers
{
    public class DatbanController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        // GET: Datban
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Datban()
        {
            if (Session["Taikhoan"] == null )
            {
                return RedirectToAction("Dangnhap", "User");
            }
            return View();
                        
        }
        [HttpPost]
        public ActionResult Datban(FormCollection collection, datban datban,chitietdatban chitietdatban)
        {

            var ngaythang = collection["ngaythang"];
            var loaiban = collection["loaiban"];
            var songuoi = collection["songuoi"];
            var tenmon = collection["ctdb_tenmon"];
            if (string.IsNullOrEmpty(ngaythang))
            {
                ViewData["Loi1"] = "Vui lòng nhập thông tin!";
            }
            else if (string.IsNullOrEmpty(loaiban))
            {
                ViewData["Loi2"] = "Vui lòng nhập thông tin!";
            }
            else if (string.IsNullOrEmpty(songuoi))
            {
                ViewData["Loi3"] = "Vui lòng nhập thông tin!";
            }
            else if (string.IsNullOrEmpty(tenmon))
            {
                ViewData["Loi4"] = "Vui lòng nhập thông tin!";
            }
            else
            {

                chitietdatban.kh_ma = int.Parse(Session["Taikhoan"].ToString());
                datban.kh_ma = int.Parse(Session["Taikhoan"].ToString());

                datban.ngaythang = DateTime.Parse(ngaythang);
                datban.loaiban = loaiban;
                chitietdatban.songuoi = int.Parse(songuoi);
                chitietdatban.ctdb_tenmon = tenmon;
                
                data.datbans.InsertOnSubmit(datban);
                data.SubmitChanges();
                chitietdatban.datban_ma = datban.datban_ma;
                data.chitietdatbans.InsertOnSubmit(chitietdatban);
                data.SubmitChanges();
                return RedirectToAction("Xacnhan", "Datban");
            }
            return this.Datban();
        }
        public ActionResult Xacnhan()
        {
            return View();
        }
    }
}