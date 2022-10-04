namespace SocialWeb.PLL.Helpers
{
    /// <summary>
    /// Вывод сообщения об успешнои выполнениии операции.
    /// </summary>
    public static class SuccessMessage
    {
        public static void Show(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
            Console.ReadKey();
            Console.Clear();
        }
    }
}
