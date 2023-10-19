using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string SpeakerImage { get; set; }

        // Add any navigation properties here if needed.

    }
}
