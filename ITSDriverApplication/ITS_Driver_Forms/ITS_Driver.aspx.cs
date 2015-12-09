using ITSDriverApplication.App_Code;
using System;
using System.Net.Mail;
using System.Globalization;
using Microsoft.Office.Interop.Outlook;
using System.Net;
using System.Windows.Forms;

namespace ITSDriverApplication.ITS_Driver_Forms
{
    public partial class ITS_Driver : System.Web.UI.Page
    {
        ITSDriverBLL bll = new ITSDriverBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            SupervisorDropDownList.DataSource = bll.GetSupervisorsForDropDown();
            SupervisorDropDownList.DataTextField = "NameDeptEmail";
            SupervisorDropDownList.DataValueField = "Email";
            SupervisorDropDownList.DataBind();
        }

        protected void SubmitApplication(object sender, EventArgs e)
        {            
            CreateEmail newEmail = new CreateEmail();

            string fname = txt_FName.Text;
            string lname = txt_LName.Text;
            DateTime DOB = DateTime.ParseExact(txt_DOB.Text,
                                               "MM/dd/yyyy",
                                                CultureInfo.InvariantCulture);
            string primaryPhone = txt_Phone.Text;
            string altPhone = txt_altPhone.Text;            
            string email = txt_Email.Text;
            string regisID = txt_RegisID.Text;

            string subject = "New Driver Application Form";
            string body = "A new driver application form has been submitted for " + fname 
                + " " + lname + ".";
            //// Driver Type
            //Ejob
            //EOD
            //    SWSP
            //    Vol

            //    // Vehicle Type
            //Vehicle



            bll.NewApplication(false, false, true, true, regisID, fname, lname, "A", DOB, primaryPhone, altPhone, email, 
                Models.Driver_Type.Emp_Required, Models.Driver_Status.Active, "DL001234", "CO", DOB, "Geico", "InsPolicyNum", DOB, "nolivetto@regis.edu");

            bool success = newEmail.SendEmail("nahodge1@hotmail.com", subject, body);

            if (success)
            {
                DialogResult result = MessageBox.Show("Your form was successfully submitted and an email " + 
                    "was sent to notify your supervisor.",
                    "Success", 
                    MessageBoxButtons.OK);
                
                // Reset fields on the form to the default.
                if (result == DialogResult.OK)
                {
                    ResetForm();
                }
            }            
        }

        private void ResetForm()
        {
            txt_FName.Text = "";
            txt_LName.Text = "";
            txt_Phone.Text = "";
            txt_altPhone.Text = "";
            txt_DOB.Text = "";
            txt_Email.Text = "";
            txt_RegisID.Text = "";


            // Fill in other fields.
        }


        // Class that sends email
        private class CreateEmail
        {
            public bool SendEmail(string recipient, string subject, string body)
            {
                MailMessage email = new MailMessage();

                String senderEmail = System.Configuration.ConfigurationManager.AppSettings["fromEmailAddress"];
                String emailPassword = System.Configuration.ConfigurationManager.AppSettings["emailPassword"];

                email.From = new MailAddress(senderEmail);
                email.To.Add(recipient);

                email.Subject = subject;
                email.Body = body;
                email.IsBodyHtml = true;

                NetworkCredential authinfo = new NetworkCredential(senderEmail, emailPassword);

                SmtpClient client = new SmtpClient();
                client.Host = System.Configuration.ConfigurationManager.AppSettings["host"];
                client.Port = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["port"]);                

                client.UseDefaultCredentials = false;
                client.Credentials = authinfo;
                client.Timeout = 60000;
                client.EnableSsl = true;

                try
                {
                    client.Send(email);
                }
                catch (SmtpException err)
                {
                    throw new ApplicationException(err.Message);
                }

                return true;
            }
        }
    }
}