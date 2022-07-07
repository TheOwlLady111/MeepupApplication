namespace Business.Models
{
    public class RoleModel : Model<byte>
    {
        public string Name { get; set; }

        public ICollection<UserModel> Users { get; set; }
    }
}
