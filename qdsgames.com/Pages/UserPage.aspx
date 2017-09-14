<%@ Page Title="" Language="C#" MasterPageFile="Main.master" AutoEventWireup="true" 
    CodeFile="UserPage.aspx.cs" Inherits="qdsgames_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/MainUserPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left_bar" runat="Server">
    <!--Main Content
        -->
    <div class="btn-group">

        <p>Page activity</p>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

    </div>
    <div class="btn-group">
        <p>Recent Actions</p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="right_bar" runat="Server">

    <div class="btn-group">
        <p>Friends List</p>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main_content" runat="Server">

    <h2 id="username">Username here</h2>

    <table id="social_table">
        <tr>
            <td width="25%"><a href="http://www.facebook.com" target="_blank">
                <img src="images/Social_Icons/Facebook.png" height="100%" width="100%" /></a></td>
            <td width="33%">
                <iframe src="https://www.facebook.com/plugins/post.php?href=https%3A%2F%2Fwww.facebook.com%2Ffacebook%2Fposts%2F10156293183221729&width=500"
                    width="75%" height="75%"></iframe>
            </td>
            <td width="33%%">
                <p>Then facebook post.</p>
            </td>
        </tr>
        <tr>
            <td><a href="http://www.twitch.com" target="_blank">
                <img src="images/Social_Icons/Twitch.png" height="100" width="100" /></a></td>
            <td>
                <p>Twitch homepage. </p>
            </td>
            <td>
                <p>Then Twitch stream or video</p>
            </td>
        </tr>
        <tr>
            <td><a href="http://www.youtube.com" target="_blank">
                <img src="images/Social_Icons/Youtube.png" height="100" width="100" /></a></td>
            <td>
                <p>Youtube Homepage.</p>
            </td>
            <td>
                <p>Then favorite video.</p>
            </td>
        </tr>
    </table>

</asp:Content>

