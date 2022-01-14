using PasswordSafeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordSafeForms {

    /// <summary>
    /// Manages the main interface and logic like adding, editing or deleting entries
    /// </summary>
    public partial class MainForm : Form {
        private readonly PasswordSafeEngine passwordSafeEngine;
        List<StringValue> passwordNames;
        BindingList<StringValue> bindingList;

        public class StringValue : INotifyPropertyChanged {
            public StringValue(string s) {
                _value = s;
            }
            public string Name { get { return _value; } set { _value = value; } }
            string _value;

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string p) {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public MainForm(string filePath, PasswordSafeEngine pwSafeEngine) {
            InitializeComponent();
            passwordSafeEngine = pwSafeEngine;
            passwordNames = passwordSafeEngine.GetStoredPasswords().Where(name => name != "")
                                                                .ToList()
                                                                .ConvertAll(x => new StringValue(x));
            bindingList = new BindingList<StringValue>(passwordNames);
            bindingList.AllowEdit = false;
            var source = new BindingSource(bindingList, null);
            passworddataGridView1.DataSource = source;
            passworddataGridView1.UserDeletingRow += PassworddataGridView1_UserDeletingRow;
            passworddataGridView1.CellClick += PassworddataGridView1_CellClick;
            passworddataGridView1.CellDoubleClick += PassworddataGridView1_CellDoubleClick;
            passworddataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            passworddataGridView1.MouseClick += passworddataGridContextMenuShow_MouseClick;
            passworddataGridView1.RowHeadersVisible = false;

        }
        
        private void passworddataGridContextMenuShow_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {

                
                //m.MenuItems.Add(new MenuItem("Cut"));
                //m.MenuItems.Add(new MenuItem("Copy"));
                //m.MenuItems.Add(new MenuItem("Paste"));

                int currentMouseOverRow = passworddataGridView1.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0) {
                    passworddataGridView1.ClearSelection();
                    passworddataGridView1.Rows[currentMouseOverRow].Selected = true;
                    //m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                    passwordGridcontextMenuStrip.Show(passworddataGridView1,new Point(e.X, e.Y));
                }

            }
        }

        private void PassworddataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0)
                if (passworddataGridView1.Rows[e.RowIndex] != null)
                    passworddataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void PassworddataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            copyPasswordEntryToClipboard();
        }

        private void PassworddataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            if (e.Row.DataBoundItem.GetType() == typeof(StringValue)) {
                passwordSafeEngine.DeletePassword(((StringValue)e.Row.DataBoundItem).Name);
            }
        }

        private void toolStripAddPassword_Click(object sender, EventArgs e) {
            PasswordInfo pwInfo = ShowAddPasswordDialogBox();
            if (pwInfo != null && pwInfo.Password != "" && pwInfo.PasswordName != "") {
                StringValue item = new StringValue(
                    passwordSafeEngine.AddNewPassword(
                                pwInfo)
                                .PasswordName);
                bindingList.Add(item);
            }
        }

        private void DeletePwStripButton1_Click(object sender, EventArgs e) {
            if (passworddataGridView1.SelectedRows.Count > 0) {
                passwordSafeEngine.DeletePassword((passworddataGridView1.SelectedRows[0].DataBoundItem as StringValue).Name);
                bindingList.Remove(passworddataGridView1.SelectedRows[0].DataBoundItem as StringValue);
            }
        }

        public PasswordInfo ShowAddPasswordDialogBox() {
            EditOrAddPasswordForm testDialog = new EditOrAddPasswordForm();

            return ShowDialogGetResult(testDialog);
        }

        public PasswordInfo ShowAddPasswordDialogBox(string name) {
            EditOrAddPasswordForm testDialog = new EditOrAddPasswordForm();
            testDialog.NameTextBox.Text = name;

            return ShowDialogGetResult(testDialog);
        }

        private static PasswordInfo ShowDialogGetResult(EditOrAddPasswordForm testDialog) {
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog() == DialogResult.OK) {
                // Read the contents of testDialog's TextBox.
                var passwordName = testDialog.NameTextBox.Text;
                var passwordValue = testDialog.passwordTextbox.Text;
                return new PasswordInfo(passwordValue, passwordName);
            }
            return null;
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            MessageBox.Show("Double click on an item to retrieve password. " +
                "Select item and either press del on your keyboard or use the icon to delete. Exported passwords " +
                "can be opened in any text editor. Made by David Fischer");
        }

        private void editPwToolStripButton_Click(object sender, EventArgs e) {
            editPasswordEntry();
        }

        private void editPasswordEntry() {
            string oldPasswordName = (passworddataGridView1.SelectedRows[0].DataBoundItem as StringValue).Name;
            if (passworddataGridView1.SelectedRows.Count > 0) {
                PasswordInfo pwInfo = ShowAddPasswordDialogBox(oldPasswordName);
                if (pwInfo != null && pwInfo.Password != "" && pwInfo.PasswordName != "") {
                    StringValue item = new StringValue(
                        passwordSafeEngine.UpdatePassword(
                                    pwInfo)
                                    .PasswordName);
                    // replace item
                    bindingList[bindingList.IndexOf(passworddataGridView1.SelectedRows[0].DataBoundItem as StringValue)] = item;
                    MessageBox.Show("Password sucessfully changed");

                }else if (pwInfo != null && pwInfo.Password == "" && pwInfo.PasswordName != "" && oldPasswordName != pwInfo.PasswordName) {
                    StringValue item = new StringValue(
                        passwordSafeEngine.AddNewPassword(
                            new PasswordInfo(
                                passwordSafeEngine.GetPassword(oldPasswordName), 
                                pwInfo.PasswordName))
                                    .PasswordName);
                    passwordSafeEngine.DeletePassword(oldPasswordName);
                    // replace item
                    bindingList[bindingList.IndexOf(passworddataGridView1.SelectedRows[0].DataBoundItem as StringValue)] = item;
                    MessageBox.Show("Password sucessfully changed");
                }
            }
        }

        private void EditMasterPwtoolStripButton_Click(object sender, EventArgs e) {
            EditOrAddDatabaseForm testDialog = new EditOrAddDatabaseForm();
            testDialog.databaseNameTextbox.Enabled = false;
            testDialog.databaseNameTextbox.Text = "";
            testDialog.Text = "Change master password";

            if (testDialog.ShowDialog() == DialogResult.OK) {
                // Read the contents of testDialog's TextBox.
                var passwordValue = testDialog.masterPwRetypeTextbox.Text;
                passwordSafeEngine.ChangeMasterPw(passwordValue);
                MessageBox.Show("Password sucessfully changed");
            }
        }

        private void ExportPasswordstoolStripButton_Click(object sender, EventArgs e) {
            List<PasswordInfo> passwordInfos = new List<PasswordInfo>();

            // get all passwords decrypted and store them
            foreach (string storedPwString in passwordSafeEngine.GetStoredPasswords()) {
                passwordInfos.Add(new PasswordInfo(passwordSafeEngine.GetPassword(storedPwString), storedPwString));
            }

            //exportEntriesDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            exportEntriesDialog.DefaultExt = "xml";
            exportEntriesDialog.AddExtension = true;
            exportEntriesDialog.FileName = "passwords.xml";
            exportEntriesDialog.Filter = "XML (*.xml)|*.XML|All files (*.*)|*.*";
            exportEntriesDialog.Title = "Export all entries as xml";
            if (exportEntriesDialog.ShowDialog() == DialogResult.OK) {
                ExportXml(ref passwordInfos,exportEntriesDialog.FileName);
                MessageBox.Show("Passwords sucessfully exported");
            }
        }

        public static void ExportXml<T>(ref T toExport, string location) {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(T));

            var path = location;
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, toExport);
            file.Close();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e) {
            copyPasswordEntryToClipboard();
        }

        private void copyPasswordEntryToClipboard() {
            Clipboard.SetText(
                            passwordSafeEngine.GetPassword(
                            (passworddataGridView1.SelectedRows[0].DataBoundItem as StringValue).Name));
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            editPasswordEntry();
        }
    }
}
