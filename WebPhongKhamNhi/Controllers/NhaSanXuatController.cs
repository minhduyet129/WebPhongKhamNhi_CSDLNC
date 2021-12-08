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

        [HttpPost]
        public IActionResult Index(string textSearch)
        {
            if (string.IsNullOrEmpty(textSearch) || string.IsNullOrWhiteSpace(textSearch))
                return RedirectToAction(nameof(Index));

            string textSearchFormat = textSearch.Trim().ToLower();
            var listNsx = _context.Nhasanxuats.Where(
                n => n.TenNhaSanXuat.ToLower().Contains(textSearchFormat)
                || n.DiaChi.ToLower().Contains(textSearchFormat)
                || n.SoDienThoai.Contains(textSearchFormat)
            ).OrderBy(n => n.TenNhaSanXuat);

            return View(listNsx);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        private ViewResult NsxCheckDupplicateName(Nhasanxuat nsx)
        {
            //kiểm tra trùng tên
            ViewData["DupplicateNameErrorMessage"] = null;
            var nsxSameName = _context.Nhasanxuats.Where(n => n.TenNhaSanXuat == nsx.TenNhaSanXuat);
            if (nsxSameName.Count() > 0)
            {
                ViewData["DupplicateNameErrorMessage"] = "Tên nhà sản xuất đã tồn tại.";
                return View(nsx);
            }
            return null;
        }

        [HttpPost]
        public IActionResult Create(Nhasanxuat nsx)
        {
            //kiểm tra trùng tên
            ViewResult viewAfterValidate = NsxCheckDupplicateName(nsx);
            if (viewAfterValidate != null)
                return viewAfterValidate;

            _context.Add(nsx);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Nhasanxuat nsx = _context.Nhasanxuats.Find(id);
            if (nsx == null)
            {
                return NotFound();
            }
            
            return View(nsx);
        }

        [HttpPost]
        public IActionResult Edit(int id, Nhasanxuat nsx)
        {
            var nsxUpdate = _context.Nhasanxuats.Find(id);
            if (nsxUpdate == null)
            {
                return NotFound();
            }

            //kiểm tra trùng tên nsx
            var nsxNameDupplicate = _context.Nhasanxuats
                                            .Where(n => n.MaNhaSanXuat != id && n.TenNhaSanXuat == nsx.TenNhaSanXuat)
                                            .FirstOrDefault();
            if (nsxNameDupplicate != null) 
            {
                ViewData["DupplicateNameErrorMessage"] = "Tên nhà sản xuất đã tồn tại.";
                return View(nsxUpdate); 
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
