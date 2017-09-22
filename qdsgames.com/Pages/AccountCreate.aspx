<%@ Page Title="Account Creation" Language="C#" MasterPageFile="Main.master"
    AutoEventWireup="true" CodeFile="AccountCreate.aspx.cs" Inherits="qdsgames_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- ID	Name	Age	Email	Phone	Address	UserType		Ban
-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 503px;
        }
    </style>
    <link href="../css/Custom/signup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left_bar" runat="Server">
    <p>Benefits of making an account</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="right_bar" runat="Server">
    <p>Social Sites we have on the site.</p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main_content" runat="Server">
    <div class="container">
        <button onclick="document.getElementById('id01').style.display='block'" style="width: auto;">Register</button>

        <div id="id01" class="modal">
            <span onclick="document.getElementById('id01').style.display='none'" class="close" title="Close Modal">×</span>
            <form class="modal-content animate" action="/action_page.php">
                <div class="container">
                    

                    <span onclick="document.getElementById('id01').style.display='none'" class="close" title="Close Modal">×</span>
                    
                        <br />
                        <label><b>Username</b></label>
                        <input type="text" placeholder="Enter Username" name="username" required />
                        <br />
                        <label><b>Email</b></label>
                        <input type="text" placeholder="Enter Email" name="email" required>
                        <br />
                        <label><b>Password</b></label>
                        <input type="password" placeholder="Enter Password" name="psw" required>
                        <br />
                        <label><b>Repeat Password</b></label>
                        <input type="password" placeholder="Repeat Password" name="psw-repeat" required>
                        <br />
                        <input type="checkbox" checked="checked">
                        Remember me
                        <br />
                        <p>By creating an account you agree to our <a href="#">Terms & Privacy</a>.</p>

                        <div class="clearfix">
                            <button type="button" onclick="document.getElementById('id01').style.display='none'" class="cancelbtn">Cancel</button>
                            <button type="submit" class="signupbtn">Register</button>
                        </div>
                    </div>
                
            </form>
        </div>
        <script>
            // Get the modal
            var modal = document.getElementById('id01');

            // When the user clicks anywhere outside of the modal, close it
            window.onclick = function (event) {
                if (event.target == modal) {
                    modal.style.display = "none";
                }
            }
        </script>
    </div>
    <footer>
        &copy; i just added this cuz why not
    </footer>
</asp:Content>