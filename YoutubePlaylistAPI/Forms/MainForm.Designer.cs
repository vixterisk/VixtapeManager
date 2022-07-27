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
            this.playlistDGV = new System.Windows.Forms.DataGridView();
            this.showAddVideoFormButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SynchronizeButton = new System.Windows.Forms.Button();
            this.indexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.videoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.channelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.playlistDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.playlistDGV.Size = new System.Drawing.Size(800, 653);
            this.playlistDGV.TabIndex = 1;
            this.playlistDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.playlistDGV_CellContentClick);
            this.playlistDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.playlistDGV_CellEndEdit);
            this.playlistDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.playlistDGV_CellFormatting);
            this.playlistDGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.playlistDGV_CellValidating);
            this.playlistDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.playlistDGV_KeyDown);
            // 
            // showAddVideoFormButton
            // 
            this.showAddVideoFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showAddVideoFormButton.Location = new System.Drawing.Point(653, 12);
            this.showAddVideoFormButton.Name = "showAddVideoFormButton";
            this.showAddVideoFormButton.Size = new System.Drawing.Size(135, 20);
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
            this.splitContainer1.Panel1.Controls.Add(this.SynchronizeButton);
            this.splitContainer1.Panel1.Controls.Add(this.showAddVideoFormButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.playlistDGV);
            this.splitContainer1.Size = new System.Drawing.Size(800, 700);
            this.splitContainer1.SplitterDistance = 43;
            this.splitContainer1.TabIndex = 3;
            // 
            // SynchronizeButton
            // 
            this.SynchronizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SynchronizeButton.Location = new System.Drawing.Point(503, 12);
            this.SynchronizeButton.Name = "SynchronizeButton";
            this.SynchronizeButton.Size = new System.Drawing.Size(144, 20);
            this.SynchronizeButton.TabIndex = 3;
            this.SynchronizeButton.Text = "Synchronize with Youtube";
            this.SynchronizeButton.UseVisualStyleBackColor = true;
            this.SynchronizeButton.Click += new System.EventHandler(this.SynchronizeButton_Click);
            // 
            // indexColumn
            // 
            this.indexColumn.HeaderText = "№";
            this.indexColumn.MinimumWidth = 50;
            this.indexColumn.Name = "indexColumn";
            // 
            // videoBindingSource
            // 
            this.videoBindingSource.DataSource = typeof(YoutubePlaylistAPI.VideoModel);
            // 
            // stateBindingSource
            // 
            this.stateBindingSource.DataSource = typeof(YoutubePlaylistAPI.Store);
            // 
            // channelDataGridViewTextBoxColumn
            // 
            this.channelDataGridViewTextBoxColumn.DataPropertyName = "Channel";
            this.channelDataGridViewTextBoxColumn.HeaderText = "Channel";
            this.channelDataGridViewTextBoxColumn.MinimumWidth = 175;
            this.channelDataGridViewTextBoxColumn.Name = "channelDataGridViewTextBoxColumn";
            this.channelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 175;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Vixtape Manager";
            ((System.ComponentModel.ISupportInitialize)(this.playlistDGV)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
    }
}

