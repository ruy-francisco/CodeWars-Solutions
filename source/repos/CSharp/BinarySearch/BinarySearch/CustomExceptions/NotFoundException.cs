using System;

namespace BinarySearch.CustomExceptions
{
    public class ValueNotFoundException: Exception
    {
        public ValueNotFoundException(string message)
            : base(message) { }

        public ValueNotFoundException()
            : base("Value not found!") { }
    }
}
