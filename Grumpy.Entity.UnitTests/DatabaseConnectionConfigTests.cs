using System.Data.SqlClient;
using FluentAssertions;
using Grumpy.Entity.Exceptions;
using Xunit;

// ReSharper disable StringLiteralTypo

namespace Grumpy.Entity.UnitTests
{
    public class DatabaseConnectionConfigTests
    {
        [Fact]
        public void DatabaseNotSetShouldThrowException()
        {
            var cut = new DatabaseConnectionConfig();

            Assert.Throws<InvalidDatabaseConnectionException>(() => cut.ConnectionString);
        }

        [Fact]
        public void ShouldBuildConnectionString()
        {
            var cut = new DatabaseConnectionConfig("(localdb)", "MSSQLLocalDB", "TestDatabase");

            cut.ConnectionString.Should().Be(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDatabase;Integrated Security=True");
        }

        [Fact]
        public void CanConstructWithServerAndDatabase()
        {
            var cut = new DatabaseConnectionConfig("(localdb)\\MSSQLLocalDB", "TestDatabase");

            cut.ConnectionString.Should().Be(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDatabase;Integrated Security=True");
        }

        [Fact]
        public void ShouldParseConnectionString()
        {
            var cut = new DatabaseConnectionConfig(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDatabase;Integrated Security=True");

            cut.DatabaseServerName.Should().Be("(localdb)");
            cut.DatabaseServerInstance.Should().Be("MSSQLLocalDB");
            cut.DatabaseName.Should().Be("TestDatabase");
        }

        [Fact]
        public void CanConstructWithSqlConnectionStringBuilder()
        {
            var cut = new DatabaseConnectionConfig(new SqlConnectionStringBuilder(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDatabase;Integrated Security=True"));

            cut.DatabaseServerName.Should().Be("(localdb)");
            cut.DatabaseServerInstance.Should().Be("MSSQLLocalDB");
            cut.DatabaseName.Should().Be("TestDatabase");
        }
    }
}
