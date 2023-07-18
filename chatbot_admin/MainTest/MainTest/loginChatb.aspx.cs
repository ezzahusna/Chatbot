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
using System.DirectoryServices;
using System.Drawing;

namespace chatbotAdmin
{
    public partial class loginChatb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Session["udep"] = "None";
            
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }
                
        //Sign in
        protected void signin_Click(object sender, EventArgs e)
        {            
            string userid = tbuserid.Text;
            string password = tbpassword.Text;

            if (dep.SelectedValue == "0")
            {
                require.Text = "* Please select the department *";
                require.ForeColor = Color.Red;
            }
            else if (dep.SelectedValue == "1")
            {
                Session["udep"] = "HR";
                require.Text = "";

                // set up LDAP
                // ection to AD
                string ldapPath = "LDAP://10.3.100.165";
                DirectoryEntry entry = new DirectoryEntry(ldapPath);

                // set credentials for LDAP
                // ection
                entry.Username = userid;
                entry.Password = password;

                try
                {
                    // search for the user in AD
                    DirectorySearcher searcher = new DirectorySearcher(entry);
                    searcher.Filter = "(&(sAMAccountName=" + userid + "))";

                    SearchResult result = searcher.FindOne();

                    if (result != null)
                    {
                        // user exists in AD, check if they are a member of the security group
                        DirectoryEntry user = result.GetDirectoryEntry();
                        PropertyValueCollection groups = user.Properties["memberOf"];

                        foreach (string group in groups)
                        {
                            if (group.Contains("CN=KEM-TRAINEE,OU=IT,OU=KEM,OU=Knowles,DC=knowles,DC=com")) // replace with the name of the security group you want to check
                            {
                                // user is a member of the security group
                                Session["admin"] = userid;

                                Response.Redirect("home.aspx", false);
                            }
                            else
                            {
                                // user is not a member of the security group
                                signinfail.Text = "You are not authorized to sign in.";
                                signinfail.ForeColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        // user does not exist in AD
                        signinfail.Text = "Invalid user ID or password.";
                        signinfail.ForeColor = Color.Red;
                    }
                }
                catch (DirectoryServicesCOMException ex)
                {
                    signinfail.Text = "Invalid user ID or password.";
                    signinfail.ForeColor = Color.Red;
                }
            }
            else if (dep.SelectedValue == "2")
            {
                Session["udep"] = "IT";
                require.Text = "";

                // set up LDAP connection to AD
                string ldapPath = "LDAP://10.3.100.165";
                DirectoryEntry entry = new DirectoryEntry(ldapPath);

                // set credentials for LDAP connection
                entry.Username = userid;
                entry.Password = password;

                try
                {
                    // search for the user in AD
                    DirectorySearcher searcher = new DirectorySearcher(entry);
                    searcher.Filter = "(&(sAMAccountName=" + userid + "))";

                    SearchResult result = searcher.FindOne();

                    if (result != null)
                    {
                        // user exists in AD, check if they are a member of the security group
                        DirectoryEntry user = result.GetDirectoryEntry();
                        PropertyValueCollection groups = user.Properties["memberOf"];

                        foreach (string group in groups)
                        {
                            if (group.Contains("CN=KEM-TRAINEE,OU=IT,OU=KEM,OU=Knowles,DC=knowles,DC=com")) // replace with the name of the security group you want to check
                            {
                                // user is a member of the security group
                                Session["admin"] = userid;

                                Response.Redirect("home.aspx", false);
                            }
                            else
                            {
                                // user is not a member of the security group
                                signinfail.Text = "You are not authorized to sign in.";
                                signinfail.ForeColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        // user does not exist in AD
                        signinfail.Text = "Invalid user ID or password.";
                        signinfail.ForeColor = Color.Red;
                    }
                }
                catch (DirectoryServicesCOMException ex)
                {
                    signinfail.Text = "Invalid user ID or password.";
                    signinfail.ForeColor = Color.Red;
                }
            }
            else if (dep.SelectedValue == "3")
            {
                Session["udep"] = "Finance";
                require.Text = "";

                // set up LDAP connection to AD
                string ldapPath = "LDAP://10.3.100.165";
                DirectoryEntry entry = new DirectoryEntry(ldapPath);

                // set credentials for LDAP connection
                entry.Username = userid;
                entry.Password = password;

                try
                {
                    // search for the user in AD
                    DirectorySearcher searcher = new DirectorySearcher(entry);
                    searcher.Filter = "(&(sAMAccountName=" + userid + "))";

                    SearchResult result = searcher.FindOne();

                    if (result != null)
                    {
                        // user exists in AD, check if they are a member of the security group
                        DirectoryEntry user = result.GetDirectoryEntry();
                        PropertyValueCollection groups = user.Properties["memberOf"];

                        foreach (string group in groups)
                        {
                            if (group.Contains("CN=KEM-TRAINEE,OU=IT,OU=KEM,OU=Knowles,DC=knowles,DC=com")) // replace with the name of the security group you want to check
                            {
                                // user is a member of the security group
                                Session["admin"] = userid;

                                Response.Redirect("home.aspx", false);
                            }
                            else
                            {
                                // user is not a member of the security group
                                signinfail.Text = "You are not authorized to sign in.";
                                signinfail.ForeColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        // user does not exist in AD
                        signinfail.Text = "Invalid user ID or password.";
                        signinfail.ForeColor = Color.Red;
                    }
                }
                catch (DirectoryServicesCOMException ex)
                {
                    signinfail.Text = "Invalid user ID or password.";
                    signinfail.ForeColor = Color.Red;
                }
            }
        }
    }
}