using System.Collections.Generic;
using System.Linq;

namespace Last_Project
{
    public class VigCipher
    {
        const string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        readonly string letters;
        Dictionary<int, string> symbolswithindex = new Dictionary<int, string>();

        public VigCipher(string alphabet = null)
        {
            letters = alphabet;
        }
        private void Input(string text)
        {

            for (int i = 0; i < text.Length; i++)
            {
                if (!letters.Contains(text[i]))
                {
                    symbolswithindex.Add(i, text[i].ToString());
                }
            }
        }
        private string EncryptDecryptFunc(string text, string password, bool encrypting = true)
        {
            string tempText = text.ToUpper();
            Input(tempText);
       
            var retValue = "";
            var q = letters.Length;
            int keyword_index = 0;
            for (int i = 0; i < text.Length; i++)
            {
                var letterIndex = letters.IndexOf(tempText[i]);
                //
                if (letterIndex < 0)
                {
                    //если буква не найдена, добавляем её в исходном виде
                    string value = "";
                    symbolswithindex.TryGetValue(i, out value);
                    retValue += value;
                }
                else
                {

                    var codeIndex = letters.IndexOf(password[keyword_index]);
                    if (char.IsLower(text[i]))
                    {
                        retValue += letters[(q + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % q].ToString().ToLower();
                    }
                    if (char.IsUpper(text[i]))
                    {
                        retValue += letters[(q + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % q].ToString().ToUpper();
                    }

                    if ((keyword_index + 1) == password.Length)
                    {
                        keyword_index = -1;
                    }

                    keyword_index++;
                }
            }

            return retValue;
        }

        //шифрование текста
        public string Encrypt(string plainMessage, string password)
        => EncryptDecryptFunc(plainMessage, password.ToUpper());

        //дешифрование текста
        public string Decrypt(string encryptedMessage, string password)
        => EncryptDecryptFunc(encryptedMessage, password.ToUpper(), false);
    }
}