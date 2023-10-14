namespace WIL_Project.Models
{
    public class ReviewRating
    {
        public int ReviewID { get; set; }
        public int EventID { get; set; }
        public int SessionID { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }

        // Navigation properties for related event, session, and user
        public EventInformation EventInformation { get; set; }
        public SessionInformation SessionInformation { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
