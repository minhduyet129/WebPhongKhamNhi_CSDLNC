using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class HoSoKhamController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public HoSoKhamController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }

       

        public IActionResult GetHoSoTheoBenhNhan(int id)
        {
            var listhsk = _context.Hosokhams.Include(x => x.MaBacSiNavigation).OrderByDescending(x => x.NgayTao).Where(x=>x.MaBenhNhan==id);

            ViewBag.MaBenhNhan = id;
            return View(listhsk);
        }

        [HttpGet]
        public IActionResult CreateHoSoTheoBenhNhan(int id)
        {
            var listbs = _context.Bacsis.OrderBy(x => x.HoTen);
            ViewBag.BacSi = listbs;
            ViewBag.MaBenhNhan = id;
            return View();
        }
        [HttpPost]
        public IActionResult CreateHoSoTheoBenhNhan(Hosokham hoso)
        {
            var hs = new Hosokham()
            {
                ChuanDoan=hoso.ChuanDoan,
                TrieuChung = hoso.TrieuChung,
                NgayTao = hoso.NgayTao,
                MaBacSi = hoso.MaBacSi,
                MaBenhNhan = hoso.MaBenhNhan
                

            };
            _context.Hosokhams.Add(hs);
            _context.SaveChanges();
            return RedirectToAction("GetHoSoTheoBenhNhan",new { id=hoso.MaBenhNhan});
        }
        [HttpGet]
        public IActionResult EditHoSoTheoBenhNhan(int id)
        {
            var kh = _context.Hosokhams.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            var listbs = _context.Bacsis.OrderBy(x => x.HoTen);
            ViewBag.BacSi = listbs;
            return View(kh);
        }
        [HttpPost]
        public IActionResult EditHoSoTheoBenhNhan(Hosokham hoso)
        {
            var kh = _context.Hosokhams.Find(hoso.MaHoSo);
            if (kh == null)
            {
                return NotFound();
            }

            kh.TrieuChung = hoso.TrieuChung;
            
            kh.NgayTao = hoso.NgayTao;
            kh.ChuanDoan = hoso.ChuanDoan;

            _context.SaveChanges();
            return RedirectToAction("GetHoSoTheoBenhNhan", new { id = hoso.MaBenhNhan });

        }

        public IActionResult Details(int id)
        {
            var hosokham = _context.Hosokhams.Include(x=>x.MaBacSiNavigation).FirstOrDefault(x=>x.MaHoSo==id);
            if (hosokham == null)
            {
                return NotFound();
            }
            return View(hosokham);
        }
        [HttpGet]
        public IActionResult DeleteTheoBenhNhan(int id,int idbn)
        {
            var kh = _context.Hosokhams.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            ViewBag.MaBenhNhan = idbn;
            return View(kh);
        }

        [HttpPost]
        public IActionResult DeletePostTheoBenhNhan(int MaHoSo,int MaBenhNhan)
        {
            var kh = _context.Hosokhams.Find(MaHoSo);
            if (kh == null)
            {
                return NotFound();
            }
            var listdt = _context.Donthuocs.Where(x => x.MaHoSo == MaHoSo);
            foreach (var dt in listdt)
            {
                dt.MaHoSo = null;
            }
            var listpxn = _context.Phieuxetnghiems.Where(x => x.MaHoSo == MaHoSo);
            foreach (var dt in listpxn)
            {
                dt.MaHoSo = null;
            }

            _context.Hosokhams.Remove(kh);
            _context.SaveChanges();
            return RedirectToAction("GetHoSoTheoBenhNhan",new { id=MaBenhNhan});
        }


        //CRUD cũ


        public IActionResult Index(string keyword)
        {
            var listhsk = _context.Hosokhams.Include(x => x.MaBacSiNavigation).Include(x=>x.MaBenhNhanNavigation).OrderByDescending(x => x.NgayTao).ToList();
            if (String.IsNullOrEmpty(keyword))
            {
                return View(listhsk);
            }
            listhsk = listhsk.Where(x => x.MaHoSo.ToString().Contains(keyword.ToLower()) || x.NgayTao.ToString().Contains(keyword)).ToList();
            return View(listhsk);
        }


        public IActionResult DetailsHoSo(int id)
        {
            var hosokham = _context.Hosokhams.Include(x => x.MaBacSiNavigation).FirstOrDefault(x => x.MaHoSo == id);
            if (hosokham == null)
            {
                return NotFound();
            }
            return View(hosokham);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var kh = _context.Hosokhams.Include(x=>x.MaBenhNhanNavigation).FirstOrDefault(x=>x.MaHoSo==id);
            if (kh == null)
            {
                return NotFound();
            }
            var listbs = _context.Bacsis.OrderBy(x => x.HoTen);
            ViewBag.BacSi = listbs;
            return View(kh);
        }
        [HttpPost]
        public IActionResult Edit(int id, Hosokham hoso)
        {
            var kh = _context.Hosokhams.Find(id);
            if (kh == null)
            {
                return NotFound();
            }

            kh.TrieuChung = hoso.TrieuChung;

            kh.MaBacSi = hoso.MaBacSi;
            kh.NgayTao = hoso.NgayTao;
            kh.ChuanDoan = hoso.ChuanDoan;
           
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var kh = _context.Hosokhams.Find(id);
            if (kh == null)
            {
                return NotFound();
            }
            return View(kh);
        }

        [HttpPost]
        public IActionResult DeletePost(int MaHoSo)
        {
            var kh = _context.Hosokhams.Find(MaHoSo);
            if (kh == null)
            {
                return NotFound();
            }
            var listdt = _context.Donthuocs.Where(x => x.MaHoSo == MaHoSo);
            foreach(var dt in listdt)
            {
                dt.MaHoSo = null;
            }
            var listpxn = _context.Phieuxetnghiems.Where(x => x.MaHoSo == MaHoSo);
            foreach (var dt in listpxn)
            {
                dt.MaHoSo = null;
            }
            
            _context.Hosokhams.Remove(kh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
