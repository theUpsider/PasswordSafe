
namespace PasswordSafeForms {
    partial class FormLogin {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.openDatabase = new System.Windows.Forms.OpenFileDialog();
            this.databasePathTextbox = new System.Windows.Forms.TextBox();
            this.masterpwTextbox = new System.Windows.Forms.TextBox();
            this.Enter = new System.Windows.Forms.Button();
            this.databasefilelocationlabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.masterpasswordGroupbox = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpendatabasetoolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.newDatabasetoolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.masterpasswordGroupbox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openDatabase
            // 
            this.openDatabase.FileName = "passwords.db";
            this.openDatabase.FileOk += new System.ComponentModel.CancelEventHandler(this.openDatabase_FileOk);
            // 
            // databasePathTextbox
            // 
            this.databasePathTextbox.Enabled = false;
            this.databasePathTextbox.Location = new System.Drawing.Point(127, 58);
            this.databasePathTextbox.Name = "databasePathTextbox";
            this.databasePathTextbox.Size = new System.Drawing.Size(143, 20);
            this.databasePathTextbox.TabIndex = 1;
            // 
            // masterpwTextbox
            // 
            this.masterpwTextbox.Location = new System.Drawing.Point(6, 36);
            this.masterpwTextbox.Name = "masterpwTextbox";
            this.masterpwTextbox.PasswordChar = '*';
            this.masterpwTextbox.Size = new System.Drawing.Size(168, 20);
            this.masterpwTextbox.TabIndex = 2;
            this.masterpwTextbox.UseSystemPasswordChar = true;
            // 
            // Enter
            // 
            this.Enter.Location = new System.Drawing.Point(180, 34);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(75, 23);
            this.Enter.TabIndex = 3;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.button2_Click);
            // 
            // databasefilelocationlabel
            // 
            this.databasefilelocationlabel.AutoSize = true;
            this.databasefilelocationlabel.Enabled = false;
            this.databasefilelocationlabel.Location = new System.Drawing.Point(12, 61);
            this.databasefilelocationlabel.Name = "databasefilelocationlabel";
            this.databasefilelocationlabel.Size = new System.Drawing.Size(112, 13);
            this.databasefilelocationlabel.TabIndex = 4;
            this.databasefilelocationlabel.Text = "Database file location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Masterpassword";
            // 
            // masterpasswordGroupbox
            // 
            this.masterpasswordGroupbox.Controls.Add(this.Enter);
            this.masterpasswordGroupbox.Controls.Add(this.label2);
            this.masterpasswordGroupbox.Controls.Add(this.masterpwTextbox);
            this.masterpasswordGroupbox.Enabled = false;
            this.masterpasswordGroupbox.Location = new System.Drawing.Point(15, 84);
            this.masterpasswordGroupbox.Name = "masterpasswordGroupbox";
            this.masterpasswordGroupbox.Size = new System.Drawing.Size(265, 71);
            this.masterpasswordGroupbox.TabIndex = 5;
            this.masterpasswordGroupbox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(289, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "File controls";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openToolStripMenuItem.Image = global::PasswordSafeForms.Properties.Resources.outline_note_add_black_24dp;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "New";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openToolStripMenuItem1.Image = global::PasswordSafeForms.Properties.Resources.outline_folder_open_black_24dp;
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // OpendatabasetoolStripButton1
            // 
            this.OpendatabasetoolStripButton1.Image = global::PasswordSafeForms.Properties.Resources.outline_folder_open_black_24dp;
            this.OpendatabasetoolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpendatabasetoolStripButton1.Name = "OpendatabasetoolStripButton1";
            this.OpendatabasetoolStripButton1.Size = new System.Drawing.Size(106, 22);
            this.OpendatabasetoolStripButton1.Text = "Open database";
            this.OpendatabasetoolStripButton1.Click += new System.EventHandler(this.OpenDatabasetoolStripButton1_Click);
            // 
            // newDatabasetoolStripButton1
            // 
            this.newDatabasetoolStripButton1.Image = global::PasswordSafeForms.Properties.Resources.outline_note_add_black_24dp;
            this.newDatabasetoolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newDatabasetoolStripButton1.Name = "newDatabasetoolStripButton1";
            this.newDatabasetoolStripButton1.Size = new System.Drawing.Size(101, 22);
            this.newDatabasetoolStripButton1.Text = "New database";
            this.newDatabasetoolStripButton1.Click += new System.EventHandler(this.newDatabasetoolStripButton1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpendatabasetoolStripButton1,
            this.newDatabasetoolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(289, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::PasswordSafeForms.Properties.Resources.baseline_help_outline_black_24dp;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 20);
            this.toolStripButton1.Text = "Help";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.Enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 164);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.masterpasswordGroupbox);
            this.Controls.Add(this.databasefilelocationlabel);
            this.Controls.Add(this.databasePathTextbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.masterpasswordGroupbox.ResumeLayout(false);
            this.masterpasswordGroupbox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openDatabase;
        private System.Windows.Forms.TextBox databasePathTextbox;
        private System.Windows.Forms.TextBox masterpwTextbox;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox masterpasswordGroupbox;
        public System.Windows.Forms.Label databasefilelocationlabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton OpendatabasetoolStripButton1;
        private System.Windows.Forms.ToolStripButton newDatabasetoolStripButton1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

