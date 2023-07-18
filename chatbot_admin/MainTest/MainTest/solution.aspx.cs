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
    public partial class solution : System.Web.UI.Page
    {
        //Declare variables
        SqlConnection conn;

        bool flag = false;
        

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
                display_data();
            }
        }



        //Display data in gridview
        public void display_data()
        {
            conn.Open();

            if (Session["udep"].ToString() == "None") //Not sign in
            {
                Response.Cache.SetNoStore();
                Response.Redirect("loginChatb.aspx");
            }
            else if (Session["udep"].ToString() == "HR") //HR
            {
                /*Change category name here*/
                cat1.Text = "Leave";
                cat2.Text = "Payroll";
                cat3.Text = "General";

                if (Session["cat"] == null) //No value store in session
                {
                    //Set the value as 1
                    Session["cat"] = 1;

                    SqlCommand disp = new SqlCommand("SELECT * FROM solutionHR WHERE SolutionCategory = '" + cat1.Text + "' ORDER BY SolutionTitle ASC", conn);
                    disp.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(disp);
                    sda.Fill(dt);
                    gridv.DataSource = dt;
                    gridv.DataBind();
                }
                else if ((int)Session["cat"] == 1) //Category 1 - Leave
                {
                    SqlCommand disp2 = new SqlCommand("SELECT * FROM solutionHR WHERE SolutionCategory = '" + cat1.Text + "' ORDER BY SolutionTitle ASC", conn);
                    disp2.ExecuteNonQuery();
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter sda2 = new SqlDataAdapter(disp2);
                    sda2.Fill(dt2);
                    gridv.DataSource = dt2;
                    gridv.DataBind();
                }
                else if ((int)Session["cat"] == 2) //Category 2 - Payroll
                {
                    SqlCommand disp3 = new SqlCommand("SELECT * FROM solutionHR WHERE SolutionCategory = '" + cat2.Text + "' ORDER BY SolutionTitle ASC", conn);
                    disp3.ExecuteNonQuery();
                    DataTable dt3 = new DataTable();
                    SqlDataAdapter sda3 = new SqlDataAdapter(disp3);
                    sda3.Fill(dt3);
                    gridv2.DataSource = dt3;
                    gridv2.DataBind();
                }
                else if ((int)Session["cat"] == 3) //Category 3 - General
                {
                    SqlCommand disp4 = new SqlCommand("SELECT * FROM solutionHR WHERE SolutionCategory = '" + cat3.Text + "' ORDER BY SolutionTitle ASC", conn);
                    disp4.ExecuteNonQuery();
                    DataTable dt4 = new DataTable();
                    SqlDataAdapter sda4 = new SqlDataAdapter(disp4);
                    sda4.Fill(dt4);
                    gridv3.DataSource = dt4;
                    gridv3.DataBind();
                }
            }
            else if (Session["udep"].ToString() == "IT") //IT
            {
                /*Change category name here*/
                cat1.Text = "Hardware";
                cat2.Text = "Network";
                cat3.Text = "General";

                if (Session["cat"] == null) //No value store in session
                {
                    //Set value as 1
                    Session["cat"] = 1;

                    SqlCommand disp = new SqlCommand("SELECT * FROM solutionIT WHERE SolutionCategory = '" + cat1.Text + "' ORDER BY SolutionTitle ASC", conn);
                    disp.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(disp);
                    sda.Fill(dt);
                    gridv.DataSource = dt;
                    gridv.DataBind();
                }
                else if ((int)Session["cat"] == 1) //Category 1 - Hardware
                {
                    SqlCommand disp2 = new SqlCommand("SELECT * FROM solutionIT WHERE SolutionCategory = '" + cat1.Text + "' ORDER BY SolutionTitle ASC", conn);
                    disp2.ExecuteNonQuery();
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter sda2 = new SqlDataAdapter(disp2);
                    sda2.Fill(dt2);
                    gridv.DataSource = dt2;
                    gridv.DataBind();
                }
                else if ((int)Session["cat"] == 2) //Category 2 - Network
                {
                    SqlCommand disp3 = new SqlCommand("SELECT * FROM solutionIT WHERE SolutionCategory = '" + cat2.Text + "' ORDER BY SolutionTitle ASC", conn);
                    disp3.ExecuteNonQuery();
                    DataTable dt3 = new DataTable();
                    SqlDataAdapter sda3 = new SqlDataAdapter(disp3);
                    sda3.Fill(dt3);
                    gridv2.DataSource = dt3;
                    gridv2.DataBind();
                }
                else if ((int)Session["cat"] == 3) //Category 3 - General
                {
                    SqlCommand disp4 = new SqlCommand("SELECT * FROM solutionIT WHERE SolutionCategory = '" + cat3.Text + "' ORDER BY SolutionTitle ASC", conn);
                    disp4.ExecuteNonQuery();
                    DataTable dt4 = new DataTable();
                    SqlDataAdapter sda4 = new SqlDataAdapter(disp4);
                    sda4.Fill(dt4);
                    gridv3.DataSource = dt4;
                    gridv3.DataBind();
                }

            }
            else if (Session["udep"].ToString() == "Finance") //Finance
            {
                /*Change category name here or add new category text*/
                cat1.Text = "Business";
                cat2.Text = "Fund";
                cat3.Text = "General";

                if (Session["cat"] == null) //No value store in session
                {
                    //Set value as 1
                    Session["cat"] = 1;

                    SqlCommand disp = new SqlCommand("SELECT * FROM solutionFinance WHERE SolutionCategory = '" + cat1.Text + "' ORDER BY SolutionTitle ASC", conn);
                    disp.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(disp);
                    sda.Fill(dt);
                    gridv.DataSource = dt;
                    gridv.DataBind();
                }
                else if ((int)Session["cat"] == 1) //Category 1 - Business
                {
                    SqlCommand disp2 = new SqlCommand("SELECT * FROM solutionFinance WHERE SolutionCategory = '" + cat1.Text + "' ORDER BY SolutionTitle ASC", conn);
                    disp2.ExecuteNonQuery();
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter sda2 = new SqlDataAdapter(disp2);
                    sda2.Fill(dt2);
                    gridv.DataSource = dt2;
                    gridv.DataBind();
                }
                else if ((int)Session["cat"] == 2) //Category 2 - Fund
                {
                    SqlCommand disp3 = new SqlCommand("SELECT * FROM solutionFinance WHERE SolutionCategory = '" + cat2.Text + "' ORDER BY SolutionTitle ASC", conn);
                    disp3.ExecuteNonQuery();
                    DataTable dt3 = new DataTable();
                    SqlDataAdapter sda3 = new SqlDataAdapter(disp3);
                    sda3.Fill(dt3);
                    gridv2.DataSource = dt3;
                    gridv2.DataBind();
                }
                else if ((int)Session["cat"] == 3) //Category 3 - General
                {
                    SqlCommand disp4 = new SqlCommand("SELECT * FROM solutionFinance WHERE SolutionCategory = '" + cat3.Text + "' ORDER BY SolutionTitle ASC", conn);
                    disp4.ExecuteNonQuery();
                    DataTable dt4 = new DataTable();
                    SqlDataAdapter sda4 = new SqlDataAdapter(disp4);
                    sda4.Fill(dt4);
                    gridv3.DataSource = dt4;
                    gridv3.DataBind();
                }

            }

            conn.Close();
        }
        
        //Display first category
        protected void cat1_Click(object sender, EventArgs e)
        {
            Session["cat"] = 1;

            display_data();
        }

        //Display second category
        protected void cat2_Click(object sender, EventArgs e)
        {
            Session["cat"] = 2;

            display_data();
        }

        //Display third category
        protected void cat3_Click(object sender, EventArgs e)
        {
            Session["cat"] = 3;

            display_data();
        }

        /* Add on category function here */

        //Enable row editing
        protected void gridv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if ((int)Session["cat"] == 1) //Category 1
            {
                gridv.EditIndex = e.NewEditIndex;
                this.display_data();
            }
            else if ((int)Session["cat"] == 2) //Category 2
            {
                gridv2.EditIndex = e.NewEditIndex;
                this.display_data();
            }
            else if ((int)Session["cat"] == 3) //Category 3
            {
                gridv3.EditIndex = e.NewEditIndex;
                this.display_data();
            }            
        }



        /* Need to add more if more categories is declared*/
        //Update the records
        //Category 1 for 3 departments
        protected void gridv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Retrieve the controls
            TextBox tt = (TextBox)gridv.Rows[e.RowIndex].FindControl("otitle");
            TextBox l = (TextBox)gridv.Rows[e.RowIndex].FindControl("olink");
            Label sid = (Label)gridv.Rows[e.RowIndex].FindControl("oid");
            Label cat = (Label)gridv.Rows[e.RowIndex].FindControl("ocategory");

            string c = cat.Text;
            int id = Convert.ToInt32(sid.Text);
                        
            conn.Open();

            if (Session["udep"].ToString() == "HR") //HR
            {                
                SqlCommand upd = new SqlCommand("UPDATE solutionHR SET SolutionTitle = '" + tt.Text + "', SolutionLink = '" + l.Text + "' WHERE SolutionID = '" + id + "' AND SolutionCategory = '" + c + "'", conn);
                upd.ExecuteNonQuery();

                string script = "window.onload = function() { alert('Record has been updated.'); };";
                ClientScript.RegisterStartupScript(this.GetType(), "alertS", script, true);
            }
            else if (Session["udep"].ToString() == "IT") //IT
            {
                SqlCommand upd2 = new SqlCommand("UPDATE solutionIT SET SolutionTitle = '" + tt.Text + "', SolutionLink = '" + l.Text + "' WHERE SolutionID = '" + id + "' AND SolutionCategory = '" + c + "'", conn);
                upd2.ExecuteNonQuery();

                string script = "window.onload = function() { alert('Record has been updated.'); };";
                ClientScript.RegisterStartupScript(this.GetType(), "alertS", script, true);
            }
            else if (Session["udep"].ToString() == "Finance") //Finance
            {
                SqlCommand upd3 = new SqlCommand("UPDATE solutionFinance SET SolutionTitle = '" + tt.Text + "', SolutionLink = '" + l.Text + "' WHERE SolutionID = '" + id + "' AND SolutionCategory = '" + c + "'", conn);
                upd3.ExecuteNonQuery();

                string script = "window.onload = function() { alert('Record has been updated.'); };";
                ClientScript.RegisterStartupScript(this.GetType(), "alertS", script, true);
            }
            
            //Exit edit mode
            gridv.EditIndex = -1;
            conn.Close();

            this.display_data();
        }

        //Category 2 for 3 departments
        protected void gridv_RowUpdating2(object sender, GridViewUpdateEventArgs e)
        {
            //Retrieve the controls
            TextBox tt = (TextBox)gridv2.Rows[e.RowIndex].FindControl("otitle");
            TextBox l = (TextBox)gridv2.Rows[e.RowIndex].FindControl("olink");
            Label sid = (Label)gridv2.Rows[e.RowIndex].FindControl("oid");
            Label cat = (Label)gridv2.Rows[e.RowIndex].FindControl("ocategory");

            string c = cat.Text;
            int id = Convert.ToInt32(sid.Text);

            conn.Open();

            if (Session["udep"].ToString() == "HR") //HR
            {
                SqlCommand upd = new SqlCommand("UPDATE solutionHR SET SolutionTitle = '" + tt.Text + "', SolutionLink = '" + l.Text + "' WHERE SolutionID = '" + id + "' AND SolutionCategory = '" + c + "'", conn);
                upd.ExecuteNonQuery();

                string script = "window.onload = function() { alert('Record has been updated.'); };";
                ClientScript.RegisterStartupScript(this.GetType(), "alertS", script, true);
            }
            else if (Session["udep"].ToString() == "IT") //IT
            {
                SqlCommand upd2 = new SqlCommand("UPDATE solutionIT SET SolutionTitle = '" + tt.Text + "', SolutionLink = '" + l.Text + "' WHERE SolutionID = '" + id + "' AND SolutionCategory = '" + c + "'", conn);
                upd2.ExecuteNonQuery();

                string script = "window.onload = function() { alert('Record has been updated.'); };";
                ClientScript.RegisterStartupScript(this.GetType(), "alertS", script, true);
            }
            else if (Session["udep"].ToString() == "Finance") //Finance
            {
                SqlCommand upd3 = new SqlCommand("UPDATE solutionFinance SET SolutionTitle = '" + tt.Text + "', SolutionLink = '" + l.Text + "' WHERE SolutionID = '" + id + "' AND SolutionCategory = '" + c + "'", conn);
                upd3.ExecuteNonQuery();

                string script = "window.onload = function() { alert('Record has been updated.'); };";
                ClientScript.RegisterStartupScript(this.GetType(), "alertS", script, true);
            }

            //Exit edit mode
            gridv2.EditIndex = -1;
            conn.Close();

            this.display_data();
        }

        //Category 3 for 3 departments
        protected void gridv_RowUpdating3(object sender, GridViewUpdateEventArgs e)
        {
            //Retrieve the controls
            TextBox tt = (TextBox)gridv3.Rows[e.RowIndex].FindControl("otitle");
            TextBox l = (TextBox)gridv3.Rows[e.RowIndex].FindControl("olink");
            Label sid = (Label)gridv3.Rows[e.RowIndex].FindControl("oid");
            Label cat = (Label)gridv3.Rows[e.RowIndex].FindControl("ocategory");

            string c = cat.Text;
            int id = Convert.ToInt32(sid.Text);

            conn.Open();

            if (Session["udep"].ToString() == "HR") //HR
            {
                SqlCommand upd = new SqlCommand("UPDATE solutionHR SET SolutionTitle = '" + tt.Text + "', SolutionLink = '" + l.Text + "' WHERE SolutionID = '" + id + "' AND SolutionCategory = '" + c + "'", conn);
                upd.ExecuteNonQuery();

                string script = "window.onload = function() { alert('Record has been updated.'); };";
                ClientScript.RegisterStartupScript(this.GetType(), "alertS", script, true);
            }
            else if (Session["udep"].ToString() == "IT") //IT
            {
                SqlCommand upd2 = new SqlCommand("UPDATE solutionIT SET SolutionTitle = '" + tt.Text + "', SolutionLink = '" + l.Text + "' WHERE SolutionID = '" + id + "' AND SolutionCategory = '" + c + "'", conn);
                upd2.ExecuteNonQuery();

                string script = "window.onload = function() { alert('Record has been updated.'); };";
                ClientScript.RegisterStartupScript(this.GetType(), "alertS", script, true);
            }
            else if (Session["udep"].ToString() == "Finance") //Finance
            {
                SqlCommand upd3 = new SqlCommand("UPDATE solutionFinance SET SolutionTitle = '" + tt.Text + "', SolutionLink = '" + l.Text + "' WHERE SolutionID = '" + id + "' AND SolutionCategory = '" + c + "'", conn);
                upd3.ExecuteNonQuery();

                string script = "window.onload = function() { alert('Record has been updated.'); };";
                ClientScript.RegisterStartupScript(this.GetType(), "alertS", script, true);
            }

            //Exit edit mode
            gridv3.EditIndex = -1;
            conn.Close();

            this.display_data();
        }



        //Cancel edit mode
        protected void OnCancel_Click(object sender, EventArgs e)
        {
            if ((int)Session["cat"] == 1) //Category 1
            {
                gridv.EditIndex = -1;
                this.display_data();
            }
            else if ((int)Session["cat"] == 2) //Category 2
            {
                gridv2.EditIndex = -1;
                this.display_data();
            }
            else if ((int)Session["cat"] == 3) //Category 3
            {
                gridv3.EditIndex = -1;
                this.display_data();
            }
            
        }



        //Delete row data
        //Category 1 for 3 departments
        protected void gridv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Retrieve the controls
            Label tt = (Label)gridv.Rows[e.RowIndex].FindControl("ltitle");
            string title = tt.Text;

            conn.Open();

            if (Session["udep"].ToString() == "HR") //HR
            {
                SqlCommand del = new SqlCommand("DELETE FROM solutionHR WHERE SolutionTitle = '" + title + "'", conn);
                del.ExecuteNonQuery();
            }
            else if (Session["udep"].ToString() == "IT") //IT
            {
                SqlCommand del = new SqlCommand("DELETE FROM solutionIT WHERE SolutionTitle = '" + title + "'", conn);
                del.ExecuteNonQuery();
            }
            else if (Session["udep"].ToString() == "Finance") //Finance
            {
                SqlCommand del = new SqlCommand("DELETE FROM solutionFinance WHERE SolutionTitle = '" + title + "'", conn);
                del.ExecuteNonQuery();
            }

            conn.Close();

            string script = "window.onload = function() { alert('Record has been deleted.'); };";
            ClientScript.RegisterStartupScript(this.GetType(), "alertS", script, true);

            this.display_data();
        }

        //Category 2 for 3 departments
        protected void gridv_RowDeleting2(object sender, GridViewDeleteEventArgs e)
        {
            //Retrieve the controls
            Label tt = (Label)gridv2.Rows[e.RowIndex].FindControl("ltitle");
            string title = tt.Text;

            conn.Open();

            if (Session["udep"].ToString() == "HR") //HR
            {
                SqlCommand del = new SqlCommand("DELETE FROM solutionHR WHERE SolutionTitle = '" + title + "'", conn);
                del.ExecuteNonQuery();
            }
            else if (Session["udep"].ToString() == "IT") //IT
            {
                SqlCommand del = new SqlCommand("DELETE FROM solutionIT WHERE SolutionTitle = '" + title + "'", conn);
                del.ExecuteNonQuery();
            }
            else if (Session["udep"].ToString() == "Finance") //Finance
            {
                SqlCommand del = new SqlCommand("DELETE FROM solutionFinance WHERE SolutionTitle = '" + title + "'", conn);
                del.ExecuteNonQuery();
            }

            conn.Close();

            string script = "window.onload = function() { alert('Record has been deleted.'); };";
            ClientScript.RegisterStartupScript(this.GetType(), "alertS", script, true);

            this.display_data();
        }

        //Catgeory 3 for 3 departments
        protected void gridv_RowDeleting3(object sender, GridViewDeleteEventArgs e)
        {
            //Retrieve the controls
            Label tt = (Label)gridv3.Rows[e.RowIndex].FindControl("ltitle");
            string title = tt.Text;

            conn.Open();

            if (Session["udep"].ToString() == "HR") //HR
            {
                SqlCommand del = new SqlCommand("DELETE FROM solutionHR WHERE SolutionTitle = '" + title + "'", conn);
                del.ExecuteNonQuery();
            }
            else if (Session["udep"].ToString() == "IT") //IT
            {
                SqlCommand del = new SqlCommand("DELETE FROM solutionIT WHERE SolutionTitle = '" + title + "'", conn);
                del.ExecuteNonQuery();
            }
            else if (Session["udep"].ToString() == "Finance") //Finance
            {
                SqlCommand del = new SqlCommand("DELETE FROM solutionFinance WHERE SolutionTitle = '" + title + "'", conn);
                del.ExecuteNonQuery();
            }

            conn.Close();

            string script = "window.onload = function() { alert('Record has been deleted.'); };";
            ClientScript.RegisterStartupScript(this.GetType(), "alertS", script, true);

            this.display_data();
        }



        //Head to pop-up page
        protected void new_Click(object sender, EventArgs e)
        {
            news.Enabled = false;

            addslt.Visible = true;            
        }

        //Back to solution page
        protected void close_Click(object sender, EventArgs e)
        {
            news.Enabled = true;

            addslt.Visible = false;
        }

        //Add new
        protected void add_Click(object sender, EventArgs e)
        {
            string tt = ntitle.Text;
            string l = nlink.Text;

            if (Session["udep"].ToString() == "None") //Not sign in
            {
                Response.Cache.SetNoStore();
                Response.Redirect("loginChatb.aspx");
            }
            else if (Session["udep"].ToString() == "HR") //HR
            {
                if (hrcat.SelectedValue != "0") //User selected the category
                {
                    require.Text = "";

                    if (tt == "" || l == "") //User not entering anything
                    {
                        string script = "window.onload = function() { alert('Please make sure that all information has been entered.'); };";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                    else
                    {
                        //Check whether the value exists in database
                        conn.Open();

                        SqlCommand exist = new SqlCommand("SELECT * FROM solutionHR WHERE SolutionTitle = '" + tt + "'", conn);
                        SqlDataReader exrd = exist.ExecuteReader();

                        while (exrd.Read())
                        {
                            if (exrd.HasRows == true)
                            {
                                flag = true;
                                break;                                
                            }                            
                        }
                        conn.Close();

                        conn.Open();

                        if (flag == true)
                        {
                            ttexist.Text = "The title already exist";
                            ttexist.ForeColor = Color.Red;
                        }
                        else
                        {
                            SqlCommand disp = new SqlCommand(" INSERT INTO solutionHR (SolutionCategory, SolutionTitle, SolutionLink) VALUES ('" + hrcat.SelectedValue + "', '" + tt + "', '" + l + "')", conn);
                            disp.ExecuteNonQuery();

                            Response.Write("<script language='javascript'>window.alert('Solution uploaded.'); window.location='solution.aspx'; function hforward(){ window.history.forward(); }</script>");
                        }

                        conn.Close();
                    }
                }
                else
                {
                    require.Text = "Please select a suitable category for the solution.";
                    require.ForeColor = Color.Red;
                }
            }
            else if (Session["udep"].ToString() == "IT") //IT
            {
                require.Text = "";

                if (itcat.SelectedValue != "0") //User selected the category
                {
                    if (tt == "" || l == "") //User not entering anything
                    {
                        string script = "window.onload = function() { alert('Please make sure that all information has been entered.'); };";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                    else
                    {
                        //Check whether the value exists in database
                        conn.Open();

                        SqlCommand exist = new SqlCommand("SELECT * FROM solutionIT WHERE SolutionTitle = '" + tt + "'", conn);
                        SqlDataReader exrd = exist.ExecuteReader();

                        while (exrd.Read())
                        {
                            if (exrd.HasRows == true)
                            {
                                flag = true;
                                break;
                            }
                        }
                        conn.Close();

                        conn.Open();

                        if (flag == true)
                        {
                            ttexist.Text = "The title already exist";
                            ttexist.ForeColor = Color.Red;
                        }
                        else
                        {
                            SqlCommand disp = new SqlCommand(" INSERT INTO solutionIT (SolutionCategory, SolutionTitle, SolutionLink) VALUES ('" + itcat.SelectedValue + "', '" + tt + "', '" + l + "')", conn);
                            disp.ExecuteNonQuery();

                            Response.Write("<script language='javascript'>window.alert('Solution uploaded.'); window.location='solution.aspx'; function hforward(){ window.history.forward(); }</script>");
                        }

                        conn.Close();
                    }
                }
                else
                {
                    require.Text = "Please select a suitable category for the solution.";
                    require.ForeColor = Color.Red;
                }
            }
            else if (Session["udep"].ToString() == "Finance") //Finance
            {
                require.Text = "";

                if (fncat.SelectedValue != "0") //User selected the category
                {
                    if (tt == "" || l == "") //User not entering anything
                    {
                        string script = "window.onload = function() { alert('Please make sure that all information has been entered.'); };";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                    else
                    {
                        //Check whether the value exists in database
                        conn.Open();

                        SqlCommand exist = new SqlCommand("SELECT * FROM solutionFinance WHERE SolutionTitle = '" + tt + "'", conn);
                        SqlDataReader exrd = exist.ExecuteReader();

                        while (exrd.Read())
                        {
                            if (exrd.HasRows == true)
                            {
                                flag = true;
                                break;
                            }
                        }
                        conn.Close();

                        conn.Open();

                        if (flag == true)
                        {
                            ttexist.Text = "The title already exist";
                            ttexist.ForeColor = Color.Red;
                        }
                        else
                        {
                            SqlCommand disp = new SqlCommand(" INSERT INTO solutionFinance (SolutionCategory, SolutionTitle, SolutionLink) VALUES ('" + fncat.SelectedValue + "', '" + tt + "', '" + l + "')", conn);
                            disp.ExecuteNonQuery();

                            Response.Write("<script language='javascript'>window.alert('Solution uploaded.'); window.location='solution.aspx'; function hforward(){ window.history.forward(); }</script>");
                        }

                        conn.Close();
                    }
                }
                else
                {
                    require.Text = "Please select a suitable category for the solution.";
                    require.ForeColor = Color.Red;
                }
            }
        }

        //Sign out
        protected void signout2_Click(object sender, EventArgs e)
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