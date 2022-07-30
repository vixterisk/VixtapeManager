namespace YoutubePlaylistAPI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.playlistDGV = new System.Windows.Forms.DataGridView();
            this.indexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.showAddVideoFormButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.playlistGB = new System.Windows.Forms.GroupBox();
            this.menuTabControl = new System.Windows.Forms.TabControl();
            this.descriptionTabPage = new System.Windows.Forms.TabPage();
            this.descriptionRTB = new System.Windows.Forms.RichTextBox();
            this.actionsTabPage = new System.Windows.Forms.TabPage();
            this.logoutButton = new System.Windows.Forms.Button();
            this.SynchronizeButton = new System.Windows.Forms.Button();
            this.searchTabPage = new System.Windows.Forms.TabPage();
            this.arrowButtonLeft = new System.Windows.Forms.Button();
            this.arrowButtonRight = new System.Windows.Forms.Button();
            this.searchTB = new System.Windows.Forms.TextBox();
            this.ExportToCSVButton = new System.Windows.Forms.Button();
            this.linkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.channelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.videoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DeleteVideoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playlistDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.playlistGB.SuspendLayout();
            this.menuTabControl.SuspendLayout();
            this.descriptionTabPage.SuspendLayout();
            this.actionsTabPage.SuspendLayout();
            this.searchTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // playlistDGV
            // 
            this.playlistDGV.AllowUserToAddRows = false;
            this.playlistDGV.AutoGenerateColumns = false;
            this.playlistDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.playlistDGV.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.playlistDGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.playlistDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playlistDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indexColumn,
            this.linkDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.channelDataGridViewTextBoxColumn});
            this.playlistDGV.DataSource = this.videoBindingSource;
            this.playlistDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistDGV.Location = new System.Drawing.Point(0, 0);
            this.playlistDGV.Name = "playlistDGV";
            this.playlistDGV.RowHeadersWidth = 50;
            this.playlistDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.playlistDGV.Size = new System.Drawing.Size(993, 595);
            this.playlistDGV.TabIndex = 1;
            this.playlistDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.playlistDGV_CellContentClick);
            this.playlistDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.playlistDGV_CellEndEdit);
            this.playlistDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.playlistDGV_CellFormatting);
            this.playlistDGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.playlistDGV_CellValidating);
            this.playlistDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.playlistDGV_KeyDown);
            // 
            // indexColumn
            // 
            this.indexColumn.HeaderText = "№";
            this.indexColumn.MinimumWidth = 50;
            this.indexColumn.Name = "indexColumn";
            // 
            // showAddVideoFormButton
            // 
            this.showAddVideoFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.showAddVideoFormButton.Location = new System.Drawing.Point(6, 6);
            this.showAddVideoFormButton.Name = "showAddVideoFormButton";
            this.showAddVideoFormButton.Size = new System.Drawing.Size(147, 25);
            this.showAddVideoFormButton.TabIndex = 2;
            this.showAddVideoFormButton.Text = "Add Video to Playlist";
            this.showAddVideoFormButton.UseVisualStyleBackColor = true;
            this.showAddVideoFormButton.Click += new System.EventHandler(this.ShowAddVideoButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.playlistGB);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.playlistDGV);
            this.splitContainer1.Size = new System.Drawing.Size(993, 710);
            this.splitContainer1.SplitterDistance = 111;
            this.splitContainer1.TabIndex = 3;
            // 
            // playlistGB
            // 
            this.playlistGB.Controls.Add(this.menuTabControl);
            this.playlistGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistGB.Location = new System.Drawing.Point(0, 0);
            this.playlistGB.Name = "playlistGB";
            this.playlistGB.Size = new System.Drawing.Size(993, 111);
            this.playlistGB.TabIndex = 5;
            this.playlistGB.TabStop = false;
            this.playlistGB.Text = "Current playlist:";
            // 
            // menuTabControl
            // 
            this.menuTabControl.Controls.Add(this.descriptionTabPage);
            this.menuTabControl.Controls.Add(this.actionsTabPage);
            this.menuTabControl.Controls.Add(this.searchTabPage);
            this.menuTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTabControl.Location = new System.Drawing.Point(3, 16);
            this.menuTabControl.Name = "menuTabControl";
            this.menuTabControl.SelectedIndex = 0;
            this.menuTabControl.Size = new System.Drawing.Size(987, 92);
            this.menuTabControl.TabIndex = 4;
            // 
            // descriptionTabPage
            // 
            this.descriptionTabPage.Controls.Add(this.descriptionRTB);
            this.descriptionTabPage.Location = new System.Drawing.Point(4, 22);
            this.descriptionTabPage.Name = "descriptionTabPage";
            this.descriptionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.descriptionTabPage.Size = new System.Drawing.Size(979, 66);
            this.descriptionTabPage.TabIndex = 0;
            this.descriptionTabPage.Text = "Description";
            this.descriptionTabPage.UseVisualStyleBackColor = true;
            // 
            // descriptionRTB
            // 
            this.descriptionRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionRTB.Enabled = false;
            this.descriptionRTB.Location = new System.Drawing.Point(3, 3);
            this.descriptionRTB.Name = "descriptionRTB";
            this.descriptionRTB.Size = new System.Drawing.Size(973, 60);
            this.descriptionRTB.TabIndex = 5;
            this.descriptionRTB.Text = "";
            // 
            // actionsTabPage
            // 
            this.actionsTabPage.Controls.Add(this.DeleteVideoButton);
            this.actionsTabPage.Controls.Add(this.ExportToCSVButton);
            this.actionsTabPage.Controls.Add(this.logoutButton);
            this.actionsTabPage.Controls.Add(this.showAddVideoFormButton);
            this.actionsTabPage.Controls.Add(this.SynchronizeButton);
            this.actionsTabPage.Location = new System.Drawing.Point(4, 22);
            this.actionsTabPage.Name = "actionsTabPage";
            this.actionsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.actionsTabPage.Size = new System.Drawing.Size(979, 66);
            this.actionsTabPage.TabIndex = 1;
            this.actionsTabPage.Text = "Actions";
            this.actionsTabPage.UseVisualStyleBackColor = true;
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutButton.Location = new System.Drawing.Point(312, 6);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(147, 25);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "Log Out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // SynchronizeButton
            // 
            this.SynchronizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SynchronizeButton.Location = new System.Drawing.Point(159, 6);
            this.SynchronizeButton.Name = "SynchronizeButton";
            this.SynchronizeButton.Size = new System.Drawing.Size(147, 25);
            this.SynchronizeButton.TabIndex = 3;
            this.SynchronizeButton.Text = "Synchronize with Youtube";
            this.SynchronizeButton.UseVisualStyleBackColor = true;
            this.SynchronizeButton.Click += new System.EventHandler(this.SynchronizeButton_Click);
            // 
            // searchTabPage
            // 
            this.searchTabPage.Controls.Add(this.arrowButtonLeft);
            this.searchTabPage.Controls.Add(this.arrowButtonRight);
            this.searchTabPage.Controls.Add(this.searchTB);
            this.searchTabPage.Location = new System.Drawing.Point(4, 22);
            this.searchTabPage.Name = "searchTabPage";
            this.searchTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.searchTabPage.Size = new System.Drawing.Size(979, 66);
            this.searchTabPage.TabIndex = 2;
            this.searchTabPage.Text = "Search";
            this.searchTabPage.UseVisualStyleBackColor = true;
            // 
            // arrowButtonLeft
            // 
            this.arrowButtonLeft.Location = new System.Drawing.Point(751, 21);
            this.arrowButtonLeft.Name = "arrowButtonLeft";
            this.arrowButtonLeft.Size = new System.Drawing.Size(18, 23);
            this.arrowButtonLeft.TabIndex = 2;
            this.arrowButtonLeft.Text = "<";
            this.arrowButtonLeft.UseVisualStyleBackColor = true;
            this.arrowButtonLeft.Click += new System.EventHandler(this.arrowButtonLeft_Click);
            // 
            // arrowButtonRight
            // 
            this.arrowButtonRight.Location = new System.Drawing.Point(768, 21);
            this.arrowButtonRight.Name = "arrowButtonRight";
            this.arrowButtonRight.Size = new System.Drawing.Size(18, 23);
            this.arrowButtonRight.TabIndex = 1;
            this.arrowButtonRight.Text = ">";
            this.arrowButtonRight.UseVisualStyleBackColor = true;
            this.arrowButtonRight.Click += new System.EventHandler(this.arrowButtonRight_Click);
            // 
            // searchTB
            // 
            this.searchTB.Location = new System.Drawing.Point(6, 23);
            this.searchTB.Name = "searchTB";
            this.searchTB.Size = new System.Drawing.Size(739, 20);
            this.searchTB.TabIndex = 0;
            this.searchTB.TextChanged += new System.EventHandler(this.searchTB_TextChanged);
            // 
            // ExportToCSVButton
            // 
            this.ExportToCSVButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ExportToCSVButton.Location = new System.Drawing.Point(159, 35);
            this.ExportToCSVButton.Name = "ExportToCSVButton";
            this.ExportToCSVButton.Size = new System.Drawing.Size(147, 25);
            this.ExportToCSVButton.TabIndex = 4;
            this.ExportToCSVButton.Text = "Export To CSV";
            this.ExportToCSVButton.UseVisualStyleBackColor = true;
            this.ExportToCSVButton.Click += new System.EventHandler(this.ExportToCSVButton_Click);
            // 
            // linkDataGridViewTextBoxColumn
            // 
            this.linkDataGridViewTextBoxColumn.DataPropertyName = "Link";
            this.linkDataGridViewTextBoxColumn.HeaderText = "Link";
            this.linkDataGridViewTextBoxColumn.MinimumWidth = 175;
            this.linkDataGridViewTextBoxColumn.Name = "linkDataGridViewTextBoxColumn";
            this.linkDataGridViewTextBoxColumn.ReadOnly = true;
            this.linkDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.linkDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 175;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // channelDataGridViewTextBoxColumn
            // 
            this.channelDataGridViewTextBoxColumn.DataPropertyName = "Channel";
            this.channelDataGridViewTextBoxColumn.HeaderText = "Channel";
            this.channelDataGridViewTextBoxColumn.MinimumWidth = 175;
            this.channelDataGridViewTextBoxColumn.Name = "channelDataGridViewTextBoxColumn";
            this.channelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // videoBindingSource
            // 
            this.videoBindingSource.DataSource = typeof(YoutubePlaylistAPI.VideoModel);
            // 
            // stateBindingSource
            // 
            this.stateBindingSource.DataSource = typeof(YoutubePlaylistAPI.Store);
            // 
            // DeleteVideoButton
            // 
            this.DeleteVideoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteVideoButton.Location = new System.Drawing.Point(6, 35);
            this.DeleteVideoButton.Name = "DeleteVideoButton";
            this.DeleteVideoButton.Size = new System.Drawing.Size(147, 25);
            this.DeleteVideoButton.TabIndex = 5;
            this.DeleteVideoButton.Text = "Delete Video From Playlist";
            this.DeleteVideoButton.UseVisualStyleBackColor = true;
            this.DeleteVideoButton.Click += new System.EventHandler(this.DeleteVideoButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 710);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(707, 298);
            this.Name = "MainForm";
            this.Text = "Vixtape Manager";
            ((System.ComponentModel.ISupportInitialize)(this.playlistDGV)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.playlistGB.ResumeLayout(false);
            this.menuTabControl.ResumeLayout(false);
            this.descriptionTabPage.ResumeLayout(false);
            this.actionsTabPage.ResumeLayout(false);
            this.searchTabPage.ResumeLayout(false);
            this.searchTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource stateBindingSource;
        private System.Windows.Forms.BindingSource videoBindingSource;
        private System.Windows.Forms.DataGridView playlistDGV;
        private System.Windows.Forms.Button showAddVideoFormButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button SynchronizeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexColumn;
        private System.Windows.Forms.DataGridViewLinkColumn linkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn channelDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button arrowButtonLeft;
        private System.Windows.Forms.Button arrowButtonRight;
        private System.Windows.Forms.TextBox searchTB;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.GroupBox playlistGB;
        private System.Windows.Forms.RichTextBox descriptionRTB;
        private System.Windows.Forms.TabControl menuTabControl;
        private System.Windows.Forms.TabPage descriptionTabPage;
        private System.Windows.Forms.TabPage actionsTabPage;
        private System.Windows.Forms.TabPage searchTabPage;
        private System.Windows.Forms.Button ExportToCSVButton;
        private System.Windows.Forms.Button DeleteVideoButton;
    }
}

