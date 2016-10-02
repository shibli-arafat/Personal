using System.Web.UI.WebControls;

namespace ArmyTraining
{
    public static class ControlExtension
    {
        public static void SetTooltip(this DropDownList ddList)
        {
            if (ddList == null || ddList.Items == null || ddList.Items.Count == 0)
                return;
            foreach (ListItem item in ddList.Items)
            {
                item.Attributes.Add("title", item.Text);
            }
            ddList.ToolTip = ddList.SelectedItem.Text;
        }

        public static void SetSelectedItem(this DropDownList ddList, int itemId)
        {
            if (ddList == null || ddList.Items == null || ddList.Items.Count == 0)
                return;
            for (int i = 0; i < ddList.Items.Count; i++)
            {
                if (ddList.Items[i].Value == itemId.ToString())
                {
                    ddList.SelectedIndex = i;
                    return;
                }
            }
        }
    }
}
