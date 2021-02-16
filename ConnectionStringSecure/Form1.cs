using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectionStringSecure
{
    public partial class Form1 : Form
    {
        private ConnectionProtection _operations = 
            new ConnectionProtection(Application.ExecutablePath);

        public Form1()
        {
            InitializeComponent();

            _operations.EncryptFile();
           
            Closing += OnClosing;

        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            _operations.EncryptFile();
        }

        private void GetUnencryptedConnectionButton_Click(object sender, EventArgs e)
        {
            var mainConnection = "";
            _operations.DecryptFile();
            mainConnection = Properties.Settings.Default.ConnectionString;
            ConnectionStringTextBox.Text = mainConnection;
            

        }
     
    }
}
