using System.ComponentModel.DataAnnotations;

namespace StickyNotesWebsite.Models
{
    public class Category
    {     
        public int Id { get; set; }

        [Required]
        public string category { get; set; } = string.Empty;
        [Required]
        public string createdBy { get; set; } = string.Empty;
        [Required]
        public DateTime createdDate { get; set; }
        [Required]
        public string description { get; set; } = string.Empty;
    }
}
