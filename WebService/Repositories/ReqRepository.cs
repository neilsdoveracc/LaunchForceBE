using MySql.Data.MySqlClient;
using WebService.configs;
using WebService.Constants;
using WebService.Entities;
using WebService.Interfaces;

namespace WebService.Repositories
{
    public class ReqRepository : IReqRepository
    {
        public async Task<bool> CreateReq(ReqDTO req)
        {
            //_logger.LogInformation("Start");
            using (MySqlConnection connection = new MySqlConnection(ConfigConstants.MySqlConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    connection.Open();

                    cmd.CommandText = MySqlConstants.CreateReq;
                    cmd.Connection = connection;
                    

                    //_logger.LogInformation("End");
                    return await cmd.ExecuteNonQueryAsync() > 0;

                }
            }
        }
    }
}
