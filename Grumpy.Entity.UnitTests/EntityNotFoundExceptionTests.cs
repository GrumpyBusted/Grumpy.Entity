using Grumpy.Entity.Exceptions;
using Xunit;

namespace Grumpy.Entity.UnitTests
{
    public class EntityNotFoundExceptionTests
    {
        [Fact]
        public void CanThrowEntityNotFoundException()
        {
            try
            {
                throw new EntityNotFoundException(null);
            }
            catch
            {
                // ignored
            }
        }
    }
}