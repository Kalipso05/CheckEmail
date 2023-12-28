using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheckEmail
{

    class CheckData
    {
        public void CreateAccount(string email, string password)
        {
            Console.WriteLine($"===== В базу данных добавлен новый аккаунт =====\n\nEmail:\t{email}\nPassword:\t{password}\n");
        }

        public bool IsEmailCorrect(string email)
        {
            if (Regex.IsMatch(email, @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)"))
                return true;

            Console.WriteLine("[!] Ваш Email адрес введен неверно!");
            return false;
        }

        private bool ContainsNumbers(string password)
        {
            var list = password.ToArray();

            int temp = 0;

            foreach (var number in list)
            {
                if (int.TryParse(number.ToString(), out temp))
                {
                    return true;
                }
            }
            Console.WriteLine("[!] Пароль должен содержать хотя бы любую цифру");
            return false;
            
        }

        private bool isUpper(string password)
        {
            var list = password.ToList();


            foreach (var item in list)
            {
                if (item.ToString() == item.ToString().ToUpper())
                {
                    return true;
                }
            }
            Console.WriteLine("[!] Пароль должен содержать хотя бы символ верхнего регистра");
            return false;
        }

        private bool isLower(string password)
        {
            var list = password.ToList();


            foreach (var item in list)
            {
                if (item.ToString() == item.ToString().ToLower())
                {
                    return true;
                }
            }
            Console.WriteLine("[!] Пароль должен содержать хотя бы символ нижнего регистра");
            return false;
        }

        public bool IsPasswordCorrect(string password)
        {
            if (password.Length >= 8 && isUpper(password) && isLower(password) && ContainsNumbers(password))
            {

                return true;
            }
            return false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CheckData data = new CheckData();

            string email = Console.ReadLine();

            if (data.IsEmailCorrect(email))
            {
                string password = Console.ReadLine();
                if (data.IsPasswordCorrect(password))
                {
                    data.CreateAccount(email, password);
                }
            }
        }
    }
}
