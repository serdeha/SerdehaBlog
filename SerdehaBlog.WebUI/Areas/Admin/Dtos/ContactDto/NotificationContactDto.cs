namespace SerdehaBlog.WebUI.Areas.Admin.Dtos.ContactDto
{
    public class NotificationContactDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MessageText { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
