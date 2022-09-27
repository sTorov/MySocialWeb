using SocialWeb.BLL.Models;

namespace SocialWeb.PLL.Views
{
    public class UserOutcomingMessageView
    {
        public void Show(IEnumerable<Message> outcomingMessages)
        {
            Console.WriteLine("Исхлодящие сообщения");

            if (outcomingMessages.Count() == 0)
            {
                Console.WriteLine("Исходящих сообщений нет");
                return;
            }

            outcomingMessages.ToList().ForEach(m =>
            {
                Console.WriteLine($"Кому: {m.RecipientEmail}. Текст сообщения: {m.Content}");
            });
        }
    }
}
