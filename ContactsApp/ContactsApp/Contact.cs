using System;


namespace ContactsApp
{
    /// <summary>
    /// Класс контакта, хранящий информацию о номере телефона, имени, фамилии, дне рождения и, возможно, e-mail'а и ссылки ВКонтакте
    /// </summary>
    public class Contact : ICloneable
    {
        
        /// <summary>
        /// Поле, хранящее имя контакта
        /// </summary>
        private string _name;
        /// <summary>
        /// Поле, хранящее фамилию контакта
        /// </summary>
        private string _surname;
        /// <summary>
        /// Поле, хранящее дату рождения контакта
        /// </summary>
        private DateTime _birthday;
        /// <summary>
        /// Поле, хранящее номер телефона контакта
        /// </summary>
        private PhoneNumber _phone = new PhoneNumber();
        /// <summary>
        /// Поле, хранящее e-mail контакта
        /// </summary>
        private string _email = "";
        /// <summary>
        /// Поле, хранящее идентификатор аккаунта ВКонтакте контакта
        /// </summary>
        private string _vkID = "";

       
        /// <summary>
        /// Свойство, возвращающее и задающее фамилию контакта
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Поле Фамилии не может быть пустым");
                }
                else if (value.Length > 50)
                {
                    throw new ArgumentException(
                        "Слишком длинная фамилия, пожалуйста, придумайте фамилию короче 50-ти символов");
                }
                else
                    _surname = char.ToUpper(value[0]) + value.Substring(1);
            }
        }
        /// <summary>
        /// Свойство, возвращающее и задающее имя контакта
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Поле имени не может быть пустым");
                }
                else if (value.Length > 50)
                {
                    throw new ArgumentException(
                        "Слишком длинное имя, пожалуйста, придумайте имя короче 50-ти символов");
                }
                else
                    _name = char.ToUpper(value[0]) + value.Substring(1);
            }
        }

        /// <summary>
        /// Свойство, возвращающее и задающее дату рождения контакта
        /// </summary>
        public DateTime DateOfBirhday
        {
            get => _birthday;
            set
            {
                if (value > DateTime.Today)
                {
                    throw new ArgumentException("Дата рождения не может быть в будущем времени, а была" + value.Date.ToLongDateString());
                }
                else if (value.Year < 1900)
                {
                    throw new ArgumentException("Дата рождения не может быть ранее 1900-го года");
                }
                else
                    _birthday = value;
            }
        }

        /// <summary>
        /// Свойство, возвращающее и задающее номер телефона контакта
        /// </summary>
        public PhoneNumber Phone {
            get => _phone;
            set { _phone = value;}
        }

        /// <summary>
        /// Свойство, возвращающее и задающее e-mail контакта
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
				if (value.Length > 50)
				{
					throw new ArgumentException("E-mail слишком длинный, " +
						"попробуйте придумать E-mail меньше 50-ти символов");
				}
				else
					_email = value;
            }
        }

        /// <summary>
        /// Свойство, возвращающее и задающее идентификатор аккаунта ВКонтакте контакта
        /// </summary>
        public string VkID
        {
            get => _vkID;
            set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentException("ID VK слишком длинный");
                }
                else
                    _vkID = value;
            }
        }

        /// <summary>
        /// Свойство, реализующее интерфейс клонирования
        /// </summary>
        public object Clone()
        {
            Contact cloneContact = new Contact();
            cloneContact.Surname = Surname;
            cloneContact.Name = Name;
            cloneContact.DateOfBirhday = DateOfBirhday;
            cloneContact.Phone.Number = Phone.Number;
            cloneContact.Email = Email;
            cloneContact.VkID = VkID;
            return cloneContact;
        }
    }
}
