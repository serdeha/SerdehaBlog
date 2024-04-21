namespace SerdehaBlog.WebUI.Areas.Admin.Dtos.ContactDto
{
    public class ListContactDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRead { get; set; }
    }
}
