﻿using System;

namespace Dit.Lms.Api
{
    public class InvalidDataException : ApplicationException
    {
        public InvalidDataException(string message)
            : base(message)
        {
        }

        public InvalidDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
