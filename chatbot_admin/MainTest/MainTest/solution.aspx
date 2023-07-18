<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="solution.aspx.cs" Inherits="chatbotAdmin.solution" %>

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

        .new
        {
            width: 6em;
            margin-right: 2em;
            padding: 0.6em;
            border: 0.1em solid;
            border-color: #235A8C;
            background-color: white;
            font-weight: 600;
            cursor: pointer;
            font-size: 0.9em;
            float: right;
        }

        .new:enabled:hover
        {            
            background-color: #20486B;
            color: white;
        }
        
        .sol
        {
            padding: 0.6em;
            font-size: 1.2em;
            text-transform: uppercase;
        }

        .categories
        {
            width: 15em;
            padding: 0.6em;
            border: 0.1em solid;
            border-color: #235A8C;
            background-color: white;
            font-weight: 600;
            cursor: pointer;
            font-size: 0.9em;
        }

        .categories:hover
        {            
            background-color: #20486B;
            color: white;
        }

        .gridv
        {
            width: 98%;
        }

        .hcolumn
        {
            height: 1.8em;
            padding: 0.2em;
            font-size: 0.9em;
            background-color: #103356;
            color: white;
        }

        .column
        {
            width: 15%;
            height: 2.4em;
            padding: 0.2em;
            font-size: 0.9em;
        }
                
        .ccolumn
        {
            width: 15%;
            padding: 0.2em;
            font-size: 0.9em;
        }

        .lblt
        {
            width: 28%;
        }

        .lbll
        {
            width: 48%;
        }

        .lbltitle
        {
            width: 96%;
            resize: none;
            outline: none;
            padding: 0.2em;
            border: none;
            font-size: 0.9em;
        }

        .txttitle
        {
            width: 96%;
            overflow-x: hidden;
            overflow-y: auto;
            resize: none;
            outline: none;
            padding: 0.2em;
            border: 0.1em solid gray;
            background-color: transparent;
            font-size: 0.9em;
            font-family: Tahoma;
        }

        .lbllink
        {
            width: 98%;
            overflow-x: hidden;
            overflow-y: auto;
            resize: none;
            outline: none;
            padding: 0.2em;
            border: none;
            background-color: transparent;
            font-size: 0.9em;
            font-family: Tahoma;
        }

        .txtlink
        {
            width: 98%;
            overflow-x: hidden;
            overflow-y: auto;
            resize: none;
            outline: none;
            padding: 0.2em;
            border: 0.1em solid gray;
            background-color: transparent;
            font-size: 0.9em;
            font-family: Tahoma;
        }

        .txtlink::-webkit-scrollbar, .lbllink::-webkit-scrollbar
		{
			width: 0.4em;
		}

		::-webkit-scrollbar-thumb
		{
			background: #3A586D; 
		}
		
		::-webkit-scrollbar-thumb:hover 
		{
			background: #627F94; 
		}

        .addslt
        {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            width: fit-content;
            padding: 1em;
            border: none;
            background-image: linear-gradient(#B4D3F3, #86BBF0);
        }

        .newform 
        {
            height: fit-content;
    		width: fit-content;
    		background-color: white;
    		padding: 1.2em;
    		font-size: 0.9em;
    	}

        .close
		{
			float: right;
			border: none;
			background-color: transparent;
			font-size: 0.9em;
			font-weight: 800;
			transition: all 0.2s;
		}

		.close:hover 
		{
			color: #FFFEF0;
		}
        
        .cat
        {
            outline: none;
            height: 2.2em;
            padding: 0.2em;
            border: none;
            border-bottom: 0.1em solid gray;
        }

        .title
		{
            resize: none;
            outline: none;
            height: 1.4em;
            width: 25em;
            padding: 0.4em;
            border: none;
            border-bottom: 0.1em solid gray;
            background-color: white;
		}

        .link
        {
            resize: none;
            outline: none;
            width: 25em;
            padding: 0.2em;
            border: 0.1em solid gray;
            border-radius: 0.2em;
            font-family: Tahoma;
            text-align: justify;
        }

        .title:focus, .link:focus
        {
            border-bottom: 0.1em solid blue;
        }
        
        .link::-webkit-scrollbar
		{
			width: 0.3em;
		}

		::-webkit-scrollbar-thumb
		{
			background: #3A586D; 
		}
		
		::-webkit-scrollbar-thumb:hover 
		{
			background: #627F94; 
		}

        .add
        {
            width: 5.8em;
            padding: 0.4em;
            border: 0.1em solid;
            border-radius: 0.2em;
            border-color: #8EAFC8;
            background-color: white;
            font-weight: 600;
            cursor: pointer;
        }
                
        .add:hover
        {            
            background-color: #4F6D83;
            color: white;
        }

        .require, .ttexist
        {
            font-size: 0.8em;
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
                <li><asp:Button runat="server" ID="signout" class="hnav" Text="Sign Out" OnClick="signout2_Click"></asp:Button></li>
            </ul>
        </div>

        <br />

        <div class="margin">
            <asp:Panel runat="server" ID="slttry"></asp:Panel>
            <asp:Panel runat="server" ID="sltpage" CssClass="sltpage">
                <asp:Button runat="server" ID="news" CssClass="new" Text="New" OnClick="new_Click"></asp:Button>
                <asp:Label runat="server" ID="sol" CssClass="sol" Text="Categories" Font-Bold="true"></asp:Label>                
                
                <br />
                <br />

                <%/* Add on category here */ %>
                <asp:Button runat="server" ID="cat1" CssClass="categories" OnClick="cat1_Click"></asp:Button>
                <asp:Button runat="server" ID="cat2" CssClass="categories" OnClick="cat2_Click"></asp:Button>
                <asp:Button runat="server" ID="cat3" CssClass="categories" OnClick="cat3_Click"></asp:Button>

                <br />
                <br />
                <br />

                <div class="gridview">
                    <% if (Session["cat"] == null)
                        {
                            Session["cat"] = 1;
                        }
                        else if ((int)Session["cat"] == 1)
                        { %>
                    <asp:GridView runat="server" ID="gridv" CssClass="gridv" name="gridv" DataKeyNames="SolutionID, SolutionCategory" AutoGenerateColumns="false" AllowPaging="true" OnRowEditing="gridv_RowEditing" OnRowUpdating="gridv_RowUpdating" OnRowDeleting="gridv_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="SID" HeaderStyle-CssClass="hcolumn" ItemStyle-HorizontalAlign="Center" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="oid" CssClass="oid" Text='<%#Eval("SolutionID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Category" HeaderStyle-CssClass="hcolumn" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="ocategory" CssClass="ccolumn" Text='<%#Eval("SolutionCategory") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Title" HeaderStyle-CssClass="hcolumn" ItemStyle-CssClass="lblt" ItemStyle-HorizontalAlign="Center">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="otitle" CssClass="txttitle" Text='<%#Bind("SolutionTitle") %>' />
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:Label runat="server" ID="ltitle" CssClass="lbltitle" Text='<%#Bind("SolutionTitle") %>' />
                                </ItemTemplate>
                                
                                <FooterTemplate>
                                    <asp:TextBox ID="ftitle" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfvtitle" runat="server" ControlToValidate="ftitle" Text="*" ValidationGroup="validation" />
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="URL" HeaderStyle-CssClass="hcolumn" ItemStyle-CssClass="lbll" ItemStyle-HorizontalAlign="Center">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="olink" CssClass="txtlink" Text='<%#Bind("SolutionLink") %>' TextMode="MultiLine" Rows="2" />
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="llink" CssClass="lbllink" Text='<%#Bind("SolutionLink") %>' TextMode="MultiLine" Rows="2" Enabled="false" />
                                </ItemTemplate>

                                <FooterTemplate>
                                    <asp:TextBox ID="flink" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfvlink" runat="server" ControlToValidate="flink" Text="*" ValidationGroup="validation" />
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="hcolumn" ItemStyle-CssClass="column" ItemStyle-HorizontalAlign="Center">
                                <EditItemTemplate>
                                    <asp:Label Text="Click the column that you want to edit" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label>
                                    <br />
                                    <asp:LinkButton Text="Update" runat="server" CommandName="Update" CausesValidation="true" />
                                    <asp:LinkButton Text="Cancel" runat="server" OnClick="OnCancel_Click" />
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:LinkButton Text="Edit" runat="server" CommandName="Edit" />
                                    <asp:LinkButton Text="Delete" runat="server" CommandName="Delete" OnClientClick="return confirm('Confirm to delete this?');" />
                                </ItemTemplate>                                
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <%}
                        else if ((int)Session["cat"] == 2)
                        { %>
                    <asp:GridView runat="server" ID="gridv2" CssClass="gridv" name="gridv2" DataKeyNames="SolutionID, SolutionCategory" AutoGenerateColumns="false" AllowPaging="true" OnRowEditing="gridv_RowEditing" OnRowUpdating="gridv_RowUpdating2" OnRowDeleting="gridv_RowDeleting2">
                        <Columns>
                            <asp:TemplateField HeaderText="SID" HeaderStyle-CssClass="hcolumn" ItemStyle-HorizontalAlign="Center" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="oid" CssClass="oid" Text='<%#Eval("SolutionID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Category" HeaderStyle-CssClass="hcolumn" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="ocategory" CssClass="ccolumn" Text='<%#Eval("SolutionCategory") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Title" HeaderStyle-CssClass="hcolumn" ItemStyle-CssClass="lblt" ItemStyle-HorizontalAlign="Center">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="otitle" CssClass="txttitle" Text='<%#Bind("SolutionTitle") %>' />
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:Label runat="server" ID="ltitle" CssClass="lbltitle" Text='<%#Bind("SolutionTitle") %>' />
                                </ItemTemplate>
                                
                                <FooterTemplate>
                                    <asp:TextBox ID="ftitle" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfvtitle" runat="server" ControlToValidate="ftitle" Text="*" ValidationGroup="validation" />
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="URL" HeaderStyle-CssClass="hcolumn" ItemStyle-CssClass="lbll" ItemStyle-HorizontalAlign="Center">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="olink" CssClass="txtlink" Text='<%#Bind("SolutionLink") %>' TextMode="MultiLine" Rows="2" />
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="llink" CssClass="lbllink" Text='<%#Bind("SolutionLink") %>' TextMode="MultiLine" Rows="2" Enabled="false" />
                                </ItemTemplate>

                                <FooterTemplate>
                                    <asp:TextBox ID="flink" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfvlink" runat="server" ControlToValidate="flink" Text="*" ValidationGroup="validation" />
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="hcolumn" ItemStyle-CssClass="column" ItemStyle-HorizontalAlign="Center">
                                <EditItemTemplate>
                                    <asp:Label Text="Click the column that you want to edit" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label>
                                    <br />
                                    <asp:LinkButton Text="Update" runat="server" CommandName="update" />
                                    <asp:LinkButton Text="Cancel" runat="server" OnClick="OnCancel_Click" />
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:LinkButton Text="Edit" runat="server" CommandName="Edit" />
                                    <asp:LinkButton Text="Delete" runat="server" CommandName="Delete" OnClientClick="return confirm('Confirm to delete this?');" />
                                </ItemTemplate>                                
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <%}
                        else if ((int)Session["cat"] == 3)
                        { %>
                    <asp:GridView runat="server" ID="gridv3" CssClass="gridv" name="gridv3"  DataKeyNames="SolutionID, SolutionCategory" AutoGenerateColumns="false" AllowPaging="true" OnRowEditing="gridv_RowEditing" OnRowUpdating="gridv_RowUpdating3" OnRowDeleting="gridv_RowDeleting3">
                        <Columns>
                            <asp:TemplateField HeaderText="SID" HeaderStyle-CssClass="hcolumn" ItemStyle-HorizontalAlign="Center" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="oid" CssClass="oid" Text='<%#Eval("SolutionID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Category" HeaderStyle-CssClass="hcolumn" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="ocategory" CssClass="ccolumn" Text='<%#Eval("SolutionCategory") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Title" HeaderStyle-CssClass="hcolumn" ItemStyle-CssClass="lblt" ItemStyle-HorizontalAlign="Center">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="otitle" CssClass="txttitle" Text='<%#Bind("SolutionTitle") %>' />
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:Label runat="server" ID="ltitle" CssClass="lbltitle" Text='<%#Bind("SolutionTitle") %>' />
                                </ItemTemplate>
                                
                                <FooterTemplate>
                                    <asp:TextBox ID="ftitle" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfvtitle" runat="server" ControlToValidate="ftitle" Text="*" ValidationGroup="validation" />
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="URL" HeaderStyle-CssClass="hcolumn" ItemStyle-CssClass="lbll" ItemStyle-HorizontalAlign="Center">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="olink" CssClass="txtlink" Text='<%#Bind("SolutionLink") %>' TextMode="MultiLine" Rows="2" />
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="llink" CssClass="lbllink" Text='<%#Bind("SolutionLink") %>' TextMode="MultiLine" Rows="2" Enabled="false" />
                                </ItemTemplate>

                                <FooterTemplate>
                                    <asp:TextBox ID="flink" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfvlink" runat="server" ControlToValidate="flink" Text="*" ValidationGroup="validation" />
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="hcolumn" ItemStyle-CssClass="column" ItemStyle-HorizontalAlign="Center">
                                <EditItemTemplate>
                                    <asp:Label Text="Click the column that you want to edit" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label>
                                    <br />
                                    <asp:LinkButton Text="Update" runat="server" CommandName="update" />
                                    <asp:LinkButton Text="Cancel" runat="server" OnClick="OnCancel_Click" />
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:LinkButton Text="Edit" runat="server" CommandName="Edit" />
                                    <asp:LinkButton Text="Delete" runat="server" CommandName="Delete" OnClientClick="return confirm('Confirm to delete this?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <%} %>
                </div>
            </asp:Panel>

            <asp:Panel runat="server" ID="addslt" CssClass="addslt" Visible="false">
                <div class="newform" id="nform">
                    <asp:Button runat="server" ID="close" CssClass="close" name="close" Text="X" OnClick="close_Click" ToolTip="Close"></asp:Button>
                    <asp:Label runat="server" Text="Add New Solution" Font-Bold="true"></asp:Label>

                    <br />
                    <br />

                    <b><%= DateTime.Now.ToString("dd/M/yyyy h:mm tt") %></b>

                    <br />
                    <br />
                    <br />
                                        
                    <asp:Label runat="server" Text="Category" Font-Bold="true"></asp:Label>
                    <br />
                    <% /* Add more list item here if got add on new category and change the list item value */
                        if (Session["udep"].ToString() == "HR")
                        { %>
                    <asp:DropDownList runat="server" ID="hrcat" CssClass="cat">                        
                        <asp:ListItem Value="0" Text="-Select a category-"></asp:ListItem>
                        <asp:ListItem Value="Leave" Text="Leave"></asp:ListItem>
                        <asp:ListItem Value="Payroll" Text="Payroll"></asp:ListItem>
                        <asp:ListItem Value="General" Text="General"></asp:ListItem>
                    </asp:DropDownList>
                    <%}
                        else if (Session["udep"].ToString() == "IT")
                        { %>
                    <asp:DropDownList runat="server" ID="itcat" CssClass="cat">                        
                        <asp:ListItem Value="0" Text="-Select a category-"></asp:ListItem>
                        <asp:ListItem Value="Hardware" Text="Hardware"></asp:ListItem>
                        <asp:ListItem Value="Network" Text="Network"></asp:ListItem>
                        <asp:ListItem Value="General" Text="General"></asp:ListItem>
                    </asp:DropDownList>
                    <%}
                        else if (Session["udep"].ToString() == "Finance")
                        { %>
                    <asp:DropDownList runat="server" ID="fncat" CssClass="cat">                        
                        <asp:ListItem Value="0" Text="-Select a category-"></asp:ListItem>
                        <asp:ListItem Value="Business" Text="Business"></asp:ListItem>
                        <asp:ListItem Value="Fund" Text="Fund"></asp:ListItem>
                        <asp:ListItem Value="General" Text="General"></asp:ListItem>
                    </asp:DropDownList>
                    <%} %>
                    <br />
                    <asp:Label runat="server" ID="require" CssClass="require"></asp:Label>

                    <br />
                    <br />

                    <asp:Label runat="server" Text="Solution Title" Font-Bold="true"></asp:Label>
                    <br />
                    <asp:TextBox runat="server" ID="ntitle" CssClass="title" AutoCompleteType="Disabled"></asp:TextBox>
                    <br />
                    <asp:Label runat="server" ID="ttexist" CssClass="require"></asp:Label>

                    <br />
                    <br />
                    <br />

                    <asp:Label runat="server" Text="Links/Paths" Font-Bold="true"></asp:Label>
                    <br />
                    <asp:TextBox runat="server" ID="nlink" CssClass="link" TextMode="MultiLine" Rows="4"></asp:TextBox>

                    <br />
                    <br />
                    <br />

                    <div align="center">
                        <asp:Button runat="server" ID="add" CssClass="add" name="add" Text="Add" OnClick="add_Click" ToolTip="Add"></asp:Button>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
