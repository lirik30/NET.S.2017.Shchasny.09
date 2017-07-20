using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookListServiceLogic
{
    class StorageCreateException : Exception
    {
        public StorageCreateException()
        {
        }

        public StorageCreateException(string message) : base(message)
        {
        }

        public StorageCreateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StorageCreateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
