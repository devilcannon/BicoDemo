namespace BicoDemo.Data.Entities
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string? Last_name { get; set; }

        /// <summary>
        /// Gets or sets the second last name of the user.
        /// </summary>
        public string? Second_Last_Name { get; set; }

        /// <summary>
        /// Gets or sets the salary of the user.
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// Gets or sets the CURP of the user.
        /// CURP is a unique identity code for both citizens and residents of Mexico.
        /// </summary>
        public string? CURP { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        public string? Phone_Number { get; set; }
    }
}
