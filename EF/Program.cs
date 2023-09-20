using EF.Entities;
using EF.Repositories;

namespace EF{
    class Program{
        static void Main(string[] args){

            using (var db = new AppContext()){

                var User1 = new User { Name = "Федор", Email = "fe45@gmail.com" };
                var User2 = new User { Name = "Алиса", Email = "alisa345@gmail.com" };
                var Book1 = new Book { Name = "Дюна. Первая трилогия", Author = "Фрэнк Герберт", Genre = "Фантастика", CreatedDate = 20150720 };
                var Book2 = new Book { Name = "Семь дней до Мегиддо", Author = "Сергей Лукьяненко", Genre = "Фантастика", CreatedDate = 20180426 };


                var BookRepository = new BookRepository(db);
                var UserRepository = new UserRepository(db);

                UserRepository.AddUser(User1);
                UserRepository.AddUser(User2);
                BookRepository.AddBook(Book1);
                BookRepository.AddBook(Book2);
                UserRepository.TakeBook(User1, Book2);
                UserRepository.TakeBook(User1, Book1);

                db.SaveChanges();
                var book = BookRepository.GetAllBooks();
            }
        }
    }
}
