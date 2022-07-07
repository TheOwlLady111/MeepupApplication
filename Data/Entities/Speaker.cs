namespace Data
{
    public class Speaker : Entity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
