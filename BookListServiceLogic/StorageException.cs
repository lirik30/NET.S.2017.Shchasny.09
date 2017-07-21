﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookListServiceLogic
{
    public class StorageException : Exception
    {
        public StorageException()
        {
        }

        public StorageException(string message) : base(message)
        {
        }

        public StorageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StorageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
