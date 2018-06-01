using Data_Access.ChiTietPhong;
using Data_Access.DTO;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace QLKS.Areas.Admin.Controllers
{
    public class ChiTietPhongController : Controller
    {
        ConnectClass cc = new ConnectClass();
        // GET: Admin/ChiTietPhong
        public ActionResult Index()
        {
            ViewBag.var1 = new SelectList(cc.Loadphong(), "ID", "TENPHONG");
            return View(cc.LoadChiTietPhong());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.var2 = new SelectList(cc.LoadThuePhong(0), "ID", "PHONG");

            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, CHITIETPHONG ct )
        {
            if (ModelState.IsValid)
            {
                int num;
                int.TryParse(collection["var2"], out num);
                ct.IDCT = num;
                
                if (cc.Create(ct))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi khi thêm");
                }
            }
            ViewBag.var2 = new SelectList(cc.LoadThuePhong(0), "ID", "PHONG");
            return View();
        }

    }
}