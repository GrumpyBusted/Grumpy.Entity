using Grumpy.Entity.Interfaces;

namespace Grumpy.Entity
{
    public class EntityConnectionConfig : IEntityConnectionConfig
    {
        private readonly IDatabaseConnectionConfig _databaseConnectionConfig;

        public EntityConnectionConfig(IDatabaseConnectionConfig databaseConnectionConfig)
        {
            _databaseConnectionConfig = databaseConnectionConfig;
        }

        public string ConnectionString()
        {
            return ConnectionString("*", "Model");
        }

        public string ConnectionString(string entityFrameworkAssembly, string entityFrameworkModel)
        {
            return $"metadata=res://{entityFrameworkAssembly}/{entityFrameworkModel}.csdl|res://{entityFrameworkAssembly}/{entityFrameworkModel}.ssdl|res://{entityFrameworkAssembly}/{entityFrameworkModel}.msl;provider=System.Data.SqlClient;provider connection string=\"{_databaseConnectionConfig.ConnectionString};MultipleActiveResultSets=True;App=EntityFramework\"";
        }
    }
}