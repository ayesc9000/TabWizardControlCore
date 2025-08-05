using System;
using System.Windows.Forms;

namespace TabWizardControl.Example
{
    public partial class FormExample : Form
    {
        public FormExample()
        {
            InitializeComponent();

            /* NextFunction allows you to define either what page to navigate to after a specific
            page has been displayed, or whether the user should be allowed to continue to the next
            page yet. You can even do both at the same time!
            
            NextFunction has 3 overloads to handle all 3 scenarios. You can define a specific page
            to navigate to after a specific page has been displayed by providing two TabPages, you
            can define whether to enable the next button by providing a TabPage and a function with
            a boolean return type, or combine both by providing a TabPage and a function that
            returns a nullable TabPage. If the TabPage is null, the next button is disabled.
            
            Remember that when you are disabling the next button temporarily to call
            Wizard.UpdateState() when you are ready to enable the button, as the function will not
            be re-evaluated automatically.
            
            If you do not specify a next function for a tab page, then the wizard will navigate to
            the next page in the tab list and leave the next button enabled.
            
            This example displays how to specify a tab page and determine whether to enable or
            disable the button by provinding a Func with a nullable TabPage return type. */
            Wizard.NextFunction(FooPage, () => BarRadioButton.Checked ? BarPage : BazRadioButton.Checked ? BazPage : null);

            /* PreviousFunction is the same as NextFunction but applies to navigating backwards
            instead. This example demonstrates specifying a specific page to navigate to when
            navigating away from a tab page. */
            Wizard.PreviousFunction(BazPage, FooPage);

            /* This example shows how to use a function with a boolean return value to enable or
            disable the next page button. */
            Wizard.NextFunction(BazPage, () => BazComboBox.SelectedIndex >= 0);

            Wizard.NextFunction(BarPage, () => BarCheckBox.Checked ? EndPage : null);
            Wizard.PreviousFunction(EndPage, () => BarRadioButton.Checked ? BarPage : BazRadioButton.Checked ? BazPage : FooPage);

            /* PageDisplayed allows you to invoke an action when a specific tab page is displayed.
            You can also determine whether the page was navigated to forwards or backwards based on
            the provided boolean parameter. This example will change a label to reflect whether the
            page was navigated to using the next or previous button.
            
            If you clicked next to get to the page, value will be true and it will display "You
            navigated forwards to this page!". If you clicked previous to get to the page, value
            will be false and it will display "You navigated backwards to this page!". */
            Wizard.PageDisplayed(FooPage, (value) =>
            {
                if (value)
                    NavigationLabel.Text = "You navigated forwards to this page!";
                else
                    NavigationLabel.Text = "You navigated backwards to this page!";
            });
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
