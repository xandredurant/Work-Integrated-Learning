using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WIL_Project.Models
{
    [Table("ReviewRating")]
    public class ReviewRating
    {
        [Key]
        public int ReviewID { get; set; }
        [ForeignKey("EventInformation")]
        public int EventID { get; set; }
        [ForeignKey("SessionInformation")]
        public int SessionID { get; set; }
        [ForeignKey("UserInfo")]
        public string Id { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        [Required]
        public string ReviewText { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ReviewDate { get; set; }

        // Navigation properties for related event, session, and user
        public EventInformation EventInformation { get; set; }
        public SessionInformation SessionInformation { get; set; }
        [ForeignKey("Id")]
        public UserInfo UserInfo { get; set; }
    }
}
