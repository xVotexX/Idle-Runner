namespace Idle_Runner.Forms
{
    partial class Settings
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
            closeButton = new Button();
            rpcCheck = new CheckBox();
            gamesLabel = new Label();
            hideIdleCheck = new CheckBox();
            gameListComboBox = new ComboBox();
            idletimeTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            applyTimeButton = new Button();
            deleteDataButton = new Button();
            resetTimeButton = new Button();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            closeButton.FlatAppearance.MouseOverBackColor = Color.Red;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            closeButton.ForeColor = Color.Transparent;
            closeButton.Location = new Point(264, 12);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(24, 29);
            closeButton.TabIndex = 0;
            closeButton.Text = "X";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // rpcCheck
            // 
            rpcCheck.AutoSize = true;
            rpcCheck.Checked = true;
            rpcCheck.CheckState = CheckState.Checked;
            rpcCheck.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rpcCheck.ForeColor = Color.White;
            rpcCheck.Location = new Point(18, 99);
            rpcCheck.Name = "rpcCheck";
            rpcCheck.Size = new Size(156, 22);
            rpcCheck.TabIndex = 1;
            rpcCheck.Text = "Discord Rich Presence";
            rpcCheck.UseVisualStyleBackColor = true;
            rpcCheck.CheckedChanged += rpcCheck_CheckedChanged;
            // 
            // gamesLabel
            // 
            gamesLabel.AutoSize = true;
            gamesLabel.Font = new Font("Nunito", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gamesLabel.ForeColor = Color.White;
            gamesLabel.Location = new Point(12, 12);
            gamesLabel.Name = "gamesLabel";
            gamesLabel.Size = new Size(92, 29);
            gamesLabel.TabIndex = 3;
            gamesLabel.Text = "Settings";
            gamesLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // hideIdleCheck
            // 
            hideIdleCheck.AutoSize = true;
            hideIdleCheck.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            hideIdleCheck.ForeColor = Color.White;
            hideIdleCheck.Location = new Point(18, 127);
            hideIdleCheck.Name = "hideIdleCheck";
            hideIdleCheck.Size = new Size(139, 22);
            hideIdleCheck.TabIndex = 4;
            hideIdleCheck.Text = "Hide Idlers on start";
            hideIdleCheck.UseVisualStyleBackColor = true;
            hideIdleCheck.CheckedChanged += hideIdleCheck_CheckedChanged;
            // 
            // gameListComboBox
            // 
            gameListComboBox.BackColor = Color.FromArgb(30, 30, 30);
            gameListComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            gameListComboBox.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gameListComboBox.ForeColor = Color.White;
            gameListComboBox.FormattingEnabled = true;
            gameListComboBox.Location = new Point(18, 211);
            gameListComboBox.Name = "gameListComboBox";
            gameListComboBox.Size = new Size(265, 26);
            gameListComboBox.Sorted = true;
            gameListComboBox.TabIndex = 5;
            gameListComboBox.SelectedIndexChanged += gameListComboBox_SelectedIndexChanged;
            // 
            // idletimeTextBox
            // 
            idletimeTextBox.BackColor = Color.FromArgb(30, 30, 30);
            idletimeTextBox.BorderStyle = BorderStyle.FixedSingle;
            idletimeTextBox.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idletimeTextBox.ForeColor = Color.White;
            idletimeTextBox.Location = new Point(18, 243);
            idletimeTextBox.Name = "idletimeTextBox";
            idletimeTextBox.PlaceholderText = "Idletime in Hours";
            idletimeTextBox.Size = new Size(102, 25);
            idletimeTextBox.TabIndex = 6;
            idletimeTextBox.KeyPress += playtimeBox_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nunito", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 65);
            label1.Name = "label1";
            label1.Size = new Size(46, 22);
            label1.TabIndex = 7;
            label1.Text = "Main";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Nunito", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(14, 177);
            label2.Name = "label2";
            label2.Size = new Size(92, 22);
            label2.TabIndex = 8;
            label2.Text = "Edit Config";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // applyTimeButton
            // 
            applyTimeButton.BackColor = Color.Transparent;
            applyTimeButton.FlatAppearance.BorderSize = 0;
            applyTimeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(15, 15, 15);
            applyTimeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            applyTimeButton.FlatStyle = FlatStyle.Flat;
            applyTimeButton.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            applyTimeButton.ForeColor = Color.White;
            applyTimeButton.Location = new Point(126, 243);
            applyTimeButton.Name = "applyTimeButton";
            applyTimeButton.Size = new Size(157, 25);
            applyTimeButton.TabIndex = 15;
            applyTimeButton.TabStop = false;
            applyTimeButton.Text = "Apply Idletime";
            applyTimeButton.UseVisualStyleBackColor = false;
            applyTimeButton.Click += applyTimeButton_Click;
            // 
            // deleteDataButton
            // 
            deleteDataButton.BackColor = Color.Transparent;
            deleteDataButton.FlatAppearance.BorderSize = 0;
            deleteDataButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            deleteDataButton.FlatAppearance.MouseOverBackColor = Color.Red;
            deleteDataButton.FlatStyle = FlatStyle.Flat;
            deleteDataButton.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deleteDataButton.ForeColor = Color.White;
            deleteDataButton.Location = new Point(18, 362);
            deleteDataButton.Name = "deleteDataButton";
            deleteDataButton.Size = new Size(265, 26);
            deleteDataButton.TabIndex = 16;
            deleteDataButton.TabStop = false;
            deleteDataButton.Text = "Delete Game Data";
            deleteDataButton.UseVisualStyleBackColor = false;
            deleteDataButton.Click += deleteDataButton_Click;
            // 
            // resetTimeButton
            // 
            resetTimeButton.BackColor = Color.Transparent;
            resetTimeButton.FlatAppearance.BorderSize = 0;
            resetTimeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 64, 0);
            resetTimeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            resetTimeButton.FlatStyle = FlatStyle.Flat;
            resetTimeButton.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resetTimeButton.ForeColor = Color.White;
            resetTimeButton.Location = new Point(18, 330);
            resetTimeButton.Name = "resetTimeButton";
            resetTimeButton.Size = new Size(265, 26);
            resetTimeButton.TabIndex = 17;
            resetTimeButton.TabStop = false;
            resetTimeButton.Text = "Reset Idletime";
            resetTimeButton.UseVisualStyleBackColor = false;
            resetTimeButton.Click += resetTimeButton_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(300, 400);
            Controls.Add(resetTimeButton);
            Controls.Add(deleteDataButton);
            Controls.Add(applyTimeButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(idletimeTextBox);
            Controls.Add(gameListComboBox);
            Controls.Add(hideIdleCheck);
            Controls.Add(gamesLabel);
            Controls.Add(rpcCheck);
            Controls.Add(closeButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Settings";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            Load += Settings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button closeButton;
        private Label gamesLabel;
        private TextBox idletimeTextBox;
        private Label label1;
        private Label label2;
        public ComboBox gameListComboBox;
        private Button applyTimeButton;
        private Button deleteDataButton;
        private Button resetTimeButton;
        public CheckBox rpcCheck;
        public CheckBox hideIdleCheck;
    }
}