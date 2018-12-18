using System;
using System.Drawing;
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
        private bool _isSurnameCorrect = false;

        /// <summary>
        /// Флаг верности ввода имени
        /// </summary>
        private bool _isNameCorrect = false;

        /// <summary>
        /// Флаг верности ввода даты
        /// </summary>
        private bool _isDataCorrect = false;

        /// <summary>
        /// Флаг верности ввода номера телефона
        /// </summary>
        private bool _isPhoneCorrect = false;

        #endregion

        public Contact Contact
        {
            get => _contact;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (_isSurnameCorrect && _isNameCorrect && _isDataCorrect && _isPhoneCorrect)
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
                errorProvider1.SetError(SurnameTextBox, string.Empty);
                _isSurnameCorrect = true;
            }
            catch (ArgumentException exception)
            {
                errorProvider1.SetError(SurnameTextBox, exception.Message);
                SurnameTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Name = NameTextBox.Text;
                NameTextBox.BackColor = Color.White;
                errorProvider1.SetError(NameTextBox, string.Empty);
                _isNameCorrect = true;
            }
            catch (ArgumentException exception)
            {
                errorProvider1.SetError(NameTextBox, exception.Message);
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
                errorProvider1.SetError(PhoneNumberTextBox, string.Empty);
                _isPhoneCorrect = true;
            }
            catch (FormatException exception)
            {
                errorProvider1.SetError(PhoneNumberTextBox, exception.Message);
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
                errorProvider1.SetError(EmailTextBox, string.Empty);
            }
            catch (ArgumentException exception)
            {
                errorProvider1.SetError(EmailTextBox, exception.Message);
                EmailTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void VKTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.VkID = VKTextBox.Text;
                VKTextBox.BackColor = Color.White;
                errorProvider1.SetError(VKTextBox, string.Empty);
            }
            catch (ArgumentException exception)
            {
                errorProvider1.SetError(VKTextBox, exception.Message);
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
                errorProvider1.SetError(BirthdayDateTimePicker, string.Empty);
                _isDataCorrect = true;
            }
            catch (ArgumentException exception)
            {
                errorProvider1.SetError(BirthdayDateTimePicker, exception.Message);
            }
            catch (IndexOutOfRangeException exception)
            {
                errorProvider1.SetError(BirthdayDateTimePicker, exception.Message);
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
