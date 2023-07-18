using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Text;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Diagnostics.Eventing.Reader;
using System.Data.Common;
using System.Web.Services.Description;
using System.Net;
using System.Net.Mail;

/*
 Things to change:
- Categories (Declare category button, 1st part: If else statement with session,2nd part: Change session value, variable name)
 */

namespace chatbotUser
{
    public partial class chatbot : System.Web.UI.Page
    {
        //Declare the variables
        //SQL
        SqlConnection conn;
        SqlCommand hrdep, itdep, fdep, Ghr, Git, Gf, cathr, catit, catfn;

        int choice, cat;
        int i = 0;

        //Labels Button
        Label h1 = new Label();
        Label h2 = new Label();
        Label h3 = new Label();
        Label b1 = new Label();
        Label b2 = new Label();
        Label b3 = new Label();
        Label b4 = new Label();

        //Textboxes Button
        TextBox tb1 = new TextBox();
        TextBox tb2 = new TextBox();
        TextBox tb3 = new TextBox();
        TextBox tb4 = new TextBox();
        TextBox tb5 = new TextBox();
        TextBox tb7 = new TextBox();
        TextBox tb8 = new TextBox();
        TextBox tb9 = new TextBox();
        HtmlTextArea tb6 = new HtmlTextArea();

        //Departments Button
        Button hrd = new Button();
        Button itd = new Button();
        Button fnd = new Button();


        /* --- May declare more for more categories --- */
        //Category Button
        Button hrc1 = new Button();
        Button hrc2 = new Button();
        Button itc1 = new Button();
        Button itc2 = new Button();
        Button fnc1 = new Button();
        Button fnc2 = new Button();
        Button general = new Button();

        //Continue Button
        Button byes = new Button();
        Button byes1 = new Button();

        //Email Button
        Button email = new Button();


        protected void Page_Load(object sender, EventArgs e)
        {
            //Connect to database - make changes here (Data Source and Initial Catalog)
            conn = new SqlConnection(@"Data Source=HOTSQLT01\KEMSQLT01;Initial Catalog=dbKEMChatBot;User ID=dbKEMChatBotUser;Password=dbKEMChatBotUser#12t");

            display_data();

            System.Threading.Thread.Sleep(300);


            if (Session["continue"] != null)
            {
                string script = "window.onload = function() { toggleChat(); };";
                ClientScript.RegisterStartupScript(this.GetType(), "toggleChat", script, true);

                closechatb.Visible = true;
                chatb.Visible = false;
            }

            botMsg1();

            userMsg1();
            botMsg2();

            userMsg2();
            botMsg3();


            /* --- Change here if add on or edit the category buttons --- */
            //Run the button events based on the session
            if (Session["cat"] == null)
            {
                Session["cat"] = 0;
            }
            else if ((int)Session["cat"] == 1) //HR
            {
                //HR Category 1
                hrc1_Click(sender, e);
            }
            else if ((int)Session["cat"] == 2) //HR
            {
                //HR Category 2
                hrc2_Click(sender, e);
            }
            else if ((int)Session["cat"] == 3) //IT
            {
                //IT Category 1
                itc1_Click(sender, e);
            }
            else if ((int)Session["cat"] == 4) //IT
            {
                //IT Category 2
                itc2_Click(sender, e);
            }
            else if ((int)Session["cat"] == 5) //Finance
            {
                //Finance Category 1
                fnc1_Click(sender, e);
            }
            else if ((int)Session["cat"] == 6) //Finance
            {
                //Finance Category 2
                fnc2_Click(sender, e);
            }
            else if ((int)Session["cat"] == 7) //General
            {
                //General Category
                genc_Click(sender, e);
            }

            //Continue to new session
            botExtra();
        }



        /* --- 1st part - asking for the department --- */
        //Show bot's message and list out the departments
        public void botMsg1()
        {
            b1.Font.Bold = true;
            b1.Text = "PauBot: ";

            display.Controls.Add(b1);

            //First message - Display the welcoming message and instruction for users
            tb1.ID = "tb1";
            tb1.Rows = 2;
            tb1.CssClass = "bottb";
            tb1.TextMode = TextBoxMode.MultiLine;
            tb1.BorderStyle = BorderStyle.None;
            tb1.ReadOnly = true;
            tb1.Text = "Welcome! PauBot here. Please choose the department that corresponds to your inquiry.";

            display.Controls.Add(tb1);

            //HR Button
            hrd.ID = "hrd";
            hrd.CssClass = "button";
            hrd.BorderStyle = BorderStyle.Solid;
            hrd.Text = "HR";

            hrd.Click += new EventHandler(this.hrd_Click);
            display.Controls.Add(hrd);

            //IT Button
            itd.ID = "itd";
            itd.CssClass = "button";
            itd.BorderStyle = BorderStyle.Solid;
            itd.Text = "IT";

            itd.Click += new EventHandler(this.itd_Click);
            display.Controls.Add(itd);

            //Finance Button
            fnd.ID = "fnd";
            fnd.CssClass = "button";
            fnd.BorderStyle = BorderStyle.Solid;
            fnd.Text = "Finance";

            fnd.Click += new EventHandler(this.fnd_Click);
            display.Controls.Add(fnd);
        }

        /* To disabled the department buttons & set the category buttons to be visibled */
        //HR department button
        private void hrd_Click(object sender, EventArgs e)
        {
            choice = 1;
            Session["choice"] = choice;

            tb2.Text = hrd.Text;

            hrd.Enabled = false;
            itd.Enabled = false;
            fnd.Enabled = false;
            hrd.Style["background-color"] = "#4D8BBB";

            h1.Visible = true;
            b2.Visible = true;
            tb2.Visible = true;
            tb3.Visible = true;
            hrc1.Visible = true;
            hrc2.Visible = true;
            general.Visible = true;
        }

        //IT department button
        private void itd_Click(object sender, EventArgs e)
        {
            choice = 2;
            Session["choice"] = choice;

            tb2.Text = itd.Text;

            hrd.Enabled = false;
            itd.Enabled = false;
            fnd.Enabled = false;
            itd.Style["background-color"] = "#4D8BBB";

            h1.Visible = true;
            b2.Visible = true;
            tb2.Visible = true;
            tb3.Visible = true;
            itc1.Visible = true;
            itc2.Visible = true;
            general.Visible = true;
        }

        //Finance department button
        private void fnd_Click(object sender, EventArgs e)
        {
            choice = 3;
            Session["choice"] = choice;

            tb2.Text = fnd.Text;

            hrd.Enabled = false;
            itd.Enabled = false;
            fnd.Enabled = false;
            fnd.Style["background-color"] = "#4D8BBB";

            h1.Visible = true;
            b2.Visible = true;
            tb2.Visible = true;
            tb3.Visible = true;
            fnc1.Visible = true;
            fnc2.Visible = true;
            general.Visible = true;
        }



        /* --- 2nd part - asking for the category --- */
        //Show user's message
        public void userMsg1()
        {
            h1.Font.Bold = true;
            h1.Text = "<br /><br />" + "You: ";

            h1.Visible = false;
            display.Controls.Add(h1);

            //Second message - Display the department selected by users
            tb2.ID = "tb2";
            tb2.Rows = 1;
            tb2.CssClass = "humantb";
            tb2.BorderStyle = BorderStyle.None;
            tb2.ReadOnly = true;

            tb2.Visible = false;
            display.Controls.Add(tb2);
        }

        /* Set the properties of the categories in this part */
        //Show bot's message and list out the categories
        public void botMsg2()
        {
            b2.Font.Bold = true;
            b2.Text = "<br /><br />" + "PauBot: ";

            b2.Visible = false;
            display.Controls.Add(b2);

            //Third message - Display the next instruction for users
            tb3.ID = "tb3";
            tb3.Rows = 2;
            tb3.CssClass = "bottb";
            tb3.TextMode = TextBoxMode.MultiLine;
            tb3.BorderStyle = BorderStyle.None;
            tb3.ReadOnly = true;
            tb3.Text = "Ok. Would you mind letting me know which category you want to go on to?";

            tb3.Visible = false;
            display.Controls.Add(tb3);

            /* --- May change the button text here or add on buttons --- */
            //Category Button
            //HR Category 1
            hrc1.ID = "hrc1"; //change the ID
            hrc1.Style["margin-bottom"] = "5.396px";
            hrc1.CssClass = "button";
            hrc1.BorderStyle = BorderStyle.Solid;
            hrc1.Text = "Leave"; //change the text shown

            hrc1.Visible = false;
            hrc1.Click += new EventHandler(this.hrc1_Click);
            display.Controls.Add(hrc1);

            //HR Category 2
            hrc2.ID = "hrc2"; //change the ID
            hrc2.Style["margin-bottom"] = "5.396px";
            hrc2.CssClass = "button";
            hrc2.BorderStyle = BorderStyle.Solid;
            hrc2.Text = "Payroll"; //change the text shown

            hrc2.Visible = false;
            hrc2.Click += new EventHandler(this.hrc2_Click);
            display.Controls.Add(hrc2);

            //May add on new HR category here

            //IT Category 1
            itc1.ID = "itc1"; //change the ID
            itc1.Style["margin-bottom"] = "5.396px";
            itc1.CssClass = "button";
            itc1.BorderStyle = BorderStyle.Solid;
            itc1.Text = "Hardware"; //change the text shown

            itc1.Visible = false;
            itc1.Click += new EventHandler(this.itc1_Click);
            display.Controls.Add(itc1);

            //IT Category 2
            itc2.ID = "itc2"; //change the ID
            itc2.Style["margin-bottom"] = "5.396px";
            itc2.CssClass = "button";
            itc2.BorderStyle = BorderStyle.Solid;
            itc2.Text = "Network"; //change the text shown

            itc2.Visible = false;
            itc2.Click += new EventHandler(this.itc2_Click);
            display.Controls.Add(itc2);

            //May add on new IT category here

            //Finance Category 1
            fnc1.ID = "fnc1"; //change the ID
            fnc1.Style["margin-bottom"] = "5.396px";
            fnc1.CssClass = "button";
            fnc1.BorderStyle = BorderStyle.Solid;
            fnc1.Text = "Business"; //change the text shown

            fnc1.Visible = false;
            fnc1.Click += new EventHandler(this.fnc1_Click);
            display.Controls.Add(fnc1);

            //Finance Category 2
            fnc2.ID = "fnc2"; //change the ID
            fnc2.Style["margin-bottom"] = "5.396px";
            fnc2.CssClass = "button";
            fnc2.BorderStyle = BorderStyle.Solid;
            fnc2.Text = "Fund"; //change the text shown

            fnc2.Visible = false;
            fnc2.Click += new EventHandler(this.fnc2_Click);
            display.Controls.Add(fnc2);

            //May add on new Finance category here

            //General Category
            general.ID = "general";
            general.Style["margin-bottom"] = "5.396px";
            general.CssClass = "button";
            general.BorderStyle = BorderStyle.Solid;
            general.Text = "General";

            general.Visible = false;
            general.Click += new EventHandler(this.genc_Click);
            display.Controls.Add(general);
        }



        /* --- 3rd part - ask user to select the solution needed  --- */
        //Show user's message
        public void userMsg2()
        {
            h2.Font.Bold = true;
            h2.Text = "<br /><br />" + "You: ";

            h2.Visible = false;
            display.Controls.Add(h2);

            //Fourth message - Display the category selected by users
            tb4.ID = "tb4";
            tb4.Rows = 1;
            tb4.CssClass = "humantb";
            tb4.BorderStyle = BorderStyle.None;
            tb4.ReadOnly = true;

            tb4.Visible = false;
            display.Controls.Add(tb4);
        }

        //Show bot's message before list out the solutions
        public void botMsg3()
        {
            b3.Font.Bold = true;
            b3.Text = "<br /><br />" + "PauBot: ";

            b3.Visible = false;
            display.Controls.Add(b3);

            //Fifth message - Display the following instruction after selecting the category
            tb5.ID = "tb5";
            tb5.Rows = 2;
            tb5.CssClass = "bottb";
            tb5.TextMode = TextBoxMode.MultiLine;
            tb5.BorderStyle = BorderStyle.None;
            tb5.ReadOnly = true;
            tb5.Text = "Noted. Please pick the option that will be most helpful to you.";

            tb5.Visible = false;
            display.Controls.Add(tb5);

            //Sixth message - Display the following instruction after selecting the category
            tb6.ID = "tb6";
            tb6.Cols = 38;
            tb6.Rows = 4;
            tb6.Style["overflow"] = "auto";
            tb6.Style["resize"] = "none";
            tb6.Style["outline"] = "none";
            tb6.Style["width"] = "253.612px";
            tb6.Style["padding"] = "5.396px";
            tb6.Style["border-radius"] = "5.396px";
            tb6.Style["background-color"] = "#C4E0F6";
            tb6.Style["border"] = "none";
            tb6.Attributes.Add("readonly", "readonly");

            tb6.Visible = false;
            display.Controls.Add(tb6);
        }

        /* Retrieve admin's message from database & retrieve the solutions from the database */
        //HR category
        private void hrc1_Click(object sender, EventArgs e)
        {
            cat = 1; //change the value for new category
            Session["cat"] = cat;

            hrc1.Enabled = false;
            hrc2.Enabled = false;
            general.Enabled = false;
            hrc1.Style["background-color"] = "#4D8BBB";

            h2.Visible = true;
            b3.Visible = true;
            tb4.Visible = true;
            tb5.Visible = true;
            tb6.Visible = true;
            tb7.Visible = true;
            email.Visible = true;

            //Connect to messageadmin database and retrieve the data
            conn.Open();
            cathr = new SqlCommand("SELECT * FROM messageAdmin WHERE msgCategory = '" + hrc1.Text + "' AND msgDepartment = '" + hrd.Text + "'", conn); //change the variable name(e.g: hrc1)
            SqlDataReader Chrsrd = cathr.ExecuteReader();

            while (Chrsrd.Read())
            {
                tb6.Value = Chrsrd.GetString(1).ToString();
            }
            conn.Close();


            //Connect to HR database and retrieve the data
            conn.Open();
            hrdep = new SqlCommand("SELECT * FROM solutionHR WHERE SolutionCategory = '" + hrc1.Text + "'", conn); //change the variable name(e.g: hrc1)
            SqlDataReader Shrsrd = hrdep.ExecuteReader();

            tb4.Text = hrc1.Text; //change the variable name(e.g: hrc1)

            while (Shrsrd.Read())
            {
                i++;

                HyperLink hslt1 = new HyperLink(); //change the variable name(e.g: hslt1)
                hslt1.ID = "solution" + i;
                hslt1.CssClass = "solution";
                hslt1.BorderStyle = BorderStyle.Solid;
                hslt1.Text = Shrsrd.GetString(2).ToString();
                hslt1.NavigateUrl = Shrsrd.GetString(3).ToString();
                hslt1.Target = "_blank";

                display.Controls.Add(hslt1); //change the variable name(e.g: hslt1)
                ScriptManager1.SetFocus(hslt1);
            }
            conn.Close();
        }

        private void hrc2_Click(object sender, EventArgs e)
        {
            cat = 2;
            Session["cat"] = cat;

            hrc1.Enabled = false;
            hrc2.Enabled = false;
            general.Enabled = false;
            hrc2.Style["background-color"] = "#4D8BBB";

            h2.Visible = true;
            b3.Visible = true;
            tb4.Visible = true;
            tb5.Visible = true;
            tb6.Visible = true;
            tb7.Visible = true;
            email.Visible = true;

            //Connect to messageadmin database and retrieve the data
            conn.Open();
            cathr = new SqlCommand("SELECT * FROM messageAdmin WHERE msgCategory = '" + hrc2.Text + "' AND msgDepartment = '" + hrd.Text + "'", conn); //change the variable name(e.g: hrc2)
            SqlDataReader Chrsrd = cathr.ExecuteReader();

            while (Chrsrd.Read())
            {
                tb6.Value = Chrsrd.GetString(1).ToString();
            }
            conn.Close();


            //Connect to HR database and retrieve the data
            conn.Open();
            hrdep = new SqlCommand("SELECT * FROM solutionHR WHERE SolutionCategory = '" + hrc2.Text + "'", conn); //change the variable name(e.g: hrc2)
            SqlDataReader Shrsrd = hrdep.ExecuteReader();

            tb4.Text = hrc2.Text; //change the variable name(e.g: hrc2)

            while (Shrsrd.Read())
            {
                i++;

                HyperLink hslt2 = new HyperLink(); //change the variable name(e.g: hslt2)
                hslt2.ID = "solution" + i;
                hslt2.CssClass = "solution";
                hslt2.BorderStyle = BorderStyle.Solid;
                hslt2.Text = Shrsrd.GetString(2).ToString();
                hslt2.NavigateUrl = Shrsrd.GetString(3).ToString();
                hslt2.Target = "_blank";

                display.Controls.Add(hslt2); //change the variable name(e.g: hslt2)
                ScriptManager1.SetFocus(hslt2);
            }
            conn.Close();
        }


        //IT category
        private void itc1_Click(object sender, EventArgs e)
        {
            cat = 3; //change the value for new category
            Session["cat"] = cat;

            itc1.Enabled = false;
            itc2.Enabled = false;
            general.Enabled = false;
            itc1.Style["background-color"] = "#4D8BBB";

            h2.Visible = true;
            b3.Visible = true;
            tb4.Visible = true;
            tb5.Visible = true;
            tb6.Visible = true;
            tb7.Visible = true;
            email.Visible = true;

            //Connect to messageadmin database and retrieve the data
            conn.Open();
            catit = new SqlCommand("SELECT * FROM messageAdmin WHERE msgCategory = '" + itc1.Text + "' AND msgDepartment = '" + itd.Text + "'", conn); //change the variable name(e.g: hrc1)
            SqlDataReader Citsrd = catit.ExecuteReader();

            while (Citsrd.Read())
            {
                tb6.Value = Citsrd.GetString(1).ToString();
            }
            conn.Close();


            //Connect to IT database and retrieve the data
            conn.Open();
            itdep = new SqlCommand("SELECT * FROM solutionIT WHERE SolutionCategory = '" + itc1.Text + "'", conn); //change the variable name(e.g: itc1)
            SqlDataReader Sitsrd = itdep.ExecuteReader();

            tb4.Text = itc1.Text; //change the variable name(e.g: itc1)

            while (Sitsrd.Read())
            {
                i++;

                HyperLink islt1 = new HyperLink(); //change the variable name(e.g: islt1)
                islt1.ID = "solution" + i;
                islt1.CssClass = "solution";
                islt1.BorderStyle = BorderStyle.Solid;
                islt1.Text = Sitsrd.GetString(2).ToString();
                islt1.NavigateUrl = Sitsrd.GetString(3).ToString();
                islt1.Target = "_blank";

                display.Controls.Add(islt1); //change the variable name(e.g: islt1)
                ScriptManager1.SetFocus(islt1);
            }
            conn.Close();
        }

        private void itc2_Click(object sender, EventArgs e)
        {
            cat = 4;
            Session["cat"] = cat;

            itc1.Enabled = false;
            itc2.Enabled = false;
            general.Enabled = false;
            itc2.Style["background-color"] = "#4D8BBB";

            h2.Visible = true;
            b3.Visible = true;
            tb4.Visible = true;
            tb5.Visible = true;
            tb6.Visible = true;
            tb7.Visible = true;
            email.Visible = true;

            //Connect to messageadmin database and retrieve the data
            conn.Open();
            catit = new SqlCommand("SELECT * FROM messageAdmin WHERE msgCategory = '" + itc2.Text + "' AND msgDepartment = '" + itd.Text + "'", conn); //change the variable name(e.g: itc2)
            SqlDataReader Citsrd = catit.ExecuteReader();

            while (Citsrd.Read())
            {
                tb6.Value = Citsrd.GetString(1).ToString();
            }
            conn.Close();


            //Connect to IT database and retrieve the data
            conn.Open();
            itdep = new SqlCommand("SELECT * FROM solutionIT WHERE SolutionCategory = '" + itc2.Text + "'", conn); //change the variable name(e.g: itc2)
            SqlDataReader Sitsrd = itdep.ExecuteReader();

            tb4.Text = itc2.Text; //change the variable name(e.g: itc2)

            while (Sitsrd.Read())
            {
                i++;

                HyperLink islt2 = new HyperLink(); //change the variable name(e.g: islt2)
                islt2.ID = "solution" + i;
                islt2.CssClass = "solution";
                islt2.BorderStyle = BorderStyle.Solid;
                islt2.Text = Sitsrd.GetString(2).ToString();
                islt2.NavigateUrl = Sitsrd.GetString(3).ToString();
                islt2.Target = "_blank";

                display.Controls.Add(islt2); //change the variable name(e.g: islt2)
                ScriptManager1.SetFocus(islt2);
            }
            conn.Close();
        }


        //Finance category
        private void fnc1_Click(object sender, EventArgs e)
        {
            cat = 5; //change the value for new category
            Session["cat"] = cat;

            fnc1.Enabled = false;
            fnc2.Enabled = false;
            general.Enabled = false;
            fnc1.Style["background-color"] = "#4D8BBB";

            h2.Visible = true;
            b3.Visible = true;
            tb4.Visible = true;
            tb5.Visible = true;
            tb6.Visible = true;
            tb7.Visible = true;
            email.Visible = true;

            //Connect to messageadmin database and retrieve the data
            conn.Open();
            catfn = new SqlCommand("SELECT * FROM messageAdmin WHERE msgCategory = '" + fnc1.Text + "' AND msgDepartment = '" + fnd.Text + "'", conn); //change the variable name(e.g: hrc1)
            SqlDataReader Cfnsrd = catfn.ExecuteReader();

            while (Cfnsrd.Read())
            {
                tb6.Value = Cfnsrd.GetString(1).ToString();
            }
            conn.Close();


            //Connect to Finance database and retrieve the data
            conn.Open();
            fdep = new SqlCommand("SELECT * FROM solutionFinance WHERE SolutionCategory = '" + fnc1.Text + "'", conn); //change the variable name(e.g: fnc1)
            SqlDataReader Sfnsrd = fdep.ExecuteReader();

            tb4.Text = fnc1.Text; //change the variable name(e.g: fnc1)

            while (Sfnsrd.Read())
            {
                i++;

                HyperLink fslt1 = new HyperLink(); //change the variable name(e.g: fslt1)
                fslt1.ID = "solution" + i;
                fslt1.CssClass = "solution";
                fslt1.BorderStyle = BorderStyle.Solid;
                fslt1.Text = Sfnsrd.GetString(2).ToString();
                fslt1.NavigateUrl = Sfnsrd.GetString(3).ToString();
                fslt1.Target = "_blank";

                display.Controls.Add(fslt1); //change the variable name(e.g: fslt1)
                ScriptManager1.SetFocus(fslt1);
            }
            conn.Close();
        }

        private void fnc2_Click(object sender, EventArgs e)
        {
            cat = 6; //change the value for new category
            Session["cat"] = cat;

            fnc1.Enabled = false;
            fnc2.Enabled = false;
            general.Enabled = false;
            fnc2.Style["background-color"] = "#4D8BBB";

            h2.Visible = true;
            b3.Visible = true;
            tb4.Visible = true;
            tb5.Visible = true;
            tb6.Visible = true;
            tb7.Visible = true;
            email.Visible = true;

            //Connect to messageadmin database and retrieve the data
            conn.Open();
            catfn = new SqlCommand("SELECT * FROM messageAdmin WHERE msgCategory = '" + fnc2.Text + "' AND msgDepartment = '" + fnd.Text + "'", conn); //change the variable name(e.g: fnc1)
            SqlDataReader Cfnsrd = catfn.ExecuteReader();

            while (Cfnsrd.Read())
            {
                tb6.Value = Cfnsrd.GetString(1).ToString();
            }
            conn.Close();


            //Connect to Finance database and retrieve the data
            conn.Open();
            fdep = new SqlCommand("SELECT * FROM solutionFinance WHERE SolutionCategory = '" + fnc2.Text + "'", conn); //change the variable name(e.g: fnc2)
            SqlDataReader Sfnsrd = fdep.ExecuteReader();

            tb4.Text = fnc2.Text; //change the variable name(e.g: fnc2)

            while (Sfnsrd.Read())
            {
                i++;

                HyperLink fslt2 = new HyperLink();
                fslt2.ID = "solution" + i;
                fslt2.CssClass = "solution";
                fslt2.BorderStyle = BorderStyle.Solid;
                fslt2.Text = Sfnsrd.GetString(2).ToString();
                fslt2.NavigateUrl = Sfnsrd.GetString(3).ToString();
                fslt2.Target = "_blank";

                display.Controls.Add(fslt2);
                ScriptManager1.SetFocus(fslt2);
            }
            conn.Close();
        }


        //General category
        private void genc_Click(object sender, EventArgs e)
        {
            cat = 7; //Change the value for new category
            Session["cat"] = cat;

            h2.Visible = true;
            b3.Visible = true;
            tb4.Visible = true;
            tb5.Visible = true;
            tb6.Visible = true;
            tb7.Visible = true;
            email.Visible = true;

            if ((int)Session["choice"] == 1)
            {
                hrc1.Enabled = false;
                hrc2.Enabled = false;
                general.Enabled = false;
                general.Style["background-color"] = "#4D8BBB";

                //Connect to messageadmin database and retrieve the data
                conn.Open();
                cathr = new SqlCommand("SELECT * FROM messageAdmin WHERE msgCategory = '" + general.Text + "' AND msgDepartment = '" + hrd.Text + "'", conn); //change the variable name(e.g: hrc1)
                SqlDataReader Chrsrd = cathr.ExecuteReader();

                while (Chrsrd.Read())
                {
                    tb6.Value = Chrsrd.GetString(1).ToString();
                }
                conn.Close();


                //Connect to HR database and retrieve the data
                conn.Open();
                Ghr = new SqlCommand("SELECT * FROM solutionHR WHERE SolutionCategory = '" + general.Text + "'", conn); //change the variable name(e.g: general)
                SqlDataReader Shrsrd = Ghr.ExecuteReader();

                tb4.Text = general.Text; //change the variable name(e.g: general)

                while (Shrsrd.Read())
                {
                    i++;

                    HyperLink gslt1 = new HyperLink(); //change the variable name(e.g: gslt1)
                    gslt1.ID = "solution" + i;
                    gslt1.CssClass = "solution";
                    gslt1.BorderStyle = BorderStyle.Solid;
                    gslt1.Text = Shrsrd.GetString(2).ToString();
                    gslt1.NavigateUrl = Shrsrd.GetString(3).ToString();
                    gslt1.Target = "_blank";

                    display.Controls.Add(gslt1); //change the variable name(e.g: gslt1)
                    ScriptManager1.SetFocus(gslt1);
                }
                conn.Close();
            }
            else if ((int)Session["choice"] == 2)
            {
                itc1.Enabled = false;
                itc2.Enabled = false;
                general.Enabled = false;
                general.Style["background-color"] = "#4D8BBB";

                //Connect to messageadmin database and retrieve the data
                conn.Open();
                catit = new SqlCommand("SELECT * FROM messageAdmin WHERE msgCategory = '" + general.Text + "' AND msgDepartment = '" + itd.Text + "'", conn); //change the variable name(e.g: hrc1)
                SqlDataReader Citsrd = catit.ExecuteReader();

                while (Citsrd.Read())
                {
                    tb6.Value = Citsrd.GetString(1).ToString();
                }
                conn.Close();


                //Connect to HR database and retrieve the data
                conn.Open();
                Git = new SqlCommand("SELECT * FROM solutionIT WHERE SolutionCategory = '" + general.Text + "'", conn); //change the variable name(e.g: general)
                SqlDataReader Sitsrd = Git.ExecuteReader();

                tb4.Text = general.Text;

                while (Sitsrd.Read())
                {
                    i++;

                    HyperLink gslt2 = new HyperLink(); //change the variable name(e.g: gslt2)
                    gslt2.ID = "solution" + i;
                    gslt2.CssClass = "solution";
                    gslt2.BorderStyle = BorderStyle.Solid;
                    gslt2.Text = Sitsrd.GetString(2).ToString();
                    gslt2.NavigateUrl = Sitsrd.GetString(3).ToString();
                    gslt2.Target = "_blank";

                    display.Controls.Add(gslt2); //change the variable name(e.g: gslt2)
                    ScriptManager1.SetFocus(gslt2);
                }
                conn.Close();
            }
            else if ((int)Session["choice"] == 3)
            {
                fnc1.Enabled = false;
                fnc2.Enabled = false;
                general.Enabled = false;
                general.Style["background-color"] = "#4D8BBB";

                //Connect to messageadmin database and retrieve the data
                conn.Open();
                catfn = new SqlCommand("SELECT * FROM messageAdmin WHERE msgCategory = '" + general.Text + "' AND msgDepartment = '" + fnd.Text + "'", conn); //change the variable name(e.g: hrc1)
                SqlDataReader Cfnsrd = catfn.ExecuteReader();

                while (Cfnsrd.Read())
                {
                    tb6.Value = Cfnsrd.GetString(1).ToString();
                }
                conn.Close();


                //Connect to HR database and retrieve the data
                conn.Open();
                Gf = new SqlCommand("SELECT * FROM solutionFinance WHERE SolutionCategory = '" + general.Text + "'", conn); //change the variable name(e.g: general)
                SqlDataReader Sfnsrd = Gf.ExecuteReader();

                tb4.Text = general.Text;

                while (Sfnsrd.Read())
                {
                    i++;

                    HyperLink gslt3 = new HyperLink(); //change the variable name(e.g: gslt3)
                    gslt3.ID = "solution" + i;
                    gslt3.CssClass = "solution";
                    gslt3.BorderStyle = BorderStyle.Solid;
                    gslt3.Text = Sfnsrd.GetString(2).ToString();
                    gslt3.NavigateUrl = Sfnsrd.GetString(3).ToString();
                    gslt3.Target = "_blank";

                    display.Controls.Add(gslt3); //change the variable name(e.g: gslt3)
                    ScriptManager1.SetFocus(gslt3);
                }
                conn.Close();
            }
        }



        /* --- 4th part - allow user to continue new question  --- */
        //Show a sentence to ask user whether to start a new session
        public void botExtra()
        {
            tb7.ID = "tb7";
            tb7.Style["overflow"] = "hidden";
            tb7.Style["resize"] = "none";
            tb7.Style["outline"] = "none";
            tb7.Style["height"] = "21.584px";
            tb7.Style["width"] = "132.202px";
            tb7.Style["background-color"] = "transparent";
            tb7.BorderStyle = BorderStyle.None;
            tb7.ReadOnly = true;
            tb7.Text = "Couldn't find the answer?";

            tb7.Visible = false;
            cont.Controls.Add(tb7);

            //Email button - To send an email as a feedback
            email.ID = "email";
            email.Style["height"] = "18.886px";
            email.Style["background-color"] = "transparent";
            email.Style["text-decoration"] = "underline";
            email.Style["cursor"] = "pointer";
            email.ForeColor = Color.Blue;
            email.BorderStyle = BorderStyle.None;
            email.Text = "Email";

            email.Visible = false;
            email.Click += new EventHandler(email_Click);
            cont.Controls.Add(email);


            tb8.ID = "tb8";
            tb8.Style["overflow"] = "hidden";
            tb8.Style["resize"] = "none";
            tb8.Style["outline"] = "none";
            tb8.Style["height"] = "21.584px";
            tb8.Style["width"] = "156.484px";
            tb8.Style["background-color"] = "transparent";
            tb8.BorderStyle = BorderStyle.None;
            tb8.ReadOnly = true;
            tb8.Text = "Start a new session now? - Click";

            cont.Controls.Add(tb8);

            //New button - To continue on other question
            byes.ID = "continue";
            byes.Style["height"] = "18.886px";
            byes.Style["background-color"] = "transparent";
            byes.Style["text-decoration"] = "underline";
            byes.Style["cursor"] = "pointer";
            byes.ForeColor = Color.Blue;
            byes.BorderStyle = BorderStyle.None;
            byes.Text = "New";

            byes.Click += new EventHandler(yes_Click);
            cont.Controls.Add(byes);

            tb9.ID = "tb9";
            tb9.Style["overflow"] = "hidden";
            tb9.Style["resize"] = "none";
            tb9.Style["outline"] = "none";
            tb9.Style["height"] = "21.584px";
            tb9.Style["width"] = "77.846px";
            tb9.Style["background-color"] = "transparent";
            tb9.BorderStyle = BorderStyle.None;
            tb9.ReadOnly = true;
            tb9.Text = "Admin? Login ";

            cont.Controls.Add(tb9);

            //New button - Admin Login 
            byes1.ID = "admin";
            byes1.Style["height"] = "18.886px";
            byes1.Style["background-color"] = "transparent";
            byes1.Style["text-decoration"] = "underline";
            byes1.Style["cursor"] = "pointer";
            byes1.ForeColor = Color.Blue;
            byes1.BorderStyle = BorderStyle.None;
            byes1.Text = "Here";

            byes1.Click += new EventHandler(admin_Click);
            cont.Controls.Add(byes1);
        }

        //Send email to department related
        protected void email_Click(object sender, EventArgs e)
        {
            Response.Redirect("email.aspx");
        }

        //Continue option button
        protected void yes_Click(object sender, EventArgs e)
        {
            //Clear the history
            Session.Clear();

            Session["continue"] = 1;
            Response.Redirect("https://localhost:44380/chatbot.aspx");

        
        }

        protected void admin_Click(object sender, EventArgs e)
        {
            //Clear the history
            Session.Clear();

            Session["admin"] = 1;
            string url = "https://localhost:44302/loginChatb.aspx"; //change localhost chatbot admin to new web link of chatbot admin
            string script = "window.top.location.href='" + url + "';";
            ScriptManager.RegisterStartupScript(this, GetType(), "Redirect", script, true);
        }



        /* --- Display the data in table view and the chat button --- */
        //Gridview data
        public void display_data()
        {
            conn.Open();
            //HR
            SqlCommand disp = new SqlCommand("SELECT * FROM solutionHR", conn);
            disp.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(disp);
            sda.Fill(dt);
            gridv.DataSource = dt;
            gridv.DataBind();

            //IT
            SqlCommand disp2 = new SqlCommand("SELECT * FROM solutionIT", conn);
            disp.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter sda2 = new SqlDataAdapter(disp2);
            sda2.Fill(dt2);
            gridv2.DataSource = dt2;
            gridv2.DataBind();

            //Finance
            SqlCommand disp3 = new SqlCommand("SELECT * FROM solutionFinance", conn);
            disp3.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter sda3 = new SqlDataAdapter(disp3);
            sda3.Fill(dt3);
            gridv3.DataSource = dt3;
            gridv3.DataBind();
            conn.Close();
        }

        //Open chat button
        protected void chatb_Click(object sender, EventArgs e)
        {
            string script = "window.onload = function() { toggleChat(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "toggleChat", script, true);

            closechatb.Visible = true;
            chatb.Visible = false;
        }

        //Close chat button
        protected void closechatb_Click(object sender, EventArgs e)
        {
            string script = "window.onload = function() { toggleChat2(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "toggleChat2", script, true);

            closechatb.Visible = false;
            chatb.Visible = true;
        }

        //Close and clear chat button (Cross icon)
        protected void close_Click(object sender, EventArgs e)
        {
            //Clear the history
            Session.Clear();
            display.Controls.Clear();
            cont.Controls.Clear();

            chatb.Visible = true;
            closechatb.Visible = false;

            string script = "window.onload = function() { toggleChat2(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "toggleChat2", script, true);
        }
    }
}