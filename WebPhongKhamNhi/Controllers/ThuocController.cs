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

        public IActionResult Index()
        {
            var listthuoc = _context.Thuocs.Include(x=>x.MaNhaSanXuatNavigation).OrderBy(x => x.Ten);

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
            var kh = new Thuoc()
            {
                Ten=thuoc.Ten,
                HuongDan=thuoc.HuongDan,
                SoLuongTonKho=thuoc.SoLuongTonKho,
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
            var kh = _context.Khoas.Find(MaThuoc);
            if (kh == null)
            {
                return NotFound();
            }
            _context.Khoas.Remove(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
