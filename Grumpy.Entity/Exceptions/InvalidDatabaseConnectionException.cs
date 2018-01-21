using System;
using System.Runtime.Serialization;

namespace Grumpy.Entity.Exceptions
{
    // ReSharper disable once UnusedMember.Global
    [Serializable]
    public sealed class InvalidDatabaseConnectionException : Exception
    {
        private InvalidDatabaseConnectionException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvalidDatabaseConnectionException(string databaseServerName, string databaseName) : base("Invalid Database Connection")
        {
            Data.Add("databaseServerName", databaseServerName);
            Data.Add("databaseName", databaseName);
        }
    }
}