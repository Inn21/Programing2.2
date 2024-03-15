//Створіть перелік(enum) DaysOfWeek, який містить назви днів тижня.

//Далі створіть клас CalendarEvent, який представляє подію у календарі і має наступні властивості:
//      EventName(назва події)
//      EventDay(день події з переліку DaysOfWeek)
//      Створіть конструктор для класу CalendarEvent, що дозволяє встановити назву події та день.
//      Напишіть метод PrintEventDetails(), який виводить інформацію про подію на консоль у форматі: "Подія EventName відбудеться в день EventDay".

//Створіть об'єкт класу CalendarEvent, встановіть йому значення та виведіть інформацію про подію на консоль.

using Module1;
public class Program
{
    static void Main(string[] args)
    {
        CalendarEvent ev = new CalendarEvent("Module", DaysOfWeek.Friday);
        ev.PrintEventDetails();
    }
}