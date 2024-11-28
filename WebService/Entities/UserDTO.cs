namespace WebService.Entities
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string OrgId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int Location { get; set; }
        public bool IsNewUser{ get; set; }
        public int RoleId{ get; set; }
        public int DepId{ get; set; }
        public string Email{ get; set; }
        public string Mobile{ get; set; }
        public string Password{ get; set; }
        public string CreatedBy{ get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy{ get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
