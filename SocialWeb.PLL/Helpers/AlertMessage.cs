﻿namespace SocialWeb.PLL.Helpers
{
    public static class AlertMessage
    {
        public static void Show(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
            Console.ReadKey();
            Console.Clear();
        }
    }
}
