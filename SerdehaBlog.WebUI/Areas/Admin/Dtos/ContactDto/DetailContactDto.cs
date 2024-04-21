namespace SerdehaBlog.WebUI.Areas.Admin.Dtos.ContactDto
{
    public class DetailContactDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Text { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
