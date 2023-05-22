using BicoDemo.Data.Context;
using BicoDemo.Data.Entities;
using BicoDemo.Domain.Interface;
using Dapper;

namespace BicoDemo.Data.Repository
{
    /// <summary>
    /// Represents a repository for accessing and manipulating the users data.
    /// </summary>
    public class UsersRepository : IUserRepostory
    {
        /// <summary>
        /// The context for creating database connections.
        /// </summary>
        private readonly UsersContext _usersContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersRepository"/> class.
        /// </summary>
        /// <param name="usersContext">The context for creating database connections.</param>
        public UsersRepository(UsersContext usersContext)
        {
            _usersContext = usersContext;
        }

        /// <summary>
        /// Creates a new user in the database asynchronously.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns>The created user with the assigned identifier.</returns>
        async Task<Users> IUserRepostory.CreateUsersAsync(Users user)
        {
            var procedure = "CreateUser";
            var parameters = new DynamicParameters();
            parameters.Add("name", user.Name, System.Data.DbType.String);
            parameters.Add("last_name", user.Last_name, System.Data.DbType.String);
            parameters.Add("second_last_name", user.Second_Last_Name, System.Data.DbType.String);
            parameters.Add("salary", user.Salary, System.Data.DbType.Decimal);
            parameters.Add("CURP", user.CURP, System.Data.DbType.String);
            parameters.Add("phone_number", user.Phone_Number, System.Data.DbType.String);
            using var con = _usersContext.CreateConnection();
            var id = await con.ExecuteScalarAsync<int>(procedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
            user.Id = id;
            return user;
        }

        /// <summary>
        /// Deletes a user from the database asynchronously.
        /// </summary>
        /// <param name="idValue">The identifier of the user to delete.</param>
        async Task IUserRepostory.DeleteUsersAsync(int idValue)
        {
            var procedure = "DeleteUser";
            var values = new { id = idValue };
            using var con = _usersContext.CreateConnection();
            await con.QueryAsync(procedure, values, commandType: System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// Gets all users from the database asynchronously.
        /// </summary>
        /// <returns>A collection of users.</returns>
        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            var procedure = "ReadAllUsers";
            using var con = _usersContext.CreateConnection();
            var users = await con.QueryAsync<Users>(procedure, null, commandType: System.Data.CommandType.StoredProcedure);
            return users.ToList();
        }

        /// <summary>
        /// Gets a user by identifier from the database asynchronously.
        /// </summary>
        /// <param name="idValue">The identifier of the user to get.</param>
        /// <returns>The user with the specified identifier or null if not found.</returns>
        async Task<Users> IUserRepostory.GetUsersByIdAsync(int idValue)
        {
            var procedure = "ReadUser";
            var values = new { id = idValue };
            using var con = _usersContext.CreateConnection();
            var user = await con.QueryFirstOrDefaultAsync<Users>(procedure, values, commandType: System.Data.CommandType.StoredProcedure);
            return user;
        }

        /// <summary>
        /// Updates a user in the database asynchronously.
        /// </summary>
        /// <param name="user">The user to update.</param>
        async Task IUserRepostory.UpdateUsersAsync(Users user)
        {
            var procedure = "UpdateUser";
            var parameters = new DynamicParameters();
            parameters.Add("id", user.Id, System.Data.DbType.Int32);
            parameters.Add("name", user.Name, System.Data.DbType.String);
            parameters.Add("last_name", user.Last_name, System.Data.DbType.String);
            parameters.Add("second_last_name", user.Second_Last_Name, System.Data.DbType.String);
            parameters.Add("salary", user.Salary, System.Data.DbType.Decimal);
            parameters.Add("CURP", user.CURP, System.Data.DbType.String);
            parameters.Add("phone_number", user.Phone_Number, System.Data.DbType.String);
            using var con = _usersContext.CreateConnection();
            await con.ExecuteAsync(procedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
