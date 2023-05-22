using BicoDemo.Data.Entities;

namespace BicoDemo.Domain.Interface
{
    /// <summary>
    /// Defines the contract for a repository that handles users data.
    /// </summary>
    public interface IUserRepostory
    {
        /// <summary>
        /// Gets all users from the database asynchronously.
        /// </summary>
        /// <returns>A collection of users.</returns>
        Task<IEnumerable<Users>> GetAllUsersAsync();

        /// <summary>
        /// Gets a user by identifier from the database asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the user to get.</param>
        /// <returns>The user with the specified identifier or null if not found.</returns>
        Task<Users> GetUsersByIdAsync(int id);

        /// <summary>
        /// Creates a new user in the database asynchronously.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns>The created user with the assigned identifier.</returns>
        Task<Users> CreateUsersAsync(Users user);

        /// <summary>
        /// Updates a user in the database asynchronously.
        /// </summary>
        /// <param name="user">The user to update.</param>
        Task UpdateUsersAsync(Users user);

        /// <summary>
        /// Deletes a user from the database asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the user to delete.</param>
        Task DeleteUsersAsync(int id);
    }
}
