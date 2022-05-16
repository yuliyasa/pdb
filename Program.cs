using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Entity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                string[] command;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введите команду");
                        command = Console.ReadLine().Split();
                        if (command[0] == "add")
                        {
                            string nickname = command[1];
                            string name = command[2];
                            string password = command[3];
                            int age = Int32.Parse(command[4]);
                            addUser(nickname, name, password, age);
                        }
                        else if (command[0] == "remove")
                        {
                            string nickname = command[1];
                            removeUser(nickname);
                        }
                        else if (command[0] == "setAge")
                        {
                            string nickname = command[1];
                            int age = Int32.Parse(command[2]);
                            updateAge(nickname, age);
                        }
                        else if (command[0] == "printAll")
                        {
                            printAllUsers();
                            Console.WriteLine("Done");
                        }
                        else
                        {
                            Console.WriteLine("Неопознанная команда");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Неопознанная команда");
                    }
                }

            }
        }

        public static void addUser(string nickname, string name, string password, int age)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = new User { Nickname = nickname, Name = name, Password = GetMD5(password), Age = age };
                if (getUser(nickname) is null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    Console.WriteLine("Вставка успешна");
                }
                else
                {
                    Console.WriteLine("Пользователь с таким ником уже существует");
                }
            }
        }

        public static User getUser(string nickname)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var user_query = db.Users.Where(p => p.Nickname == nickname);
                if (user_query.Any())
                    return user_query.First();
                else
                    return null;
            }
        }

        public static void updateAge(string nickname, int age)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = getUser(nickname);
                if (user is null)
                {
                    Console.WriteLine("Не существует пользователя с таким ником");
                }
                else
                {
                    user.Age = age;
                    db.SaveChanges();
                    Console.WriteLine("Изменено");
                }

            }
        }

        public static void removeUser(string nickname)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = getUser(nickname);
                if (user is not null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    Console.WriteLine("Удалено");
                }
            }
        }
        public static void printAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var user_query = db.Users;
                foreach (User user in user_query)
                    Console.WriteLine($"{user.Nickname}, {user.Password}, {user.Name},  {user.Age}");
            }
        }
        static string GetMD5(string password)
        {
            byte[] hash = Encoding.ASCII.GetBytes(password);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string result = "";
            foreach (var b in hashenc)
            {
                result += b.ToString("x2");
            }
            return result;
        }
    }
}