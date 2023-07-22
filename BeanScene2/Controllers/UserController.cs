using BeanScene2.Services;
using Microsoft.AspNetCore.Mvc;
using BeanScene2.Data;
using BeanScene2.Models;
using BeanScene2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BeanScene2.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IUserService _authService;

        public UserController(IUserService authService)
        {
            _authService = authService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            model.Role = "user";
            var result = await _authService.RegisterAsync(model);

            EmailOuterService Outer = new EmailOuterService();
            var confirmation = Outer.Inner.SendEmailConfirmation(model.Email, model.LastName, model.UserName, model.Password);

            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Login));
        }
        //create admin user acc and password
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            model.Role = "admin";
            var result = await _authService.RegisterAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Register));
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        public async Task<IActionResult> Logout()
        {
            await this._authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        //public IActionResult User()
        //{

        //  //  var UserDetail = _db.users;

        //    IEnumerable<User> UserList = _db.users;
        //    return View(UserList);
        //}
    }
}
