using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SongsList.Models;

namespace SongsList.Controllers
{
    public class HomeController : Controller
    {
        private SongContext context { get; set; }

        public HomeController(SongContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var songs = context.Songs.OrderBy(x => x.Name).ToList();

            return View(songs);
        }

        

    }
}
