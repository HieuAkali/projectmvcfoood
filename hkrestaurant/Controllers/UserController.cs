using hkrestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace hkrestaurant.Controllers
{
    public class UserController : Controller
    {
        MD5 md5 = new MD5();
        DataClasses1DataContext data = new DataClasses1DataContext();
        DataClasses1DataContext objhKRESTAURANTEntities2 = new DataClasses1DataContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, acckh acckh)
        {

            var taikhoan = collection["kh_taikhoan"];
            var matkhau = collection["kh_matkhau"];
            var hoten = collection["kh_tendaydu"];
            var sdt = collection["kh_sdt"];
            var email = collection["kh_email"];
            if (string.IsNullOrEmpty(taikhoan))
            {
                ViewData["Loi1"] = "Không được để trống";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Không được để trống";
            }
            else if (string.IsNullOrEmpty(hoten))
            {
                ViewData["Loi3"] = "Không được để trống";
            }
            else if (string.IsNullOrEmpty(sdt))
            {
                ViewData["Loi4"] = "Không được để trống";
            }
            else if (string.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Không được để trống";
            }
            else
            {
                acckh.kh_taikhoan = taikhoan;
                acckh.kh_matkhau = md5.MD5Hash(matkhau);
                acckh.kh_tendaydu = hoten;
                acckh.kh_sdt = sdt;
                acckh.kh_email = email;
                data.acckhs.InsertOnSubmit(acckh);
                data.SubmitChanges();
                return RedirectToAction("Dangnhap");
            }
            return this.Dangky();

        }
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var taikhoan = collection["kh_taikhoan"];
            var matkhau = collection["kh_matkhau"];
            if (string.IsNullOrEmpty(taikhoan))
            {
                ViewData["Loi1"] = "Không được để trống";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Không được để trống";
            }
            else
            {
                acckh kh = data.acckhs.SingleOrDefault(n => n.kh_taikhoan == (taikhoan) && n.kh_matkhau == md5.MD5Hash(matkhau));
                if (kh != null)
                {
                    Session["Taikhoan"] = kh.kh_ma;
                    Session["Tenkhachhang"] = kh.kh_tendaydu;
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.Thongbao = "Sai thông tin đăng nhập ";
            }
            return View();

        }
        public ActionResult Dangxuat()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}