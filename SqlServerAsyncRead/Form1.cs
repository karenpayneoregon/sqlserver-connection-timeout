using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlServerAsyncRead.Classes;

namespace SqlServerAsyncRead
{
    public partial class Form1 : Form
    {
        /*
         * Our object to provide cancellation with a timeout, here it's four
         * seconds.
         */
        private CancellationTokenSource _cancellationTokenSource = 
            new CancellationTokenSource(TimeSpan.FromSeconds(4));
        
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Provides a successful or unsuccessful connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoadProductsButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            
            //await Task.Delay(1000);
            
            await LoadData();
            
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadData(true);
        }
        
        /// <summary>
        /// Load data from database table, if not first time calling this method
        /// create a new CancellationTokenSource
        /// </summary>
        /// <param name="firstTime">passing false to recreate CancellationTokenSource</param>
        /// <returns>A Task</returns>
        private async Task LoadData(bool firstTime = false)
        {
            if (!firstTime)
            {
                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    _cancellationTokenSource.Dispose();
                    
                    // cancel after four seconds, this value could be read from app.config or project property settings
                    _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(4));
                }
            }

            var dataResults = await DataOperations.ReadProductsTask(_cancellationTokenSource.Token);

            if (dataResults.HasException)
            {
                MessageBox.Show(dataResults.ConnectionFailed ? @"Connection failed" : dataResults.GeneralException.Message);
            }
            else
            {
                dataGridView1.DataSource = dataResults.DataTable;
            }

            /*
             * Even if we failed on load let's show the logic works here too.
             */
            LoadProductsButton.Enabled = true;
        }

        private void NoIssuesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DataOperations.RunWithoutIssues = NoIssuesCheckBox.Checked;
        }
    }
}
