namespace WIL_Project.Models
{
    public class Survey
    {
        public int SurveyID { get; set; }
        public string SurveyType { get; set; }
        public int EventID { get; set; }
        public int SessionID { get; set; }
        public int UserID { get; set; }
        public string SurveyResponses { get; set; }

        // Navigation properties for related event, session, and user
        public EventInformation EventInformation { get; set; }
        public SessionInformation SessionInformation { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
