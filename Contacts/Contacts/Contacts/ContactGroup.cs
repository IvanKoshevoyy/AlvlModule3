using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Contacts
{
    public class ContactGroup : IComparable<ContactGroup>
    {
        public ContactGroup(string name, Contact contact = null)
        {
            Name = name;
            Contacts = contact != null
                ? new SortedSet<Contact>() { contact }
                : new SortedSet<Contact>();
        }

        public string Name { get; set; }

        public SortedSet<Contact> Contacts { get; set; }

        public int CompareTo([AllowNull] ContactGroup other)
        {
            if (other != null)
            {
                return Name.CompareTo(other.Name);
            }

            throw new InvalidOperationException();
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void PrintGroup()
        {
            Console.WriteLine(Name);
            foreach (var contact in Contacts)
            {
                Console.Write(contact);
            }
        }
       
    }
}
