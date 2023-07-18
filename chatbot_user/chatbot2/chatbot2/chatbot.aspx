<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chatbot.aspx.cs" Inherits="chatbotUser.chatbot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <meta charset = "UTF-8"/>
    <meta name = "viewport" content = "width = device-width, initial-scale = 1.0"/>
    <meta http-equiv = "X-UA-Compatible" content = "ie = edge"/>
	
	<link rel = "stylesheet" href = "https://www.w3schools.com/w3css/4/w3.css"/>
	<link rel = "stylesheet" href = "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>

	<script type = "text/javascript">
		//Function to open the chat
		function toggleChat()
		{
			document.getElementById("cBot").classList.toggle("show");
		}

		//Function to close the chat
		function toggleChat2()
		{
            document.getElementById("cBot").classList.toggle("none");
		}

		//Function to disable the browser's back button
		window.onbeforeunload = window.history.forward(0);
    </script>

	<style>

		body 
		{
			font-family: Tahoma;
		}

		
			.chatb, .closechatb {
				
				position: absolute;
				top: 5px;
				right: 26.98px;
				border: none;
				border-radius: 24.28px;
				width: 55px;
				height: 55px;
				box-shadow: 2.69px 2.69px #86939D;
				background-color: #68ADE2;
				padding: 8.09px;
				transition: all 0.4s;
			}
	
		.chatb:hover
		{
			background-color: #C4E0F6;
		}

		.form-popup
		{
			transform: translate(4%,4%) scale(0);
			position: fixed;
			top: 10.79px;
			width: 296.78px;
			height: 493.73px;
			box-shadow: 1.34px 1.34px #BBCFDD;
			border-radius: 5.39px;
			background-color: #7EBFF1;
			padding: 10.79px;
			font-size: 13.49px;
			right:53.96px;

		}

		.form-popup.show
		{
			transition: all 250ms ease-in-out;
			transform: translate(4%,14%) scale(1);
		}

		.display
		{
			height: 391.21px;
			overflow-y: auto;
			overflow-x: hidden;
			background-color: white;
			font-size:12.14px;
			text-align: justify;
			padding: 10.79px;
		}

		.display::-webkit-scrollbar
		{
			width: 5.39px;
		}

		::-webkit-scrollbar-thumb
		{
			background: #3A586D; 
		}
		
		::-webkit-scrollbar-thumb:hover 
		{
			background: #627F94; 
		}

		.humantb
		{
			overflow: hidden;
            resize: none;
            outline: none;
            width: 253.61px;
            padding: 5.39px;
            border-radius:  5.39px;
            background-color: #C4E0F6;
		}

		.bottb
		{
			overflow: hidden;
            resize: none;
            outline: none;
            width: 253.61px;
            padding:  5.39px;
            border-radius:  5.39px;
            background-color: #C4E0F6;
			text-align: justify;
		}

		.button
		{
			width:78.24px;
            margin-right: 4.05px;
            padding: 2.70px;
            border: 2.70px solid;
            border-radius: 2.70px;
            border-color: #8EAFC8;
            background-color: white;
            font-weight: 600;
            cursor: pointer;
		}

		.solution
		{
            margin-right: 4.05px;
			margin-bottom: 5.40px;
            padding: 2.70px;
            border: 2.70px solid;
            border-radius: 2.70px;
            border-color: #8EAFC8;
            background-color: white;
            font-weight: 600;
            text-align: center;
            text-decoration: none;
            cursor: pointer;
		}

		.cont
		{
			height: 45.86px;
			overflow-y: hidden;
			overflow-x: hidden;
			background-color: #7EBFF1;
			font-size: 10.79px;
			padding: 5.39px;
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
	</style>
</head>

<body>
    <asp:SqlDataSource runat="server" ConnectionString='<%$ ConnectionStrings:chatbotConnectionString %>' SelectCommand="SELECT * FROM [dbKEMChatBot]"></asp:SqlDataSource>
    
    <form id="pop" runat="server">
        <div class="chatbutton">
            <asp:ImageButton runat="server" ID="chatb" CssClass="chatb" name="chatb" ImageUrl="~\chat.png" OnClick="chatb_Click" ToolTip="Ask PauBot"></asp:ImageButton>
			<asp:ImageButton runat="server" ID="closechatb" CssClass="chatb" name="closechatb" ImageUrl="~\chat.png" OnClick="closechatb_Click" ToolTip="Close PauBot" Visible="false"></asp:ImageButton>
        </div>


        <div class="form-popup" id="cBot">
            <asp:Button runat="server" ID="close" CssClass="close" name="close" Text="X" OnClick="close_Click" ToolTip="Clear All"></asp:Button>
            <asp:Label runat="server" Text="Ask here" Font-Bold="true"></asp:Label>

            <br />
            <br />

            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="humansay">
                        <asp:Panel runat="server" ID="display" CssClass="display">
                        </asp:Panel>
                    </div>

                    <asp:Panel runat="server" ID="cont" CssClass="cont">
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

		<div class="email-popup" id="emailpop">
            
		</div>

        <div class="gridview">
            <asp:GridView runat="server" ID="gridv" class="gridv" name="gridv" Visible="false"></asp:GridView>
            <asp:GridView runat="server" ID="gridv2" class="gridv" name="gridv" Visible="false"></asp:GridView>
            <asp:GridView runat="server" ID="gridv3" class="gridv" name="gridv" Visible="false"></asp:GridView>
        </div>
    </form>
</body>
</html>
