namespace ContactsAppUI
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.ProgramNameLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.AuthorNameLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.GitHubLabel = new System.Windows.Forms.Label();
            this.CopyrightLabel = new System.Windows.Forms.Label();
            this.EmailLinkLabel = new System.Windows.Forms.LinkLabel();
            this.GitHubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ProgramNameLabel
            // 
            this.ProgramNameLabel.AutoSize = true;
            this.ProgramNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProgramNameLabel.Location = new System.Drawing.Point(12, 12);
            this.ProgramNameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.ProgramNameLabel.Name = "ProgramNameLabel";
            this.ProgramNameLabel.Size = new System.Drawing.Size(182, 31);
            this.ProgramNameLabel.TabIndex = 0;
            this.ProgramNameLabel.Text = "ContactsApp";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(15, 49);
            this.VersionLabel.Margin = new System.Windows.Forms.Padding(3);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(72, 13);
            this.VersionLabel.TabIndex = 1;
            this.VersionLabel.Text = "Version: 1.0.0";
            // 
            // AuthorNameLabel
            // 
            this.AuthorNameLabel.AutoSize = true;
            this.AuthorNameLabel.Location = new System.Drawing.Point(12, 98);
            this.AuthorNameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.AuthorNameLabel.Name = "AuthorNameLabel";
            this.AuthorNameLabel.Size = new System.Drawing.Size(126, 13);
            this.AuthorNameLabel.TabIndex = 2;
            this.AuthorNameLabel.Text = "Author: Georgy Raznikov";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(12, 151);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(3);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(101, 13);
            this.EmailLabel.TabIndex = 3;
            this.EmailLabel.Text = "E-mail for feedback:";
            // 
            // GitHubLabel
            // 
            this.GitHubLabel.AutoSize = true;
            this.GitHubLabel.Location = new System.Drawing.Point(12, 170);
            this.GitHubLabel.Margin = new System.Windows.Forms.Padding(3);
            this.GitHubLabel.Name = "GitHubLabel";
            this.GitHubLabel.Size = new System.Drawing.Size(43, 13);
            this.GitHubLabel.TabIndex = 4;
            this.GitHubLabel.Text = "GitHub:";
            // 
            // CopyrightLabel
            // 
            this.CopyrightLabel.AutoSize = true;
            this.CopyrightLabel.Location = new System.Drawing.Point(12, 225);
            this.CopyrightLabel.Margin = new System.Windows.Forms.Padding(3);
            this.CopyrightLabel.Name = "CopyrightLabel";
            this.CopyrightLabel.Size = new System.Drawing.Size(177, 13);
            this.CopyrightLabel.TabIndex = 5;
            this.CopyrightLabel.Text = "Copyright by Georgy Raznikov 2018";
            // 
            // EmailLinkLabel
            // 
            this.EmailLinkLabel.AutoSize = true;
            this.EmailLinkLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EmailLinkLabel.Location = new System.Drawing.Point(119, 151);
            this.EmailLinkLabel.Margin = new System.Windows.Forms.Padding(3);
            this.EmailLinkLabel.Name = "EmailLinkLabel";
            this.EmailLinkLabel.Size = new System.Drawing.Size(125, 13);
            this.EmailLinkLabel.TabIndex = 6;
            this.EmailLinkLabel.TabStop = true;
            this.EmailLinkLabel.Text = "biggreenelpy@gmail.com";
            this.EmailLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EmailLinkLabel_LinkClicked);
            // 
            // GitHubLinkLabel
            // 
            this.GitHubLinkLabel.AutoSize = true;
            this.GitHubLinkLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GitHubLinkLabel.Location = new System.Drawing.Point(61, 170);
            this.GitHubLinkLabel.Margin = new System.Windows.Forms.Padding(3);
            this.GitHubLinkLabel.Name = "GitHubLinkLabel";
            this.GitHubLinkLabel.Size = new System.Drawing.Size(227, 13);
            this.GitHubLinkLabel.TabIndex = 7;
            this.GitHubLinkLabel.TabStop = true;
            this.GitHubLinkLabel.Text = "https://github.com/raznikovgeorgy/NTIP_labs";
            this.GitHubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubLinkLabel_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(297, 250);
            this.Controls.Add(this.GitHubLinkLabel);
            this.Controls.Add(this.EmailLinkLabel);
            this.Controls.Add(this.CopyrightLabel);
            this.Controls.Add(this.GitHubLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.AuthorNameLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.ProgramNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(313, 285);
            this.MinimumSize = new System.Drawing.Size(313, 285);
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProgramNameLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label AuthorNameLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label GitHubLabel;
        private System.Windows.Forms.Label CopyrightLabel;
        private System.Windows.Forms.LinkLabel EmailLinkLabel;
        private System.Windows.Forms.LinkLabel GitHubLinkLabel;
    }
}