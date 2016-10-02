using System;

namespace Dit.Lms.Api
{
    public class DataNotFoundException : ApplicationException
    {
        public DataNotFoundException(string message)
            : base(message)
        {
        }

        public DataNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
