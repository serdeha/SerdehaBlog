namespace SerdehaBlog.WebUI.Areas.Admin.Dtos.NotificationDto
{
    public class ListNotificationDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? NotificationIcon { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
