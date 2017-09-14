<%@ Page Title="Account Creation" Language="C#" MasterPageFile="Pages/Main.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="qdsgames_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- ID	Name	Age	Email	Phone	Address	UserType		Ban
-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left_bar" runat="Server">
    <p>Benefits of making an account</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="right_bar" runat="Server">
    <p>Social Sites we have on the site.</p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main_content" runat="Server">
    <form id="form1" runat="server" defaultfocus="arrivalTextBox" defaultbutton="submitButton">
        <div class="container">
            
                <!-- Subtitle -->
                <div class="form-group">
                    <h3>Request Data</h3>
                </div>
                <!-- Validation Summary -->
                <div class="form-group">
                    <div class="next">
                        <asp:ValidationSummary ID="ValidationSummary" runat="server"
                            HeaderText="Please correct these entries: " BorderColor="Black"
                            BorderStyle="Solid" BorderWidth="1px" CssClass="validation" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="next">
                        <p class="validation">* means that the field is required</p>
                    </div>
                </div>
                
                <!-- First Name Text Box -->
                <div class="form-group">
                    <div class="next">
                        <asp:Label for="firstName" runat="server">First Name<span class="validation">*</span></asp:Label>
                        <asp:RequiredFieldValidator ID="firstNameReqValid" runat="server" ErrorMessage="Must enter first name" ControlToValidate="firstName" CssClass="validation"></asp:RequiredFieldValidator>
                    </div>
                    <div class="next">
                        <asp:TextBox ID="firstName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!-- Last Name Text Box -->
                <div class="form-group">
                    <div class="next">
                        <asp:Label for="lastName" runat="server">Last Name<span class="validation">*</span></asp:Label>
                        <asp:RequiredFieldValidator ID="lastNameReqValid" runat="server" ErrorMessage="Must enter last name" ControlToValidate="lastName" CssClass="validation"></asp:RequiredFieldValidator>
                    </div>
                    <div class="next">
                        <asp:TextBox ID="lastName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!-- Email Address Text Box -->
                <div class="form-group">
                    <div class="next">
                        <asp:Label  runat="server">Email address<span class="validation">*</span></asp:Label>
                        <asp:RequiredFieldValidator ID="emailReqValid" runat="server" ErrorMessage="Must enter an email" ControlToValidate="emailAddress" CssClass="validation"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="emailRegExpresValid" runat="server" ErrorMessage="Must enter a valid email" CssClass="validation" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailAddress"></asp:RegularExpressionValidator>
                    </div>
                    <div class="next">
                        <asp:TextBox ID="emailAddress" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!-- Phone Number Text Box -->
                <div class="form-group">
                    <div class="next">
                        <asp:Label for="phoneNumber" runat="server">Telephone number<span class="validation">*</span></asp:Label>
                        <asp:RequiredFieldValidator ID="phoneReqValid" runat="server" ErrorMessage="Must enter a phone number" ControlToValidate="phoneNumber" CssClass="validation"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="phoneRegExpresValid" runat="server" ErrorMessage="Must enter a valid phone number (###-###-####)" ControlToValidate="phoneNumber" CssClass="validation" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                    </div>
                    <div class="next">
                        <asp:TextBox ID="phoneNumber" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                    </div>
                </div>
                
                <!-- Submit and clear buttons -->

                <div class="form-group">
                    <asp:Button ID="submitButton" runat="server" Text="Submit" CssClass="blueButton btn btn-primary" OnClick="SubmitButton_Click" />
                    <div class="next"></div>
                </div>

            </div>
        
    </form>
</asp:Content>