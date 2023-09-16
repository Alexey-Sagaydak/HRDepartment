using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HRDepartment
{
    public sealed class PasswordHash
    {
        private string staticSalt;

        public PasswordHash(string staticSalt)
        {
            this.staticSalt = staticSalt;
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Конкатенируем пароль и соль, преобразуем в байты
                byte[] bytes = Encoding.UTF8.GetBytes(password + staticSalt);

                // Вычисляем хэш
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Преобразуем байты хэша в строку для сравнения
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
