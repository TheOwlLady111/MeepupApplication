namespace Data.IRepositories
{
    public interface ISpeakerRepository : IBaseRepository<Speaker, int>
    {
        Task<Speaker> GetByNameAndSurname(string name, string surname);
    }
}
