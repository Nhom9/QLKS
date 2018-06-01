using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data_Access.DTO;
using Data_Access.ThuePhong;
using QLKS.Areas.Admin.Models;
namespace QLKS.Areas.NhanVien.Controllers
{
    public class thuephongController : Controller
    {
        // GET: NhanVien/Test1
        ConnectClass cc = new ConnectClass();

        List<SelectListItem> loaiPhong = new List<SelectListItem>();
        // GET: Admin/Test1
        public ActionResult Index()
        {
            return View(cc.LoadThuePhong());
        }
        public SelectList SetViewBag()
        {
            List<LOAIPHONG> loaiPhong1 = cc.LoadLoaiPhong();
            foreach (LOAIPHONG item in loaiPhong1)
            {
                loaiPhong.Add(new SelectListItem { Text = item.TEN, Value = item.ID.ToString() });
            }
            return new SelectList(loaiPhong, "Value", "Text");
        }
        [HttpGet]
        public ActionResult Test()
        {
            ViewBag.var1 = SetViewBag();
            ViewBag.var2 = new SelectList(cc.LoadPhong(0), "ID", "TENPHONG");
            return View();
        }
        [HttpPost]
        public ActionResult Test(FormCollection collect, PhieuThue phieuthue)
        {
            if (ModelState.IsValid)
            {
                NHANVIEN ad = (NHANVIEN)Session["TaiKhoanAdmin"];
                phieuthue.IDNhanVien = ad.ID;
                var id = collect["var2"].ToString();
                if (phieuthue.TenCongTy == null)
                    phieuthue.TenCongTy = "";
                if (phieuthue.SDT == null)
                    phieuthue.SDT = "";
                if (phieuthue.DiaChi == null)
                    phieuthue.DiaChi = "";
                if (cc.Test(int.Parse(id), phieuthue.IDNhanVien, phieuthue.CMND, phieuthue.Ten, phieuthue.DiaChi, phieuthue.SDT, phieuthue.TenCongTy))
                {
                    return RedirectToAction("Create", "ChiTietPhong");
                }
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



        public ActionResult GetDropDownTenPhong(int id)
        {
            var data = cc.LoadPhong(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Thanhtoan(int id)
        {
            return View(cc.HoaDon(id));
        }
        [HttpPost]
        public ActionResult Thanhtoan(FormCollection Collection, ThanhToanPhong thanhtoan)
        {
            if (ModelState.IsValid)
            {

                //int.TryParse(Collection["tong"].ToString(), out tong);
                //thanhtoan.TongTien = tong;
                if (cc.ThanhToan(cc.HoaDon(thanhtoan.ID)))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi");
                }
            }
            return View();
        }
        public ActionResult Detail(int id)
        {
            return View(cc.HoaDon(id, 1));
        }
        public ActionResult DetailPhong(int id)
        {
            return View(cc.HoaDon(id, 0));
        }
        [HttpGet]
        public ActionResult ThemNguoi(int id)
        {
            CHITIETPHONGLOAD tam = new CHITIETPHONGLOAD();
            var t = cc.HoaDon(id);
            tam.TenPhong = t.phong.TENPHONG;
            tam.IDCT = t.ID;
            return View(tam);
        }
        [HttpPost]
        public ActionResult ThemNguoi(CHITIETPHONGLOAD ctp)
        {
            if (ModelState.IsValid)
            {
                if (cc.Create(ctp))
                {
                    return RedirectToAction("DetailPhong", new { id = ctp.IDCT });
                }
                else
                {
                    ModelState.AddModelError("", "Quá số người quy định");
                }
            }
            return View(ctp);
        }
        [HttpGet]
        public ActionResult DichVu(int id)
        {
            ViewBag.var2 = new SelectList(cc.LoadDichVu(), "ID", "TEN");
            SDDVLOAD tam = new SDDVLOAD();
            var t = cc.HoaDon(id, 0);
            tam.IDCT = t.ID;
            tam.PHONG = t.phong.TENPHONG;
            return View(tam);
        }

        public ActionResult DichVu(SDDV sDDV, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                int num2;
                int.TryParse(collection["var2"], out num2);
                sDDV.IDDV = num2;
                if (cc.Create(sDDV))
                {
                    return RedirectToAction("DetailPhong", new { id = sDDV.IDCT });
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi khi thêm");
                }
            }
            return View();

        }
    }
}