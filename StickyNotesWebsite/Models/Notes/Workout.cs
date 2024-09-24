namespace StickyNotesWebsite.Models.Notes
{
    public class Workout : Card
    {
        public string Name { get; set;} = string.Empty;
        public List<string> Exercises { get; set;}
        public List<int> Reps { get; set; }
        public List<int> Sets { get; set; }
        public List<string> Weights { get; set; }

        public Workout()
        {
            this.Exercises = new List<string>();
            this.Reps = new List<int>();
            this.Sets = new List<int>();
            this.Weights = new List<string>();
            this.category = "Workout";
        }
    }
}
