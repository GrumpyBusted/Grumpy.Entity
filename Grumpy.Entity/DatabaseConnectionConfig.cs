using System;
using System.Data.SqlClient;
using System.Linq;
using Grumpy.Common.Extensions;
using Grumpy.Entity.Exceptions;
using Grumpy.Entity.Interfaces;

namespace Grumpy.Entity
{
    /// <inheritdoc />
    public class DatabaseConnectionConfig : IDatabaseConnectionConfig
    {
        /// <inheritdoc />
        public string ConnectionString
        {
            get
            {
                if (DatabaseServerName.NullOrEmpty() || DatabaseName.NullOrEmpty())
                    throw new InvalidDatabaseConnectionException(DatabaseServerName, DatabaseName);

                var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
                {
                    InitialCatalog = DatabaseName,
                    DataSource = $"{DatabaseServerName}" + (DatabaseServerInstance.NullOrEmpty() ? "" : $@"\{DatabaseServerInstance}"),
                    IntegratedSecurity = true
                };

                return sqlConnectionStringBuilder.ConnectionString;
            }
            set => Initialize(new SqlConnectionStringBuilder(value));
        }

        /// <inheritdoc />
        public string DatabaseServerName { get; set; } = "";

        /// <inheritdoc />
        public string DatabaseServerInstance { get; set; } = "";

        /// <inheritdoc />
        public string DatabaseName { get; set; } = "";

        /// <inheritdoc />
        public DatabaseConnectionConfig()
        {
        }

        /// <inheritdoc />
        public DatabaseConnectionConfig(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            Initialize(sqlConnectionStringBuilder);
        }

        /// <inheritdoc />
        public DatabaseConnectionConfig(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <inheritdoc />
        public DatabaseConnectionConfig(string dataSource, string databaseName)
        {
            SplitDataSource(dataSource);

            DatabaseName = databaseName;
        }

        /// <inheritdoc />
        public DatabaseConnectionConfig(string databaseServerName, string databaseServerInstance, string databaseName)
        {
            DatabaseServerName = databaseServerName;
            DatabaseServerInstance = databaseServerInstance;
            DatabaseName = databaseName;
        }

        private void SplitDataSource(string dataSource)
        {
            var dataSourceParts = dataSource.Split('\\').Where(s => !s.NullOrEmpty()).ToList();

            DatabaseServerName = dataSourceParts.Count > 0 ? dataSourceParts[0] : "";
            DatabaseServerInstance = dataSourceParts.Count > 1 ? dataSourceParts[1] : "";

            if (dataSourceParts.Count > 2)
                throw new ArgumentException("DataSource");
        }

        private void Initialize(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            SplitDataSource(sqlConnectionStringBuilder.DataSource);

            DatabaseName = sqlConnectionStringBuilder.InitialCatalog;
        }
    }
}
