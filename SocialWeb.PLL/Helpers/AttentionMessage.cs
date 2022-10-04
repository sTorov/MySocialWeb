namespace SocialWeb.PLL.Helpers
{
    /// <summary>
    /// Вывод уведомляющего сообщения.
    /// </summary>
    static class AttentionMessage
    {
        public static void Show(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ForegroundColor = originalColor;
        }
    }
}
