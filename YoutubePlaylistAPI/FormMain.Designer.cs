namespace VixtapeManager
{
    partial class FormMain
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
            this.addVideoButton = new System.Windows.Forms.Button();
            this.videoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.indexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.channelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.playlistDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // playlistDGV
            // 
            this.playlistDGV.AutoGenerateColumns = false;
            this.playlistDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.playlistDGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.playlistDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playlistDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indexColumn,
            this.linkDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.channelDataGridViewTextBoxColumn});
            this.playlistDGV.DataSource = this.videoBindingSource;
            this.playlistDGV.Location = new System.Drawing.Point(12, 105);
            this.playlistDGV.Name = "playlistDGV";
            this.playlistDGV.RowHeadersWidth = 50;
            this.playlistDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.playlistDGV.Size = new System.Drawing.Size(776, 583);
            this.playlistDGV.TabIndex = 1;
            this.playlistDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.playlistDGV_CellEndEdit);
            this.playlistDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.playlistDGV_CellFormatting);
            this.playlistDGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.playlistDGV_CellValidating);
            // 
            // addVideoButton
            // 
            this.addVideoButton.Location = new System.Drawing.Point(658, 12);
            this.addVideoButton.Name = "addVideoButton";
            this.addVideoButton.Size = new System.Drawing.Size(130, 23);
            this.addVideoButton.TabIndex = 2;
            this.addVideoButton.Text = "Add Video to Playlist";
            this.addVideoButton.UseVisualStyleBackColor = true;
            // 
            // videoBindingSource
            // 
            this.videoBindingSource.DataSource = typeof(VixtapeManager.VideoModel);
            // 
            // stateBindingSource
            // 
            this.stateBindingSource.DataSource = typeof(VixtapeManager.Store);
            // 
            // indexColumn
            // 
            this.indexColumn.HeaderText = "№";
            this.indexColumn.MinimumWidth = 50;
            this.indexColumn.Name = "indexColumn";
            // 
            // linkDataGridViewTextBoxColumn
            // 
            this.linkDataGridViewTextBoxColumn.DataPropertyName = "Link";
            this.linkDataGridViewTextBoxColumn.HeaderText = "Link";
            this.linkDataGridViewTextBoxColumn.MinimumWidth = 175;
            this.linkDataGridViewTextBoxColumn.Name = "linkDataGridViewTextBoxColumn";
            this.linkDataGridViewTextBoxColumn.ReadOnly = true;
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.addVideoButton);
            this.Controls.Add(this.playlistDGV);
            this.Name = "FormMain";
            this.Text = "Vixtape Manager";
            ((System.ComponentModel.ISupportInitialize)(this.playlistDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource stateBindingSource;
        private System.Windows.Forms.BindingSource videoBindingSource;
        private System.Windows.Forms.DataGridView playlistDGV;
        private System.Windows.Forms.Button addVideoButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn channelDataGridViewTextBoxColumn;
    }
}

