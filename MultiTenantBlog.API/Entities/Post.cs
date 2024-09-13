using MultiTenantBlog.API.Abstractions.Entity;

namespace MultiTenantBlog.API.Entities
{
    public class Post : BaseEntity, IMustHaveTenant
    {
        public DateTime PublishDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string TenantId { get; set; }
    }
}
