using System.ComponentModel.DataAnnotations;

namespace SocialWeb
{
    class Program
    {
        private static void Main(string[] args)
        {
            string firstName = null;
            string lastName = null;
            string password = null;
            string emailAddress = null;

            try
            {
                if (string.IsNullOrEmpty(lastName))
                    throw new ArgumentNullException();

                if (password.Length < 8)
                    throw new ArgumentNullException();

                if(!new EmailAddressAttribute().IsValid(emailAddress))
                    throw new ArgumentNullException();

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}