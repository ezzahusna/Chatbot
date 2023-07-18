<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="chatbotAdmin.message" %>

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

        .lblcat
        {
            padding: 0.6em;
            font-size: 1.2em;
            text-transform: uppercase;
        }

        .msgbtn
        {
            width: 5.2em;
            margin-right: 2em;
            padding: 0.2em;
            border: 0.1em solid;
            border-radius: 0.2em;
            border-color: #235A8C;
            background-color: white;
            font-weight: 600;
            cursor: pointer;
            font-size: 0.9em;
            float: right;
        }

        .lbldesc
        {
            padding: 0.4em;
        }

        .msgcat
        {
            padding: 0.6em;
        }

        .msgbtn:hover
        {            
            background-color: #20486B;
            color: white;
        }

        .lblc
        {
            padding: 0.4em;
            font-weight: 600;
            font-size: 0.9em;
        }

        .msg
		{
            overflow: hidden;
            outline: none;
            resize: none;
            width: 96%;
            padding: 0.4em;
            border: 0.1em solid;
            border-color: #8EAFC8;
            background-color: white;
            font-size: 0.9em;
            font-family: Tahoma;
		}
    </style>
</head>
<body>
    <asp:SqlDataSource runat="server" ConnectionString='<%$ ConnectionStrings:chatbotConnectionString %>' SelectCommand="SELECT * FROM [messageAdmin]"></asp:SqlDataSource>

    <form id="form1" runat="server">
        <div class="navbar">
            <ul>
                <li><asp:Image runat="server" ID="img" CssClass="img" ImageUrl="Images/logo.png"></asp:Image></li>
                <li><a class="hnav" href="home.aspx" target="_parent">Home</a></li>
                <li><a class="hnav" href="solution.aspx" target="_parent">Solutions</a></li>
                <li><a class="hnav" href="message.aspx" target="_parent">Messages</a></li>
                <li><asp:Button runat="server" ID="signout" class="hnav" Text="Sign Out" OnClick="signout3_Click"></asp:Button></li>
            </ul>
        </div>

        <br />

        <div class="margin">
            <asp:Label runat="server" ID="lblcat" CssClass="lblcat" Font-Bold="true" Text="Messages to users"></asp:Label>
            <br />
            <asp:Label runat="server" ID="lbldesc" CssClass="lbldesc" Font-Size="Small" Text="You may edit the last message in the chat bot for users based on the category."></asp:Label>
            <br />            
            <br />
            <br />

            <% //Add on the buttons and textbox (copy paste line166-line177 and change the ID and OnClick) if the category more than 3 %>
            <asp:Panel runat="server" ID="msgCat" CssClass="msgcat">
                <asp:Button runat="server" ID="msgedit1" CssClass="msgbtn" Text="Edit" OnClick="msgedit1_Click"></asp:Button>
                <asp:Button runat="server" ID="msgcancel1" CssClass="msgbtn" Text="Cancel" OnClick="msgcancel1_Click"></asp:Button>
                <asp:Button runat="server" ID="msgsave1" CssClass="msgbtn" Text="Save" OnClick="msgsave1_Click"></asp:Button>
                <asp:Label runat="server" ID="lblc1" CssClass="lblc"></asp:Label>
                
                <br />
                <br />

                <asp:TextBox runat="server" ID="txtc1" CssClass="msg" TextMode="MultiLine" Rows="5"></asp:TextBox>
                <div align="right" style="margin-right:2vw;">
                    <asp:Label runat="server" ID="date1" Font-Size="Smaller" Font-Italic="true" ForeColor="Gray"></asp:Label>
                </div>

                <br />
                <br />

                <asp:Button runat="server" ID="msgedit2" CssClass="msgbtn" Text="Edit" OnClick="msgedit2_Click"></asp:Button>
                <asp:Button runat="server" ID="msgcancel2" CssClass="msgbtn" Text="Cancel" OnClick="msgcancel2_Click"></asp:Button>
                <asp:Button runat="server" ID="msgsave2" CssClass="msgbtn" Text="Save" OnClick="msgsave2_Click"></asp:Button>
                <asp:Label runat="server" ID="lblc2" CssClass="lblc"></asp:Label>
                
                <br />
                <br />

                <asp:TextBox runat="server" ID="txtc2" CssClass="msg" TextMode="MultiLine" Rows="5"></asp:TextBox>
                <div align="right" style="margin-right:2vw;">
                    <asp:Label runat="server" ID="date2" Font-Size="Smaller" Font-Italic="true" ForeColor="Gray"></asp:Label>
                </div>

                <br />
                <br />

                <asp:Button runat="server" ID="msgedit3" CssClass="msgbtn" Text="Edit" OnClick="msgedit3_Click"></asp:Button>
                <asp:Button runat="server" ID="msgcancel3" CssClass="msgbtn" Text="Cancel" OnClick="msgcancel3_Click"></asp:Button>
                <asp:Button runat="server" ID="msgsave3" CssClass="msgbtn" Text="Save" OnClick="msgsave3_Click"></asp:Button>
                <asp:Label runat="server" ID="lblc3" CssClass="lblc"></asp:Label>
                
                <br />
                <br />

                <asp:TextBox runat="server" ID="txtc3" CssClass="msg" TextMode="MultiLine" Rows="5"></asp:TextBox>
                <div align="right" style="margin-right:2vw;">
                    <asp:Label runat="server" ID="date3" Font-Size="Smaller" Font-Italic="true" ForeColor="Gray"></asp:Label>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
