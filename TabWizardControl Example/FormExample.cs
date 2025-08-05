using System;
using System.Windows.Forms;

namespace TabWizardControl.Example
{
    public partial class FormExample : Form
    {
        public FormExample()
        {
            InitializeComponent();

            Wizard.NextFunction(FooPage, () => BarRadioButton.Checked ? BarPage : BazRadioButton.Checked ? BazPage : null);
            Wizard.PreviousFunction(BazPage, FooPage);
            Wizard.NextFunction(BazPage, () => BazComboBox.SelectedIndex >= 0);
            Wizard.NextFunction(BarPage, () => BarCheckBox.Checked ? EndPage : null);
            Wizard.PreviousFunction(EndPage, () => BarRadioButton.Checked ? BarPage : BazRadioButton.Checked ? BazPage : FooPage);
        }

        private void StateControlChanged(object sender, EventArgs e)
        {
            Wizard.UpdateState();
        }

        private void WizardPageChanged(object sender, EventArgs e)
        {
            Text = "TabWizardControl Example - " + Wizard.Text;
        }

        private void WizardLastButtonClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
