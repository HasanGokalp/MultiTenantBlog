namespace MultiTenantBlog.API.ConfClasses
{
    public class TentantSettings
    {
        public Defaults Defaults { get; set; }
        public List<Tentant> Tentants { get; set; }
    }
}
