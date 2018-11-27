using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Объявление нового экземпляра списка контактов
        /// </summary>
        private Project _project = new Project();

        public MainForm()
        {
            InitializeComponent();
            _project = ProjectManager.LoadFile(@"c:\contacts.json");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectManager.SaveFile(_project, @"c:\contacts.json");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Contact contact = new Contact();
            //contact.Name = "Георгий";
            //contact.Surname = "Разников";
            //contact.DateOfBirhday = new DateTime(1997, 03, 12);
            //contact.Email = "biggreenelpy@gmail.com";
            //contact.VkID = "biggreenelpy";
            //contact.Phone.Number = 79138101010;
            //_project.Contacts.Add(contact);
            //ContactsListBox.Items.Add(contact.Name);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form About = new AboutBox();
            About.ShowDialog();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EditContactButton_Click(object sender, EventArgs e)
        {

        }

        private void DelecteContactButton_Click(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void VKTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void AddContactButton_Click(object sender, EventArgs e)
        {

        }

        private void AddContactButton_MouseEnter(object sender, EventArgs e)
        {
            InfoLabel.Text = "Add new contact";
        }

        private void AddContactButton_MouseLeave(object sender, EventArgs e)
        {
            InfoLabel.Text = "";
        }

        private void EditContactButton_MouseEnter(object sender, EventArgs e)
        {
            InfoLabel.Text = "Edit this contact";
        }

        private void EditContactButton_MouseLeave(object sender, EventArgs e)
        {
            InfoLabel.Text = "";
        }

        private void DelecteContactButton_MouseEnter(object sender, EventArgs e)
        {
            InfoLabel.Text = "Delete this contact";
        }

        private void DelecteContactButton_MouseLeave(object sender, EventArgs e)
        {
            InfoLabel.Text = "";
        }
    }
}
