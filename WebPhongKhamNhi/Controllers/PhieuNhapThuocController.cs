using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class PhieuNhapThuocController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public PhieuNhapThuocController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }

        // GET: PhieuNhapThuoc
        public ActionResult Index()
        {
            var listPhieuNhap = _context.Phieunhaps.Include(p => p.MaNhaSanXuatNavigation).OrderByDescending(p => p.NgayNhap);
            return View(listPhieuNhap);
        }

        // GET: PhieuNhapThuoc/Details/5
        public ActionResult Details(int id)
        {
            var phieuNhap = _context.Phieunhaps.Include(p => p.MaNhaSanXuatNavigation).Where(p => p.MaPhieuNhap == id).First();
            if (phieuNhap == null)
            {
                return NotFound();
            }

            var listChiTietPhieuNhap = _context.Chitietphieunhaps
                .Include(c => c.MaPhieuNhapNavigation)
                .Include(c => c.MaThuocNavigation).Where(ct => ct.MaPhieuNhap == id);
            ViewBag.listChiTietPhieuNhap = listChiTietPhieuNhap;

            return View(phieuNhap);
        }

        // GET: PhieuNhapThuoc/Create
        public ActionResult Create()
        {
            
            var listNsx = _context.Nhasanxuats.OrderBy(n => n.TenNhaSanXuat);
            var listThuoc = _context.Thuocs.OrderBy(t => t.Ten);

            if (listNsx == null || listThuoc == null)
            {
                return NotFound();
            }
            ViewBag.listNsx = listNsx;
            ViewBag.listThuoc = listThuoc;

            return View();
        }

        // POST: PhieuNhapThuoc/Create
        [HttpPost]
        public ActionResult Create(Phieunhap phieunhap, IEnumerable<Chitietphieunhap> chiTietPhieus)
        {

            try
            {
                _context.Phieunhaps.Add(phieunhap);
                _context.SaveChanges();
                Phieunhap phieunhapInDb = _context.Phieunhaps.Where(p => p.NgayNhap == phieunhap.NgayNhap).FirstOrDefault();
                if(phieunhapInDb != null)
                {
                    foreach (var ct in chiTietPhieus)
                    {
                        ct.MaPhieuNhap = phieunhap.MaPhieuNhap;
                        _context.Chitietphieunhaps.Add(ct);
                    }
                    _context.SaveChanges();
                    return Json(new { status = true, redirectToUrl = Url.Action("Index", "PhieuNhapThuoc") });
                }
                else
                {
                    return Json(new { status = false});
                }
            }
            catch (Exception ex)
            {
                return Json(new { status= false , message = ex.Message});
            }

        }

        // GET: PhieuNhapThuoc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhieuNhapThuoc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhieuNhapThuoc/Delete/5
        public ActionResult Delete(int id)
        {
            Phieunhap phieuXoa = _context.Phieunhaps.Find(id);
            return View(phieuXoa);
        }

        // POST: PhieuNhapThuoc/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int MaPhieuNhap)
        {
            Phieunhap phieuXoa = _context.Phieunhaps.Find(MaPhieuNhap);
            if(phieuXoa == null)
            {
                return NotFound();
            }
            //xoá chi tiết phiếu nhập trước
            var chiTiets = _context.Chitietphieunhaps.Where(c => c.MaPhieuNhap == MaPhieuNhap);
            if(chiTiets.Count() == 0)
            {
                return NotFound();
            }
            foreach (var ct in chiTiets)
            {
                _context.Chitietphieunhaps.Remove(ct);
            }

            //xoá nốt phiếu nhập
            _context.Phieunhaps.Remove(phieuXoa);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
