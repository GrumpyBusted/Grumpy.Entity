using Grumpy.Entity.Interfaces;

namespace Grumpy.Entity
{
    /// <summary>
    /// Builder for Entity Framework Connection Configuration
    /// </summary>
    public static class EntityConnectionConfigBuilder
    {
        /// <summary>
        /// Build Entity Framework Configuration
        /// </summary>
        /// <param name="dataSource">Database Source (Server and Instance)</param>
        /// <param name="databaseName">Database Name</param>
        /// <returns>Entity Framework Connection Configuration</returns>
        public static IEntityConnectionConfig Build(string dataSource, string databaseName)
        {
            return new EntityConnectionConfig(new DatabaseConnectionConfig(dataSource, databaseName));
        }
    }
}