namespace InternetStausChecker
{
    partial class InvisableForm
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
            this.jarvisMute = new System.Windows.Forms.CheckBox();
            this.isMuted = new System.Windows.Forms.Label();
            this.NameLable = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // jarvisMute
            // 
            this.jarvisMute.AutoSize = true;
            this.jarvisMute.BackColor = System.Drawing.SystemColors.Control;
            this.jarvisMute.Location = new System.Drawing.Point(12, 35);
            this.jarvisMute.Name = "jarvisMute";
            this.jarvisMute.Size = new System.Drawing.Size(80, 17);
            this.jarvisMute.TabIndex = 0;
            this.jarvisMute.Text = "Mute Jarvis";
            this.jarvisMute.UseVisualStyleBackColor = false;
            this.jarvisMute.CheckedChanged += new System.EventHandler(this.MuteJarvis_CheckBox);
            // 
            // isMuted
            // 
            this.isMuted.AccessibleDescription = "Test";
            this.isMuted.AccessibleName = "IsMuted";
            this.isMuted.AutoSize = true;
            this.isMuted.Location = new System.Drawing.Point(108, 35);
            this.isMuted.Name = "isMuted";
            this.isMuted.Size = new System.Drawing.Size(94, 13);
            this.isMuted.TabIndex = 1;
            this.isMuted.Text = "Jarvis is not muted";
            this.isMuted.Click += new System.EventHandler(this.IsMuted_Click);
            // 
            // NameLable
            // 
            this.NameLable.AutoSize = true;
            this.NameLable.Location = new System.Drawing.Point(12, 9);
            this.NameLable.Name = "NameLable";
            this.NameLable.Size = new System.Drawing.Size(35, 13);
            this.NameLable.TabIndex = 2;
            this.NameLable.Text = "Name";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(111, 6);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.UserNameTextBox.Size = new System.Drawing.Size(91, 21);
            this.UserNameTextBox.TabIndex = 3;
            this.UserNameTextBox.Text = "";
            this.UserNameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBox_TextChanged);
            // 
            // InvisableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(368, 261);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.NameLable);
            this.Controls.Add(this.isMuted);
            this.Controls.Add(this.jarvisMute);
            this.MaximizeBox = false;
            this.Name = "InvisableForm";
            this.Text = "Internet Status Checker Settings";
            this.Load += new System.EventHandler(this.InvisavleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox jarvisMute;
        private System.Windows.Forms.Label isMuted;
        private System.Windows.Forms.Label NameLable;
        private System.Windows.Forms.RichTextBox UserNameTextBox;
    }
}

