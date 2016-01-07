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
            supervisorDropDownList.DataSource = bll.GetSupervisorsForDropDown();
            supervisorDropDownList.DataTextField = "NameDeptEmail";
            supervisorDropDownList.DataValueField = "Email";
            supervisorDropDownList.DataBind();
        }

        protected void SubmitApplication(object sender, EventArgs e)
        {            
            CreateEmail newEmail = new CreateEmail();

            string fname = txt_FName.Text;
            string lname = txt_LName.Text;
            string middleInitial = txt_M_Initial.Text;
            DateTime DOB = DateTime.ParseExact(txt_DOB.Text,
                                               "MM/dd/yyyy",
                                                CultureInfo.InvariantCulture);
            string primaryPhone = txt_Phone.Text;
            string altPhone = txt_altPhone.Text;            
            string email = txt_Email.Text;
            string regisID = txt_RegisID.Text;
            string driverLicense = txtDriverLicense.Text;
            string dlState = txtState.Text;
            DateTime dlExpDate = DateTime.ParseExact(txtDLExpirationDate.Text,
                                               "MM/dd/yyyy",
                                                CultureInfo.InvariantCulture);
            string insuranceCompany = txtInsCompany.Text;
            string policyNumber = txtInsPolicyNumber.Text;
            DateTime insPolicyExpDate = DateTime.ParseExact(txtPolicyExpirationDate.Text,
                                               "MM/dd/yyyy",
                                                CultureInfo.InvariantCulture);
            string supervisorEmail = supervisorDropDownList.SelectedValue;
            bool university = ckbxUniversity.Checked;
            bool rental = ckbxRental.Checked;
            bool personal = ckbxPersonal.Checked;
            bool multiple = ckbxMultiple.Checked;

            Models.Driver_Type driver = Models.Driver_Type.Student;
            string selectedDriverType = driverTypeRBtnList.SelectedValue;
            if (selectedDriverType.Equals("2"))
            {
                driver = Models.Driver_Type.Emp_Required;
            }
            else if (selectedDriverType.Equals("3"))
            {
                driver = Models.Driver_Type.Emp_Occasional;
            }
            else if (selectedDriverType.Equals("4"))
            {
                driver = Models.Driver_Type.Volunteer;
            }
            else
            {
                driver = Models.Driver_Type.Student;
            }

            // Used for email
            string subject = "New Driver Application Form";
            string body = "A new driver application form has been submitted for " + fname 
                + " " + lname + ".";


            bll.NewApplication(university, rental, personal, multiple, regisID, fname, lname, middleInitial, DOB, primaryPhone, altPhone, email, 
                driver, Models.Driver_Status.Active, driverLicense, dlState, dlExpDate, insuranceCompany, policyNumber, insPolicyExpDate, supervisorEmail);

            bool success = newEmail.SendEmail(supervisorEmail, subject, body);

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
            txt_M_Initial.Text = "";
            txt_LName.Text = "";
            txt_Phone.Text = "";
            txt_altPhone.Text = "";
            txt_DOB.Text = "";
            txt_Email.Text = "";
            txt_RegisID.Text = "";
            txtDLExpirationDate.Text = "";
            txtDriverLicense.Text = "";
            txtInsCompany.Text = "";
            txtInsPolicyNumber.Text = "";
            txtPolicyExpirationDate.Text = "";
            txtState.Text = "";
            ckbxUniversity.Checked = true;
            ckbxMultiple.Checked = false;
            ckbxPersonal.Checked = false;
            ckbxRental.Checked = false;

            supervisorDropDownList.SelectedValue = "0";
            driverTypeRBtnList.SelectedValue = "1";
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