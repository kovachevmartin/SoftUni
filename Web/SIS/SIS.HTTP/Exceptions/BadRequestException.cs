﻿namespace SIS.HTTP.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        private const string DefaultMessage = "The Request was malformed or contains unsupported elements.";
        public BadRequestException() : this(DefaultMessage)
        {
            
        }

        public BadRequestException(string name) : base(name)
        {

        }
    }
}
