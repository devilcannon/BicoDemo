namespace BicoDemo.Data.Entities
{
    /// <summary>
    /// Represents a connection string for the database.
    /// </summary>
    public class ConnectionString
    {
        /// <summary>
        /// The position of the connection string in the configuration.
        /// </summary>
        public const string Position = "ConnectionString";

        /// <summary>
        /// Gets or sets the connection string for the localhost database.
        /// </summary>
        public string? Localhost { set; get; }
    }
}
