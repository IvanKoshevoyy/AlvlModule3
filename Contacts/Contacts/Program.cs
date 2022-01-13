using System;
using System.Collections.Generic;

namespace Contacts
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactsList contactsList = new ContactsList();
            string Name;
            string Phone;

            Console.WriteLine("Текущее содержимое абонентской книги");

            contactsList.AddContact("Альошин Д", "0123456789");
            contactsList.AddContact("Булах И", "0123456789");
            contactsList.AddContact("Бобров В", "0123456789");
            contactsList.AddContact("Волков Г", "0123456789");
            contactsList.AddContact("Герзанич Р", "0123456789");
            contactsList.AddContact("_tt%$", "0123456789");
            contactsList.AddContact("Test", "0123456789");
            contactsList.AddContact("000000", "0123456789");
            contactsList.AddContact("1234", "0123456789");
            contactsList.PrintContact();

            while (true)
            {
                Console.Write("Хотите добавить еще один контакт(0 - Да, Остальные символы - Нет): ");
                if (Console.ReadLine() != "0")
                {
                    break;
                }
                Console.Write("Имя: ");
                Name = Console.ReadLine();
                Console.Write("Номер телефона: ");
                Phone = Console.ReadLine();
                contactsList.AddContact(Name, Phone);
                contactsList.PrintContact();
            }
        }
    }
}
