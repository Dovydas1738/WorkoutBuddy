namespace WorkoutBuddy.Api.Requests
{
    public class UserLoginRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }

        public UserLoginRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
