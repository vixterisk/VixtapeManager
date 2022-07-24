namespace YoutubePlaylistAPI
{
    partial class AuthForm
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
            this.signInButton = new System.Windows.Forms.Button();
            this.playlistCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.signInOkayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(12, 12);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(89, 23);
            this.signInButton.TabIndex = 0;
            this.signInButton.Text = "Sign In";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // playlistCB
            // 
            this.playlistCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playlistCB.FormattingEnabled = true;
            this.playlistCB.Location = new System.Drawing.Point(107, 46);
            this.playlistCB.Name = "playlistCB";
            this.playlistCB.Size = new System.Drawing.Size(527, 21);
            this.playlistCB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose a playlist:";
            // 
            // signInOkayButton
            // 
            this.signInOkayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.signInOkayButton.Location = new System.Drawing.Point(508, 79);
            this.signInOkayButton.Name = "signInOkayButton";
            this.signInOkayButton.Size = new System.Drawing.Size(126, 23);
            this.signInOkayButton.TabIndex = 3;
            this.signInOkayButton.Text = "Manage Videos";
            this.signInOkayButton.UseVisualStyleBackColor = true;
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 114);
            this.Controls.Add(this.signInOkayButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playlistCB);
            this.Controls.Add(this.signInButton);
            this.Name = "AuthForm";
            this.Text = "Sign In with Google";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.ComboBox playlistCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button signInOkayButton;
    }
}