﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

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
        public string dayCreated { get; set; }


        public StickyNote()
        {
            this.dayCreated = DateTime.Today.DayOfWeek.ToString();
            this.createdDate = DateTime.Now;
            this.updated = DateTime.Now;
            this.category = "Sticky Note";
            this.createdBy = "Me";
        }

    }
}
