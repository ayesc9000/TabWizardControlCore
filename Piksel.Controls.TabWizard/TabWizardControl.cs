using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace TabWizardControl
{
    public class TabWizardControl : TabControl
    {
        readonly Dictionary<TabPage, Func<TabPage?>> _nextPageActions = [];
        readonly Dictionary<TabPage, Func<TabPage?>> _prevPageActions = [];
        readonly Dictionary<TabPage, Action<bool>> _pageDisplay = [];
        string _nextButtonLabel = "Next";
        Button? _nextButton;
        Button? _prevButton;

        public void NextFunction(TabPage page, Func<TabPage?> func)
        {
            if (!_nextPageActions.TryAdd(page, func))
                _nextPageActions[page] = func;
        }

        public void NextFunction(TabPage page, Func<bool> func)
        {
            NextFunction(page, () => func() ? TabPages[TabPages.IndexOf(page) + 1] : null);
        }

        public void NextFunction(TabPage current, TabPage next)
        {
            NextFunction(current, () => next);
        }

        public void PreviousFunction(TabPage page, Func<TabPage?> func)
        {
            if (!_prevPageActions.TryAdd(page, func))
                _prevPageActions[page] = func;
        }

        public void PreviousFunction(TabPage page, Func<bool> func)
        {
            PreviousFunction(page, () => func() ? TabPages[TabPages.IndexOf(page) - 1] : null);
        }

        public void PreviousFunction(TabPage current, TabPage previous)
        {
            PreviousFunction(current, () => previous);
        }

        public void PageDisplayed(TabPage page, Action<bool> func)
        {
            if (!_pageDisplay.TryAdd(page, func))
                _pageDisplay[page] = func;
        }

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
                PreviousButton.Enabled = (SelectedIndex > 0);

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
                pageDisplay(false);

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
                pageDisplay(true);

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

        [Category("Buttons")]
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

        [Category("Buttons")]
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

        [DefaultValue("Finish")]
        [Category("Appearance")]
        public string LastPageButtonText { get; set; } = "Finish";

        [DefaultValue(true)]
        [Category("Design")]
        public bool HideTabs { get; set; } = true;

        [DefaultValue(false)]
        [Category("Design")]
        public bool HideTabsInDesigner { get; set; } = false;

        public new TabAlignment Alignment { get; set; } = TabAlignment.Bottom;

        public override string Text { get; set; } = string.Empty; // wth is going on with value nullability here???

        public event EventHandler? PageChanged;

        public event EventHandler? LastButtonClicked;
    }
}
