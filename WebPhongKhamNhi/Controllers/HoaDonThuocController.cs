using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class HoaDonThuocController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public HoaDonThuocController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listhoadon = _context.Hoadonthuocs.OrderByDescending(x => x.NgayThanhToan);
            var listthuoc = _context.Thuocs.OrderBy(x => x.Ten);
            ViewBag.Thuoc = listthuoc;
            return View(listhoadon);
        }

        public IActionResult Details(int id)
        {
            var khoa = _context.Hoadonthuocs.Find(id);
            if (khoa == null)
            {
                return NotFound();
            }
            ViewBag.ListCTHDT = _context.Chitiethoadonthuocs.Where(x => x.MaHoaDonThuoc == id).Include(x=>x.MaThuocNavigation);
            return View(khoa);
        }

       

        [HttpPost]
        public IActionResult Create(List<Chitiethoadonthuoc> cthoadonthuoc)
        {
            var kh = new Hoadonthuoc()
            {
                NgayThanhToan=DateTime.Now
                
            };
            _context.Hoadonthuocs.Add(kh);
            

            _context.SaveChanges();
            foreach (var cthdt in cthoadonthuoc)
            {
                var hdt = new Chitiethoadonthuoc()
                {
                    MaHoaDonThuoc=kh.MaHoaDon,
                    MaThuoc=cthdt.MaThuoc,
                    SoLuong=cthdt.SoLuong,
                    Gia=cthdt.Gia,
                    ThanhTien= cthdt.SoLuong * cthdt.Gia

                };
                _context.Chitiethoadonthuocs.Add(hdt);
                _context.SaveChanges();
            }
            var tongtien = _context.Chitiethoadonthuocs.Where(x => x.MaHoaDonThuoc == kh.MaHoaDon).Sum(x => x.ThanhTien);
            
            kh.TongTien = tongtien;
            _context.SaveChanges();
            return RedirectToAction("Details",new { id=kh.MaHoaDon});
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var kh = _context.Hoadonthuocs.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            return View(kh);
        }

        [HttpPost]
        public IActionResult DeletePost(int MaHoaDon)
        {
            var kh = _context.Hoadonthuocs.Find(MaHoaDon);

            if (kh == null)
            {
                return NotFound();
            }
            var listcthdt = _context.Chitiethoadonthuocs.Where(x => x.MaHoaDonThuoc == MaHoaDon);
            _context.Chitiethoadonthuocs.RemoveRange(listcthdt);
            _context.Hoadonthuocs.Remove(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateCTHDT(int mahoadon)
        {
            ViewBag.MaHoaDonThuoc = mahoadon;

            ViewBag.Thuoc = _context.Thuocs.OrderBy(x => x.Ten);
            return View();
        }
        [HttpPost]
        public IActionResult CreateCTHDT(Chitiethoadonthuoc chitiethoadonthuoc)
        {
            var old = _context.Chitiethoadonthuocs.FirstOrDefault(x => x.MaHoaDonThuoc == chitiethoadonthuoc.MaHoaDonThuoc && x.MaThuoc == chitiethoadonthuoc.MaThuoc);
            if (old != null)
            {
                old.SoLuong = old.SoLuong + chitiethoadonthuoc.SoLuong;
                old.Gia = chitiethoadonthuoc.Gia;
                old.ThanhTien = old.SoLuong * chitiethoadonthuoc.Gia;
                _context.SaveChanges();
                var hdtold = _context.Hoadonthuocs.FirstOrDefault(x => x.MaHoaDon == chitiethoadonthuoc.MaHoaDonThuoc);
                if (hdtold == null)
                {
                    return NotFound();
                }
                var tien = _context.Chitiethoadonthuocs.Where(x => x.MaHoaDonThuoc == chitiethoadonthuoc.MaHoaDonThuoc).Sum(x => x.ThanhTien);
                hdtold.TongTien = tien;
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = chitiethoadonthuoc.MaHoaDonThuoc });
            }
            var cthdt = new Chitiethoadonthuoc()
            {
                MaHoaDonThuoc = chitiethoadonthuoc.MaHoaDonThuoc,
                MaThuoc = chitiethoadonthuoc.MaThuoc,
                SoLuong = chitiethoadonthuoc.SoLuong,
                Gia = chitiethoadonthuoc.Gia,
                ThanhTien = chitiethoadonthuoc.SoLuong * chitiethoadonthuoc.Gia
            };
            _context.Chitiethoadonthuocs.Add(cthdt);
            _context.SaveChanges();
            var hdt = _context.Hoadonthuocs.FirstOrDefault(x => x.MaHoaDon == chitiethoadonthuoc.MaHoaDonThuoc);
            if (hdt == null)
            {
                return NotFound();
            }
            var tongtien = _context.Chitiethoadonthuocs.Where(x => x.MaHoaDonThuoc == chitiethoadonthuoc.MaHoaDonThuoc).Sum(x => x.ThanhTien);
            hdt.TongTien = tongtien;
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = chitiethoadonthuoc.MaHoaDonThuoc });
        }

        [HttpGet]
        public IActionResult EditCTHDT(int mahoadon,int mathuoc)
        {
            var cthdt = _context.Chitiethoadonthuocs.FirstOrDefault(x => x.MaThuoc == mathuoc && x.MaHoaDonThuoc == mahoadon);
            if (cthdt == null)
            {
                return NotFound();
            }

            return View(cthdt);
        }
        [HttpPost]
        public IActionResult EditCTHDT(Chitiethoadonthuoc chitiethoadonthuoc)
        {
            var cthdt = _context.Chitiethoadonthuocs.FirstOrDefault(x => x.MaThuoc == chitiethoadonthuoc.MaThuoc && x.MaHoaDonThuoc == chitiethoadonthuoc.MaHoaDonThuoc);
            if (cthdt == null)
            {
                return NotFound();
            }
            cthdt.SoLuong = chitiethoadonthuoc.SoLuong;
            cthdt.Gia = chitiethoadonthuoc.Gia;
            cthdt.ThanhTien = chitiethoadonthuoc.SoLuong * chitiethoadonthuoc.Gia;
            _context.SaveChanges();
            var tongtien = _context.Chitiethoadonthuocs.Where(x => x.MaHoaDonThuoc == chitiethoadonthuoc.MaHoaDonThuoc).Sum(x => x.ThanhTien);
            var hdt = _context.Hoadonthuocs.FirstOrDefault(x => x.MaHoaDon == chitiethoadonthuoc.MaHoaDonThuoc);
            if (hdt == null)
            {
                return NotFound();
            }
            hdt.TongTien = tongtien;
            _context.SaveChanges();
            return RedirectToAction("Details", new {id=chitiethoadonthuoc.MaHoaDonThuoc });
        }

        [HttpGet]
        public IActionResult DeleteCTHDT(int mahoadon, int mathuoc)
        {
            var cthdt = _context.Chitiethoadonthuocs.FirstOrDefault(x => x.MaThuoc == mathuoc && x.MaHoaDonThuoc == mahoadon);
            if (cthdt == null)
            {
                return NotFound();
            }
            _context.Chitiethoadonthuocs.Remove(cthdt);
            _context.SaveChanges();
            var hdt = _context.Hoadonthuocs.FirstOrDefault(x => x.MaHoaDon ==mahoadon);
            if (hdt == null)
            {
                return NotFound();
            }
            var tongtien = _context.Chitiethoadonthuocs.Where(x => x.MaHoaDonThuoc == mahoadon).Sum(x => x.ThanhTien);
            hdt.TongTien = tongtien;
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = mahoadon });
        }
    }
}
