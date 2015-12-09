<%@ Page Title="ITS Driver Application Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ITS_Driver.aspx.cs" Inherits="ITSDriverApplication.ITS_Driver_Forms.ITS_Driver" EnableEventValidation="false" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 style="color: #002B49">Please complete the Driver Application</h2>

    <script type="text/javascript">
        function Update_displayname() {
            document.getElementById('<%=lbl_displayname.ClientID%>').innerText = document.getElementById('<%=txt_FName.ClientID%>').value
            + ' ' + document.getElementById('<%=txt_LName.ClientID%>').value;
        }
    </script>

    <p>
        <b>First Name:&nbsp;</b>
        <asp:TextBox ID="txt_FName" runat="server" onchange="Update_displayname();" Style="margin-left: 28px"
            Width="299px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <b>Last Name:&nbsp;</b>
        <asp:TextBox ID="txt_LName" runat="server" onchange="Update_displayname();" Width="307px"></asp:TextBox>

    </p>
    <p>

        <b>DOB</b>:&nbsp;&nbsp;
        <asp:TextBox ID="txt_DOB" runat="server" Style="margin-left: 62px"></asp:TextBox>

    </p>
    <p>

        <b>Primary Phone:&nbsp;&nbsp;</b>
        <asp:TextBox ID="txt_Phone" runat="server" Width="255px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <b>Alternate Phone:&nbsp;&nbsp;</b>
        <asp:TextBox ID="txt_altPhone" runat="server" Width="281px"></asp:TextBox>

    </p>
    <p>

        <b>Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>
        <asp:TextBox ID="txt_Email" runat="server" Style="margin-left: 45px"
            Width="731px"></asp:TextBox>

    </p>

    <p>
        &nbsp;
    </p>
    <!-- html indentation for block paragraph for message to user input -->
    <div style="margin-left: 5em; width: 507px;">
        Note: If you have been assigned a Regis I.D. Number. please choose Yes and
        <br />
        enter that number. If you have not been assigend an I.D. number, please
        <br />
        choose No.
    </div>
    </p>

    <form>
        <div style="margin-left: 10em; width: 300px;">
            <input type="radio" name="RID" value="Yes" checked>Yes&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
                ID="txt_RegisID" runat="server" Style="margin-left: 42px" Width="108px"></asp:TextBox><br>
            <input type="radio" name="RID" value="No">
        No
    </form>
    </div>
    </p>
    <p>
    </p>

    <h7 style="color: #002B49">
        
        Driver Type and Vehicle 
     </h7>
    <p></p>
    <form>
        <input type="radio" name="SWSP" value="3" checked>
        <b>Student/Work-study Program</b> (Driving is a requirement for a student that will drive<br />
        <div style="margin-left: 2em">for Regis Univeristy business)    <b>-   1 Year Duration</b></div>
        <br>
        <input type="radio" name="Ejob" value="1">
        <b>Employee - Job Required Driver</b> (Driving is a requirement for the employee's position<br />
        <div style="margin-left: 2em">and applicant will frequently drive for Regis Univeristy)     <b>-   3 Year Duration</b></div>
        <br>
        <input type="radio" name="EOD" value="2">
        <b>Employee - Occasional Driver</b> (Driving is NOT a requirement for the employee's position but
        <br />
        <div style="margin-left: 2em">applicant may occasionally drive for Regis Univeristy)    <b>-   3 Year Duration</b></div>
        <br>
        <input type="radio" name="Vol" value="4">
        <b>Volunteer</b> (Applicant will drive for retreats/special events. Applicant may or may not be a
        <br />
        <div style="margin-left: 2em">Regis University employee)     <b>-   1 Year Duration</b></div>
        <br>
    </form>
    </p>
    <p>
        <b>Vehicles that will be driven: </b>(Please check at least one or all that apply)
    <form action="demo_form.asp" method="get">
        <input type="checkbox" name="Vehicle" value="University" checked="checked">
        Licensed University Vehicles<br>
        <input type="checkbox" name="vehicle" value="Rental">
        Rental<br>
        <input type="checkbox" name="vehicle" value="Personal">
        Personal Vehicle on University Business<br>
        <input type="checkbox" name="vehicle" value="Multiple">
        Multiple Person Vehicle (ex: Bus or shuttle)<br>
    </form>

    </p>
    <h7 style="color: #002B49">Driver Information</h7>
    <p></p>
    <form>
        <b>Driver License: </b>&nbsp;&nbsp; 
            <input type="text" name="Driver_License"
                size="25" style="margin-left: 14px; width: 179px;">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    
            <b>License State: </b>&nbsp;&nbsp;
        <input type="text" name="State" size="10">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <b>Expiration Date: </b>&nbsp;&nbsp; 
            <input type="text" name="DL_Expiration"
                size="35" style="margin-left: 5px; width: 125px;">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <p></p>
        <b>Personal Vehicle Insurance Company: </b>&nbsp;&nbsp;
        <input type="text"
            name="ins_company" size="50" style="width: 562px">
        <p></p>
        <b>Insurance Policy #: </b>&nbsp;&nbsp; 
            <input type="text"
                name="ins_policy" size="50" style="width: 562px; margin-left: 112px;">
        <p></p>
        <b>Policy Expiration Date: </b>&nbsp;&nbsp; 
            <input type="text"
                name="ins_expiration" size="50" style="width: 168px; margin-left: 87px;">
    </form>
    <p></p>
    <br />
    <h7 style="color: #002B49">Supervisor Information</h7>
    <p></p>
    <b>Supervisor Name/Email/Dept.: </b>&nbsp;&nbsp; 
            <asp:DropDownList ID="SupervisorDropDownList" runat="server" AppendDataBoundItems="true">
                <asp:ListItem Text="<Select Supervisor>" Value="0" />
            </asp:DropDownList>
    </form> 
     <p>&nbsp;</p>
    <h7 style="color: #002B49">
        
        Information And Agreement</h7>
    <p></p>
    <p>
        <div style="margin-left: 3em">
            The University’s property/casualty insurance carrier requires that members of the University community who drive licensed University owned
            <br />
            vehicles or who, as part of their routine weekly University responsibilities, drive rental or personal vehicles on University business have
            <br />
            acceptable driving records and be properly insured or insurable. The University’s insurance carrier covers all approved individuals who drive
            <br />
            University vehicles as well as vehicles rented or rented for University business. The employee’s personally owned vehicle’s liability insurance
            <br />
            provides primary coverage. The University’s insurance provides excess liability coverage. The University’s insurance program does not provide
            <br />
            coverage for physical damage for personally owned vehicles
            <br />
            <p></p>
            Any employee, student, or volunteer who will drive any licensed Regis University vehicle or who will routinely drive a rental or personal vehicle
            <br />
            on behalf of Regis University must, as a condition of initial or continuing employment read the following information, sign the form. In addition,
            <br />
            individuals who routinely drive personal vehicles on behalf of the University must provide personal insurance information.  Community members
            <br />
            to whom these requirements apply normally may not drive on University business until approval from Auxiliary & Business Services has been
            <br />
            received. In addition, a driver applicant who has been disapproved may submit an appeal to the Associate Vice President, Auxiliary & Business
            <br />
            Services for consideration by the insurance carrier.
            <br />
        </div>
        <p></p>

        <p class="one">
            I am aware that consumer and motor vehicle reports may be obtained as part of Regis University’s evaluation of my job application
            <br />
            or continuing employment status, volunteer or otherwise.  The reports may be procured by Regis University or its insurance company
            <br />
            representative(s), and may include personal information obtained from state motor vehicle department/groups, my driving record, an
            <br />
            assessment of my insurability for the insurance program, or other consumer reports.<br>
            <br />
            By signing the application, I hereby provide authorization for Regis University or its insurance representative(s) to procure such information
            <br />
            and reports, as well as additional reports about me from time-to-time as deemed appropriate, to evaluate my insurability.<br>

            <br />
            By signing this application I am confirming that I have read and accept the terms and conditions of the <a href="http://tinyurl.com/nop69s6">Vehicle Guidelines and Procedures</a>
            <br />
            that are posted on <a href="https://in2.regis.edu/sites/portal/default.aspx">INsite.<br />
                </div></a>
        </p>

        <p>
            <div style="margin-left: 10em; width: 250px;"><b>You have entered your name above as:</b></div>
            <div style="margin-left: 30em; width: 300px;">
                <asp:Label ID="lbl_displayname" runat="server" Text="Display Name"></asp:Label>
            </div>
        </p>

        <form action="demo_form.asp" method="get">
            <b>&nbsp;&nbsp;&nbsp; Please re-type your name here to indicate agreement: </b>&nbsp;&nbsp; 
                <input type="text" name="txt_signature" size="50"
                    style="width: 568px; margin-left: 5px;" /><br />
            <br />
            <b>&nbsp;&nbsp;&nbsp; Checking this box confirms your signature: </b>
            &nbsp;<input type="checkbox" name="Verify" value="University" checked="checked"
                style="width: 24px; margin-left: 37px">
        </form>
        <br />
        <br />
        <div style="text-align: center">
            <%--<input type="submit" value="Submit" onclick="SubmitApplication">--%>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="SubmitApplication" />
        </div>
        <br />
</asp:Content>
