using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class NhaSanXuatController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public NhaSanXuatController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listNsx = _context.Nhasanxuats.OrderBy(nsx => nsx.TenNhaSanXuat);
            return View(listNsx);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Nhasanxuat nsx)
        {
            _context.Add(nsx);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Nhasanxuat nsx = _context.Nhasanxuats.Find(id);
            if(nsx == null)
            {
                return NotFound();
            }

            var listNsx = _context.Nhasanxuats.OrderBy(n => n.TenNhaSanXuat);
            ViewBag.nsx = listNsx;
            return View(nsx);
        }

        [HttpPost]
        public IActionResult Edit(int id, Nhasanxuat nsx)
        {
            var nsxUpdate = _context.Nhasanxuats.Find(id);
            if(nsxUpdate == null)
            {
                return NotFound();
            }

            nsxUpdate.TenNhaSanXuat = nsx.TenNhaSanXuat;
            nsxUpdate.DiaChi = nsx.DiaChi;
            nsxUpdate.SoDienThoai = nsx.SoDienThoai;

            _context.Nhasanxuats.Update(nsxUpdate);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Nhasanxuat nsx = _context.Nhasanxuats.Find(id);
            if (nsx == null)
            {
                return NotFound();
            }
                        
            return View(nsx);
        }

        [HttpPost]
        public IActionResult DeletePost(int MaNhaSanXuat)
        {
            Nhasanxuat nsx = _context.Nhasanxuats.Find(MaNhaSanXuat);
            if (nsx == null)
            {
                return NotFound();
            }

            _context.Nhasanxuats.Remove(nsx);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
