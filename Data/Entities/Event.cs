namespace Data
{
    public class Event : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public string Organizer { get; set; }
        public string Place { get; set; }
        public DateTime DateOfEvent { get; set; }

        public ICollection<Speaker> Speakers { get; set; }
    }
}
