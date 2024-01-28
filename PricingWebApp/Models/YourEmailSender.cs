
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using PricingWebApp.Models;
using System.Threading.Tasks;

public class YourEmailSenderImplementation : IEmailSender
{
    private readonly SMTP _smtpSettings;
    public YourEmailSenderImplementation(IOptions<SMTP> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        Console.WriteLine($"Sending email to: {email}");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Message: {htmlMessage}");
        
        return Task.CompletedTask;
    }
}
