using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Yt_DotNet6IdentityWeb.Models.DTO;
using Yt_DotNet6IdentityWeb.Repositories.Abstract;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Yt_DotNet6IdentityWeb.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _service;
        public UserAuthenticationController(IUserAuthenticationService _service)
        {
            this._service= _service;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Role = "user";
            var result = await this._service.RegistrationAsync(model);
            TempData["message"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _service.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Display","Dashboard");
            }
            else
            {
                TempData["message"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        //public async Task<IActionResult> Reg()
        //{
        //    var model = new RegistrationModel()
        //    {
        //        username = "admin",
        //        Name = "Izzat Rabani",
        //        Email = "izzatrabani93@gmail.com",
        //        Password = "Admin@123#"
        //    };
        //    model.Role = "user";
        //    var result = await _service.RegistrationAsync(model);
        //    TempData["message"] = result.Message;
        //    return Ok(result);
        //}

    }
}
