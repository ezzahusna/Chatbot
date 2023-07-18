using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using static System.Net.Mime.MediaTypeNames;

namespace chatbotAdmin
{
    public partial class home : System.Web.UI.Page
    {
        //Decalre variables
        SqlConnection conn;
        SqlCommand hr1, hr2, hr3, it1, it2, it3, fn1, fn2, fn3;

        Button hrc1 = new Button();
        Button hrc2 = new Button();
        Button hrc3 = new Button();
        Button itc1 = new Button();
        Button itc2 = new Button();
        Button itc3 = new Button();
        Button fnc1 = new Button();
        Button fnc2 = new Button();
        Button fnc3 = new Button();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Connect database - make changes in Data Source and Initial Catalog
            conn = new SqlConnection(@"Data Source=HOTSQLT01\KEMSQLT01;Initial Catalog=dbKEMChatBot;User ID=dbKEMChatBotUser;Password=dbKEMChatBotUser#12t");

            Response.Cache.SetNoStore();

            /*Session["udep"] might be change*/
            if (Session["udep"] == null) //Not sign in
            {
                Session["udep"] = "None";

                Response.Cache.SetNoStore();
                Response.Redirect("loginChatb.aspx");
            }
                        
            /*Add on and change here once confirm the categores*/
            /*Session["udep"] might be change*/
            if (Session["udep"].ToString() == "None") //Not sign in
            {
                Response.Cache.SetNoStore();
                Response.Redirect("loginChatb.aspx");
            }
            else if (Session["udep"].ToString() == "HR") //HR
            {
                /*Add on and change here once confirm the categores*/
                conn.Open();

                string scategory1 = "Leave";
                string scategory2 = "Payroll";
                string scategory3 = "General";

                //First category - Leave
                hr1 = new SqlCommand("SELECT COUNT (*) FROM solutionHR WHERE SolutionCategory = '" + scategory1 + "'", conn);
                int hrcnt1 = (int)hr1.ExecuteScalar();

                hrc1.ID = "hrc1";
                hrc1.CssClass = "home";
                hrc1.Text = scategory1 + "\n\n" + hrcnt1;

                hrc1.Enabled = false;

                homepage.Controls.Add(hrc1);

                //Second category - Payroll
                hr2 = new SqlCommand("SELECT COUNT (*) FROM solutionHR WHERE SolutionCategory = '" + scategory2 + "'", conn);
                int hrcnt2 = (int)hr2.ExecuteScalar();

                hrc2.ID = "hrc2";
                hrc2.CssClass = "home";
                hrc2.Text = scategory2 + "\n\n" + hrcnt2;

                hrc2.Enabled = false;

                homepage.Controls.Add(hrc2);

                //Third category - General
                hr3 = new SqlCommand("SELECT COUNT (*) FROM solutionHR WHERE SolutionCategory = '" + scategory3 + "'", conn);
                int hrcnt3 = (int)hr3.ExecuteScalar();

                hrc3.ID = "hrc3";
                hrc3.CssClass = "home";
                hrc3.Text = scategory3 + "\n\n" + hrcnt3;

                hrc3.Enabled = false;

                homepage.Controls.Add(hrc3);

                conn.Close();
            }
            else if (Session["udep"].ToString() == "IT") //IT
            {
                /*Add on here once confirm the categores*/
                conn.Open();

                string scategory1 = "Hardware";
                string scategory2 = "Network";
                string scategory3 = "General";

                //First category - Hardware
                it1 = new SqlCommand("SELECT COUNT (*) FROM solutionIT WHERE SolutionCategory = '" + scategory1 + "'", conn);
                int itcnt1 = (int)it1.ExecuteScalar();

                itc1.ID = "itc1";
                itc1.CssClass = "home";
                itc1.Text = scategory1 + "\n\n" + itcnt1;

                itc1.Enabled = false;

                homepage.Controls.Add(itc1);

                //Second category - Network
                it2 = new SqlCommand("SELECT COUNT (*) FROM solutionIT WHERE SolutionCategory = '" + scategory2 + "'", conn);
                int itcnt2 = (int)it2.ExecuteScalar();

                itc2.ID = "itc2";
                itc2.CssClass = "home";
                itc2.Text = scategory2 + "\n\n" + itcnt2;

                itc2.Enabled = false;

                homepage.Controls.Add(itc2);

                //Third category - General
                it3 = new SqlCommand("SELECT COUNT (*) FROM solutionIT WHERE SolutionCategory = '" + scategory3 + "'", conn);
                int itcnt3 = (int)it3.ExecuteScalar();

                itc3.ID = "itc3";
                itc3.CssClass = "home";
                itc3.Text = scategory3 + "\n\n" + itcnt3;

                itc3.Enabled = false;

                homepage.Controls.Add(itc3);

                conn.Close();
            }
            else if (Session["udep"].ToString() == "Finance") //Finance
            {
                /*Add on here once confirm the categores*/
                conn.Open();

                string scategory1 = "Fund";
                string scategory2 = "Business";
                string scategory3 = "General";

                //First category - Fund
                fn1 = new SqlCommand("SELECT COUNT (*) FROM solutionFinance WHERE SolutionCategory = '" + scategory1 + "'", conn);
                int fncnt1 = (int)fn1.ExecuteScalar();

                fnc1.ID = "fnc1";
                fnc1.CssClass = "home";
                fnc1.Text = scategory1 + "\n\n" + fncnt1;

                fnc1.Enabled = false;

                homepage.Controls.Add(fnc1);

                //Second category - Business
                fn2 = new SqlCommand("SELECT COUNT (*) FROM solutionFinance WHERE SolutionCategory = '" + scategory2 + "'", conn);
                int fncnt2 = (int)fn2.ExecuteScalar();

                fnc2.ID = "fnc2";
                fnc2.CssClass = "home";
                fnc2.Text = scategory2 + "\n\n" + fncnt2;

                fnc2.Enabled = false;

                homepage.Controls.Add(fnc2);

                //Third category - General
                fn3 = new SqlCommand("SELECT COUNT (*) FROM solutionFinance WHERE SolutionCategory = '" + scategory3 + "'", conn);
                int fncnt3 = (int)fn3.ExecuteScalar();

                fnc3.ID = "fnc3";
                fnc3.CssClass = "home";
                fnc3.Text = scategory3 + "\n\n" + fncnt3;

                fnc3.Enabled = false;

                homepage.Controls.Add(fnc3);

                conn.Close();
            }
        }
        

        //Sign out
        protected void signout_Click(object sender, EventArgs e)
        {
            // Clear the authentication cookie
            FormsAuthentication.SignOut();

            Session.Remove("udep");
            Session.Remove("admin");
            Session.Remove("cat");

            Session.Abandon();
            Session.Clear();

            // Set caching options
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            Response.Redirect("loginChatb.aspx", true);
        }
    }
}