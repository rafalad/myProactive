namespace myProactive
{
	partial class myProactive
	{
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		/// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kod generowany przez Projektanta formularzy systemu Windows

		/// <summary>
		/// Metoda wymagana do obsługi projektanta — nie należy modyfikować
		/// jej zawartości w edytorze kodu.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(myProactive));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cleanEventViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBoxNo = new System.Windows.Forms.CheckBox();
			this.checkBoxYes = new System.Windows.Forms.CheckBox();
			this.comboBoxTimeRange = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TextBoxSelectedAcc = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.label2 = new System.Windows.Forms.Label();
			this.richTextBox_savepath = new System.Windows.Forms.RichTextBox();
			this.button_go = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.outlookEmailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.ver = new System.Windows.Forms.Label();
			this.latest_ver = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.outlookEmailsBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1234, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToolStripMenuItem,
            this.cleanEventViewerToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// minimizeToolStripMenuItem
			// 
			this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
			this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.minimizeToolStripMenuItem.Text = "Minimize";
			this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
			// 
			// cleanEventViewerToolStripMenuItem
			// 
			this.cleanEventViewerToolStripMenuItem.Name = "cleanEventViewerToolStripMenuItem";
			this.cleanEventViewerToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.cleanEventViewerToolStripMenuItem.Text = "Clean Event Viewer";
			this.cleanEventViewerToolStripMenuItem.Click += new System.EventHandler(this.cleanEventViewerToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// aboutToolStripMenuItem1
			// 
			this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem1.Text = "About";
			this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox1.Controls.Add(this.checkBoxNo);
			this.groupBox1.Controls.Add(this.checkBoxYes);
			this.groupBox1.Controls.Add(this.comboBoxTimeRange);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.btnCancel);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.TextBoxSelectedAcc);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.progressBar);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.richTextBox_savepath);
			this.groupBox1.Controls.Add(this.button_go);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.groupBox1.Location = new System.Drawing.Point(12, 36);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(338, 400);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Main menu";
			// 
			// checkBoxNo
			// 
			this.checkBoxNo.AutoSize = true;
			this.checkBoxNo.Checked = true;
			this.checkBoxNo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.checkBoxNo.Location = new System.Drawing.Point(254, 54);
			this.checkBoxNo.Name = "checkBoxNo";
			this.checkBoxNo.Size = new System.Drawing.Size(40, 17);
			this.checkBoxNo.TabIndex = 50;
			this.checkBoxNo.Text = "No";
			this.checkBoxNo.UseVisualStyleBackColor = true;
			this.checkBoxNo.CheckedChanged += new System.EventHandler(this.checkBoxNo_CheckedChanged);
			// 
			// checkBoxYes
			// 
			this.checkBoxYes.AutoSize = true;
			this.checkBoxYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.checkBoxYes.Location = new System.Drawing.Point(204, 54);
			this.checkBoxYes.Name = "checkBoxYes";
			this.checkBoxYes.Size = new System.Drawing.Size(44, 17);
			this.checkBoxYes.TabIndex = 49;
			this.checkBoxYes.Text = "Yes";
			this.checkBoxYes.UseVisualStyleBackColor = true;
			this.checkBoxYes.CheckedChanged += new System.EventHandler(this.checkBoxYes_CheckedChanged);
			// 
			// comboBoxTimeRange
			// 
			this.comboBoxTimeRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.comboBoxTimeRange.FormattingEnabled = true;
			this.comboBoxTimeRange.Items.AddRange(new object[] {
            "Today",
            "Yesterday",
            "This week",
            "This month",
            "Last month"});
			this.comboBoxTimeRange.Location = new System.Drawing.Point(196, 25);
			this.comboBoxTimeRange.Name = "comboBoxTimeRange";
			this.comboBoxTimeRange.Size = new System.Drawing.Size(100, 21);
			this.comboBoxTimeRange.TabIndex = 48;
			this.comboBoxTimeRange.TabStop = false;
			this.comboBoxTimeRange.Text = "Today";
			this.comboBoxTimeRange.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label9.Location = new System.Drawing.Point(6, 28);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(220, 17);
			this.label9.TabIndex = 47;
			this.label9.Text = "Select your the time range to handle:";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label8.Location = new System.Drawing.Point(6, 55);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(187, 18);
			this.label8.TabIndex = 43;
			this.label8.Text = "Would you like to set the item limit?";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label5.Location = new System.Drawing.Point(77, 340);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(160, 16);
			this.label5.TabIndex = 40;
			this.label5.Text = "Awaiting";
			// 
			// btnCancel
			// 
			this.btnCancel.Enabled = false;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnCancel.Location = new System.Drawing.Point(159, 216);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 26);
			this.btnCancel.TabIndex = 39;
			this.btnCancel.TabStop = false;
			this.btnCancel.Text = "Cancel Async";
			this.btnCancel.UseCompatibleTextRendering = true;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(196, 79);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 30;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label4.Location = new System.Drawing.Point(30, 340);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 19);
			this.label4.TabIndex = 38;
			this.label4.Text = "Progress:";
			// 
			// TextBoxSelectedAcc
			// 
			this.TextBoxSelectedAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.TextBoxSelectedAcc.Location = new System.Drawing.Point(196, 305);
			this.TextBoxSelectedAcc.Name = "TextBoxSelectedAcc";
			this.TextBoxSelectedAcc.ReadOnly = true;
			this.TextBoxSelectedAcc.Size = new System.Drawing.Size(100, 22);
			this.TextBoxSelectedAcc.TabIndex = 37;
			this.TextBoxSelectedAcc.Text = "Pending";
			this.TextBoxSelectedAcc.TextChanged += new System.EventHandler(this.TextBoxSelectedAcc_TextChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(30, 308);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 35);
			this.label1.TabIndex = 36;
			this.label1.Text = "Selected Outlook account:";
			//this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(33, 362);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(263, 30);
			this.progressBar.TabIndex = 30;
			//this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(6, 154);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 16);
			this.label2.TabIndex = 31;
			this.label2.Text = "Data save path:";
			// 
			// richTextBox_savepath
			// 
			this.richTextBox_savepath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.richTextBox_savepath.Location = new System.Drawing.Point(9, 173);
			this.richTextBox_savepath.Name = "richTextBox_savepath";
			this.richTextBox_savepath.ReadOnly = true;
			this.richTextBox_savepath.Size = new System.Drawing.Size(287, 20);
			this.richTextBox_savepath.TabIndex = 30;
			this.richTextBox_savepath.Text = "Pending";
			// 
			// button_go
			// 
			this.button_go.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button_go.Location = new System.Drawing.Point(53, 216);
			this.button_go.Name = "button_go";
			this.button_go.Size = new System.Drawing.Size(100, 26);
			this.button_go.TabIndex = 29;
			this.button_go.TabStop = false;
			this.button_go.Text = "Go";
			this.button_go.UseCompatibleTextRendering = true;
			this.button_go.UseVisualStyleBackColor = true;
			this.button_go.Click += new System.EventHandler(this.button_go_Click);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label3.Location = new System.Drawing.Point(6, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 27);
			this.label3.TabIndex = 10;
			this.label3.Text = "Enter the total number of items:";
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.groupBox2.Controls.Add(this.listBox1);
			this.groupBox2.Controls.Add(this.progressBar1);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.groupBox2.Location = new System.Drawing.Point(356, 36);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(866, 400);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Event Viewer";
			// 
			// listBox1
			// 
			this.listBox1.BackColor = System.Drawing.Color.Azure;
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.listBox1.ForeColor = System.Drawing.Color.Navy;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.HorizontalExtent = 1000;
			this.listBox1.IntegralHeight = false;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(6, 25);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(854, 369);
			this.listBox1.TabIndex = 36;
			//this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(-268, 269);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(244, 23);
			this.progressBar1.TabIndex = 29;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 439);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1234, 22);
			this.statusStrip1.TabIndex = 29;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReadMailItems);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.AktualizujProgres);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
			// 
			// ver
			// 
			this.ver.BackColor = System.Drawing.SystemColors.MenuBar;
			this.ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.ver.Location = new System.Drawing.Point(9, 443);
			this.ver.Name = "ver";
			this.ver.Size = new System.Drawing.Size(54, 18);
			this.ver.TabIndex = 32;
			this.ver.Text = "version";
			this.ver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ver.Click += new System.EventHandler(this.ver_Click);
			// 
			// latest_ver
			// 
			this.latest_ver.BackColor = System.Drawing.SystemColors.MenuBar;
			this.latest_ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.latest_ver.Location = new System.Drawing.Point(92, 443);
			this.latest_ver.Name = "latest_ver";
			this.latest_ver.Size = new System.Drawing.Size(413, 18);
			this.latest_ver.TabIndex = 35;
			this.latest_ver.Text = "version";
			this.latest_ver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// myProactive
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.AutoSize = true;
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ClientSize = new System.Drawing.Size(1234, 461);
			this.Controls.Add(this.latest_ver);
			this.Controls.Add(this.ver);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximumSize = new System.Drawing.Size(1250, 500);
			this.MinimumSize = new System.Drawing.Size(1250, 500);
			this.Name = "myProactive";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "myProactive";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.outlookEmailsBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RichTextBox richTextBox_savepath;
		private System.Windows.Forms.Button button_go;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.BindingSource outlookEmailsBindingSource;
		public System.Windows.Forms.ListBox listBox1;
		public System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.RichTextBox TextBoxSelectedAcc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label5;
		public System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Label ver;
		private System.Windows.Forms.Label latest_ver;
		private System.Windows.Forms.ToolStripMenuItem cleanEventViewerToolStripMenuItem;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox comboBoxTimeRange;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.CheckBox checkBoxNo;
		private System.Windows.Forms.CheckBox checkBoxYes;
	}
}

