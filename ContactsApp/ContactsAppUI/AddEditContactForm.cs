using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class AddEditContactForm : Form
    {
        public AddEditContactForm()
        {
            InitializeComponent();
        }

        private Contact _contact = new Contact();

        #region Флаги правильности ввода параметров

        // <summary>
        /// Флаг верности ввода фамилии
        /// </summary>
        private bool _checkSurnameResult = false;

        /// <summary>
        /// Флаг верности ввода имени
        /// </summary>
        private bool _checkNameResult = false;

        /// <summary>
        /// Флаг верности ввода даты
        /// </summary>
        private bool _checkDataResult = false;

        /// <summary>
        /// Флаг верности ввода номера телефона
        /// </summary>
        private bool _checkPhoneResult = false;

        #endregion

        public Contact Contact
        {
            get => _contact;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (_checkSurnameResult == true & _checkNameResult == true & _checkDataResult == true &
                _checkPhoneResult == true)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = Color.White;
                errorProvider1.SetError(SurnameTextBox, String.Empty);
                _checkSurnameResult = true;
            }
            catch (ArgumentNullException exception)
            {
                errorProvider1.SetError(SurnameTextBox, "Фамилия не указана!");
                SurnameTextBox.BackColor = Color.LightSalmon;
            }
            catch (ArgumentException exception)
            {
                errorProvider1.SetError(SurnameTextBox, "Фамилия слишком длинная!");
                SurnameTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Name = NameTextBox.Text;
                NameTextBox.BackColor = Color.White;
                errorProvider1.SetError(NameTextBox, String.Empty);
                _checkNameResult = true;
            }
            catch (ArgumentNullException exception)
            {
                errorProvider1.SetError(NameTextBox, "Имя не указано!");
                NameTextBox.BackColor = Color.LightSalmon;
            }
            catch (ArgumentException exception)
            {
                errorProvider1.SetError(NameTextBox, "Имя слишком длинное!");
                NameTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long number;
                long.TryParse(PhoneNumberTextBox.Text, out number);
                _contact.Phone.Number = number;
                PhoneNumberTextBox.BackColor = Color.White;
                errorProvider1.SetError(PhoneNumberTextBox, String.Empty);
                _checkPhoneResult = true;
            }
            catch (FormatException exception)
            {
                errorProvider1.SetError(PhoneNumberTextBox, "Номер телефона должен начинаться с 7!");
                PhoneNumberTextBox.BackColor = Color.LightSalmon;
            }
            catch (ArgumentException exception)
            {
                errorProvider1.SetError(PhoneNumberTextBox, exception.Message);
                PhoneNumberTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {

                _contact.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = Color.White;
                errorProvider1.SetError(EmailTextBox, String.Empty);
            }
            catch (ArgumentException exception)
            {
                errorProvider1.SetError(EmailTextBox, "Email слишком длинный!");
                EmailTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void VKTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.VkID = VKTextBox.Text;
                VKTextBox.BackColor = Color.White;
                errorProvider1.SetError(VKTextBox, String.Empty);
            }
            catch (ArgumentException exception)
            {
                errorProvider1.SetError(VKTextBox, "ID VK слишком длинный!");
                VKTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void CancelButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.DateOfBirhday = BirthdayDateTimePicker.Value;
                errorProvider1.SetError(BirthdayDateTimePicker, String.Empty);
                _checkDataResult = true;
            }
            catch (ArgumentException exception)
            {
                errorProvider1.SetError(BirthdayDateTimePicker, "Дата рождения не может быть сегодня или будущее время!");
            }
            catch (IndexOutOfRangeException exception)
            {
                errorProvider1.SetError(BirthdayDateTimePicker, "Дата рождения не может быть раньше 1900-го года!");
            }
        }

        /// <summary>
        /// Отображение информации экземпляра контакта
        /// </summary>
        /// <param name="contact">Экземпляр контакта</param>
        public void ContactView(Contact contact)
        {
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            BirthdayDateTimePicker.Value = contact.DateOfBirhday;
            PhoneNumberTextBox.Text = Convert.ToString(contact.Phone.Number);
            EmailTextBox.Text = contact.Email;
            VKTextBox.Text = contact.VkID;
        }
    }
}
