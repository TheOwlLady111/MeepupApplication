namespace MeetupApp.Response
{
    public class SpeakerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<EventResponseForSpeaker> Events { get; set; }
    }
}
