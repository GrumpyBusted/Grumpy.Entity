namespace Grumpy.Entity.Interfaces
{
    public interface IDatabaseConnectionConfig
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string DatabaseServerInstance { get; set; }
        string DatabaseServerName { get; set; }
    }
}