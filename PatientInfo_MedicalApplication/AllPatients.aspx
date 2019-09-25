<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllPatients.aspx.cs" Inherits="PatientInfo_MedicalApplication.AllPatients" %>

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
                <br/>
            </header>
            <section class="mainPic">
            </section>
            <section class="main">
                <fieldset>
                    <legend>Patient History</legend>
                    <p class="group">
                        <asp:Label ID="lblMessage" runat="server">Patients with their respective MRN are as under: -</asp:Label>
                         &nbsp;
                      </p>
                    <p class="group">  
                    <asp:TextBox ID="txtAllPatients" runat="server" TextMode="MultiLine" Height="100px" Width="44.5%" MaxLength="50000" ReadOnly="True"></asp:TextBox>              
                    </p>
                    </p>
                <p class="group">
                    <asp:Button ID="backToMain" runat="server" Text="Login Page" OnClick="loginPage_Click"/>
                    &nbsp;
                   </p>
                    <p class="group">
                        <asp:Label ID="patientErr" runat="server"></asp:Label>
                    <br />
                    
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
