using System.ComponentModel.DataAnnotations;

namespace RPGRepoEFDB
{
    public class RPG
    {
        [Key]
        public long RPGId { get; set; }
        public RPGSystemen RPGSysteem { get; set; } = RPGSystemen.Fate;
        public bool CampaignRunning { get; set; } = true;
        public string CampaignName { get; set; } = "undefined";

    }
}