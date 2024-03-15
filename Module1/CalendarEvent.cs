namespace Module1
{
    public enum DaysOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
    internal class CalendarEvent
    {
        public string EventName { get; private set; }
        public DaysOfWeek EventDay { get; private set; }

        public CalendarEvent(string eventName = "N/A", DaysOfWeek eventDay = DaysOfWeek.Sunday)
        {
            EventName = eventName;
            EventDay = eventDay;
        }

        public void PrintEventDetails()
        {
            Console.WriteLine($"Подія {EventName} відбудеться в день {EventDay}");
        }
    }
}
