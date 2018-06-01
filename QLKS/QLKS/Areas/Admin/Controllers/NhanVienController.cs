using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data_Access.DTO;
using Data_Access.NhanVien;

namespace QLKS.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        ConnectClass cc = new ConnectClass();
        // GET: Admin/NhanVien
        public ActionResult Index()
        {
            var data = cc.LoadNhanVien();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NHANVIEN nhanvien)
        {
            if(ModelState.IsValid)
            {

                /// Mã hóa mật khẩu ....
                if (cc.Create(nhanvien))
                {
                    return RedirectToAction("Index", "NhanVien");
                }
                else
                {
                    ModelState.AddModelError("", "Đã có Username " + nhanvien.USERNAME);
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            cc.Delete(id);
            ViewBag.ThongBao = "Đã xóa";
            return RedirectToAction("Index");
        }

        public ActionResult Reset(int id)
        {
            cc.Reset(id);
            ViewBag.ThongBao = "Đã reset mật khẩu";
            return RedirectToAction("Index");
        }

        public JsonResult Change(int id)
        {
            var result = cc.Change(id);
            return Json(result);
        }
    }
}