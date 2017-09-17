<%@ Page Title="Account Creation" Language="C#" MasterPageFile="Main.master"
    AutoEventWireup="true" CodeFile="AccountCreate.aspx.cs" Inherits="qdsgames_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- ID	Name	Age	Email	Phone	Address	UserType		Ban
-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left_bar" runat="Server">
    <p>Benefits of making an account</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="right_bar" runat="Server">
    <p>Social Sites we have on the site.</p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main_content" runat="Server">
    <div class="container">

        <form id="form1" runat="server" defaultfocus="firstName" defaultbutton="submitButton" class="form-horizontal">

            <!-- Validation Summary -->
            <div class="form-group">
                <div class="next">
                    <asp:ValidationSummary ID="ValidationSummary" runat="server"
                        HeaderText="Please correct these entries: " BorderColor="Black"
                        BorderStyle="Solid" BorderWidth="1px" CssClass="validation" />
                </div>
            </div>
            <!--
            <div class="form-group">
                
                    
                    <p class="validation">* means that the field is required</p>
                
            </div>
            -->
            <div class="page-header">
                <h1>Account Creation</h1>
            </div>
            

            <!-- First Name Text Box -->
            <div class="form-group">
                <div class="next">
                    <asp:Label runat="server" CssClass="col-sm-2">First Name<span class="validation">*</span></asp:Label>
                    <asp:RequiredFieldValidator ID="firstNameReqValid" runat="server" ErrorMessage="Must enter first name" ControlToValidate="firstName" CssClass="validation"></asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-4">
                    <asp:TextBox ID="firstName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!-- Last Name Text Box -->
            <div class="form-group">
                <div class="next">
                    <asp:Label runat="server" CssClass="col-sm-2">Last Name<span class="validation">*</span></asp:Label>
                    <asp:RequiredFieldValidator ID="lastNameReqValid" runat="server" ErrorMessage="Must enter last name" ControlToValidate="lastName" CssClass="validation"></asp:RequiredFieldValidator>
                </div>
                <div class="next col-sm-4">
                    <asp:TextBox ID="lastName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!-- Address Text Box -->
            <div class="form-group">
                <div class="next">
                    <asp:Label runat="server" CssClass="col-sm-12">Address</asp:Label>
                    
                </div>
                <div class="next col-sm-4">
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!-- Email Address Text Box -->
            <div class="form-group">
                <div class="next">
                    <asp:Label runat="server" CssClass="col-sm-2">Email address<span class="validation">*</span></asp:Label>
                    <asp:RequiredFieldValidator ID="emailReqValid" runat="server" ErrorMessage="Must enter an email" ControlToValidate="emailAddress" CssClass="validation"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="emailRegExpresValid" runat="server" ErrorMessage="Must enter a valid email" CssClass="validation" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailAddress"></asp:RegularExpressionValidator>
                </div>
                <div class="next col-sm-4">
                    <asp:TextBox ID="emailAddress" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!-- Phone Number Text Box -->
            <div class="form-group">
                <div class="next ">
                    <asp:Label runat="server" CssClass="col-sm-6">Telephone number<span class="validation">*</span></asp:Label>
                    <asp:RequiredFieldValidator ID="phoneReqValid" runat="server" ErrorMessage="Must enter a phone number" ControlToValidate="phoneNumber" CssClass="validation"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="phoneRegExpresValid" runat="server" ErrorMessage="Must enter a valid phone number (###-###-####)" ControlToValidate="phoneNumber" CssClass="validation" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                </div>
                <div class="next col-sm-4">
                    <asp:TextBox ID="phoneNumber" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                </div>
            </div>
            <!-- Submit and clear buttons -->

            <div class="form-group">
                <asp:Button ID="submitButton" runat="server" Text="Submit" CssClass="blueButton btn btn-primary btn-default col-sm-1" OnClick="SubmitButton_Click" />

            </div>
        </form>
    </div>

</asp:Content>