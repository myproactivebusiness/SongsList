using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SongsList.Models;

namespace SongsList.Controllers
{
    public class SongController : Controller
    {
        private SongContext context { get; set; }

        public SongController(SongContext ctx)
        {
            context = ctx;
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit",new Song());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var song = context.Songs.Find(id);

            return View(song);
        }

        [HttpPost]
        public IActionResult Edit(Song song)
        {
            if (ModelState.IsValid)
            {
                if (song.SongId == 0) // Adding
                    context.Songs.Add(song);
                else
                    context.Songs.Update(song);

                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = song.SongId == 0 ? "Add" : "Edit";
                return View(song);
            }
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var song = context.Songs.Find(id);

            return View(song);
        }

        [HttpPost]
        public IActionResult Delete(Song song)
        {
            context.Songs.Remove(song);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
