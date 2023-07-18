using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.DirectoryServices;

namespace chatbotUser
{
    public partial class email : System.Web.UI.Page
    {
        /*Before declare, please add the key for setting the email values at Web.Config*/
        /*Total 3 EmailTo need to be decalred here (EmailToHR, EmailToIT, EmailToFN)*/
        //Declare the variables
        public static string SMTPHost = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
        public static int SMTPPort = int.Parse(System.Configuration.ConfigurationManager.AppSettings["SMTPPort"]);
        public static string EmailFrom = System.Configuration.ConfigurationManager.AppSettings["EmailFrom"];
        public static string EmailTo = System.Configuration.ConfigurationManager.AppSettings["EmailTo"];


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        //Back to chatbot button event
        protected void close_Click(object sender, EventArgs e)
        {
            //Redirect to chatbot page
            Session.Clear();
            Response.Redirect("chatbot.aspx");
        }


        //Pop-up message ok button event
        protected void ok_Click(object sender, EventArgs e)
        {
            //Redirect to original page            
            Response.Redirect("email.aspx");
        }


        /*Change the EmailTo to the correct one (at Line 74, 125, 175)*/
        //Send button event
        protected void send_Click(object sender, EventArgs e)
        {
            //Did not select any department
            if (dep.SelectedValue == "0")
            {
                require.Text = "* Please select the department *";
                require.ForeColor = Color.Red;
            }
            else if (dep.SelectedValue == "1") //Selected HR department(HR = 1)
            {
                //Either Subject textbox or Message textbox is blank
                if (subject.Text == "" || message.Text == "")
                {
                    sending.Visible = true;
                    empty.Text = "Please fill in the subject and message.";
                    empty.Visible = true;
                }
                else
                {
                    //Retrieve the text and send email
                    try
                    {
                        SmtpClient smtpClient = new SmtpClient();

                        smtpClient.Host = SMTPHost;
                        smtpClient.Port = SMTPPort;

                        MailAddress to = new MailAddress(EmailTo); //Changes here
                        MailAddress frm = new MailAddress(EmailFrom);

                        MailMessage msg = new MailMessage(frm, to);

                        msg.Subject = subject.Text;
                        if (youremail.Text == "")
                        {
                            msg.Body = "Sender's Email: - \n\n" + message.Text;
                        }
                        else
                        {
                            msg.Body = "Sender's Email: " + youremail.Text + "\n\n" + message.Text;
                        }
                        msg.IsBodyHtml = false;

                        smtpClient.Send(msg);
                        sending.Visible = true;
                        success.Visible = true;
                        success.Text = "Email successfully sent.";
                        
                    }
                    catch (Exception ex)
                    {
                        sending.Visible = true;
                        fail.Text = ex.Message.ToString();
                        fail.Visible = true;
                        success.Visible = false;
                    }
                }
            }
            else if (dep.SelectedValue == "2") //Selected IT department(IT = 2)
            {
                //Either Subject textbox or Message textbox is blank
                if (subject.Text == "" || message.Text == "")
                {
                    //Show message
                    sending.Visible = true;
                    empty.Text = "Please fill in the subject and message.";
                    empty.Visible = true;
                }
                else
                {
                    //Retrieve the text and send email
                    try
                    {
                        SmtpClient smtpClient = new SmtpClient();

                        smtpClient.Host = SMTPHost;
                        smtpClient.Port = SMTPPort;

                        MailAddress to = new MailAddress(EmailTo); //Changes here
                        MailAddress frm = new MailAddress(EmailFrom);

                        MailMessage msg = new MailMessage(frm, to);

                        msg.Subject = subject.Text;
                        if (youremail.Text == "")
                        {
                            msg.Body = "Sender's Email: - \n\n" + message.Text;
                        }
                        else
                        {
                            msg.Body = "Sender's Email: " + youremail.Text + "\n\n" + message.Text;
                        }
                        msg.IsBodyHtml = false;

                        smtpClient.Send(msg);
                        sending.Visible = true;
                        success.Visible = true;
                        success.Text = "Email successfully sent.";
                    }
                    catch (Exception ex)
                    {
                        sending.Visible = true;
                        fail.Text = ex.Message.ToString();
                        fail.Visible = true;
                        success.Visible = false;
                    }
                }
            }
            else if (dep.SelectedValue == "3") //Selected Finance department(Finance = 3)
            {
                //Either Subject textbox or Message textbox is blank
                if (subject.Text == "" || message.Text == "")
                {
                    //Show message
                    sending.Visible = true;
                    empty.Text = "Please fill in the subject and message.";
                    empty.Visible = true;
                }
                else
                {
                    //Retrieve the text and send email
                    try
                    {
                        SmtpClient smtpClient = new SmtpClient();

                        smtpClient.Host = SMTPHost;
                        smtpClient.Port = SMTPPort;

                        MailAddress to = new MailAddress(EmailTo); //Changes here
                        MailAddress frm = new MailAddress(EmailFrom);

                        MailMessage msg = new MailMessage(frm, to);

                        msg.Subject = subject.Text;
                        if (youremail.Text == "")
                        {
                            msg.Body = "Sender's Email: - \n\n" + message.Text;
                        }
                        else
                        {
                            msg.Body = "Sender's Email: " + youremail.Text + "\n\n" + message.Text;
                        }
                        msg.IsBodyHtml = false;

                        smtpClient.Send(msg);
                        sending.Visible = true;
                        success.Visible = true;
                        success.Text = "Email successfully sent.";
                    }
                    catch (Exception ex)
                    {
                        sending.Visible = true;
                        fail.Text = ex.Message.ToString();
                        fail.Visible = true;
                        success.Visible = false;
                    }
                }
            }
        }
    }
}