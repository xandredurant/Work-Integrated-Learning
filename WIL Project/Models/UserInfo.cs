using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;
namespace WIL_Project.Models
{
    [Table("UserInfo")]
    public class UserInfo : IdentityUser
    {
        [Key]
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        // Navigation properties for related reviews and surveys
        public List<ReviewRating> Reviews { get; set; }
        public List<Survey> Surveys { get; set; }
    }
}
