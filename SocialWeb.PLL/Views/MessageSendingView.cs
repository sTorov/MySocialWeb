using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    /// <summary>
    /// Отображение процесса отправки сообщения
    /// </summary>
    public class MessageSendingView
    {
        UserService userService;
        MessageService messageService;

        public MessageSendingView(UserService userService, MessageService messageService)
        {
            this.userService = userService;
            this.messageService = messageService;
        }

        public User Show(User user)
        {
            var messageSendingData = new MessageSendingData();

            Console.WriteLine("Введите почтовый адрес получателя:");
            messageSendingData.RecipientEmail = Console.ReadLine();

            Console.WriteLine("Введите сообщение (не более 5000 символов):");
            messageSendingData.Content = Console.ReadLine();

            messageSendingData.SenderId = user.Id;

            try
            {
                messageService.SendMessage(messageSendingData);

                SuccessMessage.Show("Сообщение успешно отправлено!");

                return userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
                return user;
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
                return user;
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при отправке сообщения!");
                return user;
            }
        }
    }
}
