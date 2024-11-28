using System.Numerics;

namespace WebService.Constants
{
    public static class MySqlConstants
    {
        public static string CreateUser = "INSERT INTO user_master (user_id,role_id,dept_id,org_id,first_name,last_name,user_name, user_password, is_new_user, email, mobile, location, created_by, created_date, modified_by, modified_date) VALUES (@user_id,@role_id,@dept_id,@org_id,@first_name,@last_name,@user_name, @user_password, @is_new_user, @email, @mobile, @location, @created_by, @created_date, @modified_by, @modified_date)";
        public static string CreateReq = "INSERT INTO req_master (req_id) VALUES (@req_id)";
        public static string CreateVendor = "INSERT INTO vendor_master (vendor_id,vendor_name,loc_id,skill_set) VALUES (@vendor_id,@vendor_name,@loc_id,@skill_set)";
        public static string GetVendorList = "SELECT * FROM vendor_master";
    }
}
