using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class UserList : BaseForm
    {
        private Form _MdiParent;
        private UserSave _UserForm;
        private User _User;
        private UserCollection _Users;

        public UserList(Form mdiParent)
        {
            _MdiParent = mdiParent;
            InitializeComponent();
            grdUserList.AutoGenerateColumns = false;
        }

        private void RefreshGridData(User expense)
        {
            _Users.Update(expense);
            BindUsers();
        }

        private void BindUsers()
        {
            this.BindingSource.DataSource = _Users;
            this.BindingSource.ResetBindings(false);
            grdUserList.DataSource = this.BindingSource;
        }

        private void grdUserList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _User = grdUserList.CurrentRow.DataBoundItem as User;
            ShowUserForm();
        }

        private void ShowUserForm()
        {
            if (_UserForm == null || _UserForm.IsDisposed) _UserForm = new UserSave(_User, RefreshGridData);
            _UserForm.MdiParent = _MdiParent;
            if (!_UserForm.Visible) _UserForm.Show();
            else _UserForm.Activate();
        }

        private void btnAddNew_Click(object sender, System.EventArgs e)
        {
            _User = new User();
            ShowUserForm();
        }

        private void UserList_Load(object sender, System.EventArgs e)
        {
            _Users = Service.GetUsers();
            BindUsers();
        }
    }
}
