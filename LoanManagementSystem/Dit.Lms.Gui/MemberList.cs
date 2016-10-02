using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class MemberList : BaseForm
    {
        private Form _MdiParent;
        private MemberSave _MemberForm;
        private Member _Member;
        private MemberCollection _Members;

        public MemberList(Form mdiParent)
        {
            _MdiParent = mdiParent;
            InitializeComponent();
            grdMemberList.AutoGenerateColumns = false;
        }

        private void btnAddNew_Click(object sender, System.EventArgs e)
        {
            _Member = new Member();
            ShowMemberForm();
        }

        private void ShowMemberForm()
        {
            if (_MemberForm == null || _MemberForm.IsDisposed) _MemberForm = new MemberSave(_Member, RefreshGridData);
            _MemberForm.MdiParent = _MdiParent;
            if (!_MemberForm.Visible) _MemberForm.Show();
            else _MemberForm.Activate();
        }

        private void MemberList_Load(object sender, System.EventArgs e)
        {
            _Members = Service.GetMembers(txtMemberId.Text);
            BindMembers();
        }

        private void RefreshGridData(Member gridData)
        {
            _Members.Update(gridData);
            BindMembers();
        }

        private void BindMembers()
        {
            this.BindingSource.DataSource = _Members;
            this.BindingSource.ResetBindings(false);
            grdMemberList.DataSource = this.BindingSource;
        }

        private void BindMembers(List<Member> members)
        {
            this.BindingSource.DataSource = members;
            this.BindingSource.ResetBindings(false);
            grdMemberList.DataSource = this.BindingSource;
        }

        private void grdMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _Member = grdMemberList.CurrentRow.DataBoundItem as Member;
            ShowMemberForm();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            DisplaySearchResult();
        }

        private void DisplaySearchResult()
        {
            try
            {
                if (string.IsNullOrEmpty(txtMemberId.Text))
                {
                    _Members = Service.GetMembers(string.Format("{0}", txtMemberId.Text));
                    BindMembers();
                }
                else
                {
                    List<Member> members = _Members.GetByMemberId(int.Parse(txtMemberId.Text)); //Service.GetMemberByMemberId(int.Parse(txtMemberId.Text));
                    BindMembers(members);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Member ID must be Numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Member ID must be Numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtMemberId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DisplaySearchResult();
            }
        }
    }
}
