﻿using System.ComponentModel.DataAnnotations.Schema;
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
        public int UserID { get; set; }
        public decimal Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }

        // Navigation properties for related event, session, and user
        public EventInformation EventInformation { get; set; }
        public SessionInformation SessionInformation { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
