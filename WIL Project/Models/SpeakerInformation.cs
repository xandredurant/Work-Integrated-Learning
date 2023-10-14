using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WIL_Project.Models
{
    [Table("SpeakerInformation")]
    public class SpeakerInformation
    {
        [Key]
        public int SpeakerID { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerAffiliation { get; set; }
        public string SpeakerBiography { get; set; }
        public string SpeakerTopic { get; set; }

        // Navigation properties for related sessions
        public List<SessionInformation> Sessions { get; set; }
    }
}
