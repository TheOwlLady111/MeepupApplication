namespace Business.Models
{
    public class EventModel : Model<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public string Organizer { get; set; }
        public string Place { get; set; }
        public DateTime DateOfEvent { get; set; }

        public ICollection<SpeakerModel> Speakers { get; set; }
    }
}
