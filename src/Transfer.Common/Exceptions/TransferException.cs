using System;

namespace Transfer.Common.Exceptions
{
    public class TransferException : Exception
    {
        public string Code { get; }

        public TransferException()
        {
        }

        public TransferException(string code)
        {
            Code = code;
        }

        public TransferException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public TransferException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public TransferException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public TransferException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}