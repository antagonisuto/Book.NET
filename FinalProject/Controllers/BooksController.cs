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
    
    [Authorize(Roles = "Admin,User,Manager")]
    public class BooksController : Controller
    {
        private readonly BooksService _booksService;

        //[TempData]
        //public string Message { get; set; }

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task<IActionResult> Index()
        {
            var surveys = await _booksService.GetAllBooks();
            //Message = $"Session saves Books";
            return View(surveys);
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

        public async Task<IActionResult> Create()
        {
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Full_Name");
            //ViewData["SurveyId"] = new SelectList(_context.Surveys, "Id", "Question");
            ViewData["Pub_id"] = new SelectList(await _booksService.GetAllPublishers(), "Pub_id", "Pub_name");
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

            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Full_Name", user_Answers.UserId);
            //ViewData["SurveyId"] = new SelectList(_context.Surveys, "Id", "Question", user_Answers.SurveyId);
            ViewData["Pub_id"] = new SelectList(await _booksService.GetAllPublishers(), "Pub_id", "Pub_name", equipment.Pub_id);
            return View(equipment);
        }


    }
}
