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
            passwordNames = passwordSafeEngine.GetStoredPasswords()
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
        }

        private void PassworddataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0)
                if (passworddataGridView1.Rows[e.RowIndex] != null)
                    passworddataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void PassworddataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            Clipboard.SetText(
                passwordSafeEngine.GetPassword(
                (passworddataGridView1.Rows[e.RowIndex].DataBoundItem as StringValue).Name));
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
            MessageBox.Show("Double click on an item to retrieve password. Select item and either press del on your keyboard or use the icon. Made by David Fischer");
        }

        private void editPwToolStripButton_Click(object sender, EventArgs e) {
            if (passworddataGridView1.SelectedRows.Count > 0) {
                PasswordInfo pwInfo = ShowAddPasswordDialogBox((passworddataGridView1.SelectedRows[0].DataBoundItem as StringValue).Name);
                if (pwInfo != null && pwInfo.Password != "" && pwInfo.PasswordName != "") {
                    StringValue item = new StringValue(
                        passwordSafeEngine.UpdatePassword(
                                    pwInfo)
                                    .PasswordName);
                    // replace item
                    bindingList[bindingList.IndexOf(passworddataGridView1.SelectedRows[0].DataBoundItem as StringValue)] = item;

                }
            }
        }
    }
}
