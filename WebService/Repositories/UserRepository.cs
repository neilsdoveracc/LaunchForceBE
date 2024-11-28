using System.Data.Common;
using WebService.Entities;
using WebService.Interfaces;
using MySql.Data.MySqlClient;
using WebService.configs;
using WebService.Constants;

namespace WebService.Repositories
{
    public class UserRepository : IUserRepository
    {
        //private readonly ILogger _logger;
        public UserRepository()
        {
            //_logger = logger;
        }
        public async Task<bool> CreateUser(UserDTO user)
        {
           
            //_logger.LogInformation("Start");
            using (MySqlConnection connection = new MySqlConnection (ConfigConstants.MySqlConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    connection.Open();
                    
                    cmd.CommandText = MySqlConstants.CreateUser;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@user_id", user.UserId);
                    cmd.Parameters.AddWithValue("@role_id", user.RoleId);
                    cmd.Parameters.AddWithValue("@dept_id", user.DepId);
                    cmd.Parameters.AddWithValue("@org_id", user.OrgId);
                    cmd.Parameters.AddWithValue("@first_name", user.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", user.LastName);
                    cmd.Parameters.AddWithValue("@user_name", user.UserName);
                    cmd.Parameters.AddWithValue("@user_password", user.Password);
                    cmd.Parameters.AddWithValue("@is_new_user", user.IsNewUser);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@mobile", user.Mobile);
                    cmd.Parameters.AddWithValue("@location", user.Location);
                    cmd.Parameters.AddWithValue("@created_by", user.CreatedBy);
                    cmd.Parameters.AddWithValue("@created_date", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@modified_by", user.ModifiedBy);
                    cmd.Parameters.AddWithValue("@modified_date", user.ModifiedDate);

                    //_logger.LogInformation("End");
                    return await cmd.ExecuteNonQueryAsync() > 0;
                        
                }
            }
            
        }
    }
}
