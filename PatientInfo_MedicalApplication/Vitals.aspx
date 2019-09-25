<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vitals.aspx.cs" Inherits="PatientInfo_MedicalApplication.Vitals" %>

<!DOCTYPE html>
<script runat="server">

    protected void numSystolic_TextChanged(object sender, EventArgs e)
    {

    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient Vitals - Sheridan Medical Application</title>
    <link href="main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Grid Area -->
        <div class="gridArea">
            <header class="head" id="head">
                <br />
                <asp:Button ID="logout" runat="server" Text="Logout" OnClick="logout_Click" />
                <h1>Sheridan Medical Application</h1>
                <br />
            </header>
            <section class="mainPic">
            </section>
            <section class="main">
                    <h1>Vitals</h1>
                    <h3 style="float: right;">
                        <strong>MRN:</strong>&nbsp;&nbsp;<asp:Label ID="lblMRN" runat="server"></asp:Label>
                    </h3><br /><br /><br /><br />
                <fieldset>
                     <legend>Vitals Information</legend>
                    <p class="group">
                        <label>Systolic (mmHg): </label>
                        <br />
                        <asp:TextBox ID="Systolic" runat="server" TextMode="Number" min="60" Max="200"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="vldSystolic" runat="server" ErrorMessage="* Required" ControlToValidate="Systolic" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Diastolic (mmHg): </label>
                        <br />
                        <asp:TextBox ID="Diastolic" runat="server" TextMode="Number" min="30"  Max="100"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldDiastolic" runat="server" ErrorMessage="* Required" ControlToValidate="Diastolic" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>O2_Levels (mmHg): </label>
                        <br />
                        <asp:TextBox ID="o2_Levels" runat="server" TextMode="Number" min="0"  Max="100"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldO2_Levels" runat="server" ErrorMessage="* Required" ControlToValidate="o2_Levels" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Pulse (BPM): </label>
                        <br />
                        <asp:TextBox ID="Pulse" runat="server" TextMode="Number" min="40"  Max="210"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldPulse" runat="server" ErrorMessage="*Required" ControlToValidate="Pulse" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Respiratory_Rate (BPM): </label>
                        <br />
                        <asp:TextBox ID="Respiratory_Rate" runat="server" TextMode="Number" min="12" Max="60"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldRespiratory_Rate" runat="server" ErrorMessage="*Required" ControlToValidate="Respiratory_Rate" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <asp:Button ID="cmdSubmit" runat="server" Text="Submit" OnClick="cmdSubmit_Click" />
                        &nbsp;<asp:Button ID="cmdDashboard" runat="server" Text="DashBoard" OnClick="cmdDashboard_Click" />
                    </p>
                </fieldset>
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
