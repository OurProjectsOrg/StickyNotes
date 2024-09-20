using System.ComponentModel.DataAnnotations;

namespace StickyNotesWebsite.Models
{
    public class StickyNote
    {
        public int Id { get; set; }
        [Required]
        public string title { get; set; } = string.Empty;
        [Required]
        public string category { get; set; } = string.Empty;
        public DateTime createdDate { get; set; }
        public string createdBy { get; set; } = string.Empty;
        [Required]
        public string description { get; set; } = string.Empty;
        public DateTime updated { get;set; }
    }

}
