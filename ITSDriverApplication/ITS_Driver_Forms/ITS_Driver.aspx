<%@ Page Title="ITS Driver Application Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ITS_Driver.aspx.cs" Inherits="ITSDriverApplication.ITS_Driver_Forms.ITS_Driver" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 style="color: #002B49">Please complete the Driver Application</h2>
    <p>

        <b>First Name:&nbsp;</b>
        <asp:TextBox ID="txt_FName" runat="server" Style="margin-left: 28px"
            Width="299px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <b>Last Name:&nbsp;</b>
        <asp:TextBox ID="txt_LName" runat="server" Width="307px"></asp:TextBox>

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
        <input type="radio" name="Ejob" value="1" checked>
        <b>Employee - Job Required Driver</b> (Driving is a requirement for the employee's position<br />
        <div style="margin-left: 2em">and applicant will frequely drive for Regis Univeristy)     <b>-   3 Year Duration</b></div>
        <br>
        <input type="radio" name="EOD" value="2">
        <b>Employee - Occasional Driver</b> (Driving is NOT a requirement for the employee's position but
        <br />
        <div style="margin-left: 2em">applicant may occasionally drive for Regis Univeristy)    <b>-   3 Year Duration</b></div>
        <br>
        <input type="radio" name="SWSP" value="3">
        <b>Student/Work-study Program</b> (Driving is a requirement for a student that will drive<br />
        <div style="margin-left: 2em">for Regis Univeristy business)    <b>-   1 Year Duration</b></div>
        <br>
        <input type="radio" name="Vol" value="4">
        <b>Volunteer</b> (Applicant will drive for retreats/special events. Applicant may or may not be a
        <br />
        <div style="margin-left: 2em">Regis University employee)     <b>-   1 Year Duration</b></div>
        <br>
    </form>
    </p>
    <p>
        <b>Vehicles that will be driven: </b>(Please check at least on or all that apply)
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
    <h7 style="color: #002B49">
        
        Driver Information
     </h7>
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
    <div style="text-align: center">
        <input type="submit" value="Submit">
    </div>



</asp:Content>
