using Data_Access.DTO;
using Data_Access.Sddv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Areas.Admin.Controllers
{
    public class SDDVController : Controller
    {
        // GET: Admin/SDDV
        ConnectClass cc = new ConnectClass();
        public ActionResult Index()
        {
            return View(cc.LoadSDDV());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.var1 = new SelectList(cc.LoadThuePhong(), "ID", "PHONG");
            ViewBag.var2 = new SelectList(cc.LoadDichVu(), "ID", "TEN");
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection,SDDV sddv)
        {
            if(ModelState.IsValid)
            {
                int num, num2;
                int.TryParse(collection["var1"], out num);
                sddv.IDCT = num;
                int.TryParse(collection["var2"], out num2);
                sddv.IDDV = num2;
                if (cc.Create(sddv))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi khi thêm");
                }
            }
            ViewBag.var1 = new SelectList(cc.LoadThuePhong(), "ID", "PHONG");
            ViewBag.var2 = new SelectList(cc.LoadDichVu(), "ID", "TEN");
            return View();
        }

        public ActionResult Delete(int id)
        {
            cc.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}