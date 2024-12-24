namespace Game_Idler
{
    partial class IdleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IdleForm));
            gameHeader = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)gameHeader).BeginInit();
            SuspendLayout();
            // 
            // gameHeader
            // 
            gameHeader.Dock = DockStyle.Fill;
            gameHeader.Location = new Point(0, 0);
            gameHeader.Name = "gameHeader";
            gameHeader.Size = new Size(292, 136);
            gameHeader.TabIndex = 0;
            gameHeader.TabStop = false;
            // 
            // IdleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 136);
            Controls.Add(gameHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "IdleForm";
            Text = "Idling";
            Load += IdleForm_Load;
            ((System.ComponentModel.ISupportInitialize)gameHeader).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox gameHeader;
    }
}
