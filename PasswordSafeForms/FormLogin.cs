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

namespace PasswordSafeForms
{

    /// <summary>
    /// Manages the login authentication and database choice process
    /// </summary>
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private static MasterPasswordRepository masterRepository = new MasterPasswordRepository(ConfigurationManager.AppSettings.Get("masterpassword_path") + "master.pw");
        private static PasswordSafeEngine passwordSafeEngine = null;
        private string filePath = "";
        private string masterPw;
        private Form _MainForm;

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void openDatabase_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // get pw
            masterPw = masterpwTextbox.Text;

            var aes = new AESEncryption();
            byte[] masterPwByte = aes.encrypt(CipherFacility.GetKey(Encoding.UTF8.GetBytes(masterPw)), masterPw);

            passwordSafeEngine =
                    new PasswordSafeEngine(filePath,
                    new CipherFacility(Encoding.UTF8.GetBytes(masterPw)));

            // check if database has master pw entry and compare with encrypted userinput
            bool unlocked = masterRepository.MasterPasswordIsEqualTo(
                    passwordSafeEngine.getEncryptedMasterPwEntry(),
                    masterPwByte);

            //bool unlocked = masterRepository.MasterPasswordIsEqualTo(masterPwByte);
            if (unlocked)
            {
                Console.WriteLine("unlocked");
                // init Main Form
                _MainForm = new MainForm(filePath, passwordSafeEngine);
                _MainForm.Show();
                // subscribe to close event
                _MainForm.FormClosed += MainForm_FormClosed;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong password or master.pw file does not exist");
                Console.WriteLine("master password did not match ! Failed to unlock.");
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // main close cleanup
            Close();
        }

        private void OpenDatabasetoolStripButton1_Click(object sender, EventArgs e)
        {
            openFileDatabase();
        }

        private void openFileDatabase()
        {
            if (openDatabase.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                // enable textbox
                filePath = openDatabase.FileName;
                databasePathTextbox.Text = filePath;
                databasePathTextbox.Enabled = true;
                databasefilelocationlabel.Enabled = true;

                // Enable masterpw
                masterpasswordGroupbox.Enabled = true;
            }
        }

        private void newDatabasetoolStripButton1_Click(object sender, EventArgs e)
        {
            if (createNewDatabase())
                openFileDatabase();
        }

        private bool createNewDatabase()
        {
            // path including name like: ./passwords.db
            var masterpasswordsafe = ShowEditOrAddDatabaseFormDialogBox(databasePathTextbox.Text);

            if (!PasswordSafeEngine.CreateDatabase(masterpasswordsafe.PasswordName))
            {
                MessageBox.Show("File already exists.");
                return false;
            }
            try
            {
                if (masterpasswordsafe != null)
                    PasswordSafeEngine.AddNewMasterPw(
                        PasswordSafeEngine.CreateTable(
                            PasswordSafeEngine.CreateConnection(
                                masterpasswordsafe.PasswordName)),
                        masterpasswordsafe.Password);

            }
            catch (Exception ex)
            {
                MessageBox.Show("File is not a database.");
                return false;
            }
            return true;
        }

        public PasswordInfo ShowEditOrAddDatabaseFormDialogBox(string name)
        {
            EditOrAddDatabaseForm testDialog = new EditOrAddDatabaseForm(name);

            return ShowDialogGetResult(testDialog);
        }

        private static PasswordInfo ShowDialogGetResult(EditOrAddDatabaseForm testDialog)
        {
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog() == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                var databasePath = testDialog.databaseNameTextbox.Text;

                var passwordValue = testDialog.masterPwRetypeTextbox.Text;
                return new PasswordInfo(passwordValue, databasePath);
            }
            else
                return null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createNewDatabase();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDatabase();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please open a database which contains your passwords or create a new one to continue.");
        }
    }
}
