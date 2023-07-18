<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="email.aspx.cs" Inherits="chatbotUser.email" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script>
        //Function to disable the browser's back button
        window.onload = window.history.forward(0);

    </script>

    <style>
    	body 
        {
    		font-family: Tahoma;
    	}

    	.emailform 
        {
    		position: fixed;
			top:60.79px;
			width: 296.78px;
			height: 493.73px;
			box-shadow: 1.34px 1.34px #BBCFDD;
			border-radius: 5.39px;
			background-color: #7EBFF1;
			padding: 10.79px;
			font-size: 13.49px;
			right:53.96px;
    	}

    	.emailshow
        {
    		height: 377.72px;
    		overflow-y: auto;
			overflow-x: hidden;
    		background-color: white;
    		font-size: 12.14px;
    		text-align: justify;
    		padding:10.79px;
    	}

        .emailshow::-webkit-scrollbar
		{
			width: 0.4vw;
		}

		::-webkit-scrollbar-thumb
		{
			background: #3A586D; 
		}
		
		::-webkit-scrollbar-thumb:hover 
		{
			background: #627F94; 
		}

        .close
		{
			float: right;
			border: none;
			background-color: transparent;
			font-size: 13.49px;
			font-weight: 800;
			transition: all 0.2s;
		}

		.close:hover 
		{
			color: #FFFEF0;
		}

        .dep
        {
            outline: none;
            height: 26.98px;
            padding: 5.396px;
            border: none;
            border-bottom: 1.349px solid gray;
            border-radius: 2.698px;
        }

        .subject, .youremail
		{
            resize: none;
            outline: none;
            height: 18.886px;
            width: 261.706px;
            padding: 5.396px;
            border: none;
            border-bottom: 1.349px solid gray;
            border-radius: 2.698px;
            background-color: white;
		}
                
        .message
        {
            resize: none;
            outline: none;
            width: 261.706px;
            padding: 2.698px;
            border: 1.349px solid gray;
            border-radius: 2.698px;
            font-family: Tahoma;
            text-align: justify;
        }

        .dep:focus, .subject:focus, .youremail:focus
        {
            border-bottom: 1.349px solid blue;
        }
                               
        .message:focus
        {
            border: 1.349px solid blue;
        }

        .message::-webkit-scrollbar
		{
			width: 4.047px;
		}

		::-webkit-scrollbar-thumb
		{
			background: #3A586D; 
		}
		
		::-webkit-scrollbar-thumb:hover 
		{
			background: #627F94; 
		}

        .send
        {
            width: 78.242px;
            padding: 5.396px;
            border: 2.698px solid;
            border-radius:  2.698px;
            border-color: #8EAFC8;
            background-color: white;
            font-weight: 600;
            cursor: pointer;
        }

        .okay
        {
            width: 78.24px;
            padding:5.39px;
            border: 2.69px solid;
            border-radius: 2.69px;
            border-color: #8EAFC8;
            background-color: white;
            font-size: 8.09px;
            font-weight: 600;
            cursor: pointer;
        }

        .send:hover, .okay:hover, .okay2:hover
        {            
            background-color: #4F6D83;
            color: white;
        }

        .sending
        {
            position: fixed;
           top:170.79px;
			right:120.96px;
            height: 64.75px;
            width: 161.88px;
    		overflow: hidden;
            border: 1.35px solid gray;
    		background-color: #DFE3E6;
    		font-size: 12.14px;
    		text-align: justify;
    		padding: 10.79px;
        }
    </style>
</head>

<body>
    <form id="emailfeedb" runat="server">
        <div class="emailform" id="eform">
            <asp:Button runat="server" ID="close" CssClass="close" name="close" Text="X" OnClick="close_Click" ToolTip="Close"></asp:Button>
            <asp:Label runat="server" Text="Send an email" Font-Bold="true"></asp:Label>

            <br />
            <br />

            <asp:Panel runat="server" ID="display" CssClass="emailshow">
                <b><%= DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") %></b>

                <br />
                <br />
                <br />

                <asp:Label runat="server" ID="description" CssClass="description" Text="Pick the department listed below that is relevant to the question you want to ask." Font-Bold="true" Font-Italic="true"></asp:Label>
                <br />
                <asp:Label runat="server" Text="To" Font-Bold="true"></asp:Label>
                <asp:DropDownList runat="server" ID="dep" CssClass="dep">
                    <asp:ListItem Value="0">-Select a department-</asp:ListItem>
                    <asp:ListItem Value="1">HR</asp:ListItem>
                    <asp:ListItem Value="2">IT</asp:ListItem>
                    <asp:ListItem Value="3">Finance</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label runat="server" ID="require"></asp:Label>

                <br />
                <br />

                <asp:Label runat="server" Text="Your Email (Optional)" Font-Bold="true"></asp:Label>
                <br />
                <asp:TextBox runat="server" ID="youremail" CssClass="youremail" AutoCompleteType="Disabled"></asp:TextBox>

                <br />
                <br />
                <br />

                <asp:Label runat="server" Text="Subject" Font-Bold="true"></asp:Label>
                <br />
                <asp:TextBox runat="server" ID="subject" CssClass="subject" AutoCompleteType="Disabled"></asp:TextBox>

                <br />
                <br />
                <br />

                <asp:Label runat="server" Text="Message" Font-Bold="true"></asp:Label>
                <br />
                <asp:TextBox runat="server" ID="message" CssClass="message" TextMode="MultiLine" Rows="10"></asp:TextBox>                
            </asp:Panel>
            
            <br />

            <div align="center">
                <asp:Button runat="server" ID="send" CssClass="send" name="send" Text="Send" OnClick="send_Click" ToolTip="Send"></asp:Button>
            </div>
        </div>

        <asp:Panel runat="server" ID="sending" CssClass="sending" Visible="false">
            <asp:Label runat="server" ID="success" Font-Bold="true" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="fail" Font-Bold="true" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="empty" Font-Bold="true" Visible="false"></asp:Label>

            <br />
            <br />

            <div align="center">
                <asp:Button runat="server" ID="okay" CssClass="okay" name="okay" Text="OK" OnClick="ok_Click" ToolTip="OK"></asp:Button>
            </div>
        </asp:Panel>       
    </form>
</body>
</html>
