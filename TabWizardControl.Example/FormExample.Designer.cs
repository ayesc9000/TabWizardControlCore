namespace TabWizardControl.Example
{
    partial class FormExample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PreviousButton = new System.Windows.Forms.Button();
            NextButton = new System.Windows.Forms.Button();
            Wizard = new TabWizardControl();
            IntroPage = new System.Windows.Forms.TabPage();
            IntroLabel = new System.Windows.Forms.Label();
            FooPage = new System.Windows.Forms.TabPage();
            NavigationLabel = new System.Windows.Forms.Label();
            BazRadioButton = new System.Windows.Forms.RadioButton();
            BarRadioButton = new System.Windows.Forms.RadioButton();
            FooLabel = new System.Windows.Forms.Label();
            BarPage = new System.Windows.Forms.TabPage();
            BarCheckBox = new System.Windows.Forms.CheckBox();
            BarLabel = new System.Windows.Forms.Label();
            BazPage = new System.Windows.Forms.TabPage();
            BazComboBox = new System.Windows.Forms.ComboBox();
            ComboBoxLabel = new System.Windows.Forms.Label();
            BazLabel = new System.Windows.Forms.Label();
            EndPage = new System.Windows.Forms.TabPage();
            EndLabel = new System.Windows.Forms.Label();
            ButtonPanel = new System.Windows.Forms.Panel();
            Wizard.SuspendLayout();
            IntroPage.SuspendLayout();
            FooPage.SuspendLayout();
            BarPage.SuspendLayout();
            BazPage.SuspendLayout();
            EndPage.SuspendLayout();
            ButtonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // PreviousButton
            // 
            PreviousButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            PreviousButton.Location = new System.Drawing.Point(13, 11);
            PreviousButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PreviousButton.Name = "PreviousButton";
            PreviousButton.Size = new System.Drawing.Size(135, 45);
            PreviousButton.TabIndex = 1;
            PreviousButton.Text = "&Previous";
            PreviousButton.UseVisualStyleBackColor = true;
            // 
            // NextButton
            // 
            NextButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            NextButton.Location = new System.Drawing.Point(564, 11);
            NextButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NextButton.Name = "NextButton";
            NextButton.Size = new System.Drawing.Size(135, 45);
            NextButton.TabIndex = 2;
            NextButton.Text = "&Next";
            NextButton.UseVisualStyleBackColor = true;
            // 
            // Wizard
            // 
            Wizard.Alignment = System.Windows.Forms.TabAlignment.Left;
            Wizard.Controls.Add(IntroPage);
            Wizard.Controls.Add(FooPage);
            Wizard.Controls.Add(BarPage);
            Wizard.Controls.Add(BazPage);
            Wizard.Controls.Add(EndPage);
            Wizard.Dock = System.Windows.Forms.DockStyle.Fill;
            Wizard.LastPageButtonText = "Close";
            Wizard.Location = new System.Drawing.Point(0, 0);
            Wizard.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Wizard.Name = "Wizard";
            Wizard.NextButton = NextButton;
            Wizard.PreviousButton = PreviousButton;
            Wizard.SelectedIndex = 0;
            Wizard.Size = new System.Drawing.Size(712, 380);
            Wizard.TabIndex = 0;
            Wizard.Text = null;
            Wizard.PageChanged += WizardPageChanged;
            Wizard.LastButtonClicked += WizardLastButtonClicked;
            // 
            // IntroPage
            // 
            IntroPage.Controls.Add(IntroLabel);
            IntroPage.Location = new System.Drawing.Point(4, 24);
            IntroPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            IntroPage.Name = "IntroPage";
            IntroPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            IntroPage.Size = new System.Drawing.Size(704, 352);
            IntroPage.TabIndex = 3;
            IntroPage.Text = "Intro";
            IntroPage.UseVisualStyleBackColor = true;
            // 
            // IntroLabel
            // 
            IntroLabel.AutoSize = true;
            IntroLabel.Font = new System.Drawing.Font("Segoe UI Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            IntroLabel.Location = new System.Drawing.Point(7, 3);
            IntroLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            IntroLabel.Name = "IntroLabel";
            IntroLabel.Size = new System.Drawing.Size(121, 65);
            IntroLabel.TabIndex = 2;
            IntroLabel.Text = "Intro";
            // 
            // FooPage
            // 
            FooPage.Controls.Add(NavigationLabel);
            FooPage.Controls.Add(BazRadioButton);
            FooPage.Controls.Add(BarRadioButton);
            FooPage.Controls.Add(FooLabel);
            FooPage.Location = new System.Drawing.Point(4, 24);
            FooPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            FooPage.Name = "FooPage";
            FooPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            FooPage.Size = new System.Drawing.Size(704, 352);
            FooPage.TabIndex = 0;
            FooPage.Text = "Foo Page";
            FooPage.UseVisualStyleBackColor = true;
            // 
            // NavigationLabel
            // 
            NavigationLabel.AutoSize = true;
            NavigationLabel.Location = new System.Drawing.Point(20, 146);
            NavigationLabel.Name = "NavigationLabel";
            NavigationLabel.Size = new System.Drawing.Size(76, 15);
            NavigationLabel.TabIndex = 4;
            NavigationLabel.Text = "Default Value";
            // 
            // BazRadioButton
            // 
            BazRadioButton.AutoSize = true;
            BazRadioButton.Location = new System.Drawing.Point(20, 108);
            BazRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BazRadioButton.Name = "BazRadioButton";
            BazRadioButton.Size = new System.Drawing.Size(75, 19);
            BazRadioButton.TabIndex = 3;
            BazRadioButton.Text = "Go to Baz";
            BazRadioButton.UseVisualStyleBackColor = true;
            BazRadioButton.CheckedChanged += StateControlChanged;
            // 
            // BarRadioButton
            // 
            BarRadioButton.AutoSize = true;
            BarRadioButton.Location = new System.Drawing.Point(20, 82);
            BarRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BarRadioButton.Name = "BarRadioButton";
            BarRadioButton.Size = new System.Drawing.Size(74, 19);
            BarRadioButton.TabIndex = 2;
            BarRadioButton.Text = "Go to Bar";
            BarRadioButton.UseVisualStyleBackColor = true;
            BarRadioButton.CheckedChanged += StateControlChanged;
            // 
            // FooLabel
            // 
            FooLabel.AutoSize = true;
            FooLabel.Font = new System.Drawing.Font("Segoe UI Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FooLabel.Location = new System.Drawing.Point(7, 3);
            FooLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            FooLabel.Name = "FooLabel";
            FooLabel.Size = new System.Drawing.Size(104, 65);
            FooLabel.TabIndex = 1;
            FooLabel.Text = "Foo";
            // 
            // BarPage
            // 
            BarPage.Controls.Add(BarCheckBox);
            BarPage.Controls.Add(BarLabel);
            BarPage.Location = new System.Drawing.Point(4, 24);
            BarPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BarPage.Name = "BarPage";
            BarPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BarPage.Size = new System.Drawing.Size(704, 352);
            BarPage.TabIndex = 1;
            BarPage.Text = "Bar Page";
            BarPage.UseVisualStyleBackColor = true;
            // 
            // BarCheckBox
            // 
            BarCheckBox.AutoSize = true;
            BarCheckBox.Location = new System.Drawing.Point(20, 82);
            BarCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BarCheckBox.Name = "BarCheckBox";
            BarCheckBox.Size = new System.Drawing.Size(124, 19);
            BarCheckBox.TabIndex = 3;
            BarCheckBox.Text = "Enable proceeding";
            BarCheckBox.UseVisualStyleBackColor = true;
            BarCheckBox.CheckedChanged += StateControlChanged;
            // 
            // BarLabel
            // 
            BarLabel.AutoSize = true;
            BarLabel.Font = new System.Drawing.Font("Segoe UI Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            BarLabel.Location = new System.Drawing.Point(7, 3);
            BarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            BarLabel.Name = "BarLabel";
            BarLabel.Size = new System.Drawing.Size(94, 65);
            BarLabel.TabIndex = 1;
            BarLabel.Text = "Bar";
            // 
            // BazPage
            // 
            BazPage.Controls.Add(BazComboBox);
            BazPage.Controls.Add(ComboBoxLabel);
            BazPage.Controls.Add(BazLabel);
            BazPage.Location = new System.Drawing.Point(4, 24);
            BazPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BazPage.Name = "BazPage";
            BazPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BazPage.Size = new System.Drawing.Size(704, 352);
            BazPage.TabIndex = 2;
            BazPage.Text = "Baz Page";
            BazPage.UseVisualStyleBackColor = true;
            // 
            // BazComboBox
            // 
            BazComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            BazComboBox.FormattingEnabled = true;
            BazComboBox.Items.AddRange(new object[] { "One", "Two", "Three" });
            BazComboBox.Location = new System.Drawing.Point(20, 115);
            BazComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BazComboBox.Name = "BazComboBox";
            BazComboBox.Size = new System.Drawing.Size(140, 23);
            BazComboBox.TabIndex = 2;
            BazComboBox.SelectedIndexChanged += StateControlChanged;
            // 
            // ComboBoxLabel
            // 
            ComboBoxLabel.AutoSize = true;
            ComboBoxLabel.Location = new System.Drawing.Point(20, 93);
            ComboBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            ComboBoxLabel.Name = "ComboBoxLabel";
            ComboBoxLabel.Size = new System.Drawing.Size(90, 15);
            ComboBoxLabel.TabIndex = 3;
            ComboBoxLabel.Text = "Choose a value:";
            // 
            // BazLabel
            // 
            BazLabel.AutoSize = true;
            BazLabel.Font = new System.Drawing.Font("Segoe UI Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            BazLabel.Location = new System.Drawing.Point(7, 3);
            BazLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            BazLabel.Name = "BazLabel";
            BazLabel.Size = new System.Drawing.Size(100, 65);
            BazLabel.TabIndex = 1;
            BazLabel.Text = "Baz";
            // 
            // EndPage
            // 
            EndPage.Controls.Add(EndLabel);
            EndPage.Location = new System.Drawing.Point(4, 24);
            EndPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EndPage.Name = "EndPage";
            EndPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EndPage.Size = new System.Drawing.Size(704, 352);
            EndPage.TabIndex = 4;
            EndPage.Text = "End";
            EndPage.UseVisualStyleBackColor = true;
            // 
            // EndLabel
            // 
            EndLabel.AutoSize = true;
            EndLabel.Font = new System.Drawing.Font("Segoe UI Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            EndLabel.Location = new System.Drawing.Point(7, 3);
            EndLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            EndLabel.Name = "EndLabel";
            EndLabel.Size = new System.Drawing.Size(105, 65);
            EndLabel.TabIndex = 2;
            EndLabel.Text = "End";
            // 
            // ButtonPanel
            // 
            ButtonPanel.Controls.Add(PreviousButton);
            ButtonPanel.Controls.Add(NextButton);
            ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            ButtonPanel.Location = new System.Drawing.Point(0, 380);
            ButtonPanel.Name = "ButtonPanel";
            ButtonPanel.Size = new System.Drawing.Size(712, 68);
            ButtonPanel.TabIndex = 4;
            // 
            // FormExample
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(712, 448);
            Controls.Add(Wizard);
            Controls.Add(ButtonPanel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(494, 487);
            Name = "FormExample";
            Text = "TabWizardControl Example";
            Wizard.ResumeLayout(false);
            IntroPage.ResumeLayout(false);
            IntroPage.PerformLayout();
            FooPage.ResumeLayout(false);
            FooPage.PerformLayout();
            BarPage.ResumeLayout(false);
            BarPage.PerformLayout();
            BazPage.ResumeLayout(false);
            BazPage.PerformLayout();
            EndPage.ResumeLayout(false);
            EndPage.PerformLayout();
            ButtonPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private TabWizardControl Wizard;
        private System.Windows.Forms.TabPage FooPage;
        private System.Windows.Forms.TabPage BarPage;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.TabPage BazPage;
        private System.Windows.Forms.Label FooLabel;
        private System.Windows.Forms.Label BarLabel;
        private System.Windows.Forms.Label BazLabel;
        private System.Windows.Forms.CheckBox BarCheckBox;
        private System.Windows.Forms.TabPage IntroPage;
        private System.Windows.Forms.Label IntroLabel;
        private System.Windows.Forms.RadioButton BazRadioButton;
        private System.Windows.Forms.RadioButton BarRadioButton;
        private System.Windows.Forms.TabPage EndPage;
        private System.Windows.Forms.Label ComboBoxLabel;
        private System.Windows.Forms.ComboBox BazComboBox;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Label NavigationLabel;
    }
}

