namespace Dit.Lms.Api
{
    public class User : DreamData
    {
        public User()
        {
            Name = string.Empty;
        }

        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
