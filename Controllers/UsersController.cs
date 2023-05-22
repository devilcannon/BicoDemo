using BicoDemo.Data.Entities;
using BicoDemo.Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BicoDemo.Controllers
{
    /// <summary>
    /// A controller class for handling requests related to users.
    /// </summary>
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepostory _userRepostory;
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userRepostory">The user repository to use.</param>
        public UsersController(IUserRepostory userRepostory)
        {
            _userRepostory = userRepostory;
        }

        /// <summary>
        /// Gets all users asynchronously.
        /// </summary>
        /// <returns>A list of users.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userRepostory.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Gets a user by id asynchronously.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The user with the specified id.</returns>
        [HttpGet("{id}", Name = "userById")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _userRepostory.GetUsersByIdAsync(id);
            return Ok(user);
        }

        /// <summary>
        /// Creates a new user asynchronously.
        /// </summary>
        /// <param name="users">The user to create.</param>
        /// <returns>The created user.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(Users users)
        {
            try
            {
                var user = await this._userRepostory.CreateUsersAsync(users);
                return CreatedAtRoute("UserById", new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a user by id asynchronously.
        /// </summary>
        /// <param name="id">The id of the user to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userRepostory.DeleteUsersAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates a user by id asynchronously.
        /// </summary>
        /// <param name="id">The id of the user to update.</param>
        /// <param name="users">The updated user information.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsers(int id, Users users)
        {
            try
            {
                var user = await _userRepostory.GetUsersByIdAsync(id);
                if (user == null)
                    return NotFound();
                await _userRepostory.UpdateUsersAsync(users);
                return NoContent();
            }
            catch (SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
