using System.Diagnostics.CodeAnalysis;

namespace Grumpy.Entity.Interfaces
{
    /// <summary>
    /// Entity Framework Connection Configuration
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IEntityConnectionConfig
    {
        /// <summary>
        /// Connection String
        /// </summary>
        /// <returns></returns>
        string ConnectionString();

        /// <summary>
        /// Connection String
        /// </summary>
        /// <param name="entityFrameworkAssembly">Entity Framework Assembly Name</param>
        /// <param name="entityFrameworkModel">Entity Framework Model Name</param>
        /// <returns></returns>
        string ConnectionString(string entityFrameworkAssembly, string entityFrameworkModel);
    }
}