<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>
    <link href="css/uxcore.css" rel="stylesheet" />
    <link href="css/customer-comp.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container text-center" id="error">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-icon text-success"><span class="uxicon uxicon-clock-refresh"></span></div>
                    <h1>Welcome to QDS Games</h1>
                    <a href="Pages/AccountCreate.aspx">Account Create</a>
                    <a href="Pages/UserPage.aspx">User Page</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>