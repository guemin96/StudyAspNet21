using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortpolio.Data;
using MyPortpolio.Models;

namespace MyPortpolio.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]//제일 처음에 발생하는 이벤트
        public IActionResult Login()
        {
            var account = new Account();
            return View(account);
        }
        [HttpPost]//버튼을 누른뒤에 발생하는 이벤트
        public async Task<IActionResult> Login([Bind("Email,Password")] Account account)
        {
            if (ModelState.IsValid)
            {
                var result = CheckAccount(account.Email, account.Password);
                if (result==null) //계정이 없음 화면을 Home.Index로 
                {
                    ViewBag.Message = "해당계정이 없습니다.";
                    return View("Login");

                }
                else
                {//로그인
                    HttpContext.Session.SetString("UserEmail", result.Email);
                    return RedirectToAction("Index","Home");
                }
            }
            return null;
        }

        private Account CheckAccount(string email, string password)
        {
            return _context.Account.SingleOrDefault(a=> a.Email.Equals(email)&& a.Password.Equals(password));
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
