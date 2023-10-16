using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;

    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult Contact()
    {
        return View(); // This method is for displaying the Contact view.
    }

    [HttpPost]
    public IActionResult SubmitMessage(string FirstName, string LastName, string Email, string Issue, string Experience)
    {
        var emailSettings = _configuration.GetSection("EmailSettings");

        var message = new MailMessage
        {
            From = new MailAddress(emailSettings["UserName"]),
            Subject = "Contact Form Submission",
            Body = $"Name: {FirstName} {LastName}\nEmail: {Email}\nIssue: {Issue}\nExperience: {Experience}",
            IsBodyHtml = false,
        };

        message.To.Add("Janderik03@gmail.com"); // Replace with your recipient email address

        var smtpClient = new SmtpClient
        {
            Host = emailSettings["SmtpServer"],
            Port = int.Parse(emailSettings["Port"]),
            Credentials = new NetworkCredential(emailSettings["UserName"], emailSettings["Password"]),
            EnableSsl = true,
        };

        smtpClient.Send(message);

        // You can add additional logic here, like displaying a success message
        return View("Success"); // Create a Success view in your Views folder
    }
}
