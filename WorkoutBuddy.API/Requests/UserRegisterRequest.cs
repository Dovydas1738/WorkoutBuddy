namespace WorkoutBuddy.Api.Requests
{
    public class UserRegisterRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }

        public UserRegisterRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
