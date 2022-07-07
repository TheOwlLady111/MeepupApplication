namespace Data
{
    public class Role : Entity<byte>
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
