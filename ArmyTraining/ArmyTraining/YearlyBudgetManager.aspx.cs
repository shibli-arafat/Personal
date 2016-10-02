using System;
using System.Web.UI.WebControls;
using ArmyTraining.Internal;
using ArmyTraining.Model;

namespace ArmyTraining
{
    public partial class YearlyBudgetManager : System.Web.UI.Page
    {
        private YearlyBudgetInternal _Internal;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Internal = new YearlyBudgetInternal();
            if (!IsPostBack)
            {
                YearlyBudgetCollection budgets = _Internal.GetYearlyBudgets();
                this.PopulateBudgets(budgets);
            }
        }

        protected void ItemData_Bound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton deleteButton = e.Item.FindControl("imgBtnDelete") as ImageButton;
                deleteButton.CommandArgument = ((YearlyBudget)e.Item.DataItem).Id.ToString();

                ImageButton imgEdit = e.Item.FindControl("imgEdit") as ImageButton;
                imgEdit.Attributes.Add("onclick", "return OpenDetail(" + ((YearlyBudget)e.Item.DataItem).Id.ToString() + ")");
            }
        }

        protected void DeleteCommand(object sender, CommandEventArgs e)
        {
            _Internal.DeleteYearlyBudget(int.Parse(e.CommandArgument.ToString()));
            YearlyBudgetCollection budgets = _Internal.GetYearlyBudgets();
            this.PopulateBudgets(budgets);
        }

        protected void ItemEdited(object sender, EventArgs e)
        {
            YearlyBudgetCollection budgets = _Internal.GetYearlyBudgets();
            this.PopulateBudgets(budgets);
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            Server.Transfer("YearlyBudgetReportViewer.aspx");
        }

        public void PopulateBudgets(YearlyBudgetCollection ranks)
        {
            rptYearlyBudgets.Visible = ranks.Count > 0;
            spnEmptyRow.Visible = ranks.Count == 0;
            rptYearlyBudgets.Controls.Clear();
            rptYearlyBudgets.DataSource = ranks;
            rptYearlyBudgets.DataBind();
        }
    }
}
