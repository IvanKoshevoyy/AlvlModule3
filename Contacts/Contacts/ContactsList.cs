using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts
{
    public class ContactsList
    {
        private char[] englishAlphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private char[] russianAlphabet = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'};
        private char UnknownContactGroup = '#';
        private char[] NumericContactGroup = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        SortedSet<ContactGroup> ContactGroups { get; set; }

        public ContactsList(/*char[] alphabet*/)
        {
            /*_alphabet = alphabet;*/
            ContactGroups = new SortedSet<ContactGroup>();
        }

        public void AddContact(string name, string telephoneNumber)
        {
            var contact = new Contact
            {
                Name = name,
                TelephoneNumber = telephoneNumber
            };
            string UpperName = name.ToUpper();
            var firstSymbol = UpperName[0];
           
            if (Char.IsDigit(firstSymbol))
            {
                ContactGroup numericContactGroup = null;
                foreach (var contactGroup in ContactGroups)
                {
                    if (contactGroup.Name == "0-9")
                    {
                        numericContactGroup = contactGroup;
                        break;
                    }
                }

                if (numericContactGroup != null)
                {
                    numericContactGroup.AddContact(contact);
                }
                else
                {
                    ContactGroups.Add(new ContactGroup("0-9", contact));
                }
            }

            else if (englishAlphabet.Contains(firstSymbol) == true)
            {
                ContactGroup englishContactGroup = null;
                foreach (var contactGroup in ContactGroups)
                {
                    if (contactGroup.Name == firstSymbol.ToString())
                    {
                        englishContactGroup = contactGroup;
                        break;
                    }
                }

                if (englishContactGroup != null)
                {
                    englishContactGroup.AddContact(contact);
                }
                else
                {
                    ContactGroups.Add(new ContactGroup(firstSymbol.ToString(), contact));
                }
            }


            else if (russianAlphabet.Contains(firstSymbol) == true)
            {
                ContactGroup russianContactGroup = null;
                foreach (var contactGroup in ContactGroups)
                {
                    if (contactGroup.Name == firstSymbol.ToString())
                    {
                        russianContactGroup = contactGroup;
                        break;
                    }
                }

                if (russianContactGroup != null)
                {
                    russianContactGroup.AddContact(contact);
                }
                else
                {
                    ContactGroups.Add(new ContactGroup(firstSymbol.ToString(), contact));
                }
            }

            else
            {
                ContactGroup unknownContactGroup = null;
                foreach (var contactGroup in ContactGroups)
                {
                    if (contactGroup.Name == UnknownContactGroup.ToString())
                    {
                        unknownContactGroup = contactGroup;
                        break;
                    }
                }

                if (unknownContactGroup != null)
                {
                    unknownContactGroup.AddContact(contact);
                }
                else
                {
                    ContactGroups.Add(new ContactGroup('#'.ToString(), contact));
                }
            }
        }

        public void PrintContact()
        {
            foreach (var contactGroup in ContactGroups)
            {
                Console.WriteLine(contactGroup.Name);
                foreach (var contact in contactGroup.Contacts)
                {
                    Console.Write(contact.Name + "  " + contact.TelephoneNumber + "\n");
                }
            }
        }    
    }
}
