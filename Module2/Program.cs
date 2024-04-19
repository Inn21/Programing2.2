//Розробка системи управління книгами у бібліотеці
//    Ваша програма повинна містити наступні елементи:

//    Створення інтерфейсу ILibraryItem, який містить методи для видачі книги, повернення книги та перевірки стану книги.

//    Створення класу Book, який реалізує інтерфейс ILibraryItem та містить інформацію про книгу (наприклад, назва, автор, рік видання тощо).

//    Побудова ієрархії класів для користувачів бібліотеки: базовий клас LibraryUser, який містить загальні властивості, та похідні класи, наприклад, Student, Teacher тощо.

//    Використання конструкторів для ініціалізації об'єктів класів та деструкторів для звільнення ресурсів.

//    Синхронний виклик методів через делегат для видачі та повернення книг.

//    Визначення події для сповіщення про зміну статусу книги та організація взаємодії об'єктів через цю подію.

//    Розробка класу винятків для обробки помилок у випадку виникнення проблем під час видачі або повернення книги.


using Module2;
using System.Text;

class Program
{

    public delegate void Remainder(Book book);
    public static event Remainder RemaindAll;

    public static void BookStateRemainder(Book book,bool state)
    {
        Console.WriteLine($"{book} is free : {state}");
    }
    
    public static void Main(string[] args)
    {

        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;


        Book b1 = new Book("A1", "B1", 100);
        Book b2 = new Book("A1", "B2", 104);
        Book b3 = new Book("A4", "B3", 120);
        Book b4 = new Book("A2", "B4", 150);
        Book b5 = new Book("A3", "B5", 210);

        LibraryUser user1 = new Student("Bohdan", 11);
        LibraryUser user2 = new Teacher("Orest", "Programming");

        RemaindAll += user1.Reminde;
        RemaindAll += user2.Reminde;

        b1.ChangeState += BookStateRemainder;
        b2.ChangeState += BookStateRemainder;
        b3.ChangeState += BookStateRemainder;
        b4.ChangeState += BookStateRemainder;
        b5.ChangeState += BookStateRemainder;


        Console.WriteLine(user1);
        Console.WriteLine(user2);

        try
        {
            user1.GetBook(b1);
            user1.GetBook(b2);
            user1.GetBook(b3);
            user2.GetBook(b1);
            user2.GetBook(b4);
            user2.GetBook(b5);

        }
        catch(BookIsNotFreeException ex)
        {
            Console.WriteLine(ex.Message);
            RemaindAll?.Invoke(b1);
        }

        Console.WriteLine(user1);
        Console.WriteLine(user2);

        try
        {
            user1.Return(b1);
            user1.Return(b2);
            user1.Return(b3);
            user2.Return(b1);
            user2.Return(b4);
            user2.Return(b5);

        }
        catch (BookIsLostException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}