using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    
    [Authorize(Roles = "User")]
    public class BooksController : Controller
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _booksService.GetAllBooks());
        }

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _booksService.GetById((string)id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        public async Task<IActionResult> CreateAsync()
        {
            ViewData["Pub_id"] = new SelectList(await _booksService.GetAllPublishers(), "Pub_id", "Book_id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Book_id,Book_title,Book_page,Book_pub,Book_shortDec,Book_dec,Pub_id")] Books equipment)
        {
            if (ModelState.IsValid)
            {
                await _booksService.AddAndSave(equipment);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Pub_id"] = new SelectList(await _booksService.GetAllPublishers(), "Pub_id", "Book_id", equipment.Pub_id);
            return View(equipment);
        }


    }
}
