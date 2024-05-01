namespace CollectiveMomentsServer.DTO_Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Username { get; set; }
        public string? Passwrd { get; set; }
        public string? Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string ProfilePicture { get; set; }  
    }
}
