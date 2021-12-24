using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly QLPhongKhamNhiContext _context;

        public HomeController(ILogger<HomeController> logger, QLPhongKhamNhiContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.SLBacSi = _context.Bacsis.Count();
            ViewBag.SLBenhNhan = _context.Benhnhans.Where(x => x.LoaiTaiKhoan == 0).Count();
            ViewBag.SLNSX = _context.Nhasanxuats.Count();
            ViewBag.SLThuoc = _context.Thuocs.Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
