namespace StickyNotesWebsite.Models.Notes
{
    public  static class cardFactory
    {
        public static Card Factory(string category)
        {
           switch(category)
            {
                case "Workout":
                    return new Workout();
                case "Breakfast":
                    return new Breakfast();
                case "Lunch":
                    return new Lunch();
                case "Dinner":
                    return new Dinner();
                case "Achievement":
                    return new Achievement();
                case "MissedTarget":
                    return new MissedTarget();
                default:
                    return null;
            }            
        }
    }
}
