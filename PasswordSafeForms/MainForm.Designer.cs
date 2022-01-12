
namespace PasswordSafeForms {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripAddPassword = new System.Windows.Forms.ToolStripButton();
            this.editPwToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deletePwToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.passworddataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passworddataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddPassword,
            this.editPwToolStripButton,
            this.deletePwToolStripButton,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(311, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripAddPassword
            // 
            this.toolStripAddPassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAddPassword.Image = global::PasswordSafeForms.Properties.Resources.baseline_add_black_24dp;
            this.toolStripAddPassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAddPassword.Name = "toolStripAddPassword";
            this.toolStripAddPassword.Size = new System.Drawing.Size(23, 22);
            this.toolStripAddPassword.Text = "add new password";
            this.toolStripAddPassword.Click += new System.EventHandler(this.toolStripAddPassword_Click);
            // 
            // editPwToolStripButton
            // 
            this.editPwToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editPwToolStripButton.Image = global::PasswordSafeForms.Properties.Resources.baseline_edit_black_24dp;
            this.editPwToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editPwToolStripButton.Name = "editPwToolStripButton";
            this.editPwToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editPwToolStripButton.Text = "edit password";
            this.editPwToolStripButton.Click += new System.EventHandler(this.editPwToolStripButton_Click);
            // 
            // deletePwToolStripButton
            // 
            this.deletePwToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deletePwToolStripButton.Image = global::PasswordSafeForms.Properties.Resources.baseline_delete_outline_black_24dp;
            this.deletePwToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deletePwToolStripButton.Name = "deletePwToolStripButton";
            this.deletePwToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deletePwToolStripButton.Text = "delete selected password";
            this.deletePwToolStripButton.Click += new System.EventHandler(this.DeletePwStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::PasswordSafeForms.Properties.Resources.baseline_help_outline_black_24dp;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "help";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // passworddataGridView1
            // 
            this.passworddataGridView1.AllowUserToAddRows = false;
            this.passworddataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.passworddataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.passworddataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passworddataGridView1.Location = new System.Drawing.Point(0, 25);
            this.passworddataGridView1.Name = "passworddataGridView1";
            this.passworddataGridView1.Size = new System.Drawing.Size(311, 376);
            this.passworddataGridView1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 401);
            this.Controls.Add(this.passworddataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Password Manager";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passworddataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripAddPassword;
        private System.Windows.Forms.DataGridView passworddataGridView1;
        private System.Windows.Forms.ToolStripButton deletePwToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton editPwToolStripButton;
    }
}