using System;
using System.Windows.Forms;

namespace TabWizardControlExample
{
    public partial class FormExample : Form
    {
        public FormExample()
        {
            InitializeComponent();

            wizard.NextFunction(tpFoo, () => rbBar.Checked ? tpBar : rbBaz.Checked ? tpBaz : null);
            wizard.PreviousFunction(tpBaz, tpFoo);
            wizard.NextFunction(tpBaz, () => comboBox1.SelectedIndex >= 0);
            wizard.NextFunction(tpBar, () => checkBox2.Checked ? tpEnd : null);
            wizard.PreviousFunction(tpEnd, () => rbBar.Checked ? tpBar : rbBaz.Checked ? tpBaz : tpFoo);
        }

        private void StateControlChanged(object sender, EventArgs e)
        {
            wizard.UpdateState();
        }

        private void WizardPageChanged(object sender, EventArgs e)
        {
            Text = "TabWizardControl Example - " + wizard.Text;
        }

        private void WizardLastButtonClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
