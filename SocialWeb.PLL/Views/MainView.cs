namespace SocialWeb.PLL.Views
{
    /// <summary>
    /// Отображение главного меню
    /// </summary>
    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("Войти в профиль (нажмите 1)");
            Console.WriteLine("Зарегистрироваться (нажмите 2)");

            string keyValue = Console.ReadLine();

            Console.Clear();

            switch (keyValue)
            {
                case "1":
                    Program.autheticationView.Show();
                    break;
                case "2":
                    Program.registrationView.Show();
                    break;
            }
        }
    }
}
