using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordSafeLibrary;

namespace PasswordSafeForms {
    public partial class FormLogin : Form {
        public FormLogin() {
            InitializeComponent();
        }

        private static MasterPasswordRepository masterRepository = new MasterPasswordRepository(ConfigurationManager.AppSettings.Get("masterpassword_path") + "master.pw");
        private static PasswordSafeEngine passwordSafeEngine = null;
        private string filePath = "./passwords.db";
        private string masterPw;
        private Form _MainForm;

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            if (openDatabase.ShowDialog() == DialogResult.OK) {
                //Get the path of specified file
                // enable textbox
                filePath = openDatabase.FileName;
                databasePathTextbox.Text = filePath;
                databasePathTextbox.Enabled = true;

                // Enable masterpw
                masterpasswordGroupbox.Enabled = true;
            }
        }

        private void openDatabase_FileOk(object sender, CancelEventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            // get pw
            masterPw = masterpwTextbox.Text;

            var aes = new AESEncryption();
            byte[] masterPwByte = aes.encrypt(CipherFacility.GetKey(Encoding.UTF8.GetBytes(masterPw)), masterPw);

            bool unlocked = masterRepository.MasterPasswordIsEqualTo(masterPwByte);
            if (unlocked) {
                passwordSafeEngine = new PasswordSafeEngine(ConfigurationManager.AppSettings.Get("passwords_path"),
                    new CipherFacility(Encoding.UTF8.GetBytes(masterPw)));
                Console.WriteLine("unlocked");
                // init Main Form
                _MainForm = new MainForm(filePath, passwordSafeEngine);
                _MainForm.Show();
                this.Hide();
                // subscribe to close event
                MainForm.ActiveForm.FormClosed += MainForm_FormClosed;
            } else {
                MessageBox.Show("Wrong password or master.pw file does not exist");
                Console.WriteLine("master password did not match ! Failed to unlock.");
            }            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            // main close cleanup
            Close();
        }
    }
}
