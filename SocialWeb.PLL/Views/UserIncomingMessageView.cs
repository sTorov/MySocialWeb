using SocialWeb.BLL.Models;

namespace SocialWeb.PLL.Views
{
    /// <summary>
    /// Отображение входящих сообщений пользователя
    /// </summary>
    public class UserIncomingMessageView
    {
        public void Show(IEnumerable<Message> incomingMessages)
        {
            Console.WriteLine("Входящие сообщения\n");

            if(incomingMessages.Count() == 0)
            {
                Console.WriteLine("Входящих сообщений нет");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            incomingMessages.ToList().ForEach(m =>
            {
                Console.WriteLine($"От кого: {m.SenderEmail}\nТекст сообщения: {m.Content}");
                Console.WriteLine("---------------");
            });

            Console.ReadKey();
            Console.Clear();
        }
    }
}
