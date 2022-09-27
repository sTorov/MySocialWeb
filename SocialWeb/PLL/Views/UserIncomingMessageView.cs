using SocialWeb.BLL.Models;

namespace SocialWeb.PLL.Views
{
    public class UserIncomingMessageView
    {
        public void Show(IEnumerable<Message> incomingMessages)
        {
            Console.WriteLine("Входящие сообщения");

            if(incomingMessages.Count() == 0)
            {
                Console.WriteLine("Входящих сообщений нет");
                return;
            }

            incomingMessages.ToList().ForEach(m =>
            {
                Console.WriteLine($"От кого: {m.SenderEmail}. Текст сообщения: {m.Content}");
            });
        }
    }
}
