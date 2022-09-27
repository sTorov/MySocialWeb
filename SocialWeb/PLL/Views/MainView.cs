namespace SocialWeb.PLL.Views
{
    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("Войти в профиль (нажмите 1)");
            Console.WriteLine("Зарегистрироваться (нажмите 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Program.autheticationView.Show();
                    break;
                case "2":
                    Console.Clear();
                    Program.registrationView.Show();
                    break;
            }
        }
    }
}
