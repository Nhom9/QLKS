using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data_Access.DichVu;
using Data_Access.DTO;
namespace QLKS.Areas.NhanVien.Controllers
{
    public class DichVuController : Controller
    {
        
        ConnectClass cc = new ConnectClass();
        // GET: Admin/DichVu
        public ActionResult Index()
        {
            
            var db = cc.LoadDichVu();
            return View(db);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DICHVU dichvu)
        {
            if(ModelState.IsValid)
            {
                if(cc.Create(dichvu))
                    return RedirectToAction("Index", "DichVu");
                else
                    ModelState.AddModelError("", "Đã có sản phẩm tên :" + dichvu.TEN);
            }
            return View();
        }
        /*[HttpGet]
        public ActionResult Edit(FormCollection collection ,int ?id)
        {
            var ten = collection["TEN"];
            var gia = collection["GIA"];
            int num;
            int.TryParse(gia, out num);
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            DICHVU data = cc.GetDichVu(id);
            if (data == null)   return HttpNotFound();
            data.TEN = ten;
            data.GIA = num;
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TEN,GIA")] DICHVU dichVu)
        {
            if (ModelState.IsValid)
            {
                if (cc.SuaDichVu(dichVu))
                {
                    return RedirectToAction("Index");
                }
                else
                    ViewBag.ThongBao = "Đã có tên dịch vụ " + dichVu.TEN;
                
            }
            return View(dichVu);
        }*/
      
    }
}