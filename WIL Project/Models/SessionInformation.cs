using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WIL_Project.Models
{
    [Table("SessionInformation")]
    public class SessionInformation
    {
        [Key]
        public int SessionID { get; set; }
        public string SessionTitle { get; set; }
        [ForeignKey("EventInformation")]
        public int EventID { get; set; } // Foreign key
        [ForeignKey("SpeakerInformation")]
        public int SpeakerID { get; set; } // Foreign key
        public DateTime SessionStartTime { get; set; }
        public DateTime SessionEndTime { get; set; }
        public string SessionDescription { get; set; }
        public int SessionCapacity { get; set; }

        // Navigation properties for related entities
        public EventInformation EventInformation { get; set; } // Represents the related event
        public SpeakerInformation SpeakerInformation { get; set; } // Represents the related speaker
        public List<Survey> Surveys { get; set; }
        public ICollection<ReviewRating> ReviewRatings { get; set; }
    }
}
