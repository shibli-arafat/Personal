using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class LoanDisbursementList : BaseForm
    {
        private Form _MdiParent;
        private LoanDisbursementSave _LoanDisbursementForm;
        private LoanDisbursement _LoanDisbursement;
        private LoanDisbursementCollection _LoanDisbursements;

        public LoanDisbursementList(Form mdiParent)
        {
            _MdiParent = mdiParent;
            InitializeComponent();
            grdDisbursmentList.AutoGenerateColumns = false;
        }

        private void RefreshGridData(LoanDisbursement gridData)
        {
            _LoanDisbursements.Update(gridData);
            BindLoanDisbursements();
        }

        private void BindLoanDisbursements()
        {
            this.BindingSource.DataSource = _LoanDisbursements;
            this.BindingSource.ResetBindings(false);
            grdDisbursmentList.DataSource = this.BindingSource;
        }

        private void btnAddNew_Click(object sender, System.EventArgs e)
        {
            _LoanDisbursement = new LoanDisbursement();
            ShowLoanDisbursementForm();
        }

        private void ShowLoanDisbursementForm()
        {
            if (_LoanDisbursementForm == null || _LoanDisbursementForm.IsDisposed) _LoanDisbursementForm = new LoanDisbursementSave(_LoanDisbursement, RefreshGridData);
            _LoanDisbursementForm.MdiParent = _MdiParent;
            if (!_LoanDisbursementForm.Visible) _LoanDisbursementForm.Show();
            else _LoanDisbursementForm.Activate();
        }

        private void LoanDisbursementList_Load(object sender, System.EventArgs e)
        {
            _LoanDisbursements = Service.GetLoanDisbursements();
            BindLoanDisbursements();
        }

        private void grdDisbursmentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _LoanDisbursement = grdDisbursmentList.CurrentRow.DataBoundItem as LoanDisbursement;
            ShowLoanDisbursementForm();
        }
    }
}
