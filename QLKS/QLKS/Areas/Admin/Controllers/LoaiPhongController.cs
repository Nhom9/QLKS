using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data_Access.DTO;
using Data_Access.LoaiPhong;
namespace QLKS.Areas.Admin.Controllers
{
    public class LoaiPhongController : Controller
    {
        // GET: Admin/LoaiPhong
        ConnectClass cc = new ConnectClass();
        // GET: Admin/LoaiPhong
        public ActionResult Index()
        {

            var db = cc.LoadLOAIPHONG();
            return View(db);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        /*public string LuuFile(HttpPostedFileBase fileUpload)
        {
            var anh = Path.GetFileName(fileUpload.FileName);
            var path = Path.Combine(Server.MapPath("~/Asset/Img"), anh);
            if (!System.IO.File.Exists(path))
                fileUpload.SaveAs(path);
            return anh;
        }
        [HttpPost]
        public ActionResult Create(LOAIPHONG loaiphong)
        {
            var ten = collection["TEN"];
            var gia = collection["DONGIA"];
            var anh = "";
            if (fileUpload != null)
                anh = LuuFile(fileUpload);
            
            var mota = collection["MOTA"];
            var tam = collection["SOGIUONG"];
            int Num, SoGiuong = 3;
            if (ten == null)
            {
                ViewData["Loi1"] = "Chưa nhập tên sản phẩm";
            }
            else if (int.TryParse(gia, out Num) == false)
            {
                ViewData["Loi2"] = "Chưa nhập giá";
            }
            else
            {
                if (int.TryParse(tam, out SoGiuong) == false)
                    SoGiuong = 1;
                if (cc.ThemLOAIPHONG(ten, Num,anh,mota,SoGiuong) == true)
                    ViewBag.ThongBao = "Đã thêm";
                else
                    ViewBag.ThongBao = "Đã có loại phòng tên " + ten;
            }
            return View();
        }*/
        [HttpPost]
        public ActionResult Create(LOAIPHONG loaiphong)
        {
            if(ModelState.IsValid)
            {
                if (loaiphong.ANH == null)
                    loaiphong.ANH = "";
                if (loaiphong.MOTA == null)
                    loaiphong.MOTA = "";
                if (loaiphong.SOGIUONG == null)
                    loaiphong.SOGIUONG = 1;
                if(cc.Create(loaiphong))
                {
                    return RedirectToAction("Index", "LoaiPhong");
                }
                else
                {
                    ModelState.AddModelError("","Lỗi do trường dữ liệu nhập không hợp lệ");
                }
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(cc.GetLOAIPHONG(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LOAIPHONG LoaiPhong)
        {
            if (ModelState.IsValid)
            {
                if (LoaiPhong.ANH == null)
                    LoaiPhong.ANH = "";
                if (LoaiPhong.MOTA == null)
                    LoaiPhong.MOTA = "";
                if (LoaiPhong.SOGIUONG == null)
                    LoaiPhong.SOGIUONG = 1;
                if (cc.SuaLOAIPHONG(LoaiPhong))
                {
                    return RedirectToAction("Index");
                }
                else
                    ViewBag.ThongBao = "Đã có tên dịch vụ " + LoaiPhong.TEN;

            }
            return View(LoaiPhong);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            cc.Delete(id);
            return RedirectToAction("Index");
        }
    }
}