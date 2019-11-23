using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services.BooksInventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace courseProject.Controllers
{
    public class BooksInventoryController : Controller
    {
        private readonly BooksInventoryService _service;

        public BooksInventoryController(BooksInventoryService service)
        {
            _service = service;
        }

        // GET: UserAnswers
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllBooksInventory());
        }

        
        // GET: UserAnswers/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["Book_id"] = new SelectList(await _service.GetAllBooks(), "Book_id", "Book_title");
            ViewData["User_id"] = new SelectList(await _service.GetAllUsers(), "User_id", "User_id");
            return View();
        }

        // POST: UserAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Book_id,User_id")] BooksInventory bookUser)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAndSave(bookUser);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Book_id"] = new SelectList(await _service.GetAllBooks(), "Book_id", "Book_title", bookUser.Book_id);
            ViewData["User_id"] = new SelectList(await _service.GetAllUsers(), "User_id", "User_id", bookUser.User_id);
            return View(bookUser);
        }

        // GET: UserAnswers/Edit/5
        public async Task<IActionResult> Update(int? Book_id, int? Authors_id)
        {
            if (Book_id == null || Authors_id == null)
            {
                return NotFound();
            }

            var bookUser = await _service.GetById((int)Book_id, (int)Authors_id);
            if (bookUser == null)
            {
                return NotFound();
            }

            ViewData["Book_id"] = new SelectList(await _service.GetAllBooks(), "Book_id", "Book_title", bookUser.Book_id);
            ViewData["User_id"] = new SelectList(await _service.GetAllUsers(), "User_id", "User_id", bookUser.User_id);
            return View(bookUser);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync(int Book_id, int User_id, [Bind("Book_id,User_id")] BooksInventory bookUser)
        {

            if (Book_id != bookUser.Book_id || User_id != bookUser.User_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAndSave(bookUser);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.BooksInventoryExists(bookUser.Book_id, bookUser.User_id))
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

             ViewData["Book_id"] = new SelectList(await _service.GetAllBooks(), "Book_id", "Book_title", bookUser.Book_id);
            ViewData["User_id"] = new SelectList(await _service.GetAllUsers(), "User_id", "User_id", bookUser.User_id);
            return View(bookUser);
        }

        // GET: UserAnswers/Delete/5
        public async Task<IActionResult> Delete(int? Book_id, int? User_id)
        {
            if (Book_id == null || User_id == null)
            {
                return NotFound();
            }

            var bookUser = await _service.GetById((int)Book_id, (int)User_id);
            if (bookUser == null)
            {
                return NotFound();
            }

            return View(bookUser);
        }

        // POST: UserAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int Book_id, int User_id)
        {
            await _service.DeleteAndSave(Book_id, User_id);
            return RedirectToAction(nameof(Index));
        }

    }
}