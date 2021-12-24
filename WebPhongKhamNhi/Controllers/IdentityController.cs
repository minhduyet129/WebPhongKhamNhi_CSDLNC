using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Controllers
{
    public class IdentityController : Controller
    {
        private readonly QLPhongKhamNhiContext _context;

        public IdentityController(QLPhongKhamNhiContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl=null)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username,string password,string ReturnUrl)
        {
            var user = _context.Benhnhans.FirstOrDefault(x => x.TenTaiKhoan == username && x.MatKhau == password);
            
            if (user!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.NameIdentifier,user.MaBenhNhan.ToString())
                    
                };
                
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                 HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                 if(user.LoaiTaiKhoan == 1)
                {
                    return Redirect("/Home");
                }
                return Redirect(ReturnUrl == null ? "/User" : ReturnUrl);
            }
            TempData["Message"] = "Tên tài khoản và mật khẩu không chính xác";
            return View();
        }
        [HttpPost]
        public IActionResult Register(Benhnhan benhnhan)
        {
            var bn = _context.Benhnhans.FirstOrDefault(x => x.TenTaiKhoan == benhnhan.TenTaiKhoan);
            if(bn != null)
            {
                return BadRequest("Tên tài khoản đã tồn tại!.");
            }
            benhnhan.LoaiTaiKhoan = 0;
            _context.Benhnhans.Add(benhnhan);
            _context.SaveChanges();
            return Ok("Tạo thành công");

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "User");
        }
    }
}
