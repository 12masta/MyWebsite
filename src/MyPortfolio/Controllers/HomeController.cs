using System;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;
using System.Net;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using MyPortfolio.Models;
using Microsoft.Extensions.Options;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly EmailProvider _emailProvider;

        public HomeController(IStringLocalizer<HomeController> localizer, IOptions<EmailProvider> optionsAccessor)
        {
            _localizer = localizer;

            _emailProvider = optionsAccessor.Value;
        }

        public IActionResult Index()
        {
            InitViewDataLocalizationResources();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        //POST
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async void SendEmailAsync(string name, string email, string subject, string message)
        {
            if (name == null || email == null || subject == null || message == null) return;
            if (!ModelState.IsValid) return;
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(name, email));
            emailMessage.To.Add(new MailboxAddress("Marcin Stanek", "stanek.marcinp@gmail.com"));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = "Message sent from: " + name + ", email address: " + email + ". Message: " +   message };

            using (var client = new SmtpClient())
            {
                var credentials = new NetworkCredential
                {
                    UserName = _emailProvider.login,
                    Password = _emailProvider.password
                };
                client.LocalDomain = "gmail.com";
                await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(credentials);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public void InitViewDataLocalizationResources()
        {
            ViewData["Title"] = _localizer["title"];
            ViewData["sliderHi"] = _localizer["sliderHi"];
            ViewData["about"] = _localizer["about"];
            ViewData["contact"] = _localizer["contact"];
            ViewData["home"] = _localizer["home"];
            ViewData["developer"] = _localizer["developer"];
            ViewData["father"] = _localizer["father"];
            ViewData["engineer"] = _localizer["engineer"];
            ViewData["sofwareQa"] = _localizer["sofwareQa"];
            ViewData["sliderTags"] = _localizer["sliderTags"];
            ViewData["sliderDescription"] = _localizer["sliderDescription"];
            ViewData["viewWorkButton"] = _localizer["viewWorkButton"];
            ViewData["viewWorkButton"] = _localizer["viewWorkButton"];
            ViewData["aboutMe"] = _localizer["aboutMe"];
            ViewData["aboutMeDesc1"] = _localizer["aboutMeDesc1"];
            ViewData["aboutMeDesc2"] = _localizer["aboutMeDesc2"];
            ViewData["latestWoks"] = _localizer["latestWoks"];
            ViewData["gitHub"] = _localizer["gitHub"];
            ViewData["gitHubDesc"] = _localizer["gitHubDesc"];
            ViewData["thesisEngineering"] = _localizer["thesisEngineering"];
            ViewData["thesisEngineeringDesc"] = _localizer["thesisEngineeringDesc"];
            ViewData["qATools"] = _localizer["qATools"];
            ViewData["qAToolsDesc"] = _localizer["qAToolsDesc"];
            ViewData["offerFromMe"] = _localizer["offerFromMe"];
            ViewData["webDeveloping"] = _localizer["webDeveloping"];
            ViewData["webDevelopingDesc"] = _localizer["webDevelopingDesc"];
            ViewData["qa"] = _localizer["qa"];
            ViewData["qaDesc"] = _localizer["qaDesc"];
            ViewData["testDrivenDevelopment"] = _localizer["testDrivenDevelopment"];
            ViewData["testDrivenDevelopmentDesc"] = _localizer["testDrivenDevelopmentDesc"];
            ViewData["mobility"] = _localizer["mobility"];
            ViewData["mobilityDesc"] = _localizer["mobilityDesc"];
            ViewData["deliverOnTime"] = _localizer["deliverOnTime"];
            ViewData["deliverOnTimeDesc"] = _localizer["deliverOnTimeDesc"];
            ViewData["keepYouUpdated"] = _localizer["keepYouUpdated"];
            ViewData["keepYouUpdatedDesc"] = _localizer["keepYouUpdatedDesc"];
            ViewData["soWhatYouThink"] = _localizer["soWhatYouThink"];
            ViewData["contactWithMe"] = _localizer["contactWithMe"];
            ViewData["contactWithMe2"] = _localizer["contactWithMe2"];
            ViewData["contactWithMe2Desc"] = _localizer["contactWithMe2Desc"];
            ViewData["findMe"] = _localizer["findMe"];
            ViewData["findMeDesc"] = _localizer["findMeDesc"];
            ViewData["sendMessageButton"] = _localizer["sendMessageButton"];
            ViewData["place1"] = _localizer["place1"];
            ViewData["place2"] = _localizer["place2"];
            ViewData["mail"] = _localizer["mail"];
            ViewData["phone"] = _localizer["phone"];
            ViewData["footerLanguage"] = _localizer["footerLanguage"];
            ViewData["footerButton"] = _localizer["footerButton"];
            ViewData["yourName"] = _localizer["yourName"];
            ViewData["yourEmail"] = _localizer["yourEmail"];
            ViewData["subject"] = _localizer["subject"];
            ViewData["message"] = _localizer["message"];
        }
    }
}
