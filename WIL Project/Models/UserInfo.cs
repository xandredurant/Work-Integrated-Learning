namespace WIL_Project.Models
{
    public class UserInfo
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        // Navigation properties for related reviews and surveys
        public List<ReviewRating> Reviews { get; set; }
        public List<Survey> Surveys { get; set; }
    }
}
