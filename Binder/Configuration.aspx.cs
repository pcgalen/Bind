using System;
using System.Collections.Specialized;
using System.Data.SqlClient;
namespace Binder
{
    public partial class Configuration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!ValidateRequest())
            {
                Response.Write(string.Format("{0}alert('Validation failed.  Please check your entries.);{1}", Util.getJs(), Util.getJe()));
                return;
            }

            Response.Redirect("~/default.aspx", true);
        }

        protected bool ValidateRequest()
        {
            string sMessage = "";

            if (this.UserNameTextBox.Text.Length == 0)
            {
                sMessage = "Username is a required field. \n";
            }

            if (this.PasswordTextBox.Text.Length == 0)
            {
                sMessage += "Password is a required field. \n";
            }

            if (this.DatabaseServerTextBox.Text.Length == 0)
            {
                sMessage += "Database server is a required field. \n";
            }

            if (this.DatabaseTextBox.Text.Length == 0)
            {
                sMessage += "Database is a required field.\n";
            }

            if (this.DatabaseUserID.Text.Length == 0)
            {
                sMessage += "Database user is a required field.\n";
            }

            if (this.DatabasePassword.Text.Length == 0)
            {
                sMessage += "Database password is a required field. \n";
            }

            if (this.BindPath.Text.Length == 0)
            {
                sMessage += "Name server path is required. \n";
            }

            if (sMessage.Length > 0)
            {
                Response.Write(string.Format("{0}alert('{1}');{2}", Util.getJs(), sMessage, Util.getJe()));
                return false;
            }

            SqlConnection oCn = new SqlConnection(Util.getConn(this.DatabaseServerTextBox.Text, this.DatabaseTextBox.Text, this.DatabaseUserID.Text, this.DatabasePassword.Text));

            try
            {
                oCn.Open();
            }
            catch (SqlException ex)
            {
                Response.Write(string.Format("{0}alert('{1}');{2}", Util.getJs(), ex.Message, Util.getJe()));
                return false;
            }

            if (!System.IO.File.Exists(this.BindPath.Text))
            {
                Response.Write(string.Format("{0}alert('Name server path is not valid');{1}", Util.getJs(), Util.getJe()));
                return false;
            }

            if (!SaveData())
                return false;

            return true;
        }
        protected bool SaveData()
        {

            ListDictionary oLd = new ListDictionary();

            oLd.Add("Database", this.DatabaseTextBox.Text);
            oLd.Add("DatabaseServer", this.DatabaseServerTextBox.Text);
            oLd.Add("DatabaseUser", this.DatabaseUserID.Text);
            oLd.Add("DatabasePassword", this.DatabasePassword.Text);
            oLd.Add("BindPath", this.BindPath.Text);
            oLd.Add("Username", this.UserNameTextBox.Text);
            oLd.Add("Password", this.PasswordTextBox.Text);

            Util.config = oLd;
            Util.Serialize();

            SqlConnection ocn = new SqlConnection(Util.getConn());
            SqlCommand ocmd = new SqlCommand(string.Format("SELECT count(*) FROM Users WHERE UserID = '{0}'", this.UserNameTextBox.Text), ocn);
            ocn.Open();

            int iCount = (int)ocmd.ExecuteScalar();

            if (iCount == 0)
                ocmd.CommandText = "INSERT INTO Users (UserID, Password) VALUES (@UserID, @Password)";
            else
                ocmd.CommandText = "UPDATE Users SET Password = @Password WHERE UserID = @UserID";

            ocmd.Parameters.AddWithValue("@UserID", this.UserNameTextBox.Text);
            ocmd.Parameters.AddWithValue("@Password", this.PasswordTextBox.Text);

            ocmd.ExecuteNonQuery();

            //CheckCreateSchema();
            ocn.Dispose();
            ocmd.Dispose();

            return true;
        }
    }
}