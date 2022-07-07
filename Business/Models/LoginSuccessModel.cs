namespace Business.Models
{
    public class LoginSuccessModel : Model<int>
    {
        public string Jwt { get; set; }
    }
}
