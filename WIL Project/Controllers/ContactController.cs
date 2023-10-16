using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

public class ContactController : Controller
{
    private readonly IConfiguration _configuration;

    public ContactController(IConfiguration configuration)
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

        try
        {
            using (var smtpClient = new SmtpClient
            {
                Host = emailSettings["SmtpServer"],
                Port = int.Parse(emailSettings["Port"]),
                Credentials = new NetworkCredential(emailSettings["UserName"], emailSettings["Password"]),
                EnableSsl = true,
            })
            {
                var message = new MailMessage
                {
                    From = new MailAddress(emailSettings["UserName"]),
                    Subject = "Contact Form Submission",
                    Body = $"Name: {FirstName} {LastName}\nEmail: {Email}\nIssue: {Issue}\nExperience: {Experience}",
                    IsBodyHtml = false,
                };

                message.To.Add("Janderik03@gmail.com"); // Replace with your recipient email address

                smtpClient.Send(message);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions, log them, and display an error message to the user if needed.
            // Example: TempData["ErrorMessage"] = "An error occurred while sending the email.";
            // Log the exception (ex) for debugging.

            return RedirectToAction("Contact"); // Redirect back to the contact page or an error page.
        }

        // Email sent successfully, so display the success view.
        return View("Success");
    }
}
