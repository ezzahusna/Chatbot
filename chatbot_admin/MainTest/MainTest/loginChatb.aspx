<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginChatb.aspx.cs" Inherits="chatbotAdmin.loginChatb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KEM Chatbot</title>

    <meta http-equiv="cache-control" content="no-cache, no-store, must-revalidate" />
    <meta http-equiv="expires" content="0" />
    <meta http-equiv="pragma" content="no-cache" />

    <script>
        window.history.forward(0);
        function noBack() { window.history.forward(0); }
    </script>

    <style>
        body
        {
            font-family: Tahoma;
        }

        .logindetails
        {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            width: fit-content;
            padding: 2em;
            border: none;
            border-radius: 0.4em;
            background-color: #ABCDF2;
        }

        .logindt
        {
            font-size: 1em;
        }

        .dep
        {
            resize: none;
            outline: none;
            height: 2em;
            width: 12em;
            margin-top:0.2em;
            padding: 0.4em;
            border: none;
            border-bottom: 0.1em solid black;
            background: rgba(243,246,249,0.8);
            font-size: 0.9em;
        }

        .loginlabel
        {
            font-size: 0.9em;
        }

        .tbdetails
        {
            resize: none;
            outline: none;
            height: 1.4em;
            width: 16em;
            margin-top:0.2em;
            padding: 0.4em;
            border: none;
            border-bottom: 0.1em solid black;
            background: rgba(243,246,249,0.8);
            font-size: 0.9em;
        }

        .tbdetails:focus
        {
            border-bottom: 0.1em solid blue;
        }

        .btnsignin
        {
            width: 100%;
            padding: 0.4em;
            border: 0.1em solid;
            border-radius: 0.2em;
            border-color: #235A8C;
            background-color: white;
            font-weight: 600;
            cursor: pointer;
            font-size: 0.9em;
        }

        .btnsignin:hover
        {            
            background-color: #20486B;
            color: white;
        }
                
        .require, .signinfail
        {
            font-size: 0.8em;
        }
        .topnav-right
        {
             float: right;
             font-size: 0.9em;
        }
    </style>
</head>

<body onload="noBack();">    
    <form id="loginform" runat="server" autocomplete="off">
        <div class="logindetails">
            <asp:Label runat="server" ID="logindt" CssClass="logindt" Font-Bold="true" Text="- SIGN IN YOUR ACCOUNT -"></asp:Label>

            <br />
            <br />
            <br />

            <asp:Label runat="server" Text="Department" Font-Bold="true" CssClass="loginlabel"></asp:Label>
            <br />
            <asp:DropDownList runat="server" ID="dep" CssClass="dep">
                <asp:ListItem Value="0">-Select a department-</asp:ListItem>
                <asp:ListItem Value="1">HR</asp:ListItem>
                <asp:ListItem Value="2">IT</asp:ListItem>
                <asp:ListItem Value="3">Finance</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label runat="server" ID="require" CssClass="require"></asp:Label>

            <br />
            <br />

            <asp:Label runat="server" ID="userid" Text="User ID" Font-Bold="true" CssClass="loginlabel"></asp:Label>
            <br />
            <asp:TextBox runat="server" ID="tbuserid" CssClass="tbdetails" Required="true" AutoCompleteType="Disabled"></asp:TextBox>

            <br />
            <br />
            <br />

            <asp:Label runat="server" ID="password" Text="Password" Font-Bold="true" CssClass="loginlabel"></asp:Label>
            <br />
            <asp:TextBox runat="server" ID="tbpassword" CssClass="tbdetails" TextMode="password" Required="true"></asp:TextBox>

            <br />
            <br />
            <br />
            <br />
            
            <asp:Button runat="server" ID="signin" Text="SIGN IN" CssClass="btnsignin" ToolTip="Sign In" OnClick="signin_Click"></asp:Button>
            <asp:Label runat="server" ID="signinfail" CssClass="signinfail"></asp:Label>
        </div>
    </form>

    <div class="topnav-right">
        Back to intranet <a href="http://localhost:28579/Default.aspx">Home</a>  <%-- Change link of intranet here --%>
    </div>
</body>
</html>
