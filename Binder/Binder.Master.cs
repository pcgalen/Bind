using System;
using System.Web;
using System.Web.Configuration;

namespace Binder
{
    public partial class Binder : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebConfigurationManager.AppSettings["Database"] == null)
            {
                Response.Write(Request.Path);
                if (Request.Path != "/Configuration.aspx") 
                {
                    Response.Redirect("/Configuration.aspx", true);
                }

                return;
            }

            if (Session["username"] != null)
            {
                UsernameLiteral.Text = Session["username"].ToString();
                this.ActionButton.Visible = true;
                this.ActionButton.Text = "Logout";
            }
            else
            {
                UsernameLiteral.Text = "Not Logged In";
                this.ActionButton.Visible = true;
                this.ActionButton.Text = "Login";
                if (Request.Path != "/login.aspx")
                {
                    Response.Redirect(string.Format("/login.aspx?returnurl={0}", HttpUtility.UrlEncode(Request.Path)), true);
                }
            }
        }

        protected void ActionButton_Click(object sender, EventArgs e)
        {
            if (this.ActionButton.Text == "Logout")
            {

                Session.Clear();
            }

            Response.Redirect("/login.aspx", true);

        }
    }
}