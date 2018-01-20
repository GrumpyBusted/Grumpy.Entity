using FluentAssertions;
using Xunit;

namespace Grumpy.Entity.UnitTests
{
    public class EntityConnectionConfigBuilderTests
    {
        [Fact]
        public void ShouldBuildEntityConnectionConfig()
        {
            var cut = EntityConnectionConfigBuilder.Get("", "");

            cut.Should().NotBe(null);
            cut.GetType().Should().Be<EntityConnectionConfig>();
        }
    }
}