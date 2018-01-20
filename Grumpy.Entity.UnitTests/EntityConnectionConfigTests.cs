using FluentAssertions;
using Grumpy.Entity.Interfaces;
using NSubstitute;
using Xunit;

namespace Grumpy.Entity.UnitTests
{
    public class EntityConnectionConfigTests
    {
        private readonly IDatabaseConnectionConfig _databaseConnectionConfig = Substitute.For<IDatabaseConnectionConfig>();

        public EntityConnectionConfigTests()
        {
            _databaseConnectionConfig.ConnectionString.Returns("DummyDatabaseConnectionString");
        }

        [Fact]
        public void CanBuildConnectionStringWithOutEntityDetails()
        {
            var cut = new EntityConnectionConfig(_databaseConnectionConfig);

            cut.ConnectionString().Should().Be("metadata=res://*/Model.csdl|res://*/Model.ssdl|res://*/Model.msl;provider=System.Data.SqlClient;provider connection string=\"DummyDatabaseConnectionString;MultipleActiveResultSets=True;App=EntityFramework\"");
        }

        [Fact]
        public void CanBuildConnectionStringWithEntityDetails()
        {
            var cut = new EntityConnectionConfig(_databaseConnectionConfig);

            cut.ConnectionString("a", "m").Should().Be("metadata=res://a/m.csdl|res://a/m.ssdl|res://a/m.msl;provider=System.Data.SqlClient;provider connection string=\"DummyDatabaseConnectionString;MultipleActiveResultSets=True;App=EntityFramework\"");
        }
    }
}
