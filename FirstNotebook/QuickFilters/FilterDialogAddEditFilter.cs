using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FirstNotebook.QuickFilters;

namespace FirstNotebook
{
    internal class FilterDialogAddEditFilter
    {
        private readonly Form form1;
        private readonly ComboBox comboBox;
        private readonly TextBox textBox;
        private readonly List<string> currentFilters;

        public FilterDialogAddEditFilter(List<PageFilter> filterList, FilterAction action)
        {
            var showNothing = false;
            if (((filterList == null) || (filterList.Count == 0)) && (action != FilterAction.Add_New_Filter))
            {
                showNothing = true;
            }

            form1 = new Form();
            var buttonOk = new Button()
            {
                Text = action.ToString().Split('_')[0],
                Location = new Point(20, 120),
                DialogResult = DialogResult.OK,
            };

            var buttonCancel = new Button()
            {
                Text = "Cancel",
                Location = new Point(120, 120),
                DialogResult = DialogResult.Cancel,
            };

            form1.Text = action.ToString().Replace('_', ' ');

            form1.FormBorderStyle = FormBorderStyle.FixedDialog;
            form1.MaximizeBox = false;
            form1.MinimizeBox = false;

            form1.AcceptButton = buttonOk;
            form1.CancelButton = buttonCancel;
            form1.HelpButton = false;

            form1.StartPosition = FormStartPosition.CenterParent;
            if (!showNothing)
            {
                form1.Controls.Add(buttonOk);
            }

            form1.Controls.Add(buttonCancel);

            Label label1 = new Label()
            {
                Text = showNothing ? "No filters Exist." : "Filter Name:",
                Location = new Point(20, 25),
            };
            form1.Controls.Add(label1);

            if (showNothing)
            {
                return;
            }

            currentFilters = new List<string>();
            foreach (PageFilter subf in filterList)
            {
                currentFilters.Add(subf.Title);
            }

            var yPos = 50;
            if ((action == FilterAction.Update_Exising_Filter) || (action == FilterAction.Delete_Filter) ||
                (action == FilterAction.Add_Filter_To_Page) || (action == FilterAction.Delete_Filter_From_Page))
            {
                comboBox = new ComboBox()
                {
                    DataSource = currentFilters,
                    DisplayMember = currentFilters[0],
                    Location = new Point(20, yPos),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                yPos += 30;
                form1.Controls.Add(comboBox);
            }

            if ((action == FilterAction.Add_New_Filter) || (action == FilterAction.Update_Exising_Filter))
            {
                textBox = new TextBox()
                {
                    Size = new Size(200, 15),
                    Location = new Point(20, yPos),
                };
                form1.Controls.Add(textBox);
            }
        }

        public string GetSelectedName()
        {
            return comboBox.Text;
        }

        public string GetNewName()
        {
            return textBox.Text;
        }

        public DialogResult DoModal()
        {
            return form1.ShowDialog();
        }

    }
}