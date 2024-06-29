using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StickyNotesAPI.Models;
using StickyNotesWebsite.Data;
using StickyNotesWebsite.Models;

namespace StickyNotesAPI.Controllers
{
    // localhost:xxxx/api/stickynotes/
    [Route("api/[controller]")]
    [ApiController]
    public class StickyNotesController : ControllerBase
    {
        private readonly DataContext _context;
        public StickyNotesController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStickyNotes()
        {
            var allStickyNotes = _context.StickyNote.ToList();
            return Ok(allStickyNotes);
        }

        [HttpPost]
        public IActionResult AddStickyNote(AddStickyNoteDto addStickyNoteDto)
        {
            try
            {
                var stickyNote = new StickyNote()
                {
                    Id = addStickyNoteDto.Id,
                    title = addStickyNoteDto.Title,
                    category = addStickyNoteDto.Category,
                    createdBy = addStickyNoteDto.CreatedBy,
                    createdDate = addStickyNoteDto.CreatedDate,
                    description = addStickyNoteDto.Description,
                    updated = addStickyNoteDto.Updated
                };

                _context.StickyNote.Add(stickyNote);
                _context.SaveChanges();

                return Ok(stickyNote);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
