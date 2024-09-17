using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StickyNotesAPI.Models;
using StickyNotesWebsite.Data;
using StickyNotesWebsite.Models;

namespace StickyNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var allCategoriesList = _context.categories.ToList();
            return Ok(allCategoriesList);
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryDto addCategoryDto)
        {
            try
            {
                var category = new Category()
                {
                    Id = addCategoryDto.Id,
                    category = addCategoryDto.category,
                    createdBy = addCategoryDto.createdBy,
                    createdDate = addCategoryDto.createdDate,
                    description = addCategoryDto.description
 
                };

                _context.categories.Add(category);
                _context.SaveChanges();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
