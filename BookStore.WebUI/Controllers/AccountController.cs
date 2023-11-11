using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace BookStore.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;

        public AccountController(IMapper mapper, IAccountManager accountManager)
        {
            _mapper = mapper;
            _accountManager = accountManager;
        }

        public IActionResult Account()
        {
            ViewBag.Name = User.Identity.Name;
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountManager.Register(userDTO);
                if (!result.Success)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("Email", result.Message);
                    return View(userDTO);
                }

                _accountManager.Register(userDTO);
                return RedirectToAction("Login");
            }

            return View(userDTO);
        }

        [Authorize(Policy ="Administrator")]
        public IActionResult Administrator() 
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _accountManager.Login(model.Email, model.Password);
            if (!result.Success)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;

                if (result.Message == ErrorMessages.EmailNotFound)
                {
                    ModelState.AddModelError("Email", result.Message);
                }

                if (result.Message == ErrorMessages.WrongPassword)
                {
                    ModelState.AddModelError("Password", result.Message);
                }
                
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, result.Data.UserName),
            };
            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

            await HttpContext.SignInAsync("Cookie", claimsPrincipal);

            if (result.Data.UserName == "Admin")
            {
                return Redirect("Administrator");
            }

            return Redirect("Account");
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("/Home/Index");
        }
    }
}
