using System.ComponentModel.DataAnnotations;

public class Survey
{
    public int SurveyID { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Display(Name = "Participation Type")]
    public string ParticipationType { get; set; }

    [Required]
    [Display(Name = "Experience")]
    public string ExperienceText { get; set; }

    [Required]
    [Display(Name = "Event Rating")]
    public string EventRating { get; set; }

    [Required]
    [Display(Name = "Staff Rating")]
    public string StaffRating { get; set; }

    [Required]
    [Display(Name = "Dislikes")]
    public string Dislikes { get; set; }

    [Required]
    [Display(Name = "Recommend Event")]
    public string ReccomendEvent { get; set; }

    [Required]
    [Display(Name = "How Did You Find Out")]
    public string HowFoundOut { get; set; }

    [Required]
    [Display(Name = "Agree to Terms and Conditions")]
    public bool AgreeToTerms { get; set; }
}
