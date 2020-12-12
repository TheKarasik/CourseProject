using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject
{
    public class DeNcoder
    {
        const string letters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public static bool HasNotCyrillicChars(string a)
        {
            foreach (var item in a)
            {
                if (!letters.Contains(item)) return false;
            }
            return true;
        }


        public static string Encrypt(string m, string k)
        {
            char[] encryptedMessage = m.ToCharArray();
            int keyCounter = 0;
            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                if (letters.Contains(encryptedMessage[i]))
                {
                    encryptedMessage[i] = letters[(letters.IndexOf(encryptedMessage[i]) + letters.IndexOf(k[keyCounter % k.Length])) % letters.Length];
                    keyCounter++;
                }
            }
            return new string(encryptedMessage);
        }
        public static string Decrypt(string m, string k)
        {
            char[] decryptedMessage = m.ToCharArray();
            int keyCounter = 0;
            for (int i = 0; i < decryptedMessage.Length; i++)
            {
                if (letters.Contains(decryptedMessage[i]))
                {
                    decryptedMessage[i] = letters[(letters.IndexOf(decryptedMessage[i]) + letters.Length - letters.IndexOf(k[keyCounter % k.Length])) % letters.Length];
                    keyCounter++;
                }
            }
            return new string(decryptedMessage);
        }
    }
}
