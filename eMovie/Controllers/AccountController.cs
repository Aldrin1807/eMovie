﻿using eMovie.Data;
using eMovie.Data.DTOs;
using eMovie.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eMovie.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager,
                       SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }



        public IActionResult Login() => View(new LoginDTO());


        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if(!ModelState.IsValid)
            {
                return View(login);
            }

            var user  = await _userManager.FindByEmailAsync(login.EmailAddress);

            if (user != null)
            {
                var checkPass = await _userManager.CheckPasswordAsync(user, login.Password);
                if(checkPass)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Invalid credentials";
                return View(login);
            }
            TempData["Error"] = "Invalid credentials";
            return View(login);
        }

        public IActionResult Register() => View(new RegisterDTO());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            if (!ModelState.IsValid) { return View(register); }

            var isUser = _userManager.FindByEmailAsync(register.EmailAddress);
            if (isUser != null)
            {
                TempData["Error"] = "User already exists";
                return View(register);
            }

            var user = new ApplicationUser()
            {
                Email = register.EmailAddress,
                UserName = register.EmailAddress,
                FullName = register.FullName
            };

            var newUser = await _userManager.CreateAsync(user, register.Password);

            if (newUser.Succeeded)
                await _userManager.AddToRoleAsync(user, UserRoles.User);

            return View("RegisterCompleted");
            
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

    }
}
