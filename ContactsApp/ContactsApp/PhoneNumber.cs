using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactsApp
{
    /// <summary>
    /// Класс, хранящий в себе информацию о номере телефона
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Поле, хранящее в себе номер телефона
        /// </summary>
        private long _phoneNumber;

        //public PhoneNumber(long inputPhoneNumber)
        //{
        //    _phoneNumber = inputPhoneNumber;
        //}

        public PhoneNumber()
        {
        }

        /// <summary>
        /// /Метод задающий и возвращающий номер телефона
        /// </summary>
        public long Number
        {
            get => _phoneNumber;
            set
            {
                if (value.ToString()[0] != '7')
                {
                    throw new FormatException("Номер телефона должен начинаться с 7, а был с " + value.ToString()[0]);
                }
                else if (value < 9999999999)
                {
                    throw new ArgumentException("Номер телефона должен быть равен 11-ти символам, а был " + value.ToString().Length);
                }
                else  if (value > 99999999999)
                {
                    throw new ArgumentException("Номер телефона должен быть равен 11-ти символам, а был " + value.ToString().Length);
                }
                else
                    _phoneNumber = value;
            }
        }
    }
}
