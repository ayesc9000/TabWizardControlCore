using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace TabWizardControl
{
    /// <summary>
    /// The TabWizardControl provides a paged wizard control by repurposing a tab control and
    /// hiding the tabs.
    /// </summary>
    public class TabWizardControl : TabControl
    {
        readonly Dictionary<TabPage, Func<TabPage?>> _nextPageActions = [];
        readonly Dictionary<TabPage, Func<TabPage?>> _prevPageActions = [];
        readonly Dictionary<TabPage, Action<bool>> _pageDisplay = [];
        string _nextButtonLabel = "Next";
        Button? _nextButton;
        Button? _prevButton;

        /// <summary>
        /// Define a function to evaluate to determine the next tab page and associate it with the
        /// referenced tab page.
        /// </summary>
        /// <param name="page">The tab page to associate this function to.</param>
        /// <param name="func">A function to determine the next tab page to navigate to.</param>
        public void NextFunction(TabPage page, Func<TabPage?> func)
        {
            if (!_nextPageActions.TryAdd(page, func))
                _nextPageActions[page] = func;
        }

        /// <summary>
        /// Define a function to evaluate to determine whether the wizard can proceed to the next
        /// tab page and associate it with the referenced tab page.
        /// </summary>
        /// <param name="page">The tab page to associate this function to.</param>
        /// <param name="func">
        /// A function to determine whether to navigate to the next tab page.
        /// </param>
        public void NextFunction(TabPage page, Func<bool> func)
        {
            NextFunction(page, () => func() ? TabPages[TabPages.IndexOf(page) + 1] : null);
        }

        /// <summary>
        /// Define the next tab page to navigate to when the next button is clicked on a specific
        /// tab page.
        /// </summary>
        /// <param name="current">The tab page to associate the next page with.</param>
        /// <param name="next">
        /// The page to navigate to when next is clicked on the associated page.
        /// </param>
        public void NextFunction(TabPage current, TabPage next)
        {
            NextFunction(current, () => next);
        }

        /// <summary>
        /// Define a function to evaluate to determine the previous tab page and associate it with
        /// the referenced tab page.
        /// </summary>
        /// <param name="page">The tab page to associate this function to.</param>
        /// <param name="func">
        /// A function to determine the previous tab page to navigate to.
        /// </param>
        public void PreviousFunction(TabPage page, Func<TabPage?> func)
        {
            if (!_prevPageActions.TryAdd(page, func))
                _prevPageActions[page] = func;
        }

        /// <summary>
        /// Define a function to evaluate to determine whether the wizard can proceed to the 
        /// previous tab page and associate it with the referenced tab page.
        /// </summary>
        /// <param name="page">The tab page to associate this function to.</param>
        /// <param name="func">
        /// A function to determine whether to navigate to the previous tab page.
        /// </param>
        public void PreviousFunction(TabPage page, Func<bool> func)
        {
            PreviousFunction(page, () => (func() && TabPages.IndexOf(page) > 0) ? TabPages[TabPages.IndexOf(page) - 1] : null);
        }

        /// <summary>
        /// Define the previous tab page to navigate to when the previous button is clicked on a
        /// specific tab page.
        /// </summary>
        /// <param name="current">The tab page to associate the previous page with.</param>
        /// <param name="next">
        /// The page to navigate to when previous is clicked on the associated page.
        /// </param>
        public void PreviousFunction(TabPage current, TabPage previous)
        {
            PreviousFunction(current, () => previous);
        }

        /// <summary>
        /// Associate an action to a page which will be invoked when that page is shown. The action
        /// should take a single boolean parameter which will be true when the page is being
        /// navigated to next or false when navigated from previously.
        /// </summary>
        /// <param name="page">The tab page to associate this action with.</param>
        /// <param name="func">The action to invoke when the page is displayed.</param>
        public void PageDisplayed(TabPage page, Action<bool> func)
        {
            if (!_pageDisplay.TryAdd(page, func))
                _pageDisplay[page] = func;
        }

        /// <summary>
        /// Update the internal state of the tab wizard control and the state of the attached
        /// nagivation buttons.
        /// </summary>
        public void UpdateState()
        {
            // We might just want to simply return out here instead of selecting a new tab. Test
            // deeper and determine what the best course of action here is.
            if (SelectedTab == null)
                SelectDefaultTab();

            if (NextButton != null)
            {
                if (_nextPageActions.TryGetValue(SelectedTab!, out Func<TabPage?>? pageAction))
                    NextButton.Enabled = pageAction() != null;
                else
                    NextButton.Enabled = true;

                NextButton.Text = (SelectedIndex == TabCount - 1 && !string.IsNullOrEmpty(LastPageButtonText))
                    ? LastPageButtonText : _nextButtonLabel;
            }

            if (PreviousButton != null)
            {
                if (SelectedIndex <= 0)
                    PreviousButton.Enabled = false;
                else if (_prevPageActions.TryGetValue(SelectedTab!, out Func<TabPage?>? pageAction))
                    PreviousButton.Enabled = pageAction() != null;
                else
                    PreviousButton.Enabled = true;
            }

            Text = SelectedTab!.Text;
        }

        protected override void WndProc(ref Message m)
        {
            // Hide tabs by trapping the TCM_ADJUSTRECT message
            if (m.Msg == 0x1328
                && ((HideTabsInDesigner && DesignMode)
                || (HideTabs && !DesignMode)))
                m.Result = 1;
            else
                base.WndProc(ref m);
        }

        private void NextButtonClicked(object? sender, EventArgs e)
        {
            // We might just want to simply return out here instead of selecting a new tab. Test
            // deeper and determine what the best course of action here is.
            if (SelectedTab == null)
                SelectDefaultTab();

            if (SelectedIndex == TabPages.Count - 1)
            {
                OnLastButtonClicked();
                return;
            }

            if (_nextPageActions.TryGetValue(SelectedTab!, out Func<TabPage?>? pageAction))
                SelectedTab = pageAction();
            else
                SelectedIndex++;

            if (_pageDisplay.TryGetValue(SelectedTab!, out Action<bool>? pageDisplay))
                pageDisplay(true);

            UpdateState();
            OnPageChanged();
        }

        private void PreviousButtonClicked(object? sender, EventArgs e)
        {
            // We might just want to simply return out here instead of selecting a new tab. Test
            // deeper and determine what the best course of action here is.
            if (SelectedTab == null)
                SelectDefaultTab();

            if (_prevPageActions.TryGetValue(SelectedTab!, out Func<TabPage?>? pageAction))
                SelectedTab = pageAction();
            else if (SelectedIndex > 0)
                SelectedIndex--;

            if (_pageDisplay.TryGetValue(SelectedTab!, out Action<bool>? pageDisplay))
                pageDisplay(false);

            UpdateState();
            OnPageChanged();

        }

        private void SelectDefaultTab()
        {
            if (TabPages.Count < 1)
                throw new InvalidOperationException("There are no pages in this TabWizardControl.");

            TabPages[0].Select();
        }

        private void OnPageChanged() => PageChanged?.Invoke(this, new EventArgs());

        private void OnLastButtonClicked() => LastButtonClicked?.Invoke(this, new EventArgs());

        /// <summary>
        /// Define the button to treat as the next page button.
        /// </summary>
        [Category("Buttons")]
        [Description("Defines the button that will serve as the next page button.")]
        public Button? NextButton
        {
            get
            {
                return _nextButton;
            }
            set
            {
                if (value == null) return;

                _nextButton = value;
                _nextButtonLabel = _nextButton.Text;
                _nextButton.Click += NextButtonClicked;
            }
        }

        /// <summary>
        /// Define the button to treat as the last page button.
        /// </summary>
        [Category("Buttons")]
        [Description("Defines the button that will serve as the previous page button.")]
        public Button? PreviousButton
        {
            get
            {
                return _prevButton;
            }
            set
            {
                if (value == null) return;

                _prevButton = value;
                _prevButton.Enabled = false;
                _prevButton.Click += PreviousButtonClicked;
            }
        }

        /// <summary>
        /// Set the text to display on the next page button when the wizard is on the last page.
        /// </summary>
        [Category("Appearance")]
        [Description("The text to display on the next page button when the wizard is on the last page.")]
        [DefaultValue("Finish")]
        public string LastPageButtonText { get; set; } = "Finish";

        /// <summary>
        /// Whether to hide the tabs on the control.
        /// </summary>
        [Category("Design")]
        [Description("Whether to hide the tabs on the control.")]
        [DefaultValue(true)]
        public bool HideTabs { get; set; } = true;

        /// <summary>
        /// Whether to hide the tabs on the control in the designer. This is useful for previewing
        /// what the wizard will look like.
        /// </summary>
        [Category("Design")]
        [Description("Whether to hide the tabs on the control in the designer. This is useful for previewing what the wizard will look like.")]
        [DefaultValue(false)]
        public bool HideTabsInDesigner { get; set; } = false;

        /// <summary>
        /// Get or set the TabAlignment of the tabs in the wizard.
        /// </summary>
        public new TabAlignment Alignment { get; set; } = TabAlignment.Bottom;

        /// <summary>
        /// This property contains the text value to the current TabPage.
        /// </summary>
        public override string Text { get; set; } = string.Empty; // wth is going on with nullability here???

        /// <summary>
        /// This event is raised when the current page of the wizard is changed.
        /// </summary>
        public event EventHandler? PageChanged;

        /// <summary>
        /// This event is raised when the last next button is clicked.
        /// </summary>
        public event EventHandler? LastButtonClicked;
    }
}
