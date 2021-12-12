using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class DichVuKhamController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public DichVuKhamController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }

        // GET: DichVuKhams

        public ActionResult Index()
        {
            var dichVus = _context.Dichvukhams.OrderBy(dv => dv.TenDichVu);
            return View(dichVus);
        }

        //POST: DichVuKhams/Index
        [HttpPost]
        public ActionResult Index(string textSearch)
        {
            if (string.IsNullOrEmpty(textSearch) || string.IsNullOrWhiteSpace(textSearch))
                return RedirectToAction(nameof(Index));
            

            string txtFormat = textSearch.Trim().ToLower();
            var resultSearch = _context.Dichvukhams.Where(dv => dv.TenDichVu.ToLower().Contains(txtFormat));
            return View(resultSearch);
        }

        // GET: DichVuKhams/Details/5
        public ActionResult Details(int id)
        {
            Dichvukham dv = _context.Dichvukhams.Find(id);
            return View(dv);
        }

        // GET: DichVuKhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DichVuKhams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dichvukham dichvukham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //kiểm tra trùng tên
                    var dvSameName = _context.Dichvukhams.Where(dv => dv.TenDichVu == dichvukham.TenDichVu).FirstOrDefault();
                    if(dvSameName != null)
                    {
                        ViewData["DichVuDuplicateName"] = "Tên dịch vụ đã tồn tại, vui lòng nhập tên khác.";
                        return View(dichvukham);
                    }

                    _context.Add(dichvukham);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: DichVuKhams/Edit/5
        public ActionResult Edit(int id)
        {
            Dichvukham dvUpdate = _context.Dichvukhams.Find(id);
            return View(dvUpdate);
        }

        // POST: DichVuKhams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dichvukham dichvukham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    

                    Dichvukham dvUpdate = _context.Dichvukhams.Find(id);
                    if (dvUpdate == null) return NotFound();

                    //kiểm tra trùng tên
                    var dvSameName = _context.Dichvukhams.Where(dv => dv.TenDichVu == dichvukham.TenDichVu && dv.MaDichVu!=id).FirstOrDefault();
                    if (dvSameName != null)
                    {
                        ViewData["DichVuDuplicateName"] = "Tên dịch vụ đã tồn tại, vui lòng nhập tên khác.";
                        return View(dvUpdate);
                    }

                    dvUpdate.TenDichVu = dichvukham.TenDichVu;
                    dvUpdate.ChiPhi = dichvukham.ChiPhi;

                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: DichVuKhams/Delete/5
        public ActionResult Delete(int id)
        {
            Dichvukham dv = _context.Dichvukhams.Find(id);

            //Kiểm tra dịch vụ này có được tham chiếu tới phiếu đăng kí khám nào không?
            var phieuDks = _context.Phieudangkykhams.Where(p => p.MaDichVu == id);
            if (phieuDks != null)
            {
                ViewData["DichVuFK"] = "Dịch vụ này đã được sử dụng trong phiếu đăng kí, " +
                    "xoá dịch vụ sẽ làm thay đổi dữ liệu tất cả các phiếu đăng kí liên quan";
            }

            return View(dv);
        }

        // POST: DichVuKhams/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                //Kiểm tra dịch vụ này có được tham chiếu tới phiếu đăng kí khám nào không?
                var phieuDks = _context.Phieudangkykhams.Where(p => p.MaDichVu == id);
                if (phieuDks != null)
                {
                    foreach (var p in phieuDks)
                    {
                        p.MaDichVu = null;
                    }
                }

                Dichvukham dvDel = _context.Dichvukhams.Find(id);
                _context.Dichvukhams.Remove(dvDel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
