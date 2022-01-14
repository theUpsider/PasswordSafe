
namespace PasswordSafeForms {
    partial class EditOrAddDatabaseForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditOrAddDatabaseForm));
            this.label1 = new System.Windows.Forms.Label();
            this.databaseNameTextbox = new System.Windows.Forms.TextBox();
            this.masterpwlabel = new System.Windows.Forms.Label();
            this.masterPwTextbox = new System.Windows.Forms.TextBox();
            this.retypemasterpwlabel = new System.Windows.Forms.Label();
            this.masterPwRetypeTextbox = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database name:";
            // 
            // databaseNameTextbox
            // 
            this.databaseNameTextbox.Location = new System.Drawing.Point(134, 42);
            this.databaseNameTextbox.Name = "databaseNameTextbox";
            this.databaseNameTextbox.Size = new System.Drawing.Size(162, 20);
            this.databaseNameTextbox.TabIndex = 1;
            this.databaseNameTextbox.Text = "passwords.db";
            // 
            // masterpwlabel
            // 
            this.masterpwlabel.AutoSize = true;
            this.masterpwlabel.Location = new System.Drawing.Point(9, 122);
            this.masterpwlabel.Name = "masterpwlabel";
            this.masterpwlabel.Size = new System.Drawing.Size(90, 13);
            this.masterpwlabel.TabIndex = 0;
            this.masterpwlabel.Text = "Master password:";
            // 
            // masterPwTextbox
            // 
            this.masterPwTextbox.Location = new System.Drawing.Point(134, 119);
            this.masterPwTextbox.Name = "masterPwTextbox";
            this.masterPwTextbox.Size = new System.Drawing.Size(162, 20);
            this.masterPwTextbox.TabIndex = 2;
            this.masterPwTextbox.UseSystemPasswordChar = true;
            // 
            // retypemasterpwlabel
            // 
            this.retypemasterpwlabel.AutoSize = true;
            this.retypemasterpwlabel.Location = new System.Drawing.Point(9, 148);
            this.retypemasterpwlabel.Name = "retypemasterpwlabel";
            this.retypemasterpwlabel.Size = new System.Drawing.Size(126, 13);
            this.retypemasterpwlabel.TabIndex = 0;
            this.retypemasterpwlabel.Text = "Retype master password:";
            // 
            // masterPwRetypeTextbox
            // 
            this.masterPwRetypeTextbox.Location = new System.Drawing.Point(134, 145);
            this.masterPwRetypeTextbox.Name = "masterPwRetypeTextbox";
            this.masterPwRetypeTextbox.Size = new System.Drawing.Size(162, 20);
            this.masterPwRetypeTextbox.TabIndex = 3;
            this.masterPwRetypeTextbox.UseSystemPasswordChar = true;
            // 
            // createButton
            // 
            this.createButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createButton.Enabled = false;
            this.createButton.Location = new System.Drawing.Point(12, 181);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 2;
            this.createButton.Text = "create";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "This is the file for the new password safe. \r\nYou can specify a name ending with " +
    ".db";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(266, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "Enter your master password. Note it down somewhere. \r\nIf you loose it, all your p" +
    "asswords are lost.";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(93, 181);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // EditOrAddDatabaseForm
            // 
            this.AcceptButton = this.createButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(315, 216);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.masterPwRetypeTextbox);
            this.Controls.Add(this.retypemasterpwlabel);
            this.Controls.Add(this.masterPwTextbox);
            this.Controls.Add(this.masterpwlabel);
            this.Controls.Add(this.databaseNameTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditOrAddDatabaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit or add database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label masterpwlabel;
        private System.Windows.Forms.Label retypemasterpwlabel;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox databaseNameTextbox;
        public System.Windows.Forms.TextBox masterPwTextbox;
        public System.Windows.Forms.TextBox masterPwRetypeTextbox;
        private System.Windows.Forms.Button cancelButton;
    }
}