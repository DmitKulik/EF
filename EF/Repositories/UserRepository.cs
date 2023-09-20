using EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Repositories{
    public class UserRepository{

        private AppContext appcontext;
        public UserRepository(AppContext context){

            appcontext = context;
        }
        public User GetUserById(int id){

            return appcontext.Users.Where(x => x.Id == id).FirstOrDefault(); //FirstOrDefault
        }
        public List<User> GetAllUsers(){

            foreach (var user in appcontext.Users){

                Console.WriteLine(user.Name);
            }
            return appcontext.Users.ToList();
        }
        public bool AddUser(User user){

            try{

                appcontext.Users.Add(user);
            }
            catch{

                return false;
            }
            return true;
        }
        public bool DeleteUser(User user){

            try{

                appcontext.Users.Remove(user);
            }
            catch{

                return false;
            }
            return true;
        }
        public bool UpdateUserById(int id, string name){

            try{

                var user = GetUserById(id);
                user.Name = name;
                appcontext.SaveChanges();
            }
            catch{

                return false;
            }
            return true;
        }
        public bool TakeBook(User user, Book book){

            try{

                if (book.UserId != 0)
                    throw new Exception();
                user.Books.Add(book);
                book.UserId = user.Id;
                appcontext.SaveChanges();
            }
            catch{

                return false;
            }
            return true;
        }
        public int GetUserBooksCount(User user){

            return user.Books.Count;
        }

        public bool DoUserTakeBook(User user, Book book){

            return user.Books.Contains(book);
        }
    }
}
