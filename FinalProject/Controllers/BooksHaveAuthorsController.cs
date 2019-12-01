using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services.BooksHaveAuthors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
   
    [Authorize(Roles = "Manager")]
    public class BooksHaveAuthorsController : Controller
    {
        private readonly BooksHaveAuthorsService _service;

        public BooksHaveAuthorsController(BooksHaveAuthorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllBooksHaveAuthors());
        }

        public async Task<IActionResult> CreateAsync()
        {
            ViewData["Book_id"] = new SelectList(await _service.GetAllBooks(), "Book_id", "Book_title");
            ViewData["Author_id"] = new SelectList(await _service.GetAllAuthors(), "Author_id", "Author_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Book_id,Author_id")] BooksHaveAuthors BHA)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAndSave(BHA);
                return RedirectToAction(nameof(Index));
            }

            ViewData["Book_id"] = new SelectList(await _service.GetAllBooks(), "Book_id", "Book_title", BHA.Book_id);
            ViewData["Author_id"] = new SelectList(await _service.GetAllAuthors(), "Author_id", "Author_name", BHA.Author_id);
            return View(BHA);
        }

        public async Task<IActionResult> Update(string Book_id, string Authors_id)
        {

            if (Book_id == null || Authors_id == null)
            {
                return NotFound();
            }

            var BHA = await _service.GetById((string)Book_id, (string)Authors_id);
            if (BHA == null)
            {
                return NotFound();
            }

            ViewData["Book_id"] = new SelectList(await _service.GetAllBooks(), "Book_id", "Book_title", BHA.Book_id);
            ViewData["Author_id"] = new SelectList(await _service.GetAllAuthors(), "Author_id", "Author_name", BHA.Author_id);
            return View(BHA);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string Book_id, string Author_id, [Bind("Book_id,Author_id")] BooksHaveAuthors BHA)
        {

            if (Book_id != BHA.Book_id || Author_id != BHA.Author_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAndSave(BHA);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.BooksHaveAuthorsExists(BHA.Book_id, BHA.Author_id))
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

            ViewData["Book_id"] = new SelectList(await _service.GetAllBooks(), "Book_id", "Book_title", BHA.Book_id);
            ViewData["Author_id"] = new SelectList(await _service.GetAllAuthors(), "Author_id", "Author_name", BHA.Author_id);
            return RedirectToAction(nameof(Index));
        }

        //// GET: UserAnswers/Delete/5
        //public async Task<IActionResult> Delete(string Book_id, string Author_id)
        //{
        //    if (Book_id == null || Author_id == null)
        //    {
        //        return NotFound();
        //    }

        //    var BHA = await _service.GetById((string)Book_id, (string)Author_id);
        //    if (BHA == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(BHA);
        //}

        // POST: UserAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(string Book_id, string Author_id)
        {
            await _service.DeleteAndSave(Book_id, Author_id);
            return RedirectToAction(nameof(Index));
        }
    }
}
