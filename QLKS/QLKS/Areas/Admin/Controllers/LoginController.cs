using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLKS.Areas.Admin.Controllers;
using Data_Access;
using Data_Access.DAO;
using Data_Access.DTO;
using Data_Access.NhanVien;
using System.Web.Security;
using QLKS.Areas.Admin.Models;

namespace QLKS.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(NhanVienModel model)
        {
            /*var tendn = collection["username"];
            var matkhau = collection["password"];

            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên tài khoản";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }*/
            if(ModelState.IsValid)
            {
                ConnectClass cc = new ConnectClass();
                NHANVIEN kq = cc.Login(model.USERNAME, model.PASS);
                if (kq != null)
                {
                    Session["TaiKhoanAdmin"] = kq;
                    Session["ABC"] = kq.TENHIENTHI;
                    FormsAuthentication.SetAuthCookie(model.USERNAME, true);
                    return RedirectToAction("Test", "Test1");
                }
                else
                    ViewBag.Thongbao = " Tên Đăng Nhập or Mật khẩu Không đúng...";
                    ///ViewData["Loi3"] = " Tên Đăng Nhập or Mật khẩu Không đúng...";
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}