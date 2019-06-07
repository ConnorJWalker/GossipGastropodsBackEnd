namespace GossipGastropodsBackEnd.Helpers
{
    public class EnvironmentSettings
    {
        public DatabaseSettings Database { get; set; }
        public JwtSettings Jwt { get; set; }
        public string DefaultProfilePicture { get; set; }

        public class DatabaseSettings
        {
            public string ConnectionString { get; set; }
        }

        public class JwtSettings
        {
            public string Secret { get; set; }
            public int Expiry { get; set; }
        }
    }
}
