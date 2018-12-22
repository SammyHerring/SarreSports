//Project Name: SarreSports | File Name: MailClient.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 18/12/2018 | 18:36
//Last Updated On:  20/12/2018 | 14:44
using System;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;

namespace SarreSports
{
    public class MailClient
    {
        public static bool SendCustomerDetailsToCustomer(Customer c, Branch b)
        {
            Cursor.Current = Cursors.WaitCursor;

            //QR Code Generation and Content Stream Setup
            PictureBox customerQRCode = new PictureBox();
            customerQRCode.Height = 200;
            customerQRCode.Width = 200;

            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            customerQRCode.Image = qrcode.Draw(c.ID().ToString(), customerQRCode.Height);
            customerQRCode.AutoSize = true;
            customerQRCode.SizeMode = PictureBoxSizeMode.Zoom;

            var bitmap = new Bitmap(customerQRCode.Height, customerQRCode.Width);
            customerQRCode.DrawToBitmap(bitmap, customerQRCode.ClientRectangle);
            ImageConverter ic = new ImageConverter();
            Byte [] byteStream = (Byte[]) ic.ConvertTo(bitmap,typeof(Byte[]));
            MemoryStream customerQR = new MemoryStream(byteStream);

            //SMTP Client Definition
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("sarresports.smtp@gmail.com","P5:qM:7(w[/fZdfr");

            //Message Content Definition
            MailMessage mm = new MailMessage(
                "sarresports.smtp@gmail.com", 
                c.Email);
            mm.Subject = "Sarre Sports | Registration";
            mm.Body = String.Format(
                "<h1>{0}</h1></br>" +
                "<h3>Welcome, {1}. Thank you for registering, when you come into store please show your QR Code!</h3></br>" +
                "<p><b>Full Name:</b> {2}</p>" +
                "<p><b>Mobile No:</b> {3}</p>" +
                "<p><b>Customer ID:</b> {4}</p>" +
                "<p>If you are reading this text your email client does not support Image HTML Views.<br>Please try another email client to see your QR Code.</p>", 
                b.BranchName(), c.FirstName, c.FullName(), c.MobileNo, c.ID());

            LinkedResource LinkedImage = new LinkedResource(customerQR);
            LinkedImage.ContentId = "QR";
            LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                String.Format(
                    "<h1>{0}</h1></br>" +
                    "<h3>Welcome, {1}. Thank you for registering, when you come into store please show your QR Code!</h3></br>" +
                    "<p><b>Full Name:</b> {2}</p>" +
                    "<p><b>Mobile No:</b> {3}</p>" +
                    "<p><b>Customer ID:</b> {4}</p>" + 
                    "Your QR Code:</br><img src=cid:QR>",
                    b.BranchName(), c.FirstName, c.FullName(), c.MobileNo, c.ID()), 
                    null, "text/html");

            htmlView.LinkedResources.Add(LinkedImage);
            mm.AlternateViews.Add(htmlView);

            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            try
            {
                client.Send(mm);
                return true;
            }
            catch (SmtpException e)
            {
                Console.WriteLine("SMTP Error: {0}", e.StatusCode);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                mm.Dispose();
            }
        }
    }
}