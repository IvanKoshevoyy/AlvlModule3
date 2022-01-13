using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts
{
    public static class LinqExtension
    {
        public static void ForEach<T>(this IEnumerable<T> ts, Action<T> action)
        {
            foreach (var item in ts)
            {
                action(item);
            }
        }
    }

    class Program
    {


        static void Main(string[] args)
        {
            char[] russianAlphabet = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
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
            contactsList.AddContact("Tomsk", "0123456789");
            contactsList.AddContact("Tesak", "0123456789");
            contactsList.AddContact("000000", "0123456789");
            contactsList.AddContact("1234", "0123456789");
            contactsList.AddContact("12345", "0123456789");
            contactsList.AddContact("12346", "0123456789");
            contactsList.AddContact("1111", "0127456789");
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

            var ContactGroup = contactsList.ContactGroups.FirstOrDefault(x => Char.IsLetter(x.Name.FirstOrDefault()));

            if (ContactGroup != null)
            {
                Console.WriteLine("Первая буквенная контактная группа: ");
                ContactGroup.PrintGroup();
            }
            else
            {
                Console.WriteLine("В списке нет контактов");
            }

            var Contact = ContactGroup.Contacts.FirstOrDefault();

            if (Contact != null && ContactGroup != null)
            {
                Console.WriteLine("Первый контакт в буквенной группе: ");
                Console.WriteLine(Contact);
            }

            Console.WriteLine("Список всех русских контактов");
            contactsList.ContactGroups.Where(x => russianAlphabet.Contains(x.Name.FirstOrDefault())).ForEach((x) => x.PrintGroup());


            Console.WriteLine("\nКоличество контактов в группе");
            contactsList.ContactGroups.Select(x => new { x.Name, x.Contacts.Count }).ForEach(x => Console.WriteLine(x.Name + "\n" + "Количество контактов: " + x.Count));

            Console.WriteLine("\nУпорядоченные группы за возростанием количества контактов");
            contactsList.ContactGroups.OrderBy(x => x.Contacts.Count).ForEach(x => x.PrintGroup());

            /*var ContactGroup1 =*/
            var ContactGroup1 = contactsList.ContactGroups.FirstOrDefault(x => x.Name == "0-9").Contacts.GroupBy(x => x.TelephoneNumber);

            Console.WriteLine("\nГруппировка по номеру телефона в числовой группе");
            foreach (var item in ContactGroup1)
            {
                Console.WriteLine("Номер телефона: " + item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine(i.Name);
                }
            }


            bool check = contactsList.ContactGroups.Any(x => x.Name == "А");

            if (check == true)
            {
                Console.WriteLine("\nВ списке групп есть группа А");
            }
            else
            {
                Console.WriteLine("\nВ списке групп нет группы А");
            }

            Console.ReadLine();



        }
    }
}
