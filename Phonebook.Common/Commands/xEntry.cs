using System;

namespace Phonebook.Common.Commands
{
    public class xEntry : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}