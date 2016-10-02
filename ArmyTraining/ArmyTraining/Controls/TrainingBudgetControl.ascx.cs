using System;
using System.Web.UI.WebControls;
using ArmyTraining.Model.Trainings;

namespace ArmyTraining.Controls
{
    public partial class TrainingBudgetControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void OnAdditionalBudgetsBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                AdditionalExpenditure item = e.Item.DataItem as AdditionalExpenditure;
                TextBox txtName = e.Item.FindControl("txtName") as TextBox;
                ImageButton deleteButton = e.Item.FindControl("imgBtnDelete") as ImageButton;
                RadioButtonList rdbList = e.Item.FindControl("rdbList") as RadioButtonList;
                TextBox txtRemarks = e.Item.FindControl("txtRemarks") as TextBox;
                deleteButton.CommandArgument = e.Item.ItemIndex.ToString();
                txtName.Text = item.Details;
                txtRemarks.Text = item.Remarks;
                rdbList.SelectedValue = ((int)item.Mode).ToString();
            }
        }



        private void BindBudgets(AdditionalExpenditureCollection expences)
        {
            rptAdditionalBudgets.DataSource = expences;
            rptAdditionalBudgets.DataBind();
        }

        protected void DeleteAdditionalBudgetInfo(object sender, EventArgs e)
        {
            ImageButton deleteButton = sender as ImageButton;
            int index = int.Parse(deleteButton.CommandArgument);
            AdditionalExpenditureCollection expences = GetInfo().AdditionalExpences;
            expences.RemoveAt(index);
            BindBudgets(expences);
        }

        protected void AddAdditionalBudgetInfo(object sender, EventArgs e)
        {
            AdditionalExpenditureCollection expences = GetInfo().AdditionalExpences;
            expences.Add(new AdditionalExpenditure());
            BindBudgets(expences);
        }

        internal void Initialize(TrainingBudgetInfo trainingBudgetInfo)
        {
            BindBudgets(trainingBudgetInfo.AdditionalExpences);
        }

        internal TrainingBudgetInfo GetInfo()
        {
            TrainingBudgetInfo result = new TrainingBudgetInfo();
            foreach (RepeaterItem item in rptAdditionalBudgets.Items)
            {
                if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                {
                    AdditionalExpenditure expence = new AdditionalExpenditure();
                    TextBox txtName = item.FindControl("txtName") as TextBox;
                    RadioButtonList rdbList = item.FindControl("rdbList") as RadioButtonList;
                    TextBox txtRemarks = item.FindControl("txtRemarks") as TextBox;
                    expence.Details = txtName.Text;
                    expence.Remarks = txtRemarks.Text;
                    expence.Mode = (AdditionExpenditureMode)int.Parse(rdbList.SelectedValue);
                    result.AdditionalExpences.Add(expence);
                }
            }
            return result;
        }
    }
}