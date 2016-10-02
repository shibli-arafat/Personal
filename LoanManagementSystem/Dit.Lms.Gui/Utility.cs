using System;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public static class Utility
    {
        public static void SetSelectedItem(this ComboBox comboBox, DreamData data)
        {
            foreach (object item in comboBox.Items)
            {
                if ((item as DreamData).Id == data.Id)
                {
                    comboBox.SelectedItem = item;
                    return;
                }
            }
        }

        public static bool Exists(this ComboBox comboBox, DreamData data)
        {
            foreach (object item in comboBox.Items)
            {
                if ((item as DreamData).Id == data.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public static DateTime GetDate(this DateTimePicker dtPicker)
        {
            return new DateTime(dtPicker.Value.Year, dtPicker.Value.Month, dtPicker.Value.Day);
        }

        public static void FillYearCombo(this ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add(DateTime.Today.Year - 1);
            comboBox.Items.Add(DateTime.Today.Year);
            comboBox.Items.Add(DateTime.Today.Year + 1);
            comboBox.SelectedIndex = 1;
        }
    }
}
