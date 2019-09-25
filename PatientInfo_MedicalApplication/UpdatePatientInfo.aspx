<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePatientInfo.aspx.cs" Inherits="PatientInfo_MedicalApplication.UpdatePatientInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Patient Info - Sheridan Medical Application</title>
    <link href="main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Grid Area -->
        <div class="gridArea">
            <header class="head" id="head">
                <br />
                <asp:Button ID="logout" runat="server" Text="Logout" OnClick="logout_Click"/>
                <h1>New Patient Registration</h1>
                <br />
            </header>
            <section class="mainPic">
            </section>
            <section class="main">
                <fieldset>
                    <legend>Patient Information</legend><br />
                    <h3 style="float: right;">
                        <strong>MRN:</strong>&nbsp;&nbsp;<asp:Label ID="lblMRN" runat="server"></asp:Label>
                    </h3><br /><br />
                    <asp:Label ID="lblMessage" runat="server">Update Patient Information Below.</asp:Label>
                    <p class="group">
                        <label>First Name: </label>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="* Required Field." EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Last Name: </label>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="* Required Field." EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Address: </label>
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="* Required Field." EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>City: </label>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldCity" runat="server" ControlToValidate="txtCity" ErrorMessage="* Required Field." EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Province: </label>
                        <asp:DropDownList ID="selectProvince" runat="server">
                        <asp:ListItem Selected="True">Select Province</asp:ListItem>
                        <asp:ListItem>AB</asp:ListItem>
                        <asp:ListItem>BC</asp:ListItem>
                        <asp:ListItem>MB</asp:ListItem>
                        <asp:ListItem>NB</asp:ListItem>
                        <asp:ListItem>NL</asp:ListItem>
                        <asp:ListItem>NS</asp:ListItem>
                        <asp:ListItem>NT</asp:ListItem>
                        <asp:ListItem>NU</asp:ListItem>
                        <asp:ListItem>ON</asp:ListItem>
                        <asp:ListItem>PE</asp:ListItem>
                        <asp:ListItem>QC</asp:ListItem>
                        <asp:ListItem>SK</asp:ListItem>
                        <asp:ListItem>YT</asp:ListItem>
                    </asp:DropDownList>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldProvince" runat="server" ControlToValidate="selectProvince" ErrorMessage="* Required Field." InitialValue="Select Province" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                    <p class="group">
                        <label>Postal Code: </label>
                        <asp:TextBox ID="txtPostal" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:RegularExpressionValidator ID="vldCode" runat="server" ValidationExpression="^(?<full>(?<part1>[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]{1}\d{1}[A-Za-z]{1})(?:[ ](?=\d))?(?<part2>\d{1}[A-Za-z]{1}\d{1}))$" ErrorMessage="* Invalid postal code." EnableClientScript="False" ForeColor="Red" ControlToValidate="txtPostal"></asp:RegularExpressionValidator>
                    </p>
                    <p class="group">
                        <label>Phone Number: </label>
                        <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone" placeholder="905-456-7890"></asp:TextBox>
                        &nbsp;
                        <asp:RegularExpressionValidator ID="vldPhone" runat="server" ErrorMessage="* Invalid phone number." ControlToValidate="txtPhone" EnableClientScript="False" ForeColor="Red" ValidationExpression="[0-9]{3}-[0-9]{3}-[0-9]{4}|[0-9]{10}|[0-9]{11}|1{1}-[0-9]{3}-[0-9]{3}-[0-9]{4}|[(]{1}[0-9]{3}[)]{1} [0-9]{3}-[0-9]{4}|[(]{1}[0-9]{3}[)]{1}[0-9]{3}-[0-9]{4}|[0-9]{3}.[0-9]{3}.[0-9]{4}|1{1}.[0-9]{3}.[0-9]{3}.[0-9]{4}"></asp:RegularExpressionValidator>
                    </p>
                    <p class="group">
                        <label>Age: </label>
                        <asp:TextBox ID="ageNum" runat="server" TextMode="Number" min="0" max="125"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldAge" runat="server" ControlToValidate="ageNum" ErrorMessage="* Required Field." EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                        <%--&nbsp;
                        <asp:RangeValidator ID="vldAgeRange" runat="server" ControlToValidate="ageNum" ErrorMessage="* Invalid Age." EnableClientScript="False" ForeColor="Red" MaximumValue="125" MinimumValue="0"></asp:RangeValidator>--%>
                    </p>
                    <p class="group">
                        <label>Blood Type: </label>
                        <asp:DropDownList ID="selectBloodType" runat="server">
                        <asp:ListItem Selected="True">Select Blood Type</asp:ListItem>
                        <asp:ListItem>A+</asp:ListItem>
                        <asp:ListItem>A-</asp:ListItem>
                        <asp:ListItem>AB+</asp:ListItem>
                        <asp:ListItem>AB-</asp:ListItem>
                        <asp:ListItem>B+</asp:ListItem>
                        <asp:ListItem>B-</asp:ListItem>
                        <asp:ListItem>O+</asp:ListItem>
                        <asp:ListItem>O-</asp:ListItem>
                    </asp:DropDownList>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="vldBloodType" runat="server" ControlToValidate="selectBloodType" ErrorMessage="* Blood Type Required." InitialValue="Select Blood Type" EnableClientScript="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </p>
                </fieldset>
                <p class="group">
                    <asp:Button ID="cmdUpdate" runat="server" Text="Update" OnClick="cmdUpdate_Click"/>
                    &nbsp;
                        <asp:Button ID="cmdBack" runat="server" Text="Back" OnClick="cmdBack_Click"/>
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
