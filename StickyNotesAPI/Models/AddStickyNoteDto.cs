using System.ComponentModel.DataAnnotations;

namespace StickyNotesAPI.Models
{
    public class AddStickyNoteDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Category { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public DateTime Updated { get; set; }
    }
}
