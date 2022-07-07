namespace Business.Models
{
    public class SpeakerModel : Model<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<EventModel> Events { get; set; }
    }
}
