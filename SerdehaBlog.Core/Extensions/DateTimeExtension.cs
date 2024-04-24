namespace SerdehaBlog.Core.Extensions
{
    public static class DateTimeExtension
    {
        public static string AsTimeAgo(this DateTime dateTime)
        {
            TimeSpan timeSpan = DateTime.Now.Subtract(dateTime);

            return timeSpan.TotalSeconds switch
            {
                <= 60 => $"{timeSpan.Seconds} saniye önce",

                _ => timeSpan.TotalMinutes switch
                {
                    <= 1 => "yaklaşık bir dakika önce",
                    < 60 => $"yaklaşık {timeSpan.Minutes} dakika önce",
                    _ => timeSpan.TotalHours switch
                    {
                        <= 1 => "yaklaşık bir saat önce",
                        < 24 => $"yaklaşık {timeSpan.Hours} saat önce",
                        _ => timeSpan.TotalDays switch
                        {
                            <= 1 => "dün",
                            <= 30 => $"yaklaşık {timeSpan.Days} gün önce",

                            <= 60 => "yaklaşık bir ay önce",
                            < 365 => $"yaklaşık {timeSpan.Days / 30} ay önce",

                            <= 365 * 2 => "yaklaşık bir yıl önce",
                            _ => $"yaklaşık {timeSpan.Days / 365} yıl önce"
                        }
                    }
                }
            };
        }
    }
}
