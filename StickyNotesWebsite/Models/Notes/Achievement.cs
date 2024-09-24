namespace StickyNotesWebsite.Models.Notes
{
    public class Achievement : Card
    {
        public string AchievementGoal { get; set; } = string.Empty;

        public Achievement()
        {
            this.category = "Achievement";
        }
    }
}
