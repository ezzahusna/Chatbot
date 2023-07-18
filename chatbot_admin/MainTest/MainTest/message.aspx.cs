using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Security.Cryptography;
using System.Web.Security;

namespace chatbotAdmin
{
    public partial class message : System.Web.UI.Page
    {
        //Declare the variables
        SqlConnection conn;
        SqlCommand msgc1, msgc2, msgc3, inmsg;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Connect database - make changes in Data Source and Initial Catalog
            conn = new SqlConnection(@"Data Source=HOTSQLT01\KEMSQLT01;Initial Catalog=dbKEMChatBot;User ID=dbKEMChatBotUser;Password=dbKEMChatBotUser#12t");

            Response.Cache.SetNoStore();

            if (Session["udep"] == null) //Not sign in
            {
                Session["udep"] = "None";
                                
                Response.Cache.SetNoStore();
                Response.Redirect("loginChatb.aspx");
            }

            if (!IsPostBack)
            {
                display_first();
                display_second();
                display_third();

                msgsave1.Visible = false;
                msgsave2.Visible = false;
                msgsave3.Visible = false;
                msgcancel1.Visible = false;
                msgcancel2.Visible = false;
                msgcancel3.Visible = false;

                txtc1.Enabled = false;
                txtc2.Enabled = false;
                txtc3.Enabled = false;
            }            
        }



        //Display first category messages based on department
        protected void display_first() 
        {
            /*Change category name here*/
            string hr = "Leave";
            string it = "Hardware";
            string fn = "Business";

            conn.Open();

            if (Session["udep"].ToString() == "None") //Not sign in
            {
                Response.Cache.SetNoStore();
                Response.Redirect("loginChatb.aspx");
            }
            else if (Session["udep"].ToString() == "HR")
            {
                msgc1 = new SqlCommand("SELECT * FROM messageAdmin WHERE msgDepartment = '" + Session["udep"].ToString() + "' AND msgCategory = '" + hr + "'", conn); //may need to change
                SqlDataReader msgsrd = msgc1.ExecuteReader();

                while (msgsrd.Read())
                {
                    lblc1.Text = msgsrd.GetString(2).ToString();
                    txtc1.Text = msgsrd.GetString(1).ToString();
                    date1.Text = "Last Updated: " + msgsrd.GetString(5).ToString();
                }
            }
            else if (Session["udep"].ToString() == "IT")
            {
                msgc1 = new SqlCommand("SELECT * FROM messageAdmin WHERE msgDepartment = '" + Session["udep"].ToString() + "' AND msgCategory = '" + it + "'", conn); //may need to change
                SqlDataReader msgsrd = msgc1.ExecuteReader();

                while (msgsrd.Read())
                {
                    lblc1.Text = msgsrd.GetString(2).ToString();
                    txtc1.Text = msgsrd.GetString(1).ToString();
                    date1.Text = "Last Updated: " + msgsrd.GetString(5).ToString();
                }
            }
            else if (Session["udep"].ToString() == "Finance")
            {
                msgc1 = new SqlCommand("SELECT * FROM messageAdmin WHERE msgDepartment = '" + Session["udep"].ToString() + "' AND msgCategory = '" + fn + "'", conn); //may need to change
                SqlDataReader msgsrd = msgc1.ExecuteReader();

                while (msgsrd.Read())
                {
                    lblc1.Text = msgsrd.GetString(2).ToString();
                    txtc1.Text = msgsrd.GetString(1).ToString();
                    date1.Text = "Last Updated: " + msgsrd.GetString(5).ToString();
                }
            }

            conn.Close();
        }

        //Display second category messages based on department
        protected void display_second()
        {
            /*Change category name here*/
            string hr = "Payroll";
            string it = "Network";
            string fn = "Fund";

            conn.Open();

            if (Session["udep"].ToString() == "None") //Not sign in
            {
                Response.Cache.SetNoStore();
                Response.Redirect("loginChatb.aspx");
            }
            else if (Session["udep"].ToString() == "HR")
            {
                msgc2 = new SqlCommand("SELECT * FROM messageAdmin WHERE msgDepartment = '" + Session["udep"].ToString() + "' AND msgCategory = '" + hr + "'", conn); //may need to change
                SqlDataReader msgsrd = msgc2.ExecuteReader();

                while (msgsrd.Read())
                {
                    lblc2.Text = msgsrd.GetString(2).ToString();
                    txtc2.Text = msgsrd.GetString(1).ToString();
                    date2.Text = "Last Updated: " + msgsrd.GetString(5).ToString();
                }
            }
            else if (Session["udep"].ToString() == "IT")
            {
                msgc2 = new SqlCommand("SELECT * FROM messageAdmin WHERE msgDepartment = '" + Session["udep"].ToString() + "' AND msgCategory = '" + it + "'", conn); //may need to change
                SqlDataReader msgsrd = msgc2.ExecuteReader();

                while (msgsrd.Read())
                {
                    lblc2.Text = msgsrd.GetString(2).ToString();
                    txtc2.Text = msgsrd.GetString(1).ToString();
                    date2.Text = "Last Updated: " + msgsrd.GetString(5).ToString();
                }
            }
            else if (Session["udep"].ToString() == "Finance")
            {
                msgc2 = new SqlCommand("SELECT * FROM messageAdmin WHERE msgDepartment = '" + Session["udep"].ToString() + "' AND msgCategory = '" + fn + "'", conn); //may need to change
                SqlDataReader msgsrd = msgc2.ExecuteReader();

                while (msgsrd.Read())
                {
                    lblc2.Text = msgsrd.GetString(2).ToString();
                    txtc2.Text = msgsrd.GetString(1).ToString();
                    date2.Text = "Last Updated: " + msgsrd.GetString(5).ToString();
                }
            }

            conn.Close();
        }

        //Display third category messages based on department
        protected void display_third()
        {
            /*Change category name here*/
            string gen = "General";

            conn.Open();

            if (Session["udep"].ToString() == "None") //Not sign in
            {
                Response.Cache.SetNoStore();
                Response.Redirect("loginChatb.aspx");
            }
            else if (Session["udep"].ToString() == "HR")
            {
                msgc3 = new SqlCommand("SELECT * FROM messageAdmin WHERE msgDepartment = '" + Session["udep"].ToString() + "' AND msgCategory = '" + gen + "'", conn); //may need to change
                SqlDataReader msgsrd = msgc3.ExecuteReader();

                while (msgsrd.Read())
                {
                    lblc3.Text = msgsrd.GetString(2).ToString();
                    txtc3.Text = msgsrd.GetString(1).ToString();
                    date3.Text = "Last Updated: " + msgsrd.GetString(5).ToString();
                }
            }
            else if (Session["udep"].ToString() == "IT")
            {
                msgc3 = new SqlCommand("SELECT * FROM messageAdmin WHERE msgDepartment = '" + Session["udep"].ToString() + "' AND msgCategory = '" + gen + "'", conn); //may need to change
                SqlDataReader msgsrd = msgc3.ExecuteReader();

                while (msgsrd.Read())
                {
                    lblc3.Text = msgsrd.GetString(2).ToString();
                    txtc3.Text = msgsrd.GetString(1).ToString();
                    date3.Text = "Last Updated: " + msgsrd.GetString(5).ToString();
                }
            }
            else if (Session["udep"].ToString() == "Finance")
            {
                msgc3 = new SqlCommand("SELECT * FROM messageAdmin WHERE msgDepartment = '" + Session["udep"].ToString() + "' AND msgCategory = '" + gen + "'", conn); //may need to change
                SqlDataReader msgsrd = msgc3.ExecuteReader();

                while (msgsrd.Read())
                {
                    lblc3.Text = msgsrd.GetString(2).ToString();
                    txtc3.Text = msgsrd.GetString(1).ToString();
                    date3.Text = "Last Updated: " + msgsrd.GetString(5).ToString();
                }
            }

            conn.Close();
        }

        

        //Allow users to edit message
        //First category for 3 departments
        protected void msgedit1_Click(object sender, EventArgs e)
        {
            msgedit1.Visible = false;
            msgsave1.Visible = true;
            msgcancel1.Visible = true;

            msgedit2.Visible = true;
            msgedit3.Visible = true;

            txtc1.Enabled = true;
            txtc1.Focus();
        }

        //Second category for 3 departments
        protected void msgedit2_Click(object sender, EventArgs e)
        {
            msgedit2.Visible = false;
            msgsave2.Visible = true;
            msgcancel2.Visible = true;

            msgedit1.Visible = true;
            msgedit3.Visible = true;

            txtc2.Enabled = true;
            txtc2.Focus();
        }

        //Third category for 3 departments
        protected void msgedit3_Click(object sender, EventArgs e)
        {
            msgedit3.Visible = false;
            msgsave3.Visible = true;
            msgcancel3.Visible = true;

            msgedit1.Visible = true;
            msgedit2.Visible = true;

            txtc3.Enabled = true;
            txtc3.Focus();
        }



        //Cancel the edit mode
        //First category for 3 departments
        protected void msgcancel1_Click(object sender, EventArgs e)
        {
            msgedit1.Visible = true;
            msgsave1.Visible = false;
            msgcancel1.Visible = false;

            txtc1.Enabled = false;
            this.display_first();
        }

        //Second category for 3 departments
        protected void msgcancel2_Click(object sender, EventArgs e)
        {
            msgedit2.Visible = true;
            msgsave2.Visible = false;
            msgcancel2.Visible = false;

            txtc2.Enabled = false;
            this.display_second();
        }

        //Third category for 3 departments
        protected void msgcancel3_Click(object sender, EventArgs e)
        {
            msgedit3.Visible = true;
            msgsave3.Visible = false;
            msgcancel3.Visible = false;

            txtc3.Enabled = false;
            this.display_third();
        }



        //Save the user input and store in database
        //First category for 3 departments
        protected void msgsave1_Click(object sender, EventArgs e)
        {
            string msg = txtc1.Text;
            DateTime dt = DateTime.Now;
            string sqldt = dt.ToString("yyyy-MM-dd HH:mm:ss");
            string admin = Session["admin"].ToString();

            conn.Open();

            inmsg = new SqlCommand("UPDATE messageAdmin SET msgContent = '" + msg + "' , msgAdmin = '" + admin + "' , msgLastEdit = '" + sqldt + "' WHERE msgDepartment = '" + Session["udep"].ToString() + "' AND msgCategory = '" + lblc1.Text + "'", conn);
            SqlDataReader msgsrd = inmsg.ExecuteReader();

            conn.Close();

            msgedit1.Visible = true;

            Response.Write("<script language='javascript'>window.alert('Message has been updated.'); window.location='message.aspx';</script>");
        }

        //Second category for 3 departments
        protected void msgsave2_Click(object sender, EventArgs e)
        {
            string msg = txtc2.Text;
            DateTime dt = DateTime.Now;
            string sqldt = dt.ToString("yyyy-MM-dd HH:mm:ss");
            string admin = Session["admin"].ToString();

            conn.Open();

            inmsg = new SqlCommand("UPDATE messageAdmin SET msgContent = '" + msg + "' , msgAdmin = '" + admin + "' , msgLastEdit = '" + sqldt + "' WHERE msgDepartment = '" + Session["udep"].ToString() + "' AND msgCategory = '" + lblc2.Text + "'", conn); //may need to change the session name
            SqlDataReader msgsrd = inmsg.ExecuteReader();

            conn.Close();
                        
            msgedit2.Visible = true;

            Response.Write("<script language='javascript'>window.alert('Message has been updated.'); window.location='message.aspx';</script>");
        }

        //Third category for 3 departments
        protected void msgsave3_Click(object sender, EventArgs e)
        {
            string msg = txtc3.Text;
            DateTime dt = DateTime.Now;
            string sqldt = dt.ToString("yyyy-MM-dd HH:mm:ss");
            string admin = Session["admin"].ToString();

            conn.Open();

            inmsg = new SqlCommand("UPDATE messageAdmin SET msgContent = '" + msg + "' , msgAdmin = '" + admin + "' , msgLastEdit = '" + sqldt + "' WHERE msgDepartment = '" + Session["udep"].ToString() + "' AND msgCategory = '" + lblc3.Text + "'", conn); //may need to change the session name
            SqlDataReader msgsrd = inmsg.ExecuteReader();

            conn.Close();

            msgedit3.Visible = true;

            Response.Write("<script language='javascript'>window.alert('Message has been updated.'); window.location='message.aspx';</script>");
        }



        //Sign out
        protected void signout3_Click(object sender, EventArgs e)
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