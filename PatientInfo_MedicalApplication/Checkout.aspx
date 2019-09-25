<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="PatientInfo_MedicalApplication.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient Checkout - Sheridan Medical Application</title>
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
                    <h1>Checkout</h1>
                    <h3 style="float: right;">
                        <strong>MRN:</strong>&nbsp;&nbsp;<asp:Label ID="lblMRN" runat="server"></asp:Label>
                    </h3><br /><br /><br /><br />
                <fieldset>
                    <legend>Patient Information</legend>
                    <asp:Label ID="lblMessage" runat="server" Text="lblMsg" Visible="False"></asp:Label>
                        <p class="group">
                        <strong>Name:</strong>&nbsp;&nbsp;<asp:Label ID="lblName" runat="server"></asp:Label>
                    </p>
                    <p class="group">
                        <strong>Phone Number:</strong>&nbsp;&nbsp;<asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                    </p>
                    <p class="group">
                        <strong>Address:</strong>&nbsp;&nbsp;<asp:Label ID="lblAddress" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;<strong>City:</strong>&nbsp;&nbsp;<asp:Label ID="lblCity" runat="server"></asp:Label>
                    </p>
                    <p class="group">
                        <strong>Province:</strong>&nbsp;&nbsp;<asp:Label ID="lblProvince" runat="server"></asp:Label>
                        &nbsp;&nbsp&nbsp;&nbsp;<strong>Postal Code:</strong>&nbsp;&nbsp;<asp:Label ID="lblPostal" runat="server"></asp:Label>
                    </p>
                    <p class="group">
                        <strong>Age:</strong>&nbsp;&nbsp;<asp:Label ID="lblAge" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;<strong>Blood Type:</strong>&nbsp;&nbsp;<asp:Label ID="lblBloodType" runat="server"></asp:Label>
                    </p>
                    <p class="group">
                        <asp:Button ID="cmdUpdatePatient" runat="server" Text="Update" OnClick="cmdUpdatePatient_Click" />
                    </p>
                </fieldset>
                <fieldset>
                    <legend>Discharge Instructions</legend>
                    <p class="group">
                        <label>Checkout Remarks:</label>
                        <asp:TextBox ID="txtDischargeInstr" runat="server" TextMode="MultiLine" Height="100px" Width="44.5%" MaxLength="250"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldInstruction" runat="server" ControlToValidate="txtDischargeInstr" ErrorMessage="* Required." EnableClientScript="False" ForeColor="Red" ValidationGroup="instructions"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>&nbsp;Follow Ups: </label>
                        <asp:TextBox ID="txtFollowUps" runat="server" TextMode="MultiLine" Height="100px" Width="44.5%" MaxLength="250"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldFollowUps" runat="server" ControlToValidate="txtFollowUps" ErrorMessage="* Required." EnableClientScript="False" ForeColor="Red" ValidationGroup="instructions"></asp:RequiredFieldValidator>
                    </p>
                &nbsp;<p class="group">
             
                        <label>Any Conclusions: </label>
                        <asp:TextBox ID="txtConclusions" runat="server" TextMode="MultiLine" Height="100px" Width="44.5%" MaxLength="250"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="vldConclusions" runat="server" ControlToValidate="txtConclusions" ErrorMessage="* Required." EnableClientScript="False" ForeColor="Red" ValidationGroup="instructions"></asp:RequiredFieldValidator>
                    </p>
                    </fieldset>
                    <fieldset>
                    <legend>ADD</legend>
                    <p class="group">
                        <asp:Button ID="addCheckouts" runat="server" OnClick="addConclusions_Click" Text="ADD" /> 
                        &nbsp;
                        <asp:Button ID="cmdDashboard" runat="server" Text="DashBoard" OnClick="cmdDashboard_Click"/>
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
