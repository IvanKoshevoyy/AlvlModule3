using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Contacts
{
    public class Contact : IComparable<Contact>
    {
        public string Name { get; set; }

        public string TelephoneNumber { get; set; }

        public int CompareTo([AllowNull] Contact other)
        {
            if (other != null)
            {
                return Name.CompareTo(other.Name);
            }

            throw new InvalidOperationException();
        }
    }
}
