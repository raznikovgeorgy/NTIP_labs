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

        private Project _project = new Project();
        //private Contact _contact = new Contact();
        //private ProjectManager _projectManager = new ProjectManager();

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Контакты";
            this.Size = new Size(800, 600);
            _project = ProjectManager.LoadFile(@"c:\text.json");
        }

        public void TestingRealisation()
        {
            var contact = new Contact();
            var random = new Random();
            contact.Name = "Георгий" + random.Next(30);
            contact.Surname = "Разников";
            contact.DateOfBirhday = new DateTime(1997,03,12);
            contact.Email = "biggreenelpy@gmail.com";
            contact.VkID = "biggreenelpy";
            contact.Phone.Number = 79138101010;
            _project.Contacts.Add(contact);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestingRealisation();
            var currentContact = _project.Contacts[_project.Contacts.Count-1];
            MessageBox.Show(currentContact.Name,"Имя контакта",
                MessageBoxButtons.OK,MessageBoxIcon.Question);
            //MessageBox.Show(_contact.Surname, "Имя контакта",
            //    MessageBoxButtons.OK, MessageBoxIcon.Question);
            //MessageBox.Show(_contact.DateOfBirhday.ToString(), "Имя контакта",
            //    MessageBoxButtons.OK, MessageBoxIcon.Question);
            //MessageBox.Show(_contact.VkID, "Имя контакта",
            //    MessageBoxButtons.OK, MessageBoxIcon.Question);
            //MessageBox.Show(_contact.Email, "Имя контакта",
            //    MessageBoxButtons.OK, MessageBoxIcon.Question);
            //MessageBox.Show("79528853346", "Имя контакта",
            //    MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectManager.SaveFile(_project, @"c:\text.json");
        }
    }
}
