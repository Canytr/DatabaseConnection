namespace DatabaseConnection
{
    partial class Form1
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
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelSelectTable = new System.Windows.Forms.Label();
            this.labelScript = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.richTextBoxSql = new System.Windows.Forms.RichTextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.labelLog = new System.Windows.Forms.Label();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.btnSaveCommand = new System.Windows.Forms.Button();
            this.btnLoadCommand = new System.Windows.Forms.Button();
            this.btnEditCommand = new System.Windows.Forms.Button();
            this.btnDeleteCommand = new System.Windows.Forms.Button();
            this.listBoxCommands = new System.Windows.Forms.ListBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.button_TableUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(214, 21);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(485, 23);
            this.txtConnectionString.TabIndex = 0;
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectionString.Location = new System.Drawing.Point(61, 21);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(147, 17);
            this.labelConnectionString.TabIndex = 2;
            this.labelConnectionString.Text = "Connection String :";
            // 
            // cmbTables
            // 
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(846, 33);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(121, 24);
            this.cmbTables.TabIndex = 8;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(723, 18);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(117, 39);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click_1);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(28, 63);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1118, 423);
            this.dataGridView.TabIndex = 10;
            // 
            // labelSelectTable
            // 
            this.labelSelectTable.AutoSize = true;
            this.labelSelectTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectTable.Location = new System.Drawing.Point(846, 9);
            this.labelSelectTable.Name = "labelSelectTable";
            this.labelSelectTable.Size = new System.Drawing.Size(109, 17);
            this.labelSelectTable.TabIndex = 11;
            this.labelSelectTable.Text = "Select Table :";
            // 
            // labelScript
            // 
            this.labelScript.AutoSize = true;
            this.labelScript.BackColor = System.Drawing.Color.Transparent;
            this.labelScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScript.Location = new System.Drawing.Point(49, 494);
            this.labelScript.Name = "labelScript";
            this.labelScript.Size = new System.Drawing.Size(91, 17);
            this.labelScript.TabIndex = 13;
            this.labelScript.Text = "SQL Script ";
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Location = new System.Drawing.Point(146, 488);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(103, 33);
            this.btnExecute.TabIndex = 14;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // richTextBoxSql
            // 
            this.richTextBoxSql.Location = new System.Drawing.Point(62, 524);
            this.richTextBoxSql.Name = "richTextBoxSql";
            this.richTextBoxSql.Size = new System.Drawing.Size(423, 81);
            this.richTextBoxSql.TabIndex = 15;
            this.richTextBoxSql.Text = "";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(987, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 39);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.BackColor = System.Drawing.Color.Transparent;
            this.labelLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLog.Location = new System.Drawing.Point(664, 524);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(35, 17);
            this.labelLog.TabIndex = 19;
            this.labelLog.Text = "Log";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(667, 544);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(507, 61);
            this.richTextBoxLog.TabIndex = 20;
            this.richTextBoxLog.Text = "";
            // 
            // btnSaveCommand
            // 
            this.btnSaveCommand.Location = new System.Drawing.Point(255, 493);
            this.btnSaveCommand.Name = "btnSaveCommand";
            this.btnSaveCommand.Size = new System.Drawing.Size(87, 23);
            this.btnSaveCommand.TabIndex = 21;
            this.btnSaveCommand.Text = "Save Script";
            this.btnSaveCommand.UseVisualStyleBackColor = true;
            this.btnSaveCommand.Click += new System.EventHandler(this.btnSaveCommand_Click);
            // 
            // btnLoadCommand
            // 
            this.btnLoadCommand.Location = new System.Drawing.Point(348, 493);
            this.btnLoadCommand.Name = "btnLoadCommand";
            this.btnLoadCommand.Size = new System.Drawing.Size(87, 23);
            this.btnLoadCommand.TabIndex = 22;
            this.btnLoadCommand.Text = "Load Script";
            this.btnLoadCommand.UseVisualStyleBackColor = true;
            this.btnLoadCommand.Click += new System.EventHandler(this.btnLoadCommand_Click);
            // 
            // btnEditCommand
            // 
            this.btnEditCommand.Location = new System.Drawing.Point(441, 494);
            this.btnEditCommand.Name = "btnEditCommand";
            this.btnEditCommand.Size = new System.Drawing.Size(87, 23);
            this.btnEditCommand.TabIndex = 23;
            this.btnEditCommand.Text = "Edit Script";
            this.btnEditCommand.UseVisualStyleBackColor = true;
            this.btnEditCommand.Click += new System.EventHandler(this.btnEditCommand_Click);
            // 
            // btnDeleteCommand
            // 
            this.btnDeleteCommand.Location = new System.Drawing.Point(534, 495);
            this.btnDeleteCommand.Name = "btnDeleteCommand";
            this.btnDeleteCommand.Size = new System.Drawing.Size(87, 23);
            this.btnDeleteCommand.TabIndex = 24;
            this.btnDeleteCommand.Text = "Delete Script";
            this.btnDeleteCommand.UseVisualStyleBackColor = true;
            this.btnDeleteCommand.Click += new System.EventHandler(this.btnDeleteCommand_Click);
            // 
            // listBoxCommands
            // 
            this.listBoxCommands.FormattingEnabled = true;
            this.listBoxCommands.ItemHeight = 16;
            this.listBoxCommands.Location = new System.Drawing.Point(491, 524);
            this.listBoxCommands.Name = "listBoxCommands";
            this.listBoxCommands.Size = new System.Drawing.Size(144, 84);
            this.listBoxCommands.TabIndex = 25;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(1034, 492);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(112, 43);
            this.btnSaveChanges.TabIndex = 26;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // textBox_Search
            // 
            this.textBox_Search.Location = new System.Drawing.Point(667, 498);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(151, 23);
            this.textBox_Search.TabIndex = 27;
            this.textBox_Search.Text = "SEARCH";
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(824, 493);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(91, 41);
            this.button_Search.TabIndex = 28;
            this.button_Search.Text = "Search";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // button_TableUpdate
            // 
            this.button_TableUpdate.Location = new System.Drawing.Point(921, 492);
            this.button_TableUpdate.Name = "button_TableUpdate";
            this.button_TableUpdate.Size = new System.Drawing.Size(107, 41);
            this.button_TableUpdate.TabIndex = 29;
            this.button_TableUpdate.Text = "Table Update";
            this.button_TableUpdate.UseVisualStyleBackColor = true;
            this.button_TableUpdate.Click += new System.EventHandler(this.button_TableUpdate_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1186, 617);
            this.Controls.Add(this.button_TableUpdate);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.textBox_Search);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.listBoxCommands);
            this.Controls.Add(this.btnDeleteCommand);
            this.Controls.Add(this.btnEditCommand);
            this.Controls.Add(this.btnLoadCommand);
            this.Controls.Add(this.btnSaveCommand);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.richTextBoxSql);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.labelScript);
            this.Controls.Add(this.labelSelectTable);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.labelConnectionString);
            this.Controls.Add(this.txtConnectionString);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelSelectTable;
        private System.Windows.Forms.Label labelScript;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.RichTextBox richTextBoxSql;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Button btnSaveCommand;
        private System.Windows.Forms.Button btnLoadCommand;
        private System.Windows.Forms.Button btnEditCommand;
        private System.Windows.Forms.Button btnDeleteCommand;
        private System.Windows.Forms.ListBox listBoxCommands;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Button button_TableUpdate;
    }
}

