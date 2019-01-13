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
        /// <summary>
        /// Стандартный путь к файлу со списком контактов
        /// </summary>
        private static string _filePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Contacts.contactsApp";
        /// <summary>
        /// 
        /// </summary>
        private readonly Project _projectForFind = new Project();

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _project = ProjectManager.LoadFile(_filePath);
        }

        /// <summary>
        /// Действия при полной загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            FillContactList(_project.Contacts);
            if (ContactsListBox.Items.Count > 0)
            {
                ContactsListBox.SelectedIndex = 0;
            }
            CheckTodayBirthday();
            this.Text = _filePath;
        }

        /// <summary>
        /// Действия при закрытии формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectManager.SaveFile(_project, _filePath);
        }

        #region Buttons
        /// <summary>
        /// Кнопка добавления контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddContactButton_Click(object sender, EventArgs e)
        {
            FindTextBox.Clear();
            AddContact();
        }
        /// <summary>
        /// Кнопка редактирования контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditContactButton_Click(object sender, EventArgs e)
        {
            FindTextBox.Clear();
            EditContact();
        }
        /// <summary>
        /// Кнопка удаления контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelecteContactButton_Click(object sender, EventArgs e)
        {
            FindTextBox.Clear();
            DeleteContact();
        }
        /// <summary>
        /// Кнопка добавления нового контакта в верхнем меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addANewContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindTextBox.Clear();
            AddContact();
        }
        /// <summary>
        /// Кнопка редактирования контакта в верхнем меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindTextBox.Clear();
            EditContact();
        }
        /// <summary>
        /// Кнопка удаления контакта в верхнем меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindTextBox.Clear();
            DeleteContact();
        }
        /// <summary>
        /// Кнопка вызова окна "О программе..."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FindTextBox.Clear();
            Form AboutForm = new AboutForm();
            AboutForm.Show();
        }
        /// <summary>
        /// Кнопка выхода из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        /// <summary>
        /// Метод заполнения элемента ContactListBox списком контактов
        /// </summary>
        /// <param name="contacts"></param>
        public void FillContactList(List<Contact> contacts)
        {
            if (ContactsListBox.Items.Count > 0)
            {
                ContactsListBox.Items.Clear();
            }

            contacts = _project.SortContacts(contacts);

            foreach (Contact contact in contacts)
            {
                ContactsListBox.Items.Add(contact.Surname + " " + contact.Name);
            }
        }

        /// <summary>
        /// Метод, заполняющий правый блок информацией о выделенном контакте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Метод добавления нового контакта
        /// </summary>
        private void AddContact()
        {
            AddEditContactForm NewContact = new AddEditContactForm();
            Contact newContact = NewContact.Contact;
            if (NewContact.ShowDialog() == DialogResult.OK)
            {
                _project.Contacts.Add(newContact);
                ProjectManager.SaveFile(_project, _filePath);
            }
            FillContactList(_project.Contacts);
            CheckTodayBirthday();
        }

        /// <summary>
        /// Метод редактирования выделенного контакта
        /// </summary>
        private void EditContact()
        {
            if (ContactsListBox.SelectedIndex != -1)
            {
                AddEditContactForm EditContact = new AddEditContactForm();
                int index = ContactsListBox.SelectedIndices[0];
                Contact editedContact = _project.Contacts[index];
                EditContact.ContactView(editedContact);
                if (EditContact.ShowDialog() == DialogResult.OK)
                {
                    _project.Contacts.RemoveAt(index);
                    _project.Contacts.Add(EditContact.Contact);
                    ProjectManager.SaveFile(_project, _filePath);
                    FillContactList(_project.Contacts);
                    ContactsListBox.SelectedIndex = index;
                    CheckTodayBirthday();
                }
            }
        }

        /// <summary>
        /// Метод удаления выделенного контакта
        /// </summary>
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
                        ProjectManager.SaveFile(_project, _filePath);
                        FillContactList(_project.Contacts);
                        SurnameTextBox.Clear();
                        NameTextBox.Clear();
                        PhoneNumberTextBox.Clear();
                        EmailTextBox.Clear();
                        VKTextBox.Clear();
                        BirthdayDateTimePicker.Value = new DateTime(2007, 9, 3);
                        CheckTodayBirthday();
                    }
                }
            }
        }

        /// <summary>
        /// Метод поиска в списке контактов по подстроке (Имя, фамилия и телефон)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            UpperFirstSymbol(sender);

            _projectForFind.Contacts = _projectForFind.SortContacts(_project.Contacts, FindTextBox.Text);

            FillContactList(_projectForFind.Contacts);
        }

        /// <summary>
        /// Метод, приводящий первый символ в верхний регистр
        /// </summary>
        /// <param name="sender"></param>
        private void UpperFirstSymbol(object sender)
        {
            if (((TextBox)sender).Text.Length == 1)
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        /// <summary>
        /// Метод, проверяющий именинников в списке контактов
        /// </summary>
        private void CheckTodayBirthday()
        {
            BirthdayPannel.Visible = false;
            BirthdayListLabel.Text = String.Empty;
            List<Contact> birthdayList = _project.ShowBirthdayList(DateTime.Today);
            if (birthdayList.Count != 0)
            {
                BirthdayPannel.Visible = true;
                foreach (var contact in birthdayList)
                {
                    BirthdayListLabel.Text += contact.Surname + " " + contact.Name + "; ";
                }
            }
        }
    }
}