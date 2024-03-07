using Microsoft.AspNetCore.Identity;

namespace SerdehaBlog.Entity.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImageUrl { get; set; }

        public List<Article>? Articles { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
