using System;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class IncomeHeadList : BaseForm
    {
        private Form _MdiParent;
        private IncomeHeadSave _IncomeHeadForm;
        private IncomeHead _IncomeHead;
        private IncomeHeadCollection _IncomeHeads;

        public IncomeHeadList(Form mdiParent)
        {
            _MdiParent = mdiParent;
            InitializeComponent();
            grdIncomeHeadList.AutoGenerateColumns = false;
        }

        private void RefreshGridData(IncomeHead incomeHead)
        {
            _IncomeHeads.Update(incomeHead);
            BindIncomeHeads();
        }

        private void BindIncomeHeads()
        {
            this.BindingSource.DataSource = _IncomeHeads;
            this.BindingSource.ResetBindings(false);
            grdIncomeHeadList.DataSource = this.BindingSource;
        }

        private void IncomeHeadList_Load(object sender, EventArgs e)
        {
            _IncomeHeads = Service.GetIncomeHeads();
            BindIncomeHeads();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _IncomeHead = new IncomeHead();
            ShowIncomeHeadForm();
        }

        private void grdIncomeHeadList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _IncomeHead = grdIncomeHeadList.CurrentRow.DataBoundItem as IncomeHead;
            ShowIncomeHeadForm();
        }

        private void ShowIncomeHeadForm()
        {
            if (_IncomeHeadForm == null || _IncomeHeadForm.IsDisposed) _IncomeHeadForm = new IncomeHeadSave(_IncomeHead, RefreshGridData);
            _IncomeHeadForm.MdiParent = _MdiParent;
            if (!_IncomeHeadForm.Visible) _IncomeHeadForm.Show();
            else _IncomeHeadForm.Activate();
        }
    }
}
