using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class ThuocController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public ThuocController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }

        public IActionResult Index(string keyword)
        {
            var listthuoc = _context.Thuocs.Include(x=>x.MaNhaSanXuatNavigation).OrderBy(x => x.Ten).ToList();
            if (String.IsNullOrEmpty(keyword))
            {
                return View(listthuoc);
            }
            listthuoc = listthuoc.Where(x => x.Ten.ToLower().Contains(keyword.ToLower())).ToList();
            return View(listthuoc);
        }

        public IActionResult Details(int id)
        {
            var khoa = _context.Thuocs.Find(id);
            if (khoa == null)
            {
                return NotFound();
            }
            return View(khoa);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var list = _context.Nhasanxuats.OrderBy(x => x.TenNhaSanXuat);
            ViewBag.NhaSanXuat = list;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Thuoc thuoc)
        {
            var oldkhoa = _context.Thuocs.FirstOrDefault(x => x.Ten == thuoc.Ten);
            if (oldkhoa != null)
            {
                ViewData["Message"] = "Tên thuốc đã tồn tại";
                var list = _context.Nhasanxuats.OrderBy(x => x.TenNhaSanXuat);
                ViewBag.NhaSanXuat = list;
                return View();
            }
            var kh = new Thuoc()
            {
                Ten=thuoc.Ten,
                HuongDan=thuoc.HuongDan,
                SoLuongTonKho=thuoc.SoLuongTonKho ?? 0,
                Gia=thuoc.Gia,
                MaNhaSanXuat=thuoc.MaNhaSanXuat
            };
            _context.Thuocs.Add(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var kh = _context.Thuocs.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            var list = _context.Nhasanxuats.OrderBy(x => x.TenNhaSanXuat);
            ViewBag.NhaSanXuat = list;
            return View(kh);
        }
        [HttpPost]
        public IActionResult Edit(int id, Thuoc thuoc)
        {
            var kh = _context.Thuocs.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            var oldkhoa = _context.Thuocs.FirstOrDefault(x => x.Ten == thuoc.Ten);
            if (oldkhoa != null)
            {
                ViewData["Message"] = "Tên thuốc đã tồn tại";
                var list = _context.Nhasanxuats.OrderBy(x => x.TenNhaSanXuat);
                ViewBag.NhaSanXuat = list;
                return View();
            }
            kh.Ten = thuoc.Ten;
            kh.HuongDan = thuoc.HuongDan;
            kh.SoLuongTonKho = thuoc.SoLuongTonKho;
            kh.Gia = thuoc.Gia;
            kh.MaNhaSanXuat = thuoc.MaNhaSanXuat;
            _context.Thuocs.Update(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var kh = _context.Thuocs.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            return View(kh);
        }

        [HttpPost]
        public IActionResult DeletePost(int MaThuoc)
        {
            var kh = _context.Thuocs.Find(MaThuoc);
            if (kh == null)
            {
                return NotFound();
            }
            var ctdt = _context.Chitietdonthuocs.FirstOrDefault(x => x.MaThuoc == MaThuoc);
            var cthdt = _context.Chitiethoadonthuocs.FirstOrDefault(x => x.MaThuoc == MaThuoc);
            var ctpn = _context.Chitietphieunhaps.FirstOrDefault(x => x.MaThuoc == MaThuoc);
            if(ctdt !=null || cthdt != null || ctpn != null)
            {
                ViewData["Message"] = "Bạn không thể xóa thuốc này vì nó nằm trang các hóa đơn";
                
                return View("Delete");
            }
            _context.Thuocs.Remove(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
