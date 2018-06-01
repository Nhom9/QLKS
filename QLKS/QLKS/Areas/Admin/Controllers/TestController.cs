using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using Data_Access.DAO;
using Data_Access.DTO;
using Data_Access.ThuePhong;
using QLKS.Areas.Admin.Models;

namespace QLKS.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        ConnectClass cc = new ConnectClass();
        // GET: Admin/Test
        List<SelectListItem> loaiPhong = new List<SelectListItem>();
        List<SelectListItem> phong = new List<SelectListItem>();
        int idMaPhieu;
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.var1 = SetViewBag();
            List<PHONG> phong = cc.LoadPhong(0);
            ViewBag.var2 = new SelectList(phong, "ID", "TENPHONG");
            ///ViewBag.var2 = phong;
            ///ViewBag.var3 = SoPhong(0); 
            //ViewData["var3"] = SoPhong(0);
            return View();
        }
        [HttpPost]
        public ActionResult Index(LOAIPHONG loaiphong,TestDK test)
        {
            if(ModelState.IsValid)
            {
                ViewBag.var1 = new SelectList(cc.LoadLoaiPhong(), "ID", "TEN");// load loai phong len 
                ViewBag.var2 = new SelectList(cc.LoadPhong(), "ID", "TENPHONG");

                ViewBag.id = new SelectList(loaiPhong, "id", "tenPhong", loaiphong.ID);
                idMaPhieu = cc.DangKi(test.CMND, test.TenDK, test.DiaChi, test.SDT, test.TenCongTy);
                return Redirect("Step2");
            }
            return View();
        }
        public ActionResult GetPhong(int id)
        {
            var daata = cc.LoadPhong(id);
            return Json(daata, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult LayPhong(int _id)
        {
            PHONG daata = cc.PGetPhong(_id);
            return Json(new { id = daata.ID, tenphong = daata.TENPHONG });
        }

        public ActionResult Step2()
        {
            return View();
        }









        public SelectList SetViewBag()
        {
            List<LOAIPHONG> loaiPhong1 = cc.LoadLoaiPhong();
            foreach(LOAIPHONG item in loaiPhong1)
            {
                loaiPhong.Add(new SelectListItem { Text = item.TEN,Value = item.ID.ToString() });
            }
            ///return new SelectList(loaiPhong, "ID", "Text","TEN");
            return new SelectList(loaiPhong, "Value", "Text", "ID");
        }   
        public JsonResult Phong(int id)
        {
            List<PHONG> phong1 = cc.LoadPhong(id);
            foreach(PHONG item in phong1)
                phong.Add(new SelectListItem { Text = item.TENPHONG, Value = item.ID.ToString() });
            ViewBag.var2 = new SelectList(phong, "ID", "TENPHONG");
            return Json(phong, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDropDownTenPhong(int id)
        {
            var data = cc.LoadPhong(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}