using Microsoft.Identity.Client;
using System.Diagnostics.Eventing.Reader;

namespace StickyNotesWebsite.Models.Notes
{
    public class MissedTarget : Card
    {
        public string FailedTarget { get; set; } = string.Empty;
        public string FailedSource { get; set; } = string.Empty;
        public bool TryAgain { get; set; }

        public MissedTarget() {
            this.category = "MissedTarget";
        }
    }
}
