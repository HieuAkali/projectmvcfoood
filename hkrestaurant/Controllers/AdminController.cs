using hkrestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Data.Entity;

namespace hkrestaurant.Controllers
{
    public class AdminController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Monan(int ?page)
        {
            int pagenumber = (page ?? 1);
            int pageSize = 6;

            //return View(data.monans.ToList());
            return View(data.monans.ToList().OrderBy(n => n.monan_ma).ToPagedList(pagenumber,pageSize));
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var taikhoan = collection["taikhoan"];
            var matkhau = collection["matkhau"];
            if (string.IsNullOrEmpty(taikhoan))
            {
                ViewData["Loi1"] = "Không được để trống";
            }else if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Không được để trống";
            }else
            {
                adminn admin = data.adminns.SingleOrDefault(n => n.admin_taikhoan == taikhoan && n.admin_matkhau == matkhau);
                if (admin != null)
                {
                    /* Session["taikhoanadmin"] = admin; */
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Sai thông tin đăng nhập";
            }
            return View();
        }

        [HttpGet]
        public ActionResult ThemMonan()
        {
            ViewBag.loai_ma = new SelectList(data.loais.ToList().OrderBy(n => n.loai_ten), "loai_ma", "loai_ten");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMonan(monan monan, HttpPostedFileBase fileupload)
        {
            ViewBag.loai_ma = new SelectList(data.loais.ToList().OrderBy(n => n.loai_ten), "loai_ma", "loai_ten");

            if(fileupload== null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình đã tồn tại";
                    }
                    else
                    {
                        fileupload.SaveAs(path);
                    }
                    monan.monan_hinh = fileName;
                    data.monans.InsertOnSubmit(monan);
                    data.SubmitChanges();
                }
                return RedirectToAction("Monan");
            }

        }
        public ActionResult Chitiet(int id)
        {
            monan monan = data.monans.SingleOrDefault(n => n.monan_ma == id);
            ViewBag.monan_ma = monan.monan_ma;
            if (monan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(monan);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            monan monan = data.monans.SingleOrDefault(n => n.monan_ma == id);
            ViewBag.monan_ma = monan.monan_ma;
            if (monan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(monan);
        }

        [HttpPost, ActionName("Delete")]
        public  ActionResult Xacnhanxoa(int id)
        {
            monan monan = data.monans.SingleOrDefault(n => n.monan_ma == id);
            ViewBag.monan_ma = monan.monan_ma;
            if (monan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.monans.DeleteOnSubmit(monan);
            data.SubmitChanges();
            return RedirectToAction("Monan");
        }

        
        public ActionResult Edit(int id)
        {
            monan monan = data.monans.SingleOrDefault(n => n.monan_ma == id);
            
            if (monan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.loai_ma = new SelectList(data.loais.ToList().OrderBy(n => n.loai_ten), "loai_ma", "loai_ten");
            return View(monan);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(monan monan)
        {
            ViewBag.loai_ma = new SelectList(data.loais.ToList().OrderBy(n => n.loai_ten), "loai_ma", "loai_ten");

            monan a = data.monans.SingleOrDefault(n => n.monan_ma == monan.monan_ma);

            a.monan_ten = monan.monan_ten;
            a.monan_hinh = monan.monan_hinh;
            a.monan_gia = monan.monan_gia;
            a.loai_ma = monan.loai_ma;
            a.monan_ma = monan.monan_ma;
            data.SubmitChanges();
            return RedirectToAction("Monan");


        }
 
     

    }

}