namespace OnlineShop
{
    public static class Helper
    {
        public static string ToShamsi(this DateTime date)
        {
            PersianCalendar calendar = new();
            string convertedDate = $"{calendar.GetYear(date)}/{calendar.GetMonth(date)}/{calendar.GetDayOfMonth(date)}";
            return convertedDate;
        }
        public static string FormatDecimal(this decimal value)
        {
            string result = value.ToString(".##");
            return result;
        }
        public static string FormatDate(this DateTime dt)
        {
            CultureInfo englishCulture = new("en-US");
            string result = dt.ToString("MMMM d, yyyy", englishCulture);
            return result;
        }
    }
}
