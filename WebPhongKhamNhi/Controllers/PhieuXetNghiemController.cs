
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class PhieuXetNghiemController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public PhieuXetNghiemController(QLPhongKhamNhiContext context)
        {
            _context = context;
        } 

        public IActionResult Index(string keyword)
        {
            var listpxn = _context.Phieuxetnghiems.OrderByDescending(x => x.NgayThanhToan).ToList();
            var listdvxn = _context.Dichvuxetnghiems.OrderBy(x => x.TenXetNghiem);
            ViewBag.Dichvuxetnghiem = listdvxn;
            if (String.IsNullOrEmpty(keyword))
            {
                return View(listpxn);
            }
            listpxn = listpxn.Where(x => x.MaPhieuXetNghiem.ToString().Contains(keyword) || x.NgayThanhToan.ToString().Contains(keyword)).ToList();
            return View(listpxn);
        }

        public IActionResult GetPXNTheoHoSo (int id)
        {
            var listpxn = _context.Phieuxetnghiems.Include(x => x.MaHoSoNavigation).OrderByDescending(x => x.NgayThanhToan).Where(x => x.MaHoSo == id);

            ViewBag.MaHoSo = id;
            return View(listpxn);
        }

        [HttpGet]
        public IActionResult CreatePXNTheoHoSo (int id)
        {
            var listbs = _context.Bacsis.OrderBy(x => x.HoTen);
            ViewBag.BacSi = listbs;
            ViewBag.BenhNhan = id;
            return View();
        }
        [HttpPost]
        public IActionResult CreatePXNTheoHoSo (Phieuxetnghiem phieuxetnghiem)
        {
            var hs = new Phieuxetnghiem()
            {
                NgayThanhToan = phieuxetnghiem.NgayThanhToan, 
                TongTien = phieuxetnghiem.TongTien, 
                MaPhieuXetNghiem = phieuxetnghiem.MaPhieuXetNghiem, 
                MaHoSo = phieuxetnghiem.MaHoSo


            };
            _context.Phieuxetnghiems.Add(hs);
            _context.SaveChanges();
            return RedirectToAction("GetPXNTheoHoSo", new { id = phieuxetnghiem.MaHoSo });
        }
        [HttpGet]
        public IActionResult EditPXNTheoHoSo (int id)
        {
            var kh = _context.Phieuxetnghiems.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            var listbs = _context.Bacsis.OrderBy(x => x.HoTen);
            ViewBag.BacSi = listbs;
            return View(kh);
        }
        [HttpPost]
        public IActionResult EditPXNTheoHoSo (Phieuxetnghiem phieuxetnghiem)
        {
            var kh = _context.Phieuxetnghiems.Find(phieuxetnghiem.MaHoSo);
            if (kh == null)
            {
                return NotFound();
            }

            kh.NgayThanhToan = phieuxetnghiem.NgayThanhToan;

            kh.TongTien = phieuxetnghiem.TongTien;           

            _context.SaveChanges();
            return RedirectToAction("GetPXNTheoHoSo", new { id = phieuxetnghiem.MaHoSo });

        }
        public IActionResult Details(int id)
        {
            var pxn = _context.Phieuxetnghiems.Find(id);
            if (pxn == null)
            {
                return NotFound();
            }
            ViewBag.listCTPXN = _context.Chitietphieuxetnghiems.Where(x => x.MaPhieuXetNghiem == id).Include(x => x.MaXetNghiemNavigation);
            return View(pxn);
        }
        [HttpPost]
        public IActionResult Create(List<Chitietphieuxetnghiem> ctpxnghiem)
        {
            var kh = new Phieuxetnghiem()
            {
                NgayThanhToan = DateTime.Now

            };
            _context.Phieuxetnghiems.Add(kh);


            _context.SaveChanges();
            foreach (var ctpxn in ctpxnghiem)
            {
                var pxn = new Chitietphieuxetnghiem()
                {
                    MaPhieuXetNghiem = kh.MaPhieuXetNghiem,
                    MaXetNghiem = ctpxn.MaXetNghiem,
                    ChiPhi = ctpxn.ChiPhi,                    

                };
                _context.Chitietphieuxetnghiems.Add(pxn);
                _context.SaveChanges();
            }
            var tongtien = _context.Chitietphieuxetnghiems.Where(x => x.MaPhieuXetNghiem == kh.MaPhieuXetNghiem).Sum(x => x.ChiPhi);

            kh.TongTien = tongtien;
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = kh.MaPhieuXetNghiem });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var kh = _context.Phieuxetnghiems.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            return View(kh);
        }

        [HttpPost]
        public IActionResult DeletePost(int MaPhieuXetNghiem)
        {
            var kh = _context.Phieuxetnghiems.Find(MaPhieuXetNghiem);

            if (kh == null)
            {
                return NotFound();
            }
            var listctpxn = _context.Chitietphieuxetnghiems.Where(x => x.MaPhieuXetNghiem == MaPhieuXetNghiem);
            _context.Chitietphieuxetnghiems.RemoveRange(listctpxn);
            _context.Phieuxetnghiems.Remove(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateCTPXN(int maphieuxetnghiem)
        {
            ViewBag.MaPhieuXetNghiem = maphieuxetnghiem;

            ViewBag.DichVuXetNghiem = _context.Dichvuxetnghiems.OrderBy(x => x.TenXetNghiem);
            return View();
        }
        [HttpPost]
        public IActionResult CreateCTPXN(Chitietphieuxetnghiem chitietphieuxetnghiem)
        {
            var old = _context.Chitietphieuxetnghiems.FirstOrDefault(x => x.MaPhieuXetNghiem == chitietphieuxetnghiem.MaPhieuXetNghiem && x.MaXetNghiem == chitietphieuxetnghiem.MaXetNghiem);
            if (old != null)
            {
                old.ChiPhi = old.ChiPhi + chitietphieuxetnghiem.ChiPhi;                
                _context.SaveChanges();
                var hdtold = _context.Phieuxetnghiems.FirstOrDefault(x => x.MaPhieuXetNghiem == chitietphieuxetnghiem.MaPhieuXetNghiem);
                if (hdtold == null)
                {
                    return NotFound();
                }
                var tien = _context.Chitietphieuxetnghiems.Where(x => x.MaPhieuXetNghiem == chitietphieuxetnghiem.MaPhieuXetNghiem).Sum(x => x.ChiPhi);
                hdtold.TongTien = tien;
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = chitietphieuxetnghiem.MaPhieuXetNghiem });
            }
            var ctpxn = new Chitietphieuxetnghiem()
            {
                MaPhieuXetNghiem = chitietphieuxetnghiem.MaPhieuXetNghiem,
                MaXetNghiem = chitietphieuxetnghiem.MaXetNghiem,
                ChiPhi = chitietphieuxetnghiem.ChiPhi
            };
            _context.Chitietphieuxetnghiems.Add(ctpxn);
            _context.SaveChanges();
            var hdt = _context.Phieuxetnghiems.FirstOrDefault(x => x.MaPhieuXetNghiem == chitietphieuxetnghiem.MaPhieuXetNghiem);
            if (hdt == null)
            {
                return NotFound();
            }
            var tongtien = _context.Chitietphieuxetnghiems.Where(x => x.MaPhieuXetNghiem == chitietphieuxetnghiem.MaPhieuXetNghiem).Sum(x => x.ChiPhi);
            hdt.TongTien = tongtien;
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = chitietphieuxetnghiem.MaPhieuXetNghiem});
        }

        [HttpGet]
        public IActionResult EditCTPXN(int maphieuxetnghiem, int maxetnghiem)
        {
            var ctpxn = _context.Chitietphieuxetnghiems.FirstOrDefault(x => x.MaXetNghiem == maxetnghiem && x.MaPhieuXetNghiem == maphieuxetnghiem);
            if (ctpxn == null)
            {
                return NotFound();
            }

            return View(ctpxn);
        }
        [HttpPost]
        public IActionResult EditCTPXN(Chitietphieuxetnghiem chitietphieuxetnghiem)
        {
            var ctpxn = _context.Chitietphieuxetnghiems.FirstOrDefault(x => x.MaXetNghiem == chitietphieuxetnghiem.MaXetNghiem && x.MaPhieuXetNghiem == chitietphieuxetnghiem.MaPhieuXetNghiem);
            if (ctpxn == null)
            {
                return NotFound();
            }
            ctpxn.ChiPhi = chitietphieuxetnghiem.ChiPhi;
            _context.SaveChanges();
            var tongtien = _context.Chitietphieuxetnghiems.Where(x => x.MaPhieuXetNghiem == chitietphieuxetnghiem.MaPhieuXetNghiem).Sum(x => x.ChiPhi);
            var pxn = _context.Phieuxetnghiems.FirstOrDefault(x => x.MaPhieuXetNghiem == chitietphieuxetnghiem.MaPhieuXetNghiem);
            if (pxn == null)
            {
                return NotFound();
            }
           pxn.TongTien = tongtien;
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = chitietphieuxetnghiem.MaPhieuXetNghiem });
        }

        [HttpGet]
        public IActionResult DeleteCTPXN(int maphieuxetnghiem, int maxetnghiem)
        {
            var ctpxn = _context.Chitietphieuxetnghiems.FirstOrDefault(x => x.MaXetNghiem == maxetnghiem && x.MaPhieuXetNghiem == maphieuxetnghiem);
            if (ctpxn == null)
            {
                return NotFound();
            }
            _context.Chitietphieuxetnghiems.Remove(ctpxn);
            _context.SaveChanges();
            var pxn = _context.Phieuxetnghiems.FirstOrDefault(x => x.MaPhieuXetNghiem == maphieuxetnghiem);
            if (pxn == null)
            {
                return NotFound();
            }
            var tongtien = _context.Chitietphieuxetnghiems.Where(x => x.MaPhieuXetNghiem == maphieuxetnghiem).Sum(x => x.ChiPhi);
            pxn.TongTien = tongtien;
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = maphieuxetnghiem });
        }
    }
}

