using Phonebook.Common.Exceptions;
using System;

namespace Phonebook.Services.Entry.Domain.Models
{
    public class xEntry
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string PhoneNumber { get; protected set; }

        protected xEntry() { }
        public xEntry(Guid id, string name, string phoneNumber)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new PhonebookException("empty_name", $"Name cannot be empty.");
            }

            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new PhonebookException("empty_number", $"Phone number cannot be empty.");
            }

            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
