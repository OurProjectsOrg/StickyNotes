using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StickyNotesWebsite.Models.ViewModels
{
    public class StickyNoteViewModel
    {
        [Required]
        [DisplayName("Title")]
        public string title { get; set; } = string.Empty;
        [Required]
        [DisplayName(@"Categories")]
        public string SelectedCategory { get; set; } = string.Empty;
        public IEnumerable<SelectListItem> categories { get; set; }
        [Required]
        [DisplayName(@"Description")]
        public string description { get; set; } = string.Empty;
    }
}
