using System;
namespace SimpleUserDemo
{
    class User
    {
        public string Username;
        private string Password;
        protected string Email;
        internal int Id;
        public void SetPassword(string password)
        {
            Password = password;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Password: {Password}");
            Console.WriteLine($"Email: {Email}");
        }
    }
    class Admin : User
    {
        public void SetEmail(string email)
        {
            Email = email;
        }
    }
    class Program
    {
        static void Main()
        {
            Admin admin = new Admin();
            admin.Id = 1;
            admin.Username = "admin01";
            admin.SetPassword("12345");
            admin.SetEmail("admin@gmail.com");
            admin.ShowInfo();
            Console.ReadKey();
        }
    }
}