using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services.Authors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
   
    [Authorize(Roles = "Admin,Manager,User")]
    public class AuthorsController : Controller
    {
        //public readonly AppDBContext _context;

        public readonly AuthorsService _context;

        public AuthorsController(AuthorsService context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(Authors teacher)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Authors.Add(teacher);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //        return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Author_id,Author_name")] Authors author)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAndSave(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        //public IActionResult Index()
        //{
        //    return View(_context.Authors);
        //}

        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        //public IActionResult Update(int id)
        //{
        //    return View(_context.Authors.Where(a => a.Author_id == id).FirstOrDefault());
        //}

        //[HttpPost]
        //[ActionName("Update")]
        //public IActionResult Update_Post(Authors author)
        //{
        //    _context.Authors.Update(author);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    var role = _context.Authors.Where(a => a.Author_id == id).FirstOrDefault();
        //    _context.Authors.Remove(role);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        // GET: Coaches/Edit/5
        public async Task<IActionResult> Update(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, [Bind("Author_id,Aithor_name")] Authors author)
        {
            if (id != author.Author_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateAndSave(author);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.CoachExists(author.Author_id))
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
            return View(author);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.GetById((string)id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _context.DeleteAndSave(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
