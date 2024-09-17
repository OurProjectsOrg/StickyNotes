using Microsoft.AspNetCore.Mvc;
using StickyNotesWebsite.Data;
using StickyNotesWebsite.Models;
using StickyNotesWebsite.Services;
using System.Diagnostics;

namespace StickyNotesWebsite.Controllers
{
    public class StickyNotesController : Controller
    {
        private readonly ILogger<StickyNotesController> _logger;
        private readonly DataContext _context;
        public IConfiguration _config { get; set; }

        public StickyNotesController(ILogger<StickyNotesController> logger,
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


        public IActionResult Login()
        {
            return View();
        }


        public IActionResult NavigateTo_CreateStickyNotePage()
        {
            return View("CreateStickyNote");

        }

        public IActionResult NavigateTo_CreateCategory()
        {
            return View("CreateCategory");
        }

        public async Task<IActionResult> UserAction_CreateStickyNote(StickyNote stickyNote)
        {
            var result = await StickyNotesService.CreateStickyNote(stickyNote, _config);
            if (result)
            {
                ViewBag.SuccessMessage = "successfully added";
                return View("CreateStickyNote");
            }
            else
            {
                ViewBag.SuccessMessage = "not successfully added";
                return View("CreateStickyNote");
            }
        }

        public async Task<IActionResult> UserAction_CreateCategory(Category _category)
        {
            var result = await CategoryService.CreateCategory(_category, _config);
            if (result)
            {
                ViewBag.SuccessMessage = "successfully added";
                return View("CreateCategory");
            }
            else
            {
                ViewBag.SuccessMessage = "not successfully added";
                return View("CreateCategory");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
