
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class DonThuocController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public DonThuocController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }

        public IActionResult Index(string keyword)
        {
            var listdt = _context.Donthuocs.OrderByDescending(x => x.TenDonThuoc).ToList();
            var listthuoc = _context.Thuocs.OrderBy(x => x.Ten);
            ViewBag.Thuoc = listthuoc;
            if (String.IsNullOrEmpty(keyword))
            {
                return View(listdt);
            }
            listdt = listdt.Where(x => x.MaDonThuoc.ToString().Contains(keyword) || x.TenDonThuoc.ToString().Contains(keyword)).ToList();
            return View(listdt);
        }
        public IActionResult Details(int id)
        {
            var dt = _context.Donthuocs.Find(id);
            if (dt == null)
            {
                return NotFound();
            }
            ViewBag.listCTDT = _context.Chitietdonthuocs.Where(x => x.MaDonThuoc == id).Include(x => x.MaThuocNavigation);
            return View(dt);
        }
        [HttpPost]
        public IActionResult Create(List<Chitietdonthuoc> chitietdonthuoc, string tendonthuoc)
        {
            var kh = new Donthuoc()
            {
                TenDonThuoc = tendonthuoc
            }
            ;
            _context.Donthuocs.Add(kh);


            _context.SaveChanges();
            foreach (var ctdt in chitietdonthuoc)
            {
                var dt = new Chitietdonthuoc()
                {
                    MaDonThuoc = kh.MaDonThuoc,
                    MaThuoc = ctdt.MaThuoc,
                    SoLuong = ctdt.SoLuong, 
                    HuongDanSuDung = ctdt.HuongDanSuDung

                };
                _context.Chitietdonthuocs.Add(dt);
                _context.SaveChanges();
            }
           
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = kh.MaDonThuoc });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var kh = _context.Donthuocs.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            return View(kh);
        }

        [HttpPost]
        public IActionResult DeletePost(int MaDonThuoc)
        {
            var kh = _context.Donthuocs.Find(MaDonThuoc);

            if (kh == null)
            {
                return NotFound();
            }
            var listctdt = _context.Chitietdonthuocs.Where(x => x.MaDonThuoc == MaDonThuoc);
            _context.Chitietdonthuocs.RemoveRange(listctdt);
            _context.Donthuocs.Remove(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateCTDT(int madonthuoc)
        {
            ViewBag.MaDonThuoc = madonthuoc;

            ViewBag.Thuoc = _context.Thuocs.OrderBy(x => x.Ten);
            return View();
        }
        [HttpPost]
        public IActionResult CreateCTDT(Chitietdonthuoc chitietdonthuoc)
        {
            var old = _context.Chitietdonthuocs.FirstOrDefault(x => x.MaDonThuoc == chitietdonthuoc.MaDonThuoc && x.MaThuoc == chitietdonthuoc.MaThuoc);
            if (old != null)
            {
                old.SoLuong = old.SoLuong + chitietdonthuoc.SoLuong;
                old.HuongDanSuDung = old.HuongDanSuDung + chitietdonthuoc.HuongDanSuDung;
                _context.SaveChanges();
                var hdtold = _context.Donthuocs.FirstOrDefault(x => x.MaDonThuoc == chitietdonthuoc.MaDonThuoc);
                if (hdtold == null)
                {
                    return NotFound();
                }
                
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = chitietdonthuoc.MaDonThuoc });
            }
            var ctdt = new Chitietdonthuoc()
            {
                MaDonThuoc = chitietdonthuoc.MaDonThuoc,
                MaThuoc = chitietdonthuoc.MaThuoc,
                SoLuong = chitietdonthuoc.SoLuong, 
                HuongDanSuDung= chitietdonthuoc.HuongDanSuDung
            };
            _context.Chitietdonthuocs.Add(ctdt);
            _context.SaveChanges();
            var dt = _context.Donthuocs.FirstOrDefault(x => x.MaDonThuoc == chitietdonthuoc.MaDonThuoc);
            if (dt == null)
            {
                return NotFound();
            }
            
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = chitietdonthuoc.MaDonThuoc});
        }

        [HttpGet]
        public IActionResult EditCTDT(int madonthuoc, int mathuoc)
        {
            var ctdt = _context.Chitietdonthuocs.FirstOrDefault(x => x.MaThuoc == mathuoc && x.MaDonThuoc == madonthuoc);
            if (ctdt == null)
            {
                return NotFound();
            }

            return View(ctdt);
        }
        [HttpPost]
        public IActionResult EditCTDT(Chitietdonthuoc chitietdonthuoc)
        {
            var ctdt = _context.Chitietdonthuocs.FirstOrDefault(x => x.MaThuoc == chitietdonthuoc.MaThuoc && x.MaDonThuoc == chitietdonthuoc.MaDonThuoc);
            if (ctdt == null)
            {
                return NotFound();
            }
            ctdt.SoLuong = chitietdonthuoc.SoLuong;
            ctdt.HuongDanSuDung = chitietdonthuoc.HuongDanSuDung;
            _context.SaveChanges();
           
            var dt = _context.Donthuocs.FirstOrDefault(x => x.MaDonThuoc == chitietdonthuoc.MaDonThuoc);
            if (dt == null)
            {
                return NotFound();
            }
            
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = chitietdonthuoc.MaDonThuoc });
        }

        [HttpGet]
        public IActionResult DeleteCTDT(int madonthuoc, int mathuoc)
        {
            var ctdt = _context.Chitietdonthuocs.FirstOrDefault(x => x.MaThuoc == mathuoc && x.MaDonThuoc == madonthuoc);
            if (ctdt == null)
            {
                return NotFound();
            }
            _context.Chitietdonthuocs.Remove(ctdt);
            _context.SaveChanges();
            var pxn = _context.Donthuocs.FirstOrDefault(x => x.MaDonThuoc == madonthuoc);
            if (pxn == null)
            {
                return NotFound();
            }
            
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = madonthuoc });
        }
    }
}

