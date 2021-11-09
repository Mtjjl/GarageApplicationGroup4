using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace GarageApplicationGroup4
{
    public class Email
    {
        public void Emailer()
        {
            //Skapar ett Mimemessage objekt
            MimeMessage message = new MimeMessage();
            //add the sender info that will appear in the email message
            message.From.Add(new MailboxAddress("Grupp 4", "garagegrupp4@gmail.com"));

            //Mottagarmejl - Test
            //message.To.Add(MailboxAddress.Parse("garagegrupp4@gmail.com"));

            //Mottagarmail - MICKE
            message.To.Add(MailboxAddress.Parse("msdata1010@gmail.com"));

            //Meddelande ämne
            message.Subject = "Din digitala faktura från din parkering hos GarageGrupp4.";

            //Meddelande
            message.Body = new TextPart("plain")
            {
                Text = @"Tack för din senaste vistelse! Här kommer din faktura. Vänligen betala in 5000:- inom 14 dagar, dröjsmålsränta om 12321380812% tillkommer."
            };

            //Avsändarinlogg 
            string emailAdress = "garagegrupp4@gmail.com";

            string password = "abcd.123";

            //Skapar en smtp cleint
            SmtpClient client = new SmtpClient();

            try
            {
                //Uppkoppling till gmail smtp server, port 465 ssl enabled.
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(emailAdress, password);
                client.Send(message);

                //Visa detta meddelande om det inte finns en exception.
                Console.WriteLine("Email sent!");
            }
            catch (Exception ex)
            {
                //Om det blir ett fel, visa  vad.
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Alltid - avbryt kopplingen till klienten.
                client.Disconnect(true);

                //Radera klient objektet.
                client.Dispose();
            }
        }
    }
}
