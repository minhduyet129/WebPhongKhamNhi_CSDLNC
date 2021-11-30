using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class DichVuXetNghiemController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public DichVuXetNghiemController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listdichvuxetnghiem = _context.Dichvuxetnghiems.OrderBy(x => x.TenXetNghiem);

            return View(listdichvuxetnghiem);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dichvuxetnghiem Dichvuxetnghiem)
        {
            var dvxn = new Dichvuxetnghiem()
            {
                TenXetNghiem = Dichvuxetnghiem.TenXetNghiem, 
                ChiPhi = Dichvuxetnghiem.ChiPhi
            };
            _context.Dichvuxetnghiems.Add(Dichvuxetnghiem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dvxn = _context.Dichvuxetnghiems.Find(id);
            if (dvxn == null)
            {
                return NotFound();
            }
            return View(dvxn);
        }
        [HttpPost]
        public IActionResult Edit(int id, Dichvuxetnghiem Dichvuxetnghiem)
        {
            var dvxnUpdate = _context.Dichvuxetnghiems.Find(id);
            if (dvxnUpdate == null)
            {
                return NotFound();
            }

            dvxnUpdate.TenXetNghiem = Dichvuxetnghiem.TenXetNghiem;
            dvxnUpdate.ChiPhi = Dichvuxetnghiem.ChiPhi;

            _context.Dichvuxetnghiems.Update(dvxnUpdate);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dvxn = _context.Dichvuxetnghiems.Find(id);
            if (dvxn == null)
            {
                return NotFound();
            }
            return View(dvxn);
        }

        [HttpPost]
        public IActionResult DeletePost(int MaXetNghiem)
        {
            var dvxn = _context.Dichvuxetnghiems.Find(MaXetNghiem);
            if (dvxn == null)
            {
                return NotFound();
            }
            _context.Dichvuxetnghiems.Remove(dvxn);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}