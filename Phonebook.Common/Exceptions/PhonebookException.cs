using System;

namespace Phonebook.Common.Exceptions
{
    public class PhonebookException : Exception
    {
        public string Code { get; }
        public PhonebookException()
        {
        }
        public PhonebookException(string code)
        {
            Code = code;
        }
        public PhonebookException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }
        public PhonebookException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }
        public PhonebookException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }
        public PhonebookException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
