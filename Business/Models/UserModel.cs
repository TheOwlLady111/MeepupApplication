namespace Business.Models
{
    public class UserModel : Model<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte RoleId { get; set; }
        public RoleModel Role { get; set; }
    }
}
