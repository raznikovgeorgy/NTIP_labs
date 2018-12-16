using System;
using System.Collections.Generic;
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
            FillContactList(_project.Contacts);
            ContactsListBox.SelectedIndex = 0;
        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void EditContactButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void DelecteContactButton_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }

        private void addANewContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void deleteContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form AboutForm = new AboutForm();
            AboutForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FillContactList(List<Contact> contacts)
        {
            if (ContactsListBox.Items.Count > 0)
            {
                ContactsListBox.Items.Clear();

                foreach (Contact contact in contacts)
                {
                    ContactsListBox.Items.Add(contact.Surname);
                }
            }
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndices.Count != 0)
            {
                SurnameTextBox.Text = _project.Contacts[ContactsListBox.SelectedIndices[0]].Surname;
                NameTextBox.Text = _project.Contacts[ContactsListBox.SelectedIndices[0]].Name;
                BirthdayDateTimePicker.Value = _project.Contacts[ContactsListBox.SelectedIndices[0]].DateOfBirhday;
                PhoneNumberTextBox.Text = _project.Contacts[ContactsListBox.SelectedIndices[0]].Phone.Number.ToString();
                VKTextBox.Text = _project.Contacts[ContactsListBox.SelectedIndices[0]].VkID;
                EmailTextBox.Text = _project.Contacts[ContactsListBox.SelectedIndices[0]].Email;
            }
        }

        private void AddContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            Contact selectedContact = new Contact();

            AddEditContactForm NewContact = new AddEditContactForm();
            Contact newContact = NewContact.Contact;
            if (NewContact.ShowDialog() == DialogResult.OK)
            {
                _project.Contacts.Add(newContact);
                ProjectManager.SaveFile(_project, @"c:\contacts.json");
            }
            FillContactList(_project.Contacts);
        }
        private void EditContact()
        {
            AddEditContactForm EditContact = new AddEditContactForm();
            int index = ContactsListBox.SelectedIndices[0];
            Contact editedContact = _project.Contacts[index];
            EditContact.ContactView(editedContact);
            if (EditContact.ShowDialog() == DialogResult.OK)
            {
                _project.Contacts.RemoveAt(index);
                _project.Contacts.Add(EditContact.Contact);
                ProjectManager.SaveFile(_project, @"c:\contacts.json");
                FillContactList(_project.Contacts);
                ContactsListBox.SelectedIndex = index;
            }
        }

        private void DeleteContact()
        {
            if (ContactsListBox.SelectedIndex != -1)
            {
                if (ContactsListBox.Items.Count != 0)
                {
                    DialogResult result = MessageBox.Show("Do you realy want to delete this contact? " +
                                                          _project.Contacts[ContactsListBox.SelectedIndices[0]].Surname +
                                                          " " + _project.Contacts[ContactsListBox.SelectedIndices[0]].Name,
                                                          "Delete this contact?", MessageBoxButtons.YesNoCancel,
                                                          MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int index = ContactsListBox.SelectedIndices[0];
                        _project.Contacts.RemoveAt(index);
                        ContactsListBox.Items.RemoveAt(index);
                        ProjectManager.SaveFile(_project, @"c:\contacts.json");
                        FillContactList(_project.Contacts);
                        SurnameTextBox.Text = String.Empty;
                        NameTextBox.Text = String.Empty;
                        PhoneNumberTextBox.Text = String.Empty;
                        EmailTextBox.Text = String.Empty;
                        VKTextBox.Text = String.Empty;
                        BirthdayDateTimePicker.Value = new DateTime(2007, 9, 3);
                    }
                }
            }
        }
    }
}