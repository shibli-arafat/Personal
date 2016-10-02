using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Dit.Lms.Gui
{
    public partial class ReportViewerWindow : Form
    {
        public ReportViewerWindow(ReportClass reportClass)
        {
            InitializeComponent();
            rptViewer.ReportSource = reportClass;
        }
    }
}
