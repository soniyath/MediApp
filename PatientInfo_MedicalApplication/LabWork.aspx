<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabWork.aspx.cs" Inherits="PatientInfo_MedicalApplication.LabWork" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient Lab Work - Sheridan Medical Application</title>
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
                    <h1>Lab Work</h1>
                    <h3 style="float: right;">
                        <strong>MRN:</strong>&nbsp;&nbsp;<asp:Label ID="lblMRN" runat="server"></asp:Label>
                    </h3><br /><br /><br /><br />
                <fieldset>
                    <legend>Lab Work Information</legend>
                    <p class="group">
                        <label>Creatinine: </label>
                        <br />
                        <asp:TextBox ID="numCreatinine" runat="server" TextMode="Number" min="0"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldCreatinine" runat="server" ErrorMessage="* Required" ControlToValidate="numCreatinine" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Hemoglobin: </label>
                        <br />
                        <asp:TextBox ID="numHemoglobin" runat="server" TextMode="Number" min="0"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldHemoglobin" runat="server" ErrorMessage="* Required" ControlToValidate="numHemoglobin" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>WBC: </label>
                        <br />
                        <asp:TextBox ID="numWBC" runat="server" TextMode="Number" min="0"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldWBC" runat="server" ErrorMessage="* Required" ControlToValidate="numWBC" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Sodium: </label>
                        <br />
                        <asp:TextBox ID="numSodium" runat="server" TextMode="Number" min="0"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldSodium" runat="server" ErrorMessage="* Required" ControlToValidate="numSodium" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Potassium: </label>
                        <br />
                        <asp:TextBox ID="numPotassium" runat="server" TextMode="Number" min="0"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldPotassium" runat="server" ErrorMessage="* Required" ControlToValidate="numPotassium" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Fluoride: </label>
                        <br />
                        <asp:TextBox ID="numFluoride" runat="server" TextMode="Number" min="0" MaxLength="250"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldFluoride" runat="server" ErrorMessage="* Required" ControlToValidate="numFluoride" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <asp:Button ID="cmdSubmit" runat="server" Text="Submit" OnClick="cmdSubmit_Click"/>
                        &nbsp;
                        <asp:Button ID="cmdDashboard" runat="server" Text="DashBoard" OnClick="cmdDashboard_Click" />
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
