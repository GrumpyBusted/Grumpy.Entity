using System;
using System.Runtime.Serialization;

namespace Grumpy.Entity.Exceptions
{
    // ReSharper disable once UnusedMember.Global
    /// <inheritdoc />
    [Serializable]
    public sealed class InvalidDatabaseConnectionException : Exception
    {
        private InvalidDatabaseConnectionException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <inheritdoc />
        public InvalidDatabaseConnectionException(string databaseServerName, string databaseName) : base("Invalid Database Connection")
        {
            Data.Add("databaseServerName", databaseServerName);
            Data.Add("databaseName", databaseName);
        }
    }
}