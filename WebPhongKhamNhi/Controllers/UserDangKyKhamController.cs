using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    [Authorize]
    public class UserDangKyKhamController : Controller
    {
        private readonly QLPhongKhamNhiContext _context = new QLPhongKhamNhiContext();

        public UserDangKyKhamController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }

        // GET: UserDangKyKhamController
        public ActionResult Index()
        {
            ViewBag.dichVuKham = _context.Dichvukhams.OrderBy(dv => dv.TenDichVu);
            ViewBag.khoa = _context.Khoas.OrderBy(k => k.TenKhoa);

            if(TempData["UserDangKyMessage"] != null)
            {
                string msg = TempData["UserDangKyMessage"].ToString();
                ViewData["UserDangKyMessage"] = msg;

                TempData["UserDangKyMessage"] = null;
            }

            return View();
        }

        //get bac si by khoaId41
        [HttpPost]
        public JsonResult GetListBacSiByKhoaId(int maKhoa)
        { 
            if (maKhoa == null)
                return Json(new
                {
                    status = false
                });

            var bacSis = _context.Bacsis.Where(bs => bs.MaKhoa == maKhoa).OrderBy(bs => bs.HoTen);
            return Json(new
            {
                status = true,
                data = bacSis
            });
        }



        // POST: UserDangKyKhamController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Save(int maDichVu, DateTime ngayDangKy)
        {
            try
            {
                if (maDichVu == null || ngayDangKy == null)
                {
                    return NotFound();
                }

                var maUser = User.Claims.ToList()[1].Value;

                var dichVu = _context.Dichvukhams.Find(maDichVu);
                if (dichVu == null)
                {
                    return NotFound();
                }

                decimal? chiPhi = dichVu.ChiPhi;

                Phieudangkykham phieuDk = new Phieudangkykham();
                phieuDk.MaBenhNhan = int.Parse(maUser);
                phieuDk.MaDichVu = maDichVu;
                phieuDk.NgayDangKy = ngayDangKy;
                phieuDk.TongTien = chiPhi;

                _context.Phieudangkykhams.Add(phieuDk);
                _context.SaveChanges();

                TempData["UserDangKyMessage"] = "Đăng ký thành công";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

    }
}