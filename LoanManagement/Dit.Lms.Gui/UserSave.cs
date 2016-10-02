using System.Text;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class UserSave : BaseSaveForm
    {
        private RefreshGridDataHandler<User> _RefreshGridData;
        private User _User;

        public UserSave(User user, RefreshGridDataHandler<User> refreshGridData)
        {
            _User = user;
            _RefreshGridData = refreshGridData;
            InitializeComponent();
            InitData();
        }

        private void UserSave_Load(object sender, System.EventArgs e)
        {
            DisplayData();
        }

        protected override void InitData() { }

        protected override void CollectData()
        {
            _User.LoginName = txtLoginName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.Name = txtName.Text.Trim();
            _User.IsActive = true;
        }

        protected override void DisplayData()
        {
            btnDelete.Enabled = _User.Id != 0;
            txtLoginName.Text = _User.LoginName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            txtName.Text = _User.Name;
        }

        protected override void ClearData()
        {
            _User = new User();
            DisplayData();
        }

        protected override bool ValidateData()
        {
            StringBuilder msgBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(txtLoginName.Text.Trim()))
            {
                msgBuilder.AppendLine("Login name can not be blank.");
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                msgBuilder.AppendLine("Password can not be blank.");
            }
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                msgBuilder.AppendLine("Confirm password can not be blank.");
            }
            if (string.Compare(txtPassword.Text.Trim(), txtConfirmPassword.Text.Trim()) != 0)
            {
                msgBuilder.AppendLine("Password and confirm password must be the same.");
            }
            if (!string.IsNullOrEmpty(msgBuilder.ToString()))
            {
                MessageBox.Show(msgBuilder.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        protected override void RefreshGridData()
        {
            _RefreshGridData(_User);
        }

        protected override void DeleteData()
        {
            Service.DeleteUser(_User.Id);
            _User.IsActive = false;
        }

        protected override void SaveData()
        {
            Service.SaveUser(_User);
        }

        protected override void HookAnything()
        {
            LoggedInUser = _User;
        }
    }
}
