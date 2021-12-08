using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class PhieuNhapThuocController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public PhieuNhapThuocController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }

        // GET: PhieuNhapThuoc
        public ActionResult Index()
        {
            var listPhieuNhap = _context.Phieunhaps.Include(p => p.MaNhaSanXuatNavigation).OrderByDescending(p => p.NgayNhap);
            return View(listPhieuNhap);
        }

        //POST:PhieuNhapThuoc/Index
        [HttpPost]
        public IActionResult Index(string textSearch)
        {
            if (textSearch == null)
            {
                return RedirectToAction("Index");
            }

            string textSearchFormat = textSearch.Trim().ToLower();
            if (string.IsNullOrEmpty(textSearchFormat))
            {
                return RedirectToAction("Index");
            }
            else
            {
                var result = _context.Phieunhaps.Include(p => p.MaNhaSanXuatNavigation).ToList().Where(
                   p => p.MaNhaSanXuatNavigation.TenNhaSanXuat.ToLower().Contains(textSearchFormat) ||
                   p.MaPhieuNhap.ToString().ToLower().Contains(textSearchFormat) ||
                   p.NgayNhap.ToString().Contains(textSearchFormat)
               );

                return View(result);
            }
        }

        // GET: PhieuNhapThuoc/Details/5
        public ActionResult Details(int id)
        {
            var phieuNhap = _context.Phieunhaps.Include(p => p.MaNhaSanXuatNavigation).Where(p => p.MaPhieuNhap == id).First();
            if (phieuNhap == null)
            {
                return NotFound();
            }

            var listChiTietPhieuNhap = _context.Chitietphieunhaps
                .Include(c => c.MaPhieuNhapNavigation)
                .Include(c => c.MaThuocNavigation).Where(ct => ct.MaPhieuNhap == id);
            ViewBag.listChiTietPhieuNhap = listChiTietPhieuNhap;

            return View(phieuNhap);
        }

        // GET: PhieuNhapThuoc/Create
        public ActionResult Create()
        {

            var listNsx = _context.Nhasanxuats.OrderBy(n => n.TenNhaSanXuat);
            var listThuoc = _context.Thuocs.OrderBy(t => t.Ten);

            if (listNsx == null || listThuoc == null)
            {
                return NotFound();
            }
            ViewBag.listNsx = listNsx;
            ViewBag.listThuoc = listThuoc;

            return View();
        }

        // POST: PhieuNhapThuoc/Create
        [HttpPost]
        public ActionResult Create(Phieunhap phieunhap, IEnumerable<Chitietphieunhap> chiTietPhieus)
        {
            try
            {
                //vì id tự sinh, lưu phiếu nhập vào csdl để lấy id
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, message = "dữ liệu không hợp lệ" });

                }
                _context.Phieunhaps.Add(phieunhap);
                _context.SaveChanges();

                //lưu chi tiết phiếu nhập
                decimal? tongTien = 0;
                foreach (var ct in chiTietPhieus)
                {
                    //tính thành tiền
                    decimal? thanhTien = ct.GiaThuoc * ct.SoLuong;

                    //tính tổng tiền phiếu nhập
                    tongTien += thanhTien;

                    ct.MaPhieuNhap = phieunhap.MaPhieuNhap;
                    ct.ThanhTien = thanhTien;
                    _context.Chitietphieunhaps.Add(ct);

                    //cập nhật lượng thuốc tồn kho
                    _context.Thuocs.Find(ct.MaThuoc).SoLuongTonKho += ct.SoLuong;
                }

                //cập nhật tổng tiền phiếu nhập
                phieunhap.TongTien = tongTien;

                _context.SaveChanges();

                return Json(new { status = true, redirectToUrl = Url.Action("Index", "PhieuNhapThuoc") });

            }
            catch (Exception ex)
            {
                //kiểm tra có 2 thuốc trùng nhau
                var duplicateGroup = chiTietPhieus.GroupBy(c => c.MaThuoc)
                                         .Where(g => g.Count() > 1)
                                         .Select(c => c);
                if(duplicateGroup != null)
                {
                    return Json(new { status = false, message = "Thông tin thuốc bị trùng lặp" }); 
                }


                return Json(new { status = false, message = ex.Message });
            }
        }

        // GET: PhieuNhapThuoc/Edit/5
        public ActionResult Edit(int id)
        {
            var listNsx = _context.Nhasanxuats.OrderBy(n => n.TenNhaSanXuat);
            var listThuoc = _context.Thuocs.OrderBy(t => t.Ten);
            var phieuNhap = _context.Phieunhaps.Find(id);
            var chiTiets = _context.Chitietphieunhaps.Where(ct => ct.MaPhieuNhap == id).ToList();


            if (listNsx == null || listThuoc == null)
            {
                return NotFound();
            }
            ViewBag.listNsx = listNsx;
            ViewBag.listThuoc = listThuoc;
            ViewBag.chiTiets = chiTiets;
            ViewBag.phieuNhap = phieuNhap;

            return View();
        }

        // POST: PhieuNhapThuoc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int maPhieuNhap, Phieunhap phieuNhap, IEnumerable<Chitietphieunhap> chiTietPhieus)
        {
            Phieunhap phieuUpdate = _context.Phieunhaps.Find(maPhieuNhap);
            if (phieuNhap == null)
            {
                return NotFound();
            }

            phieuUpdate.MaNhaSanXuat = phieuNhap.MaNhaSanXuat;
            phieuUpdate.NgayNhap = phieuNhap.NgayNhap;
            phieuUpdate.TongTien = phieuNhap.TongTien;

            _context.Update(phieuUpdate);

            //cập nhật phiếu nhập: 2 hướng:
            //1. xoá -> thêm lại
            //2.

            //xoa 
            var chiTietsHienTai = _context.Chitietphieunhaps.Where(c => c.MaPhieuNhap == maPhieuNhap).ToList();
            foreach (var ct in chiTietsHienTai)
            {
                //cập nhật tồn kho thuốc
                _context.Thuocs.Find(ct.MaThuoc).SoLuongTonKho -= ct.SoLuong;

                _context.Chitietphieunhaps.Remove(ct);
            }
            _context.SaveChanges();

            //them lai
            foreach (var ct in chiTietPhieus)
            {
                //cập nhật tồn kho thuốc
                _context.Thuocs.Find(ct.MaThuoc).SoLuongTonKho += ct.SoLuong;

                ct.MaPhieuNhap = maPhieuNhap;
                _context.Chitietphieunhaps.Add(ct);
            }

            _context.SaveChanges();

            return Json(new { status = true, redirectToUrl = Url.Action("Index", "PhieuNhapThuoc") });
        }

        // GET: PhieuNhapThuoc/Delete/5
        public ActionResult Delete(int id)
        {
            var phieuXoa = _context.Phieunhaps.Include(p => p.MaNhaSanXuatNavigation)
                .FirstOrDefault(p => p.MaPhieuNhap == id);
            return View(phieuXoa);
        }

        // POST: PhieuNhapThuoc/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int MaPhieuNhap)
        {
            Phieunhap phieuXoa = _context.Phieunhaps.Find(MaPhieuNhap);
            if (phieuXoa == null)
            {
                return NotFound();
            }
            //xoá chi tiết phiếu nhập trước
            var chiTiets = _context.Chitietphieunhaps.Where(c => c.MaPhieuNhap == MaPhieuNhap).ToList();
            if (chiTiets.Count() != 0)
            {
                foreach (var ct in chiTiets)
                {
                    _context.Chitietphieunhaps.Remove(ct);

                    //giảm số lượng tồn kho của thuốc nếu xoá phiếu nhập
                    _context.Thuocs.Find(ct.MaThuoc).SoLuongTonKho -= ct.SoLuong;
                }
            }

            //xoá nốt phiếu nhập
            _context.Phieunhaps.Remove(phieuXoa);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
