using EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Repositories{
    public class BookRepository{

        private AppContext appcontext;
        public BookRepository(AppContext context){

            appcontext = context;
        }
        public Book GetBookById(int id){

            return appcontext.Books.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Book> GetAllBooks(){

            foreach (var book in appcontext.Books){

                Console.WriteLine(book.Name + " " + book.Author);
            }
            return appcontext.Books.ToList();
        }
        public bool AddBook(Book book){

            try{

                appcontext.Books.Add(book);
            }
            catch{

                return false;
            }
            return true;
        }
        public bool DeleteBook(Book book){

            try{

                appcontext.Books.Remove(book);
            }
            catch{

                return false;
            }
            return true;
        }
        public bool UpdateBookById(int id, int date){

            try{

                var book = GetBookById(id);
                book.CreatedDate = date;
                appcontext.SaveChanges();
            }
            catch{

                return false;
            }
            return true;
        }
        public List<Book> GetListByAuthor(string author){

            return appcontext.Books.
                Where(x => x.Author == author).ToList();
        }
        public int GetBookCountByGenre(string genre){

            return appcontext.Books.
                Where(x => x.Genre == genre).Count();
        }
        public int GetBookCountByAuthor(string author){

            return appcontext.Books.
                Where(x => x.Author == author).Count();
        }
        public List<Book> BookListSortedByName(){

            return appcontext.Books.OrderBy(x => x.Name).ToList();
        }
        public List<Book> BookListSortedByDate(){

            return appcontext.Books.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public Book GetLastBook(){

            return BookListSortedByDate().First();
        }
        public Book GetBookByNameAndAuthor(string name, string author){

            return appcontext.Books.Where(b => b.Name == name && b.Author == author).FirstOrDefault();
        }

        public List<Book> GetSpecialBookList(string genre, int up, int down){

            return appcontext.Books.Where(b => b.Genre == genre && (b.CreatedDate > down) && (b.CreatedDate < up)).ToList();
        }
    }
}
