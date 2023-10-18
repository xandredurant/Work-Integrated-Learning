using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WIL_Project.Models
{
    [Table("Survey")]
    public class Survey
    {
        public int SurveyID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Participation Type is required")]
        public string ParticipationType { get; set; }

        [Required(ErrorMessage = "Experience is required")]
        public string ExperienceText { get; set; }

        [Required(ErrorMessage = "Event Rating is required")]
        public string EventRating { get; set; }

        [Required(ErrorMessage = "Staff Rating is required")]
        public string StaffRating { get; set; }

        [Required(ErrorMessage = "Dislikes is required")]
        public string Dislikes { get; set; }

        [Required(ErrorMessage = "Recommend Event is required")]
        public string ReccomendEvent { get; set; }

        [Required(ErrorMessage = "How Found Out is required")]
        public string HowFoundOut { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the terms and conditions")]
        public bool AgreeToTerms { get; set; }
    }
}
