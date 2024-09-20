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
            this.btnAddTable = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.labelLog = new System.Windows.Forms.Label();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.btnSaveCommand = new System.Windows.Forms.Button();
            this.btnLoadCommand = new System.Windows.Forms.Button();
            this.btnEditCommand = new System.Windows.Forms.Button();
            this.btnDeleteCommand = new System.Windows.Forms.Button();
            this.listBoxCommands = new System.Windows.Forms.ListBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.richTextBoxDocument = new System.Windows.Forms.RichTextBox();
            this.btnDocument = new System.Windows.Forms.Button();
            this.btnPhrase = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(214, 21);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(485, 20);
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
            this.cmbTables.Location = new System.Drawing.Point(214, 96);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(121, 21);
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
            this.dataGridView.Location = new System.Drawing.Point(62, 123);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(776, 209);
            this.dataGridView.TabIndex = 10;
            // 
            // labelSelectTable
            // 
            this.labelSelectTable.AutoSize = true;
            this.labelSelectTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectTable.Location = new System.Drawing.Point(64, 96);
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
            this.labelScript.Location = new System.Drawing.Point(59, 353);
            this.labelScript.Name = "labelScript";
            this.labelScript.Size = new System.Drawing.Size(91, 17);
            this.labelScript.TabIndex = 13;
            this.labelScript.Text = "SQL Script ";
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Location = new System.Drawing.Point(170, 344);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(103, 33);
            this.btnExecute.TabIndex = 14;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // richTextBoxSql
            // 
            this.richTextBoxSql.Location = new System.Drawing.Point(62, 383);
            this.richTextBoxSql.Name = "richTextBoxSql";
            this.richTextBoxSql.Size = new System.Drawing.Size(507, 103);
            this.richTextBoxSql.TabIndex = 15;
            this.richTextBoxSql.Text = "";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(723, 63);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 39);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAddTable
            // 
            this.btnAddTable.Location = new System.Drawing.Point(575, 484);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(85, 23);
            this.btnAddTable.TabIndex = 17;
            this.btnAddTable.Text = "Add Table";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Location = new System.Drawing.Point(666, 484);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteTable.TabIndex = 18;
            this.btnDeleteTable.Text = "Delete Table";
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.BackColor = System.Drawing.Color.Transparent;
            this.labelLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLog.Location = new System.Drawing.Point(59, 504);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(35, 17);
            this.labelLog.TabIndex = 19;
            this.labelLog.Text = "Log";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(62, 529);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(507, 61);
            this.richTextBoxLog.TabIndex = 20;
            this.richTextBoxLog.Text = "";
            // 
            // btnSaveCommand
            // 
            this.btnSaveCommand.Location = new System.Drawing.Point(437, 354);
            this.btnSaveCommand.Name = "btnSaveCommand";
            this.btnSaveCommand.Size = new System.Drawing.Size(87, 23);
            this.btnSaveCommand.TabIndex = 21;
            this.btnSaveCommand.Text = "Save Script";
            this.btnSaveCommand.UseVisualStyleBackColor = true;
            this.btnSaveCommand.Click += new System.EventHandler(this.btnSaveCommand_Click);
            // 
            // btnLoadCommand
            // 
            this.btnLoadCommand.Location = new System.Drawing.Point(544, 354);
            this.btnLoadCommand.Name = "btnLoadCommand";
            this.btnLoadCommand.Size = new System.Drawing.Size(87, 23);
            this.btnLoadCommand.TabIndex = 22;
            this.btnLoadCommand.Text = "Load Script";
            this.btnLoadCommand.UseVisualStyleBackColor = true;
            this.btnLoadCommand.Click += new System.EventHandler(this.btnLoadCommand_Click);
            // 
            // btnEditCommand
            // 
            this.btnEditCommand.Location = new System.Drawing.Point(649, 354);
            this.btnEditCommand.Name = "btnEditCommand";
            this.btnEditCommand.Size = new System.Drawing.Size(87, 23);
            this.btnEditCommand.TabIndex = 23;
            this.btnEditCommand.Text = "Edit Script";
            this.btnEditCommand.UseVisualStyleBackColor = true;
            this.btnEditCommand.Click += new System.EventHandler(this.btnEditCommand_Click);
            // 
            // btnDeleteCommand
            // 
            this.btnDeleteCommand.Location = new System.Drawing.Point(751, 354);
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
            this.listBoxCommands.Location = new System.Drawing.Point(575, 383);
            this.listBoxCommands.Name = "listBoxCommands";
            this.listBoxCommands.Size = new System.Drawing.Size(265, 95);
            this.listBoxCommands.TabIndex = 25;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(359, 94);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(102, 23);
            this.btnSaveChanges.TabIndex = 26;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(887, 18);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(113, 39);
            this.btnOpen.TabIndex = 27;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // richTextBoxDocument
            // 
            this.richTextBoxDocument.Location = new System.Drawing.Point(887, 64);
            this.richTextBoxDocument.Name = "richTextBoxDocument";
            this.richTextBoxDocument.Size = new System.Drawing.Size(358, 268);
            this.richTextBoxDocument.TabIndex = 28;
            this.richTextBoxDocument.Text = "";
            // 
            // btnDocument
            // 
            this.btnDocument.Location = new System.Drawing.Point(887, 354);
            this.btnDocument.Name = "btnDocument";
            this.btnDocument.Size = new System.Drawing.Size(87, 23);
            this.btnDocument.TabIndex = 29;
            this.btnDocument.Text = "Add Document";
            this.btnDocument.UseVisualStyleBackColor = true;
            // 
            // btnPhrase
            // 
            this.btnPhrase.Location = new System.Drawing.Point(1003, 354);
            this.btnPhrase.Name = "btnPhrase";
            this.btnPhrase.Size = new System.Drawing.Size(87, 23);
            this.btnPhrase.TabIndex = 30;
            this.btnPhrase.Text = "Add Phrase";
            this.btnPhrase.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1283, 617);
            this.Controls.Add(this.btnPhrase);
            this.Controls.Add(this.btnDocument);
            this.Controls.Add(this.richTextBoxDocument);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.listBoxCommands);
            this.Controls.Add(this.btnDeleteCommand);
            this.Controls.Add(this.btnEditCommand);
            this.Controls.Add(this.btnLoadCommand);
            this.Controls.Add(this.btnSaveCommand);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.btnDeleteTable);
            this.Controls.Add(this.btnAddTable);
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
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Button btnSaveCommand;
        private System.Windows.Forms.Button btnLoadCommand;
        private System.Windows.Forms.Button btnEditCommand;
        private System.Windows.Forms.Button btnDeleteCommand;
        private System.Windows.Forms.ListBox listBoxCommands;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.RichTextBox richTextBoxDocument;
        private System.Windows.Forms.Button btnDocument;
        private System.Windows.Forms.Button btnPhrase;
    }
}

