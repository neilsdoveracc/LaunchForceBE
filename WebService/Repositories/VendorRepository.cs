using MySql.Data.MySqlClient;
using System.Data.Common;
using WebService.configs;
using WebService.Constants;
using WebService.Entities;
using WebService.Interfaces;

namespace WebService.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        public async Task<bool> CreateVendor(VendorDTO vendor)
        {

            //_logger.LogInformation("Start");
            using (MySqlConnection connection = new MySqlConnection(ConfigConstants.MySqlConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    connection.Open();

                    cmd.CommandText = MySqlConstants.CreateVendor;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@vendor_id", vendor.VendorId);
                    cmd.Parameters.AddWithValue("@vendor_name", vendor.VendorName);
                    cmd.Parameters.AddWithValue("@loc_id", vendor.LocationId);
                    cmd.Parameters.AddWithValue("@skill_set", vendor.SkillSet);
                    //_logger.LogInformation("End");
                    return await cmd.ExecuteNonQueryAsync() > 0;

                }
            }

        }

        public async Task<List<VendorDTO>> GetVendorList()
        {
            var vendorList = new List<VendorDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigConstants.MySqlConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    connection.Open();

                    cmd.CommandText = MySqlConstants.GetVendorList;
                    cmd.Connection = connection;
                    //_logger.LogInformation("End");

                    using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                    { 
                         while (reader.Read())
                         {
                            var VendorDto = new VendorDTO()
                            {
                                VendorId = reader[SqlColumns.VendorId].ToString(),
                                VendorName = reader[SqlColumns.VendorName].ToString(),
                                LocationId = Convert.ToInt32( reader[SqlColumns.VendorName]),
                                SkillSet = reader[SqlColumns.VendorName].ToString()
                            };
                            vendorList.Add(VendorDto);
                         }

                         return vendorList;
                    }

                }
            }
        }

       
    }
}
