using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class PhieuDangKyKhamController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public PhieuDangKyKhamController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }

        // GET: PhieuDangKyKham
        public ActionResult Index()
        {
            var test = _context.Phieudangkykhams.ToList();
            var dangkys = _context.Phieudangkykhams
                .Include(p => p.MaBenhNhanNavigation)
                .Include(p => p.MaDichVuNavigation)
                .OrderByDescending(p => p.NgayDangKy);
            return View(dangkys);
        }

        //POST:PhieuDangKyKham/Index
        [HttpPost]
        public ActionResult Index(string textSearch)
        {
            if (string.IsNullOrEmpty(textSearch) || string.IsNullOrWhiteSpace(textSearch))
                return RedirectToAction(nameof(Index));

            string txtFormat = textSearch.Trim().ToLower();
            var resultSearch = _context.Phieudangkykhams
                .Include(p => p.MaBenhNhanNavigation)
                .Include(p => p.MaDichVuNavigation)
                .ToList()
                .Where(
                    dv => dv.MaBenhNhanNavigation.HoTen.ToLower().Contains(txtFormat)
                        || dv.MaDichVuNavigation.TenDichVu.ToLower().Contains(txtFormat)
                        || dv.NgayDangKy.ToString().Contains(txtFormat)
                        || dv.MaPhieuDangKy.ToString().ToLower().Contains(txtFormat)
                );

            return View(resultSearch);
        }

        // GET: PhieuDangKyKham/Details/5
        public ActionResult Details(int id)
        {
            var phieu = _context.Phieudangkykhams
                .Include(p=>p.MaBenhNhanNavigation)
                .Include(p=>p.MaDichVuNavigation)
                .FirstOrDefault(p=>p.MaPhieuDangKy == id);
            return View(phieu);
        }

        // GET: PhieuDangKyKham/Create
        public ActionResult Create()
        {
            ViewBag.listBenhNhan = _context.Benhnhans.OrderBy(b => b.HoTen);
            ViewBag.listDichVu = _context.Dichvukhams.OrderBy(d => d.TenDichVu);
            return View();
        }

        //POST: trả về giá chi phí của dịch vụ được chọn
        [HttpPost]
        public JsonResult GetChiPhi(int maDichVu)
        {
            var dv = _context.Dichvukhams.Find(maDichVu);
            if (dv == null)
            {
                return Json(new
                {
                    status = false
                });
            }

            decimal? chiPhi = dv.ChiPhi;
            return Json(new
            {
                chiPhi = chiPhi,
                status = true
            });
        }

        // POST: PhieuDangKyKham/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Phieudangkykham phieu)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                _context.Phieudangkykhams.Add(phieu);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhieuDangKyKham/Edit/5
        public ActionResult Edit(int id)
        {
            var phieu = _context.Phieudangkykhams.Find(id);

            ViewBag.MaBenhNhan = _context.Benhnhans.OrderBy(b => b.MaBenhNhan);
            ViewBag.MaDichVu = _context.Dichvukhams.OrderBy(d => d.TenDichVu);

            return View(phieu);
        }

        // POST: PhieuDangKyKham/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Phieudangkykham phieu)
        {
            try
            {
                var phieuUpdate = _context.Phieudangkykhams.Find(id);
                if (phieuUpdate == null)
                    return NotFound();

                phieuUpdate.MaBenhNhan = phieu.MaBenhNhan;
                phieuUpdate.MaDichVu = phieu.MaDichVu;
                phieuUpdate.NgayDangKy = phieu.NgayDangKy;
                phieuUpdate.TongTien = phieu.TongTien;

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhieuDangKyKham/Delete/5
        public ActionResult Delete(int id)
        {
            var phieuDel = _context.Phieudangkykhams
                .Include(p => p.MaBenhNhanNavigation)
                .Include(p => p.MaDichVuNavigation)
                .FirstOrDefault(p => p.MaPhieuDangKy == id);
            if (phieuDel == null) { return NotFound(); }
            return View(phieuDel);
        }

        // POST: PhieuDangKyKham/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var phieuDel = _context.Phieudangkykhams.Find(id);
                if (phieuDel == null) { return RedirectToAction(nameof(Index)); }

                _context.Phieudangkykhams.Remove(phieuDel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #region CRUD phieu dang ky kham theo benh nhan
        //GET: PhieuDangKyKham/GetByIDBenhNhan/1
        public ActionResult GetByIDBenhNhan(int id)
        {
            ViewBag.maBenhNhan = id;

            var dangkys = _context.Phieudangkykhams
                .Where(p => p.MaBenhNhan == id)
                .Include(p => p.MaBenhNhanNavigation)
                .Include(p => p.MaDichVuNavigation)
                .OrderByDescending(p => p.NgayDangKy);

            return View(dangkys);
        }

        //GET: PhieuDangKyKham/CreateByIDBenhNhan/1
        public ActionResult CreateByIdBenhNhan(int id)
        {
            ViewBag.id = id;
            ViewBag.MaBenhNhan = _context.Benhnhans.Find(id);
            ViewBag.listDichVu = _context.Dichvukhams.OrderBy(d => d.TenDichVu);
            return View();
        }

        //POST:PhieuDangKyKham/CreateByIDBenhNhan
        [HttpPost]
        public ActionResult CreateByIdBenhNhan(Phieudangkykham phieu)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                _context.Phieudangkykhams.Add(phieu);
                _context.SaveChanges();

                return RedirectToAction(nameof(GetByIDBenhNhan), new {id=phieu.MaBenhNhan });
            }
            catch
            {
                return RedirectToAction(nameof(CreateByIdBenhNhan));
            }
        }

        //GET: PhieuDangKyKham/EditByIDBenhNhan
        public ActionResult EditByIDBenhNhan(int id)
        {
            var phieu = _context.Phieudangkykhams.Find(id);

            ViewBag.BenhNhan = _context.Benhnhans.Find(phieu.MaBenhNhan);
            ViewBag.MaDichVu = _context.Dichvukhams.OrderBy(d => d.TenDichVu);

            return View(phieu);
        }

        //POST: PhieuDangKyKham/EditByIDBenhNhan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditByIDBenhNhan(int maPhieu, Phieudangkykham phieu)
        {
            try
            {
                var phieuUpdate = _context.Phieudangkykhams.Find(maPhieu);
                if (phieuUpdate == null)
                    return NotFound();

                phieuUpdate.MaBenhNhan = phieu.MaBenhNhan;
                phieuUpdate.MaDichVu = phieu.MaDichVu;
                phieuUpdate.NgayDangKy = phieu.NgayDangKy;
                phieuUpdate.TongTien = phieu.TongTien;

                _context.SaveChanges();

                return RedirectToAction(nameof(GetByIDBenhNhan), new { id = phieu.MaBenhNhan });
            }
            catch
            {
                return View();
            }
        }
        //GET: PhieuDangKyKham/DetailsByIDBenhNhan
        public ActionResult DetailsByIDBenhNhan(int maPhieu)
        {
            var phieu = _context.Phieudangkykhams
                .Include(p => p.MaBenhNhanNavigation)
                .Include(p => p.MaDichVuNavigation)
                .FirstOrDefault(p => p.MaPhieuDangKy == maPhieu);
            return View(phieu);
        }

        //GET: PhieuDangKyKham/DeleteByIDBenhNhan
        public ActionResult DeleteByIDBenhNhan(int maPhieu)
        {
            var phieuDel = _context.Phieudangkykhams
                .Include(p => p.MaBenhNhanNavigation)
                .Include(p => p.MaDichVuNavigation)
                .FirstOrDefault(p => p.MaPhieuDangKy == maPhieu);
            if (phieuDel == null) { return NotFound(); }
            return View(phieuDel);
        }
        //POST: PhieuDangKyKham/DeleteByIDBenhNhan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteByIDBenhNhan(int maPhieu, IFormCollection collection)
        {
            try
            {
                var phieuDel = _context.Phieudangkykhams.Find(maPhieu);
                if (phieuDel == null) { return RedirectToAction(nameof(Index)); }

                _context.Phieudangkykhams.Remove(phieuDel);
                _context.SaveChanges();

                return RedirectToAction(nameof(GetByIDBenhNhan), new { id = phieuDel.MaBenhNhan });
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}
