<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="PatientRegistration.aspx.cs"
    Inherits="PatientRegestration.PatientRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Patient Registration</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />

</head>

<body>

    <form id="form1" runat="server">

        <div class="container mt-5">

            <div class="row justify-content-center">

                <div class="col-md-8 col-lg-6">

                    <div class="card shadow-sm">

                        <div class="card-body p-4">

                            <h2 class="text-center mb-4">
                                Patient Registration
                            </h2>

                            <asp:ValidationSummary
                                ID="vsPatient"
                                runat="server"
                                CssClass="alert alert-danger"
                               />

                            <asp:Label
                                ID="lblMessage"
                                runat="server"
                                CssClass="d-block mb-3">
                            </asp:Label>


                            <!-- First Name -->
                            <div class="mb-3">

                                <asp:Label
                                    ID="lblFirstName"
                                    runat="server"
                                    Text="First Name"
                                    CssClass="form-label">
                                </asp:Label>

                                <asp:TextBox
                                    ID="txtFirstName"
                                    runat="server"
                                    CssClass="form-control">
                                </asp:TextBox>

                                <asp:RequiredFieldValidator
                                    ID="rfvFirstName"
                                    runat="server"
                                    ControlToValidate="txtFirstName"
                                    ErrorMessage="First Name is required."
                                    Text="*"
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>

                            </div>


                            <!-- Last Name -->
                            <div class="mb-3">

                                <asp:Label
                                    ID="lblLastName"
                                    runat="server"
                                    Text="Last Name"
                                    CssClass="form-label">
                                </asp:Label>

                                <asp:TextBox
                                    ID="txtLastName"
                                    runat="server"
                                    CssClass="form-control">
                                </asp:TextBox>

                                <asp:RequiredFieldValidator
                                    ID="rfvLastName"
                                    runat="server"
                                    ControlToValidate="txtLastName"
                                    ErrorMessage="Last Name is required."
                                    Text="*"
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>

                            </div>


                            <!-- Phone -->
                            <div class="mb-3">

                                <asp:Label
                                    ID="lblPhone"
                                    runat="server"
                                    Text="Phone"
                                    CssClass="form-label">
                                </asp:Label>

                                <asp:TextBox
                                    ID="txtPhone"
                                    runat="server"
                                    CssClass="form-control"
                                    MaxLength="20">
                                </asp:TextBox>

                                <asp:RequiredFieldValidator
                                    ID="rfvPhone"
                                    runat="server"
                                    ControlToValidate="txtPhone"
                                    ErrorMessage="Phone is required."
                                    Text="*"
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>

                            </div>


                            <!-- Date of Birth -->
                            <div class="mb-3">

                                <asp:Label
                                    ID="lblDateOfBirth"
                                    runat="server"
                                    Text="Date of Birth"
                                    CssClass="form-label">
                                </asp:Label>

                                <asp:TextBox
                                    ID="txtDateOfBirth"
                                    runat="server"
                                    TextMode="Date"
                                    CssClass="form-control">
                                </asp:TextBox>

                                <asp:RequiredFieldValidator
                                    ID="rfvDateOfBirth"
                                    runat="server"
                                    ControlToValidate="txtDateOfBirth"
                                    ErrorMessage="Date of Birth is required."
                                    Text="*"
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>

                            </div>


                            <!-- Gender -->
                            <div class="mb-3">

                                <asp:Label
                                    ID="lblGender"
                                    runat="server"
                                    Text="Gender"
                                    CssClass="form-label">
                                </asp:Label>

                                <asp:DropDownList
                                    ID="ddlGender"
                                    runat="server"
                                    CssClass="form-select">

                                    <asp:ListItem
                                        Text="Select Gender"
                                        Value="">
                                    </asp:ListItem>

                                    <asp:ListItem
                                        Text="Male"
                                        Value="Male">
                                    </asp:ListItem>

                                    <asp:ListItem
                                        Text="Female"
                                        Value="Female">
                                    </asp:ListItem>

                                </asp:DropDownList>

                                <asp:RequiredFieldValidator
                                    ID="rfvGender"
                                    runat="server"
                                    ControlToValidate="ddlGender"
                                    InitialValue=""
                                    ErrorMessage="Please select a gender."
                                    Text="*"
                                    CssClass="text-danger">
                                </asp:RequiredFieldValidator>

                            </div>

                            <!-- Register Button -->
                            <div class="d-grid mt-4">

                                <asp:Button
                                    ID="btnRegister"
                                    runat="server"
                                    Text="Register Patient"
                                    CssClass="btn btn-primary btn-lg"
                                    OnClick="btnRegister_Click">
                                </asp:Button>

                            </div>

                        </div>

                    </div>

                </div>

            </div>

        </div>

    </form>

</body>

</html>