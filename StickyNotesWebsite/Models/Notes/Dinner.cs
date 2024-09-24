namespace StickyNotesWebsite.Models.Notes
{
    public class Dinner : Card
    {
        public string Meal { get; set; } = string.Empty;
        public List<string> Ingredients { get; set; }
        public List<string> Grams { get; set; }
        public List<int> Calories { get; set; }

        public Dinner()
        {
            this.Ingredients = new List<string>();
            this.Grams = new List<string>();
            this.Calories = new List<int>();
            this.category = "Dinner";
        }
    }
}
