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
    public partial class EditOrAddDatabaseForm : Form {
        public EditOrAddDatabaseForm(string databaseName = "database.db") {
            InitializeComponent();
            //databaseNameTextbox.Text = databaseName; // causes password to dissapear??
            masterPwRetypeTextbox.TextChanged += MasterPwRetypingEvent;
            masterPwTextbox.TextChanged += MasterPwRetypingEvent;
        }

        private void MasterPwRetypingEvent(object sender, EventArgs e) {
           if (masterPwTextbox.Text != masterPwRetypeTextbox.Text || masterPwTextbox.Text.Length == 0 || masterPwRetypeTextbox.Text.Length == 0) {
                createButton.Enabled = false;
                masterpwlabel.ForeColor = Color.Red;
                retypemasterpwlabel.ForeColor = Color.Red;
            } else {
                createButton.Enabled = true;
                masterpwlabel.ForeColor = Color.Green;
                retypemasterpwlabel.ForeColor = Color.Green;
            }
        }
    }
}
