using System;
using System.Drawing;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class AddEditContactForm : Form
    {
        /// <summary>
        /// Инициализация формы
        /// </summary>
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

        /// <summary>
        /// Свойство, возвращающее контакт
        /// </summary>
        public Contact Contact
        {
            get => _contact;
        }

        /// <summary>
        /// Кнопка ОК. Выполняется валидация даных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (_isSurnameCorrect && _isNameCorrect && _isDataCorrect && _isPhoneCorrect)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Проверка ввода фамилии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            UpperFirstSymbol(sender);
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

        /// <summary>
        /// Проверка ввода имени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            UpperFirstSymbol(sender);
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

        /// <summary>
        /// Проверка ввода номера телефона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Проверка ввода Email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Проверка ввода ID VK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Кнопка отмены создания/редактирования контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Проверка ввода даты рождения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Метод, приводящий первую букву в поле ввода к верхнему регистру
        /// </summary>
        /// <param name="sender"></param>
        private void UpperFirstSymbol(object sender)
        {
            if (((TextBox)sender).Text.Length == 1)
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
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