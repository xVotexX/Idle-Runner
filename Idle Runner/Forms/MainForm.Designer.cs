namespace Idle_Runner
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            gameListBox = new ListBox();
            gameHeader = new PictureBox();
            gamesLabel = new Label();
            startIdleButton = new Button();
            addToGroupButton = new Button();
            killIdleButton = new Button();
            statusLabel = new Label();
            idleHoursLabel2 = new Label();
            idleTimeImage = new PictureBox();
            idleHoursLabel = new Label();
            hideIdleCheck = new CheckBox();
            checkIdleButton = new Button();
            lastIdleLabel2 = new Label();
            lastIdleLabel = new Label();
            linkPictureBox = new PictureBox();
            updateLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)gameHeader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)idleTimeImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)linkPictureBox).BeginInit();
            SuspendLayout();
            // 
            // gameListBox
            // 
            gameListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gameListBox.BackColor = Color.FromArgb(30, 30, 30);
            gameListBox.BorderStyle = BorderStyle.None;
            gameListBox.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gameListBox.ForeColor = Color.White;
            gameListBox.FormattingEnabled = true;
            gameListBox.HorizontalScrollbar = true;
            gameListBox.ItemHeight = 18;
            gameListBox.Location = new Point(12, 45);
            gameListBox.Name = "gameListBox";
            gameListBox.SelectionMode = SelectionMode.MultiExtended;
            gameListBox.Size = new Size(310, 396);
            gameListBox.Sorted = true;
            gameListBox.TabIndex = 0;
            gameListBox.TabStop = false;
            gameListBox.UseTabStops = false;
            gameListBox.SelectedIndexChanged += gameListBox_SelectedIndexChanged;
            // 
            // gameHeader
            // 
            gameHeader.Location = new Point(415, 45);
            gameHeader.Name = "gameHeader";
            gameHeader.Size = new Size(292, 136);
            gameHeader.TabIndex = 1;
            gameHeader.TabStop = false;
            // 
            // gamesLabel
            // 
            gamesLabel.AutoSize = true;
            gamesLabel.Font = new Font("Nunito", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gamesLabel.ForeColor = Color.White;
            gamesLabel.Location = new Point(6, 9);
            gamesLabel.Name = "gamesLabel";
            gamesLabel.Size = new Size(169, 29);
            gamesLabel.TabIndex = 2;
            gamesLabel.Text = "Installed Games";
            // 
            // startIdleButton
            // 
            startIdleButton.BackColor = Color.FromArgb(110, 210, 30);
            startIdleButton.FlatAppearance.BorderSize = 0;
            startIdleButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(90, 170, 20);
            startIdleButton.FlatStyle = FlatStyle.Flat;
            startIdleButton.Font = new Font("Nunito Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            startIdleButton.ForeColor = Color.White;
            startIdleButton.Image = (Image)resources.GetObject("startIdleButton.Image");
            startIdleButton.ImageAlign = ContentAlignment.MiddleLeft;
            startIdleButton.Location = new Point(415, 262);
            startIdleButton.Name = "startIdleButton";
            startIdleButton.Padding = new Padding(50, 0, 15, 0);
            startIdleButton.Size = new Size(292, 36);
            startIdleButton.TabIndex = 3;
            startIdleButton.TabStop = false;
            startIdleButton.Text = "Idle Selected Game/s";
            startIdleButton.UseVisualStyleBackColor = false;
            startIdleButton.Click += startIdleButton_Click;
            // 
            // addToGroupButton
            // 
            addToGroupButton.BackColor = Color.Transparent;
            addToGroupButton.FlatAppearance.BorderSize = 0;
            addToGroupButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            addToGroupButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            addToGroupButton.FlatStyle = FlatStyle.Flat;
            addToGroupButton.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addToGroupButton.ForeColor = Color.White;
            addToGroupButton.Location = new Point(415, 368);
            addToGroupButton.Name = "addToGroupButton";
            addToGroupButton.Size = new Size(292, 26);
            addToGroupButton.TabIndex = 4;
            addToGroupButton.TabStop = false;
            addToGroupButton.Text = "Add Game To Group";
            addToGroupButton.UseVisualStyleBackColor = false;
            addToGroupButton.Click += addToGroupButton_Click;
            // 
            // killIdleButton
            // 
            killIdleButton.BackColor = Color.Transparent;
            killIdleButton.FlatAppearance.BorderSize = 0;
            killIdleButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            killIdleButton.FlatAppearance.MouseOverBackColor = Color.Red;
            killIdleButton.FlatStyle = FlatStyle.Flat;
            killIdleButton.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            killIdleButton.ForeColor = Color.White;
            killIdleButton.Location = new Point(415, 336);
            killIdleButton.Name = "killIdleButton";
            killIdleButton.Size = new Size(292, 26);
            killIdleButton.TabIndex = 6;
            killIdleButton.TabStop = false;
            killIdleButton.Text = "Kill All Idlers";
            killIdleButton.UseVisualStyleBackColor = false;
            killIdleButton.Click += killIdleButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusLabel.ForeColor = Color.White;
            statusLabel.Location = new Point(328, 412);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(460, 29);
            statusLabel.TabIndex = 7;
            statusLabel.TextAlign = ContentAlignment.BottomRight;
            // 
            // idleHoursLabel2
            // 
            idleHoursLabel2.Font = new Font("Nunito", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            idleHoursLabel2.ForeColor = Color.White;
            idleHoursLabel2.Location = new Point(577, 186);
            idleHoursLabel2.Margin = new Padding(3, 2, 3, 2);
            idleHoursLabel2.Name = "idleHoursLabel2";
            idleHoursLabel2.Size = new Size(130, 21);
            idleHoursLabel2.TabIndex = 10;
            idleHoursLabel2.Text = "IDLETIME";
            idleHoursLabel2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // idleTimeImage
            // 
            idleTimeImage.BackgroundImage = (Image)resources.GetObject("idleTimeImage.BackgroundImage");
            idleTimeImage.BackgroundImageLayout = ImageLayout.Center;
            idleTimeImage.Location = new Point(559, 187);
            idleTimeImage.Name = "idleTimeImage";
            idleTimeImage.Size = new Size(39, 36);
            idleTimeImage.TabIndex = 11;
            idleTimeImage.TabStop = false;
            // 
            // idleHoursLabel
            // 
            idleHoursLabel.Font = new Font("Nunito SemiBold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            idleHoursLabel.ForeColor = Color.White;
            idleHoursLabel.ImageAlign = ContentAlignment.TopRight;
            idleHoursLabel.Location = new Point(600, 205);
            idleHoursLabel.Name = "idleHoursLabel";
            idleHoursLabel.Size = new Size(107, 25);
            idleHoursLabel.TabIndex = 12;
            idleHoursLabel.Text = "0 Hours";
            // 
            // hideIdleCheck
            // 
            hideIdleCheck.BackColor = Color.Transparent;
            hideIdleCheck.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            hideIdleCheck.ForeColor = Color.White;
            hideIdleCheck.Location = new Point(414, 240);
            hideIdleCheck.Name = "hideIdleCheck";
            hideIdleCheck.Size = new Size(293, 21);
            hideIdleCheck.TabIndex = 13;
            hideIdleCheck.Text = "Hide Idlers on start";
            hideIdleCheck.TextAlign = ContentAlignment.TopLeft;
            hideIdleCheck.UseVisualStyleBackColor = false;
            // 
            // checkIdleButton
            // 
            checkIdleButton.BackColor = Color.Transparent;
            checkIdleButton.FlatAppearance.BorderSize = 0;
            checkIdleButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            checkIdleButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            checkIdleButton.FlatStyle = FlatStyle.Flat;
            checkIdleButton.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkIdleButton.ForeColor = Color.White;
            checkIdleButton.Location = new Point(415, 304);
            checkIdleButton.Name = "checkIdleButton";
            checkIdleButton.Size = new Size(292, 26);
            checkIdleButton.TabIndex = 14;
            checkIdleButton.TabStop = false;
            checkIdleButton.Text = "Check Idler Processes";
            checkIdleButton.UseVisualStyleBackColor = false;
            checkIdleButton.Click += checkIdleButton_Click;
            // 
            // lastIdleLabel2
            // 
            lastIdleLabel2.Font = new Font("Nunito", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lastIdleLabel2.ForeColor = Color.White;
            lastIdleLabel2.Location = new Point(415, 186);
            lastIdleLabel2.Margin = new Padding(3, 2, 3, 2);
            lastIdleLabel2.Name = "lastIdleLabel2";
            lastIdleLabel2.Size = new Size(138, 21);
            lastIdleLabel2.TabIndex = 15;
            lastIdleLabel2.Text = "LAST IDLE";
            lastIdleLabel2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // lastIdleLabel
            // 
            lastIdleLabel.Font = new Font("Nunito SemiBold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lastIdleLabel.ForeColor = Color.White;
            lastIdleLabel.ImageAlign = ContentAlignment.TopRight;
            lastIdleLabel.Location = new Point(440, 205);
            lastIdleLabel.Margin = new Padding(3, 2, 3, 2);
            lastIdleLabel.Name = "lastIdleLabel";
            lastIdleLabel.Size = new Size(96, 25);
            lastIdleLabel.TabIndex = 16;
            lastIdleLabel.Text = "Never";
            // 
            // linkPictureBox
            // 
            linkPictureBox.BackgroundImage = (Image)resources.GetObject("linkPictureBox.BackgroundImage");
            linkPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            linkPictureBox.Location = new Point(756, 12);
            linkPictureBox.Name = "linkPictureBox";
            linkPictureBox.Size = new Size(32, 32);
            linkPictureBox.TabIndex = 17;
            linkPictureBox.TabStop = false;
            linkPictureBox.Click += linkPictureBox_Click;
            linkPictureBox.MouseEnter += linkPictureBox_MouseEnter;
            linkPictureBox.MouseLeave += linkPictureBox_MouseLeave;
            // 
            // updateLabel
            // 
            updateLabel.Font = new Font("Nunito", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            updateLabel.ForeColor = Color.Lime;
            updateLabel.ImageAlign = ContentAlignment.TopRight;
            updateLabel.Location = new Point(274, 6);
            updateLabel.Name = "updateLabel";
            updateLabel.Size = new Size(257, 32);
            updateLabel.TabIndex = 18;
            updateLabel.Text = "Update Available!";
            updateLabel.TextAlign = ContentAlignment.TopCenter;
            updateLabel.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 17, 17);
            ClientSize = new Size(800, 453);
            Controls.Add(updateLabel);
            Controls.Add(linkPictureBox);
            Controls.Add(idleTimeImage);
            Controls.Add(lastIdleLabel2);
            Controls.Add(lastIdleLabel);
            Controls.Add(checkIdleButton);
            Controls.Add(hideIdleCheck);
            Controls.Add(idleHoursLabel2);
            Controls.Add(statusLabel);
            Controls.Add(killIdleButton);
            Controls.Add(addToGroupButton);
            Controls.Add(startIdleButton);
            Controls.Add(gamesLabel);
            Controls.Add(gameHeader);
            Controls.Add(gameListBox);
            Controls.Add(idleHoursLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Idle Runner v1.0";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)gameHeader).EndInit();
            ((System.ComponentModel.ISupportInitialize)idleTimeImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)linkPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox gameListBox;
        private PictureBox gameHeader;
        private Label gamesLabel;
        private Button startIdleButton;
        private Button addToGroupButton;
        private Button killIdleButton;
        private Label statusLabel;
        private Label idleHoursLabel2;
        private PictureBox idleTimeImage;
        private Label idleHoursLabel;
        private CheckBox hideIdleCheck;
        private Button checkIdleButton;
        private Label lastIdleLabel2;
        private Label lastIdleLabel;
        private PictureBox linkPictureBox;
        private Label updateLabel;
    }
}
