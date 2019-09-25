<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientInfo.aspx.cs" Inherits="PatientInfo_MedicalApplication.PatientInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient Information - Sheridan Medical Application</title>
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
                <fieldset>
                    <legend>Patient Information</legend>
                    <h3 style="float: right;">
                        <strong>MRN:</strong>&nbsp;&nbsp;<asp:Label ID="lblMRN" runat="server"></asp:Label>
                    </h3>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
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
                    <legend>Pre-Existing Conditions</legend>
                    <asp:ListBox ID="lstConditions" runat="server" Height="180px" Width="273px"></asp:ListBox>
                    <p class="group">
                        <label>Condition Name: </label>
                        <br />
                        <asp:TextBox ID="txtConditionName" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldCondition" runat="server" ControlToValidate="txtConditionName" ErrorMessage="* Required." EnableClientScript="False" ForeColor="Red" ValidationGroup="conditions"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Date Began: </label>
                        <br />
                        <asp:TextBox ID="txtConDate" runat="server" TextMode="Date"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldConDate" runat="server" ControlToValidate="txtConDate" ErrorMessage="* Required." EnableClientScript="False" ForeColor="Red" ValidationGroup="conditions"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <asp:Button ID="cmdAddCondition" runat="server" Text="Add" OnClick="cmdAddCondition_Click" ValidationGroup="conditions" />
                    </p>
                </fieldset>
                <fieldset>
                    <legend>Allergies</legend>
                    <asp:ListBox ID="lstAllergyItems" runat="server" Height="180px" Width="276px"></asp:ListBox>
                    <p class="group">
                        <label>Allergy Name: </label>
                        <br />
                        <asp:TextBox ID="txtAllergyName" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldAllergy" runat="server" ControlToValidate="txtAllergyName" ErrorMessage="* Required." EnableClientScript="False" ForeColor="Red" ValidationGroup="allergies"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Date Started: </label>
                        <br />
                        <asp:TextBox ID="txtAllerDate" runat="server" TextMode="Date"></asp:TextBox>
                    </p>
                    <p class="group">
                        <asp:Button ID="cmdAddAllergy" runat="server" Text="Add" ValidationGroup="allergies" OnClick="cmdAddAllergy_Click" />
                    </p>
                </fieldset>
                <fieldset>
                    <legend>Medications</legend>
                    <asp:ListBox ID="lstMedItems" runat="server" Height="200px" Width="283px"></asp:ListBox>
                    <p class="group">
                        <label>Med Name: </label>
                        <br />
                        <asp:TextBox ID="txtMedName" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldMedName" runat="server" ControlToValidate="txtMedName" ErrorMessage="* Required." EnableClientScript="False" ForeColor="Red" ValidationGroup="meds"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Dose: </label>
                        <br />
                        <asp:TextBox ID="txtDose" runat="server"></asp:TextBox>
                         &nbsp;
                        <asp:RequiredFieldValidator ID="vldDose" runat="server" ControlToValidate="txtDose" ErrorMessage="* Required." EnableClientScript="False" ForeColor="Red" ValidationGroup="meds"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Date Started: </label>
                        <br />
                        <asp:TextBox ID="txtMedDate" runat="server" TextMode="Date"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldMedDate" runat="server" ControlToValidate="txtMedDate" ErrorMessage="* Required." EnableClientScript="False" ForeColor="Red" ValidationGroup="meds"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <asp:Button ID="cmdAddMeds" runat="server" Text="Add" ValidationGroup="meds" OnClick="cmdAddMeds_Click" />
                    </p>
                </fieldset>
                <p class="group">
                    <asp:Button ID="cmdViewDashboard" runat="server" Text="Next" OnClick="cmdEnterAnalysis_Click"/>
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
