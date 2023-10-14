namespace WIL_Project.Models
{
    public class SessionInformation
    {
        public int SessionID { get; set; }
        public string SessionTitle { get; set; }
        public int EventID { get; set; } // Foreign key
        public int SpeakerID { get; set; } // Foreign key
        public DateTime SessionStartTime { get; set; }
        public DateTime SessionEndTime { get; set; }
        public string SessionDescription { get; set; }
        public int SessionCapacity { get; set; }

        // Navigation properties for related entities
        public EventInformation EventInformation { get; set; } // Represents the related event
        public SpeakerInformation SpeakerInformation { get; set; } // Represents the related speaker
        public List<Survey> Surveys { get; set; }
    }
}
