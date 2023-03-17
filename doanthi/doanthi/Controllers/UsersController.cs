using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using doanthi.Data;
using doanthi.Models;
using doanthi.ViewModel;

namespace doanthi.Controllers
{
    public class UsersController : Controller
    {
        private readonly doanthiDBContext _context;

        public UsersController(doanthiDBContext context)
        {
            _context = context;
        }

        // GET: Users
        public IActionResult LoginHoangNgocVy()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        
        public async Task<IActionResult> LoginHoangNgocVy(LoginInput login)
        {
            if (ModelState.IsValid)
            {
                var result = _context.Users.FirstOrDefault(x => x.Username == login.Username);
                if (result != null)
                {
                    if (result.Password == login.Password)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, "Tên Đăng Nhập Hoặc Mật Khẩu Không Chính Xác!!!");
                    return View(login);
                }
                ModelState.AddModelError(string.Empty, "Tên Đăng Nhập Hoặc Mật Khẩu Không Chính Xác!!!");
            }
            return View(login);
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }
    }
}
