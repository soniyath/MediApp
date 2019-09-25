<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Analysis.aspx.cs" Inherits="PatientInfo_MedicalApplication.Analysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient Analysis - Sheridan Medical Application</title>
    <link href="main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Grid Area -->
        <div class="gridArea">
            <header class="head" id="head">
                <br />
                <asp:Button ID="logout" runat="server" Text="Logout" OnClick="logout_Click"/>
                <h1>Sheridan Medical Application</h1>
                <br />
            </header>
            <section class="mainPic">
            </section>
            <section class="main">
                    <h1>Analysis</h1>
                    <h3 style="float: right;">
                        <strong>MRN:</strong>&nbsp;&nbsp;<asp:Label ID="lblMRN" runat="server"></asp:Label>
                    </h3><br /><br /><br /><br />
                <fieldset>
                    <legend>Hospital Visit Information</legend>
                    <p class="group">
                        <label>Reason for visit: </label>
                        <br />
                        <asp:TextBox ID="txtVisitReason" runat="server" TextMode="MultiLine" Height="100px" Width="44.5%" MaxLength="250"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldReasonForVisit" runat="server" ErrorMessage="* Reason Required" ControlToValidate="txtVisitReason" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Subjective Analysis: </label>
                        <br />
                        <asp:TextBox ID="txtSubAnal" runat="server" TextMode="MultiLine" Height="100px" Width="44.5%" MaxLength="250"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldSubAnal" runat="server" ErrorMessage="* Reason Required" ControlToValidate="txtSubAnal" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Objective Analysis: </label>
                        <br />
                        <asp:TextBox ID="txtObjAnal" runat="server" TextMode="MultiLine" Height="100px" Width="44.5%" MaxLength="250"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldObjAnal" runat="server" ErrorMessage="* Reason Required" ControlToValidate="txtObjAnal" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Checked In: </label><asp:CheckBox ID="chkCheckIn" runat="server" />
                    </p>
                    <p class="group">
                        <asp:Button ID="cmdSubmit" runat="server" Text="Submit" OnClick="cmdSubmit_Click"/>
                        &nbsp;
                        <asp:Button ID="cmdDashboard" runat="server" Text="Dashboard" OnClick="cmdDashboard_Click"/>
                    </p>
                </fieldset>
                <fieldset>
                    <legend>Analysis History</legend>
                    <p class="group">
                        <asp:TextBox ID="txtAnalHist" runat="server" TextMode="MultiLine" Height="200px" Width="100%" MaxLength="250" Enabled="False"></asp:TextBox>
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
