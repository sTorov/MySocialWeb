using SocialWeb.BLL.Models;

namespace SocialWeb.PLL.Views
{
    /// <summary>
    /// Отображение исходящих сообщений пользователя
    /// </summary>
    public class UserOutcomingMessageView
    {
        public void Show(IEnumerable<Message> outcomingMessages)
        {
            Console.WriteLine("Исходящие сообщения\n");

            if (outcomingMessages.Count() == 0)
            {
                Console.WriteLine("Исходящих сообщений нет");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            outcomingMessages.ToList().ForEach(m =>
            {
                Console.WriteLine($"Кому: {m.RecipientEmail}\nТекст сообщения: {m.Content}");
                Console.WriteLine("---------------");
            });

            Console.ReadKey();
            Console.Clear();
        }
    }
}
