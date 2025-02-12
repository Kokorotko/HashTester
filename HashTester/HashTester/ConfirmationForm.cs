using System;
using System.Drawing;
using System.Windows.Forms;

namespace HashTester
{
    public partial class ConfirmationForm : Form
    {
        string text;
        int padding = 20;
        int buttonWidth = 100;
        int buttonHeight = 30;

        public ConfirmationForm(string text)
        {
            this.text = text;
            InitializeComponent();
        }

        private void ConfirmationForm_Load(object sender, EventArgs e)
        {
            label1.Text = text;
            label1.AutoSize = true;

            Size textSize = TextRenderer.MeasureText(text, label1.Font);
            int formWidth = Math.Max(textSize.Width + padding * 2, buttonWidth * 2 + padding * 3);
            int formHeight = textSize.Height + buttonHeight + padding * 3;

            if (textSize.Width > formWidth - padding * 2) //If label1.Text is too long
            {
                label1.MaximumSize = new Size(formWidth - padding * 2, 0);
                formHeight = label1.PreferredHeight + buttonHeight + padding * 3;
            }

            //Location
            this.ClientSize = new Size(formWidth, formHeight);
            label1.Location = new Point((this.ClientSize.Width - label1.Width) / 2, padding);
            button1.Location = new Point(this.ClientSize.Width / 4 - buttonWidth / 2, this.ClientSize.Height - buttonHeight - padding);
            button2.Location = new Point(3 * this.ClientSize.Width / 4 - buttonWidth / 2, this.ClientSize.Height - buttonHeight - padding);
            FormManagement.SetUpFormTheme(this);
        }
    }
}
