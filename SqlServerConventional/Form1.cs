using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlServerConventional.Classes;

namespace SqlServerConventional
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * The other code sample loads in this event
             * while this code does not as when the connection string
             * fails the form will not display until after an exception
             * is thrown thus Shown event is used. The other code sample
             * will display the form even on a bad connection
             *
             * Best to always use the shown event.
             */
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            DataOperations.RunWithoutIssues = NoIssuesCheckBox.Checked;
            var table = DataOperations.ReadProducts();
            if (DataOperations.IsSuccessful)
            {
                dataGridView1.DataSource = table;
            }
            else
            {
                MessageBox.Show($"Ran into issues\n{DataOperations.ExceptionMessage}");
            }

            /*
             * Even if we failed on load let's show the logic works here too.
             */
            LoadProductsButton.Enabled = true;
            NoIssuesCheckBox.Checked = false;
        }

        private void LoadProductsButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
