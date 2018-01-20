using Grumpy.Entity.Interfaces;

namespace Grumpy.Entity
{
    public static class EntityConnectionConfigBuilder
    {
        public static IEntityConnectionConfig Get(string dataSource, string databaseName)
        {
            return new EntityConnectionConfig(new DatabaseConnectionConfig(dataSource, databaseName));
        }
    }
}