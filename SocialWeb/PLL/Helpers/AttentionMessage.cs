namespace SocialWeb.PLL.Helpers
{
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
