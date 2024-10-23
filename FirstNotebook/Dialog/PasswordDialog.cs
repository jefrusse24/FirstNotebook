using System.Drawing;
using System.Windows.Forms;

namespace FirstNotebook
{
    public class PasswordDialog
    {
        private readonly Form form1;
        private readonly TextBox textbox1;
        private readonly TextBox textbox2;

        public PasswordDialog()
        {
            form1 = new Form();
            var buttonOk = new Button()
            {
                Text = "OK",
                Location = new Point(20, 90),
                DialogResult = DialogResult.OK,
            };

            var buttonCancel = new Button()
            {
                Text = "Cancel",
                Location = new Point(120, 90),
                DialogResult = DialogResult.Cancel,
            };

            form1.Text = "Password Prompt";

            form1.FormBorderStyle = FormBorderStyle.FixedDialog;
            form1.MaximizeBox = false;
            form1.MinimizeBox = false;

            form1.AcceptButton = buttonOk;
            form1.CancelButton = buttonCancel;
            form1.HelpButton = false;

            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Controls.Add(buttonOk);
            form1.Controls.Add(buttonCancel);

            Label label1 = new Label()
            {
                Text = "Enter Password",
                Location = new Point(20, 25),
            };

            Label label2 = new Label()
            {
                Text = "Re-Enter Password",
                Location = new Point(20, 55),
            };

            textbox1 = new TextBox()
            {
                Size = new Size(100, 10),
                Location = new Point(120, 20),
            };
            textbox2 = new TextBox()
            {
                Size = new Size(100, 10),
                Location = new Point(120, 50),
            };

            form1.Controls.Add(label1);
            form1.Controls.Add(label2);
            form1.Controls.Add(textbox1);
            form1.Controls.Add(textbox2);
        }

        public PasswordResult IsValidPassword()
        {
            if ((textbox1 == null) || (textbox2 == null))
            {
                return PasswordResult.PasswordInvalid;
            }

            if (!textbox1.Text.Equals(textbox2.Text))
            {
                return PasswordResult.PasswordMismatch;
            }

            if (textbox1.Text.Equals(textbox1.Text))
            {
                if (textbox1.Text.Length < 6)
                {
                    return PasswordResult.PasswordTooShort;
                }
            }

            return PasswordResult.PasswordGood;
        }

        public string GetPassword()
        {
            if (IsValidPassword() != PasswordResult.PasswordGood)
            {
                return null;
            }

            return textbox1.Text;
        }

        public DialogResult DoModal()
        {
            return form1.ShowDialog();
        }
    }
}
