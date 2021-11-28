using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class KhoaController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public KhoaController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listkhoa = _context.Khoas.OrderBy(x => x.TenKhoa);

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
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Khoa khoa)
        {
            var kh = new Khoa()
            {
                TenKhoa = khoa.TenKhoa
            };
            _context.Khoas.Add(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var kh = _context.Khoas.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            return View(kh);
        }
        [HttpPost]
        public IActionResult Edit(int id,Khoa khoa)
        {
            var kh = _context.Khoas.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            
            kh.TenKhoa = khoa.TenKhoa;
            _context.Khoas.Update(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var kh = _context.Khoas.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            return View(kh);
        }

        [HttpPost]
        public IActionResult DeletePost(int MaKhoa)
        {
            var kh = _context.Khoas.Find(MaKhoa);
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
