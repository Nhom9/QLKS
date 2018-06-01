using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data_Access.DTO;
using Data_Access.TaiSan;

namespace QLKS.Areas.Admin.Controllers
{
    public class TaiSanController : Controller
    {
        ConnectClass cc = new ConnectClass();
        // GET: Admin/TaiSan
        public ActionResult Index()
        {
            ViewBag.var1 = new SelectList(cc.LoadPhong(0), "ID", "TENPHONG");
            return View(cc.Load(0));
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                int.TryParse(collection["var1"], out id);
            }
            ViewBag.var1 = new SelectList(cc.LoadPhong(0), "ID", "TENPHONG");
            return View(cc.Load(id));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(cc.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(TAISAN TaiSan)
        {
            if (ModelState.IsValid)
            {
                if (cc.EditKHO(TaiSan))
                    return RedirectToAction("Index", "TaiSan");
                else
                {
                    ModelState.AddModelError("", "Thêm không hợp lệ " + TaiSan.TEN);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(TAISAN taiSan)
        {
            if (ModelState.IsValid)
            {
                if (cc.CreateKHO(taiSan))
                {
                    return RedirectToAction("Index", "TAISAN");
                }
                else
                    ModelState.AddModelError("", "Đã có sản phẩm tên :" + taiSan.TEN + " và loại :" + taiSan.LOAI);

            }
            return View();
        }
        [HttpGet]
        public ActionResult CreatePhong(int id)
        {
            ViewBag.var1 = new SelectList(cc.LoadPhong(0), "ID", "TENPHONG");
            return View(cc.Get(id));
        }
        [HttpPost]
        public ActionResult CreatePhong(FormCollection collection, TAISAN taisan)
        {

            if (ModelState.IsValid)
            {
                int idPhong = 0;
                int.TryParse(collection["var1"], out idPhong);
                taisan.IDPHONG = idPhong;
                if (cc.CreatePhong(taisan))
                {
                    return RedirectToAction("Index", "TaiSan");
                }
                else
                {
                    ModelState.AddModelError("", "Số lượng chọn lớn hơn số lượng của tài sản");
                }
            }
            ViewBag.var1 = new SelectList(cc.LoadPhong(0), "ID", "TENPHONG");
            return View(cc.Get(taisan.ID));
        }
        public ActionResult Delete(int id)
        {
            cc.Delete(id);
            return RedirectToAction("Index");
        }
    }
}