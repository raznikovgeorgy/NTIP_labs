using System;
using System.Collections.Generic;


namespace ContactsApp
{
    /// <summary>
    /// Класс проекта, создающий список контактов
    /// </summary>
    public class Project
    {
        public List<Contact> Contacts = new List<Contact>();

        /// <summary>
        /// Метод сортировки списка контактов по фамилиям по алфавиту
        /// </summary>
        /// <param name="contactsList">Список, который нужно отсортировать</param>
        /// <returns>Возвращает отсортированный список по фамилиям по алфавиту</returns>
        public List<Contact> SortContacts(List<Contact> contactsList)
        {
            contactsList.Sort(delegate (Contact x, Contact y)
            {
                if (x.Surname == null && y.Surname == null) return 0;
                if (x.Surname == null) return -1;
                if (y.Surname == null) return 1;
                return x.Surname.CompareTo(y.Surname);
            });

            return contactsList;
        }

        /// <summary>
        /// Метод сортировки по подстроке
        /// </summary>
        /// <param name="contactsList">Список, который нужно отсортировать</param>
        /// <param name="substring">Подстрока, по которой производится сортировка</param>
        /// <returns>Возвращает отсортированный список по алфавиту</returns>
        public List<Contact> SortContacts(List<Contact> contactsList, string substring)
        {
            List<Contact> findedContacts = new List<Contact>();
            foreach (var contact in contactsList)
            {
                if (contact.Surname.StartsWith(substring) ||
                    contact.Name.StartsWith(substring) ||
                    contact.Phone.Number.ToString().StartsWith(substring))
                {
                    findedContacts.Add(contact);
                }
            }
            return findedContacts;
        }

        /// <summary>
        /// Метод, отвечающий за показ именинников в BirthdayPannel
        /// </summary>
        /// <param name="date">На вход подаётся текущая дата</param>
        /// <returns>Возвращает список контактов, у которых день и месяц рождения совпадают с текущим днём и месяцем</returns>
        public List<Contact> ShowBirthdayList(DateTime date)
        {
            List<Contact> birthdayContacts = new List<Contact>();
            foreach (var contact in Contacts)
            {
                if (contact.DateOfBirhday.Day == date.Day && contact.DateOfBirhday.Month == date.Month)
                {
                    birthdayContacts.Add(contact);
                }
            }

            return birthdayContacts;
        }
    }
}
