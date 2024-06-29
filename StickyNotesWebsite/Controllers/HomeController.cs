using Microsoft.AspNetCore.Mvc;
using StickyNotesWebsite.Data;
using StickyNotesWebsite.Models;
using StickyNotesWebsite.Services;
using System.Diagnostics;

namespace StickyNotesWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        public IConfiguration _config { get; set; }

        public HomeController(ILogger<HomeController> logger,
            DataContext context,
            IConfiguration config)
        {
            _logger = logger;
            _context = context;
            _config = config;
        }

        public async Task<IActionResult> StickyNotes()
        {
           var stickyNotes = await StickyNotesService.ReturnAllStickyNote(_config);
           return View(stickyNotes);
        }

        public IActionResult CreateStickyNote()
        {
            return View();
        }

        public async Task<IActionResult> UserAction_CreateStickyNote(StickyNote stickyNote)
        {
           var result = await StickyNotesService.CreateStickyNote(stickyNote, _config);
            if (result) return RedirectToAction("StickyNotes");
                else return RedirectToAction("error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
