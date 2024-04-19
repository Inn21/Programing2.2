using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{
    internal class Book : ILibraryItem
    {
        public string Author { get; set; }
        public string Title { get; set; }

        public uint NumberOfPages;

        private bool free = true;

        public Book(string author, string title, uint numberOfPages)
        {
            Author = author;
            Title = title;
            NumberOfPages = numberOfPages;
        }

        public delegate void changeState(Book book,bool state);
        public event changeState ChangeState;

        public bool isFree()
        {
            return free;
        }

        public void Give()
        {
           free = false;
           ChangeState?.Invoke(this,free);
        }

        public void Return()
        {
            free = true;
            ChangeState?.Invoke(this, free);
        }

        public override string ToString()
        {
            return $"Автор:{Author} Назва:{Title} Кількість сторінок:{NumberOfPages}";
        }

        ~Book()
        {
            Delegate[] delegates = ChangeState.GetInvocationList();
            foreach (Delegate d in delegates)
            {
                ChangeState -= d as changeState;
            }
        }



    }
}
