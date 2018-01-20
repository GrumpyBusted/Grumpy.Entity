using System;

namespace Grumpy.Entity.Exceptions
{
    public sealed class InvalidDatabaseConnectionException : Exception
    {
        public InvalidDatabaseConnectionException(string databaseServerName, string databaseName)
        {
            Data.Add("databaseServerName", databaseServerName);
            Data.Add("databaseName", databaseName);
        }
    }
}