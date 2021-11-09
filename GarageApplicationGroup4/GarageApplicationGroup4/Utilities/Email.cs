using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace GarageApplicationGroup4
{
    public class Email
    {
        public void Emailer()
        {
            //Create mimemsg abiject
            MimeMessage message = new MimeMessage();
            //add the sender info that will appear in the email message
            message.From.Add(new MailboxAddress("Grupp 4", "garagegrupp4@gmail.com"));

            //add the reciver email adress TEST
            message.To.Add(MailboxAddress.Parse("garagegrupp4@gmail.com"));

            //add the reciver email adress MICKES
            //message.To.Add(MailboxAddress.Parse("msdata1010@gmail.com"));

            //add message subject
            message.Subject = "Din digitala faktura från din parkering hos GarageGrupp4.";

            //add the message as plain text
            message.Body = new TextPart("plain")
            {
                Text = @"Tack för din senaste vistelse! Här kommer din faktura. Vänligen betala in 5000:- inom 14 dagar, dröjsmålsränta om 12321380812% tillkommer."
            };

            //Email sender credidentials
            string emailAdress = "garagegrupp4@gmail.com";

            string password = "abcd.123";

            //create smtp clint
            SmtpClient client = new SmtpClient();

            try
            {
                //Connect to the gmail smtp server, port 465 ssl enabled.
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(emailAdress, password);
                client.Send(message);

                //display a message if no exception thrown.
                Console.WriteLine("Email sent!");
            }
            catch (Exception ex)
            {
                //in case of error display the msg
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //at any case always disconnect from the client
                client.Disconnect(true);
                //and dispose of the client object
                client.Dispose();
            }
        }
    }
}
