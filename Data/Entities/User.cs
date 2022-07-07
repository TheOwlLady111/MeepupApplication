namespace Data
{
    public class User : Entity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte RoleId { get; set; }

        public Role Role { get; set; }
    }
}
