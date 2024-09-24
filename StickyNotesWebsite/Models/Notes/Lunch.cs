namespace StickyNotesWebsite.Models.Notes
{
    public class Lunch : Card
    { 
        public string Meal { get; set; } = string.Empty;
        public List<string> Ingredients { get; set; }
        public List<string> Grams { get; set; }
        public List<int> Calories { get; set; }

        public Lunch()
        {
            this.Ingredients = new List<string>();
            this.Grams = new List<string>();
            this.Calories = new List<int>();
            this.category = "Lunch";
        }
    }
}
