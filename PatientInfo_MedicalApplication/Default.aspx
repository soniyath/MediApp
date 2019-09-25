<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PatientInfo_MedicalApplication.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient Access - Sheridan Medical Application</title>
    <link href="main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Grid Area -->
        <div class="gridArea">
            <header class="head" id="head">
                <br />
                <h1>Sheridan Medical Application</h1>
                <br />
            </header>
            <section class="mainPic">
            </section>
            <section class="main">
                <fieldset>
                    <legend>Patient Access</legend>
                    <p class="group">
                        <asp:Label ID="lblMessage" runat="server">Enter Patient Medical Record Number</asp:Label>
                         &nbsp;
                        <asp:RequiredFieldValidator ID="vldMRN" runat=
                            "server" ControlToValidate="mrnNum" ErrorMessage="Patient MRN is required." EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>MRN: </label>
                        <asp:TextBox ID="mrnNum" runat="server" TextMode="Number" min="921487"></asp:TextBox>
                        &nbsp;</p>
                    <br />
                </fieldset>
                <p class="group">
                    <asp:Button ID="cmdGetPatient" runat="server" Text="Get Patient" OnClick="cmdGetPatient_Click"/>
                    &nbsp;
                        <asp:Button ID="cmdNewPatient" runat="server" Text="New Patient" OnClick="cmdNewPatient_Click"/>
                    &nbsp;
                        <asp:Button ID="cmdAllPatients" runat="server" Text="Patient History" OnClick="cmdAllPatients_Click"/>
                </p>
            </section>
            <footer class="foot" id="foot">
                <p>
                    &copy Sheridan Medical Application. All rights reserved.
                </p>
            </footer>
        </div>
    </form>
</body>
</html>
