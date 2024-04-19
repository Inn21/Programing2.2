using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{
    public class BookIsNotFreeException : Exception
    {
        public BookIsNotFreeException(string BookName) :
            base($"Нелжливо видати книгу '{BookName}', бо вона вже зайнята") { }
        
    }
    public class BookIsLostException : Exception
    {
        public BookIsLostException(string BookName) :
            base($"Нелжливо повернути книгу '{BookName}', бо її немає в читача") { }
        
    }

    internal class LibraryUser
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

        public LibraryUser(string name) 
        {
            Name = name;
        }

        public override string ToString()
        {
            string res = $"Ім'я : {Name}\n Книги:\n";
            foreach (var book in Books)
            {
                res += "\n"+book.ToString() ;
            }
            return res;
        }

        public void GetBook(Book book)
        {
            if (book.isFree())
            {
                book.Give();
                Books.Add(book);
            }
            else
            {
                throw new BookIsNotFreeException(book.Title);
            }
        }
        public void Return(Book book)
        {
            if (Books.Contains(book))
            {
                book.Return();
                Books.Remove(book);
            }
            else
            {
                throw new BookIsLostException(book.Title);
            }
        }

        public void Reminde(Book book)
        {
            if (Books.Contains(book))
                Console.WriteLine($"Нагадуваня для {Name} повернути книгу {book}");
        }

        ~LibraryUser() 
        {
            foreach (Book book in Books)
            {
                book.Return();
            }
            Books.Clear();
        }
    }
}
