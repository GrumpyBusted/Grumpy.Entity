using System.Diagnostics.CodeAnalysis;

namespace Grumpy.Entity.Interfaces
{
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IEntityConnectionConfig
    {
        string ConnectionString();
        string ConnectionString(string entityFrameworkAssembly, string entityFrameworkModel);
    }
}