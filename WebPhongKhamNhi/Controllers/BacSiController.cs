using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class BacSiController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public BacSiController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listkhoa = _context.Bacsis.Include(x => x.MaKhoaNavigation).OrderBy(x => x.HoTen);

            return View(listkhoa);
        }

        public IActionResult Details(int id)
        {
            var khoa = _context.Khoas.Find(id);
            if (khoa == null)
            {
                return NotFound();
            }
            return View(khoa);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var listkhoa = _context.Khoas.OrderBy(x => x.TenKhoa);
            ViewBag.Khoa = listkhoa;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bacsi bacsi)
        {
            var kh = new Bacsi()
            {
                HoTen=bacsi.HoTen,
                ChuyenMon=bacsi.ChuyenMon,
                TrinhDo=bacsi.TrinhDo,
                SoDienThoai=bacsi.SoDienThoai,
                MaKhoa=bacsi.MaKhoa
                
            };
            _context.Bacsis.Add(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var kh = _context.Bacsis.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            var listkhoa = _context.Khoas.OrderBy(x => x.TenKhoa);
            ViewBag.Khoa = listkhoa;
            return View(kh);
        }
        [HttpPost]
        public IActionResult Edit(int id, Bacsi bacsi)
        {
            var kh = _context.Bacsis.Find(id);
            if (kh == null)
            {
                return NotFound();
            }

            kh.HoTen = bacsi.HoTen;
            kh.ChuyenMon = bacsi.ChuyenMon;
            kh.TrinhDo = bacsi.TrinhDo;
            kh.SoDienThoai = bacsi.SoDienThoai;
            kh.MaKhoa = bacsi.MaKhoa;
            _context.Bacsis.Update(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var kh = _context.Bacsis.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            return View(kh);
        }

        [HttpPost]
        public IActionResult DeletePost(int MaBacSi)
        {
            var kh = _context.Bacsis.Find(MaBacSi);
            if (kh == null)
            {
                return NotFound();
            }
            _context.Bacsis.Remove(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
