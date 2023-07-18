<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="chatbotAdmin.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KEM Chatbot</title>

    <meta http-equiv="cache-control" content="no-cache, no-store, must-revalidate" />
    <meta http-equiv="expires" content="0" />
    <meta http-equiv="pragma" content="no-cache" />

    <style>
        body 
        {
            font-family: Tahoma;
            margin: 0;
        }

        ul 
        {
            list-style-type: none;
            position: fixed;
            margin: 0;
            padding: 0;        
            width: 12em;
            height: 100%;
            background-color: #EEEFF0;            
            overflow: auto;
            font-size: 0.9em;
        }

        li
        {
            padding-bottom: 0.2em;
            font-weight: 600;
        }

        li a
        {
            display: block;
            background-color: #EEEFF0;
            color: #000;
            padding: 1em;
            border: none;
            text-decoration: none;
        }      
        
        #signout
        {
            padding: 1em;
            border: none;
            width: 100%;
            background-color: #EEEFF0;
            color: #000;
            text-align:left;
            font-size: 0.9em;
            font-weight: 600;
            font-family: Tahoma;
        }

        li a:hover, li #signout:hover
        {
            background-color: #555;
            color: white;
        }

        .img
        {
            padding: 1em;
            width: 9.2em;
            height: 2em;
        }
                                
        .margin
        {
            margin-left: 12em;
        }

        .ttl
        {
            padding: 0.6em;
            font-size: 1.2em;
            text-transform: uppercase;
        }

        .home:disabled
        {
            width: 12em;
            height: 5em;
            margin-right: 1.6em;
            padding: 0.6em;
            border: none;
            border-radius: 0.2em;
            background-color: #ADBECF;
            color: black;
            font-weight: 600;
            font-size: 0.9em;
        }
    </style>
</head>

<body>
    <asp:SqlDataSource runat="server" ConnectionString='<%$ ConnectionStrings:chatbotConnectionString %>' SelectCommand="SELECT * FROM [dbKEMChatBot]"></asp:SqlDataSource>

    <form id="form1" runat="server">
        <div class="navbar">
            <ul>
                <li><asp:Image runat="server" ID="img" CssClass="img" ImageUrl="Images/logo.png"></asp:Image></li>
                <li><a class="hnav" href="home.aspx" target="_parent">Home</a></li>
                <li><a class="hnav" href="solution.aspx" target="_parent">Solutions</a></li>
                <li><a class="hnav" href="message.aspx" target="_parent">Messages</a></li>
                <li><asp:Button runat="server" ID="signout" class="hnav" Text="Sign Out" OnClick="signout_Click"></asp:Button></li>
            </ul>
        </div>

        <br />

        <div class="margin">
            <asp:Panel runat="server" ID="homepage" CssClass="homepage">
                <asp:Label runat="server" ID="ttl" CssClass="ttl" Font-Bold="true" Text="Total For Each Category"></asp:Label>
                <br />
                <br />
                <br />
            </asp:Panel>
        </div>
        
        <div class="gridview">
            <asp:GridView runat="server" ID="gridv" class="gridv" name="gridv" Visible="false"></asp:GridView>
        </div>
    </form>
</body>
</html>
