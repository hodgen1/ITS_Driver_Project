using ITSDriverApplication.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITSDriverApplication.ITS_Driver_Forms
{
    public partial class ITS_Driver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitApplication(object sender, EventArgs e)
        {
            ITSDriverBLL bll = new ITSDriverBLL();

            string fname = txt_FName.Text;
            string lname = txt_LName.Text;
            DateTime DOB = DateTime.ParseExact(txt_DOB.Text,
                                               "MM/dd/yyyy",
                                                CultureInfo.InvariantCulture);
            string primaryPhone = txt_Phone.Text;
            string altPhone = txt_altPhone.Text;            
            string email = txt_Email.Text;
            string regisID = txt_RegisID.Text;

            //// Driver Type
            //Ejob
            //EOD
            //    SWSP
            //    Vol

            //    // Vehicle Type
            //Vehicle



            bll.NewApplication(false, false, true, true, regisID, fname, lname, "A", DOB, primaryPhone, altPhone, email, 
                Models.Driver_Type.Emp_Required, Models.Driver_Status.Active, "DL001234", "CO", DOB, "Geico", DOB, "nolivetto@regis.edu");

            Response.Redirect("~/Default.aspx");
        }
    }
}