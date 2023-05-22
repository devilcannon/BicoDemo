using BicoDemo.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace BicoDemo.Data.Context
{
    /// <summary>
    /// Represents a context for accessing the users data.
    /// </summary>
    public class UsersContext
    {
        /// <summary>
        /// The connection string for the database.
        /// </summary>
        private readonly ConnectionString ConnectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersContext"/> class.
        /// </summary>
        /// <param name="optionsMonitor">The options monitor for getting the connection string.</param>
        public UsersContext(IOptionsMonitor<ConnectionString> optionsMonitor)
        {
            ConnectionString = optionsMonitor.CurrentValue;
        }

        /// <summary>
        /// Creates a new connection to the database.
        /// </summary>
        /// <returns>A new <see cref="IDbConnection"/> object.</returns>
        public IDbConnection CreateConnection() => new SqlConnection(ConnectionString.Localhost);
    }
}
