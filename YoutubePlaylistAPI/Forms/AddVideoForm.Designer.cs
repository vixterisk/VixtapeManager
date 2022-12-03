namespace YoutubePlaylistAPI
{
    partial class AddVideoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVideoForm));
            this.urlTB = new System.Windows.Forms.TextBox();
            this.specifiedIndexCheckBox = new System.Windows.Forms.CheckBox();
            this.indexComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddVideoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // urlTB
            // 
            this.urlTB.Location = new System.Drawing.Point(12, 25);
            this.urlTB.Name = "urlTB";
            this.urlTB.Size = new System.Drawing.Size(416, 20);
            this.urlTB.TabIndex = 0;
            this.urlTB.TextChanged += new System.EventHandler(this.UrlTB_TextChanged);
            // 
            // specifiedIndexCheckBox
            // 
            this.specifiedIndexCheckBox.AutoSize = true;
            this.specifiedIndexCheckBox.Location = new System.Drawing.Point(15, 57);
            this.specifiedIndexCheckBox.Name = "specifiedIndexCheckBox";
            this.specifiedIndexCheckBox.Size = new System.Drawing.Size(274, 30);
            this.specifiedIndexCheckBox.TabIndex = 2;
            this.specifiedIndexCheckBox.Text = "Insert at the specified index (Otherwise added to the \r\ndefault position)\r\n";
            this.specifiedIndexCheckBox.UseVisualStyleBackColor = true;
            this.specifiedIndexCheckBox.CheckedChanged += new System.EventHandler(this.SpecifiedIndexCheckBox_CheckedChanged);
            // 
            // indexComboBox
            // 
            this.indexComboBox.FormattingEnabled = true;
            this.indexComboBox.Location = new System.Drawing.Point(313, 57);
            this.indexComboBox.Name = "indexComboBox";
            this.indexComboBox.Size = new System.Drawing.Size(115, 21);
            this.indexComboBox.TabIndex = 3;
            this.indexComboBox.TextChanged += new System.EventHandler(this.IndexComboBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Video URL";
            // 
            // AddVideoButton
            // 
            this.AddVideoButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddVideoButton.Location = new System.Drawing.Point(313, 89);
            this.AddVideoButton.Name = "AddVideoButton";
            this.AddVideoButton.Size = new System.Drawing.Size(115, 23);
            this.AddVideoButton.TabIndex = 5;
            this.AddVideoButton.Text = "Add";
            this.AddVideoButton.UseVisualStyleBackColor = true;
            this.AddVideoButton.Click += new System.EventHandler(this.AddVideoButton_Click);
            // 
            // AddVideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 124);
            this.Controls.Add(this.AddVideoButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.indexComboBox);
            this.Controls.Add(this.specifiedIndexCheckBox);
            this.Controls.Add(this.urlTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddVideoForm";
            this.Text = "Add Video To Playlist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlTB;
        private System.Windows.Forms.CheckBox specifiedIndexCheckBox;
        private System.Windows.Forms.ComboBox indexComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddVideoButton;
    }
}