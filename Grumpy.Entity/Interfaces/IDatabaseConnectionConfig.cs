using System.Diagnostics.CodeAnalysis;

namespace Grumpy.Entity.Interfaces
{
    /// <summary>
    /// Database Connection Configuration
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IDatabaseConnectionConfig
    {
        /// <summary>
        /// Connection String
        /// </summary>
        string ConnectionString { get; set; }
        
        /// <summary>
        /// Database Name
        /// </summary>
        string DatabaseName { get; set; }
        
        /// <summary>
        /// Database Server Instance
        /// </summary>
        string DatabaseServerInstance { get; set; }

        /// <summary>
        /// Database Server Name
        /// </summary>
        string DatabaseServerName { get; set; }
    }
}