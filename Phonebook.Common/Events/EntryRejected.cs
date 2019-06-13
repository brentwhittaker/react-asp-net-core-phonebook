using System;

namespace Phonebook.Common.Events
{
    public class EntryRejected : IRejectedEvent
    {
        public Guid Id { get; set; }
        public string Reason { get; }
        public string Code { get; }

        protected EntryRejected() { }

        public EntryRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}
