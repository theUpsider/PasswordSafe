﻿
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
            this.button1 = new System.Windows.Forms.Button();
            this.openDatabase = new System.Windows.Forms.OpenFileDialog();
            this.databasePathTextbox = new System.Windows.Forms.TextBox();
            this.masterpwTextbox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.masterpasswordGroupbox = new System.Windows.Forms.GroupBox();
            this.masterpasswordGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openDatabase
            // 
            this.openDatabase.FileName = "passwords.db";
            this.openDatabase.FileOk += new System.ComponentModel.CancelEventHandler(this.openDatabase_FileOk);
            // 
            // databasePathTextbox
            // 
            this.databasePathTextbox.Enabled = false;
            this.databasePathTextbox.Location = new System.Drawing.Point(124, 11);
            this.databasePathTextbox.Name = "databasePathTextbox";
            this.databasePathTextbox.Size = new System.Drawing.Size(143, 20);
            this.databasePathTextbox.TabIndex = 1;
            // 
            // masterpwTextbox
            // 
            this.masterpwTextbox.Location = new System.Drawing.Point(6, 36);
            this.masterpwTextbox.Name = "masterpwTextbox";
            this.masterpwTextbox.PasswordChar = '*';
            this.masterpwTextbox.Size = new System.Drawing.Size(249, 20);
            this.masterpwTextbox.TabIndex = 2;
            this.masterpwTextbox.UseSystemPasswordChar = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(261, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Enter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Database file location:";
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
            this.masterpasswordGroupbox.Controls.Add(this.button2);
            this.masterpasswordGroupbox.Controls.Add(this.label2);
            this.masterpasswordGroupbox.Controls.Add(this.masterpwTextbox);
            this.masterpasswordGroupbox.Enabled = false;
            this.masterpasswordGroupbox.Location = new System.Drawing.Point(12, 37);
            this.masterpasswordGroupbox.Name = "masterpasswordGroupbox";
            this.masterpasswordGroupbox.Size = new System.Drawing.Size(343, 71);
            this.masterpasswordGroupbox.TabIndex = 5;
            this.masterpasswordGroupbox.TabStop = false;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 117);
            this.Controls.Add(this.masterpasswordGroupbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.databasePathTextbox);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.masterpasswordGroupbox.ResumeLayout(false);
            this.masterpasswordGroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openDatabase;
        private System.Windows.Forms.TextBox databasePathTextbox;
        private System.Windows.Forms.TextBox masterpwTextbox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox masterpasswordGroupbox;
    }
}
