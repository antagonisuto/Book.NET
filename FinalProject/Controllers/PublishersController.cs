﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services.Publishers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    
    [Authorize(Roles = "User,Admin,Manager")]
    public class PublishersController : Controller
    {
        
        private readonly PublishersService _pubService;

        public PublishersController(PublishersService pubService)
        {
            _pubService = pubService;
        }
        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var users = await _pubService.GetAll();
            return View(users);
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _pubService.GetById((string)id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [Authorize(Roles = "Admin,Manager")]
        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pub_id,Pub_name")] Publishers room)
        {
            if (ModelState.IsValid)
            {
                await _pubService.AddAndSave(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Update(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _pubService.GetById((string)id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, [Bind("Pub_id,Pub_name")] Publishers room)
        {
            if (id != room.Pub_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _pubService.UpdateAndSave(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_pubService.PublisherExists(room.Pub_id))
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
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _pubService.GetById((string)id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _pubService.DeleteAndSave(id);
            return RedirectToAction(nameof(Index));
        }

    }

}
