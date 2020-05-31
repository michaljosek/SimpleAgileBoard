namespace SimpleAgileBoard.Application.Common.Models
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator,
            User
        }
        
        public const string DEFAULT_USERNAME = "user";
        public const string DEFAULT_EMAIL = "user@secureapi.com";
        public const string DEFAUL_PASSWORD = "Pa$$w0rd.";
        public const Roles DEFAULT_ROLE = Roles.User;
    }
}