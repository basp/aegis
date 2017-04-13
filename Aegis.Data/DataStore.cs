namespace Aegis.Data
{
    /// <summary>
    /// A <c>DataStore</c> contains vector format spatial data. It can be a file
    /// (such as a shapefile) or a database (such as SQL Server).
    /// </summary>
    public class DataStore
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int WorkspaceId { get; set; }
    }
}
