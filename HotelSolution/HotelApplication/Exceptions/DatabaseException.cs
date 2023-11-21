using System.Runtime.Serialization;

namespace HotelApplication.Exceptions
{
    [Serializable]
    public class DatabaseException : Exception
    {
        public DatabaseException() : base("An error occurred while accessing the database.")
        {
        }

        public DatabaseException(string message) : base(message)
        {
        }
    }
}