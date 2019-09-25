<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PatientInfo_MedicalApplication.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient Dashboard - Sheridan Medical Application</title>
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
                    <h1>Dashboard</h1>
                    <h3 style="float: right;">
                        <strong>MRN:</strong>&nbsp;&nbsp;<asp:Label ID="lblMRN" runat="server"></asp:Label>
                    </h3><br /><br /><br /><br />
                <fieldset>
                    <legend>Dashboard Navigation</legend>
                    <p class="group">
                    <asp:Button ID="cmdAnalysis" runat="server" Text="Analysis" Width="50%" OnClick="cmdAnalysis_Click"/>
                    &nbsp;
                    <asp:Button ID="cmdLabWork" runat="server" Text="Lab Work" Width="50%" OnClick="cmdLabWork_Click"/>
                </p>
                <p class="group">
                    <asp:Button ID="cmdVitals" runat="server" Text="Vitals" Width="50%" OnClick="cmdVitals_Click"/>
                    &nbsp;
                    <asp:Button ID="cmdCheckout" runat="server" Text="Checkout" Width="50%" OnClick="cmdCheckout_Click"/>
                </p> 
                </fieldset>
                <fieldset>
                    <legend>Analysis</legend>
                    <p class="group">
                        <strong>Reason for Visit:</strong>&nbsp;&nbsp;<asp:Label ID="lblReason" runat="server"></asp:Label>
                    </p>
                    <p class="group">
                        <strong>Subjective Analysis:</strong>&nbsp;&nbsp;<asp:Label ID="lblSub" runat="server"></asp:Label>
                    </p>
                    <p class="group">
                        <strong>Objective Analysis:</strong>&nbsp;&nbsp;<asp:Label ID="lblObj" runat="server"></asp:Label>
                    </p>
                    <p class="group">
                        <strong>Date/Time:</strong>&nbsp;&nbsp;<asp:Label ID="lblAnalysisDate" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <strong>Checked In:</strong>&nbsp;&nbsp;<asp:Label ID="lblCheckIn" runat="server"></asp:Label>
                    </p>
                </fieldset>
                <fieldset>
                    <legend>Lab Work</legend>
                    <p class="group">
                        <label>Lab Work History: </label>
                        <br />
                        <asp:TextBox ID="txtLabHist" runat="server" TextMode="MultiLine" Height="100px" Width="44.5%" MaxLength="250" Enabled="False"></asp:TextBox>
                    </p>
                </fieldset>
                <fieldset>
                    <legend>Vitals</legend>
                    <p class="group">
                        <label>Vitals History: </label>
                        <br />
                        <asp:TextBox ID="txtVitalsHist" runat="server" TextMode="MultiLine" Height="100px" Width="44.5%" MaxLength="250" Enabled="False"></asp:TextBox>
                    </p>
                </fieldset>
                 <fieldset>
                    <legend>Checkout</legend>
                    <p class="group">
                        <label>Checkout History: </label>
                        <br />
                        <asp:TextBox ID="txtCheckoutHist" runat="server" TextMode="MultiLine" Height="100px" Width="44.5%" MaxLength="250" Enabled="False"></asp:TextBox>
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
