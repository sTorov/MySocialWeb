using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using System.Text;

namespace SocialWeb
{
    class Program
    {
        public static UserService userService = new UserService();

        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine("Добро пожаловать в социальную сеть");
            
            while (true)
            {
                Console.WriteLine("Для регистрации введите имя пользователя:");

                string firstname = Console.ReadLine();

                Console.Write("Фамилию: ");
                string lastname = Console.ReadLine();

                Console.Write("Пароль: ");
                string password = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                UserRegistrationData userRegistrationData = new UserRegistrationData()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Password = password,
                    Email = email
                };

                try
                {
                    userService.Register(userRegistrationData);
                    Console.WriteLine("Регистрация прошла успешно!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Введите корректные значения.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Произошла ошибка при регистрации.");
                }

                Console.ReadKey(true);
            }
        }
    }
}