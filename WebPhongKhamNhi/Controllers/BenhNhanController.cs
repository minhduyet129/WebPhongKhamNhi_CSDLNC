using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class BenhNhanController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public BenhNhanController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }

        public IActionResult Index(string keyword)
        {

            var listuser = _context.Benhnhans.OrderByDescending(x=>x.MaBenhNhan).ToList();
            if (String.IsNullOrEmpty(keyword))
            {
                return View(listuser);
            }
            listuser = listuser.Where(x => x.HoTen.ToLower().Contains(keyword.ToLower())||x.SoDienThoai.Contains(keyword)).ToList();
            return View(listuser);
        }

        public IActionResult Details(int id)
        {
            var bn = _context.Benhnhans.Find(id);
            if (bn == null)
            {
                return NotFound();
            }
            return View(bn);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Benhnhan benhnhan)
        {
            var bn = new Benhnhan()
            {
                HoTen=benhnhan.HoTen,
                NgaySinh=benhnhan.NgaySinh,
                DiaChi=benhnhan.DiaChi,
                TenNguoiThan=benhnhan.TenNguoiThan,
                LoaiTaiKhoan=benhnhan.LoaiTaiKhoan,
                TenTaiKhoan=benhnhan.TenTaiKhoan,
                MatKhau=benhnhan.MatKhau,
                SoDienThoai=benhnhan.SoDienThoai
                

            };
            _context.Benhnhans.Add(bn);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var kh = _context.Benhnhans.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            
            return View(kh);
        }
        [HttpPost]
        public IActionResult Edit(int MaBenhNhan,Benhnhan benhnhan)
        {
            var kh = _context.Benhnhans.Find(MaBenhNhan);
            if (kh == null)
            {
                return NotFound();
            }

            kh.HoTen = benhnhan.HoTen;
            kh.TenTaiKhoan = benhnhan.TenTaiKhoan;
            kh.MatKhau = benhnhan.MatKhau;
            kh.NgaySinh = benhnhan.NgaySinh;
            kh.SoDienThoai = benhnhan.SoDienThoai;
            kh.TenNguoiThan = benhnhan.TenNguoiThan;
            kh.LoaiTaiKhoan = benhnhan.LoaiTaiKhoan;
            kh.DiaChi = benhnhan.DiaChi;
           
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var kh = _context.Benhnhans.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            return View(kh);
        }

        [HttpPost]
        public IActionResult DeletePost(int MaBenhNhan)
        {
            var kh = _context.Benhnhans.Find(MaBenhNhan);
            if (kh == null)
            {
                return NotFound();
            }
            _context.Benhnhans.Remove(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
