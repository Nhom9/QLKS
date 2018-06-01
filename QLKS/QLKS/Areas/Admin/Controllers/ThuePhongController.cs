using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data_Access.DTO;
using Data_Access.ThuePhong;
using QLKS.Areas.Admin.Models;

namespace QLKS.Areas.Admin.Controllers
{
    public class ThuePhongController : Controller
    {
        // GET: Admin/ThuePhong
        public ConnectClass cc = new ConnectClass();
        List<SelectListItem> loaiPhong = new List<SelectListItem>();

        // GET: ThuePhongs
        public ActionResult Index()
        {
            ///var thuePhongs = db.ThuePhongs.Include(t => t.KhachHang).Include(t => t.phong);
            List<THUEPHONG> thuephong = cc.LoadThuePhong();
            return View();
        }

        // GET: ThuePhongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUEPHONG thuephong = cc.SearchThuePhong(id);
            if (thuephong == null)
            {
                return HttpNotFound();
            }
            return View(thuephong);
        }

        // GET: ThuePhongs/Create
        public ActionResult Create()
        {
            
            ViewBag.loaiphong = SetViewBag();
            ///ViewBag.idKhach = new SelectList(db.KhachHangs, "id", "ten");            
            ///ViewBag.idNV = new SelectList(db.nhanViens, "id", "tenHienThi");
            return View();
        }
        public SelectList SetViewBag()
        {
            List<LOAIPHONG> loaiPhong1 = cc.LoadLoaiPhong();
            foreach (LOAIPHONG item in loaiPhong1)
            {
                loaiPhong.Add(new SelectListItem { Text = item.TEN, Value = item.ID.ToString() });
            }
            return new SelectList(loaiPhong, "id", "ten");
        }
        // POST: ThuePhongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenDK,CMND,DiaChi,SDT,TenCongTy,DsLoaiPhong,DsPhong")] TestDK thuePhong)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ViewBag.loaiphong = SetViewBag();
            return View(thuePhong);
        }

        // GET: ThuePhongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /*ThuePhong thuePhong = db.ThuePhongs.Find(id);
            if (thuePhong == null)
            {
                return HttpNotFound();
            }
            ///ViewBag.idKhach = new SelectList(db.KhachHangs, "id", "ten", thuePhong.idKhach);*/

            //ViewBag.idPhong = new SelectList(db.phongs, "id", "tenPhong", thuePhong.idPhoSng);
            //return View(thuePhong);
            return View();
        }

        // POST: ThuePhongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenDK,CMND,DiaChi,SDT,TenCongTy,DsLoaiPhong,DsPhong")] TestDK thuePhong)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(thuePhong).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ///ViewBag.idKhach = new SelectList(db.KhachHangs, "id", "ten", thuePhong.idKhach);
            ///ViewBag.idPhong = new SelectList(db.phongs, "id", "tenPhong", thuePhong.idPhong);
            ///return View(thuePhong);
            return View();
        }

        // GET: ThuePhongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ///ThuePhong thuePhong = db.ThuePhongs.Find(id);
            /*if (thuePhong == null)
            {
                return HttpNotFound();
            }
            return View(thuePhong);*/
            return View();
        }

        // POST: ThuePhongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /*ThuePhong thuePhong = db.ThuePhongs.Find(id);
            db.ThuePhongs.Remove(thuePhong);
            db.SaveChanges();*/
            return RedirectToAction("Index");
        }
        public ActionResult GetDropDownTenPhong(int id)
        {
            ///var data = db.phongs.Where(s => s.idLoai.Equals(id)).Select(s => new { s.id, s.tenPhong }).ToArray();
            var data = cc.LoadPhong(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ///db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}