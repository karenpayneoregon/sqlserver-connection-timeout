
namespace ConnectionStringSecure
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GetUnencryptedConnectionButton = new System.Windows.Forms.Button();
            this.ConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GetUnencryptedConnectionButton
            // 
            this.GetUnencryptedConnectionButton.Location = new System.Drawing.Point(26, 12);
            this.GetUnencryptedConnectionButton.Name = "GetUnencryptedConnectionButton";
            this.GetUnencryptedConnectionButton.Size = new System.Drawing.Size(157, 23);
            this.GetUnencryptedConnectionButton.TabIndex = 0;
            this.GetUnencryptedConnectionButton.Text = "Get connection string";
            this.GetUnencryptedConnectionButton.UseVisualStyleBackColor = true;
            this.GetUnencryptedConnectionButton.Click += new System.EventHandler(this.GetUnencryptedConnectionButton_Click);
            // 
            // ConnectionStringTextBox
            // 
            this.ConnectionStringTextBox.Location = new System.Drawing.Point(26, 56);
            this.ConnectionStringTextBox.Name = "ConnectionStringTextBox";
            this.ConnectionStringTextBox.Size = new System.Drawing.Size(446, 20);
            this.ConnectionStringTextBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 105);
            this.Controls.Add(this.ConnectionStringTextBox);
            this.Controls.Add(this.GetUnencryptedConnectionButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Somewhat safe connection string";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetUnencryptedConnectionButton;
        private System.Windows.Forms.TextBox ConnectionStringTextBox;
    }
}

