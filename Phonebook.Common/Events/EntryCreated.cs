using System;

namespace Phonebook.Common.Events
{
    public class EntryCreated : IEvent
    {
        public Guid Id { get; }
        public string Name { get; }
        public string PhoneNumber { get; }

        protected EntryCreated() { }
        public EntryCreated(Guid id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
