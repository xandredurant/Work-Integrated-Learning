using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WIL_Project.Models
{
    [Table("Survey")]
    public class Survey
    {
        [Key]
        public int SurveyID { get; set; }
        public string SurveyType { get; set; }
        [ForeignKey("EventInformation")]
        public int EventID { get; set; }
        [ForeignKey("SessionInformation")]
        public int SessionID { get; set; }
        [ForeignKey("UserInfo")]
        public int UserID { get; set; }
        public string SurveyResponses { get; set; }

        // Navigation properties for related event, session, and user
        public EventInformation EventInformation { get; set; }
        public SessionInformation SessionInformation { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
