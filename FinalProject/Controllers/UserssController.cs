using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services.Userss;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserssController : Controller
    {
        private readonly UserssService _service;
        private readonly UserManager<Userss> _userManager;

        public UserssController(UserssService service, UserManager<Userss> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            //return View(await _service.GetAllUsers());
            var users = await _service.GetAll();
            return View(users);
        }

        public IActionResult Create()
        {
            //ViewData["Role_id"] = new SelectList(await _service.GetAllRoles(), "Role_id", "Role_idd");
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("User_id,Username,Password,FullName")] Userss user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _service.AddAndSave(user);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    //ViewData["Role_id"] = new SelectList(await _service.GetAllRoles(), "Role_id", "Role_idd", user.Role_id);
        //    return View(user);
        //}


        // GET: Equipment/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _service.GetById((int)id);
            if (user == null)
            {
                return NotFound();
            }
            //ViewData["Role_id"] = new SelectList(await _service.GetAllRoles(), "Role_id", "Role_idd", user.Role_id);
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("User_id,Username,Password,FullName")]  Userss user)
        {
            if (id != user.User_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAndSave(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.UserExists(user.User_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["RoomId"] = new SelectList(await _service.GetAllRoles(), "Role_id", "Role_id", user.Role_id);
            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAndSave(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new Userss
                {
                    Username = model.Email,
                    FullName = model.Full_Name,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                //await _usersService.AddAndSave(user);
                //return RedirectToAction(nameof(Index));
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "/Userss");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }


        ////VerifyUsername
        //[AcceptVerbs("Get", "Post")]
        //public IActionResult VerifyUsername(string username)
        //{
        //    if (_service.Userss.Any(m => m.Username.ToLower() == username.ToLower()))
        //    {
        //        return Json($"Username {username} is already in use.");
        //    }

        //    return Json(true);
        //}

    }
}
