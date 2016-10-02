using System;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserName.Value = (Session["LoggedInUser"] as User).UserName;
            txtUserName.Disabled = true;
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                UserBol bol = new UserBol();
                try
                {
                    bol.ChangePassword((Session["LoggedInUser"] as User).Id, txtOldPassword.Value.Trim(), txtNewPassword.Value.Trim());
                    lblMessage.Text = "Password changed successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private bool IsValidData()
        {
            if (string.IsNullOrEmpty(txtOldPassword.Value.Trim()))
            {
                lblMessage.Text = "Please enter your old password.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (string.IsNullOrEmpty(txtNewPassword.Value.Trim()))
            {
                lblMessage.Text = "Please enter your new password.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (string.Compare(txtOldPassword.Value.Trim(), txtNewPassword.Value.Trim()) == 0)
            {
                lblMessage.Text = "New password must be different from old password.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (string.IsNullOrEmpty(txtConfirmPassword.Value.Trim()))
            {
                lblMessage.Text = "Please enter confirm password.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (string.Compare(txtNewPassword.Value.Trim(), txtConfirmPassword.Value.Trim()) != 0)
            {
                lblMessage.Text = "New password and confirm password didn't match.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            return true;
        }
    }
}