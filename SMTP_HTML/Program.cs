using System.Net;
using System.Net.Mail;

namespace SMTP_HTML
{
    internal class Program
    {
        static string fromMail = "";  //gonderen mail
        static string appPassword = ""; //onun app passwordu (adi sifre deyil)


        static void Main(string[] args)
        {

            var mail = new MailMessage(); //mail formatini yaratmaq ucun
            mail.From = new MailAddress(fromMail, "STEP IT Academy"); //hardan gonderilecek

            mail.To.Add(new MailAddress("")); //kime gonderilecek 
            mail.To.Add(new MailAddress("")); //kime gonderilecek 
            mail.Subject = "HTML Mail";
            mail.IsBodyHtml = true; //body-de html fayllari aktiv edirik

            mail.Body = @"
<div style='font-family:Arial; max-width:500px; border:1px solid #ddd; border-radius:10px; overflow:hidden'
>
<div style='background:#4f46e5; color:white; padding:20px; text-align:center'>
<h1 style='margin:0'>STEP IT Academy</h1>
</div>
<div style='padding:20px'>
<h2>Salam!</h2>
<p>Bu email <b>C#</b> və <b>SMTP</b> ilə göndərildi.</p>
<a href='https://stepit.az'
style='background:#4f46e5; color:white; padding:10px 18px; border-radius:6px; text-decoration:none'>
Sayta keç
</a>
</div>
</div>";

            var smtp = new SmtpClient("smtp.gmail.com"); //gmail.com ucundur
            smtp.Port = 587;
            smtp.EnableSsl = true; //sifreleme ucundur 
            smtp.Credentials = new NetworkCredential(fromMail, appPassword);

            try
            {
                smtp.Send(mail);
                Console.WriteLine("Mail ugurla gonderildi...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xeta: " + ex.Message);
            }

        }

    }
}

