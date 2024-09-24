using System.ComponentModel.DataAnnotations;

namespace StickyNotesWebsite.Models.Notes
{
    public abstract class Card
    {
        public int Id { get; set; }
        [Required]
        public string title { get; set; } = string.Empty;
        [Required]
        public string category { get; set; } = string.Empty;
        public string createdBy { get; set; } = string.Empty;
        [Required]
        public string description { get; set; } = string.Empty;
        public DateTime createdDate { get; set; }
        public DayOfWeek dayCreated { get; set; }
        public DateTime updated { get; set; }


        public Card()
        {
            this.dayCreated = DateTime.Today.DayOfWeek;
            this.createdDate = DateTime.Now;
            this.updated = DateTime.Now;
        }

    }
}
