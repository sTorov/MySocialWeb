using SocialWeb.BLL.Exceptions;
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
                Console.WriteLine("Войти в профиль (нажмите 1)");
                Console.WriteLine("Зарегистрироваться (нажмите 2)");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            var authenticationData = new UserAuthenticationData();

                            Console.WriteLine("Введите почтовый адрес:");
                            authenticationData.Email = Console.ReadLine();

                            Console.WriteLine("Введите пароль:");
                            authenticationData.Password = Console.ReadLine();

                            try
                            {
                                User user = userService.Authenticate(authenticationData);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Вы успешно вошли в социальную сеть! Добро пожаловать {user.FirstName}");
                                Console.ResetColor();

                                while (true)
                                {
                                    Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                                    Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                                    Console.WriteLine("Добавить в друзья (нажмите 3)");
                                    Console.WriteLine("Напимать сообщение (нажмите 4)");
                                    Console.WriteLine("Выйти из профиля (нажмите 5)");

                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Информация о моём профиле");
                                                Console.WriteLine($"Мой идентификатор: {user.Id}");
                                                Console.WriteLine($"Меня зовут: {user.FirstName}");
                                                Console.WriteLine($"Моя фамилия: {user.LastName}");
                                                Console.WriteLine($"Мой пароль: {user.Password}");
                                                Console.WriteLine($"Мой почтовый адрес: {user.Email}");
                                                Console.WriteLine($"Ссылка на моё фото: {user.Photo}");
                                                Console.WriteLine($"Мой любимый фильм: {user.FavoriteMovie}");
                                                Console.WriteLine($"Моя любимая книга: {user.FavoriteBook}");
                                                Console.ResetColor();
                                            }
                                            break;
                                        case "2":
                                            {
                                                Console.WriteLine($"Меня зовут:");
                                                user.FirstName = Console.ReadLine();

                                                Console.WriteLine($"Моя фамилия:");
                                                user.LastName = Console.ReadLine();

                                                Console.WriteLine($"Ссылка на моё фото:");
                                                user.Photo = Console.ReadLine();

                                                Console.WriteLine($"Мой любимый фильм:");
                                                user.FavoriteMovie = Console.ReadLine();

                                                Console.WriteLine($"Моя любимая книга:");
                                                user.FavoriteBook = Console.ReadLine();

                                                userService.Update(user);

                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Ваш профиль успешно обновлён!");
                                                Console.ResetColor();
                                            }
                                            break;
                                    }
                                }
                            }
                            catch(WrongPasswordException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пароль некорректен!");
                                Console.ResetColor();
                            }
                            catch (UserNotFoundException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пользователь не найден!");
                                Console.ResetColor();
                            }
                        }
                        break;
                    case "2":
                        {
                            UserRegistrationData userRegistrationData = new UserRegistrationData();

                            Console.WriteLine("Для создания нового профиля введите ваше имя:");
                            userRegistrationData.FirstName = Console.ReadLine();

                            Console.Write("Ваша фамилия: ");
                            userRegistrationData.LastName = Console.ReadLine();

                            Console.Write("Пароль: ");
                            userRegistrationData.Password = Console.ReadLine();

                            Console.Write("Почтовый адрес: ");
                            userRegistrationData.Email = Console.ReadLine();
                            
                            try
                            {
                                userService.Register(userRegistrationData);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ваш профиль успешно создан. Теперь вы можете войти в систему под своими учетными данными.");
                                Console.ResetColor();
                            }
                            catch (ArgumentNullException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Введите корректное значение!");
                                Console.ResetColor();
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Произошла ошибка при регистрации!");
                                Console.ResetColor();
                            }
                        }
                        break;
                } 
            }
        }
    }
}