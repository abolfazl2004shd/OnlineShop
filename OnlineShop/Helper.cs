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
    }
}
