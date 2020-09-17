using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lab_encryption
{
    public class VigenereCipher : ICipher
    {
        const string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        private string GetRepeatKey(string s, int n)
        {
            var p = s;
            while (p.Length < n)
            {
                p += p;
            }

            return p.Substring(0, n);
        }

        private static string RemoveOtherChars(string input)
        {
            string output = input;

            for (int i = 0; i < output.Length; ++i)
                if (!char.IsLetter(output[i]))
                    output = output.Remove(i, 1);

            return output;
        }

        private static string AdjustOutput(string input, string output)
        {
            StringBuilder retVal = new StringBuilder(output);

            for (int i = 0; i < input.Length; ++i)
            {
                if (!char.IsLetter(input[i]))
                    retVal = retVal.Insert(i, input[i].ToString());

                if (char.IsLower(input[i]))
                    retVal[i] = char.ToLower(retVal[i]);
            }

            return retVal.ToString();
        }

        private string Vigenere(string text, string password, bool encrypting)
        {
            string tempInput = text.ToUpper();
           
            tempInput = RemoveOtherChars(tempInput);

            password = password.ToUpper();
            var gamma = GetRepeatKey(password, tempInput.Length);
            var retValue = "";

            var q = defaultAlphabet.Length;

            for (int i = 0; i < tempInput.Length; i++)
            {
                var letterIndex = defaultAlphabet.IndexOf(tempInput[i]);
                var codeIndex = defaultAlphabet.IndexOf(gamma[i]);

                if (letterIndex < 0)
                {
                    retValue += tempInput[i].ToString();
                }
                else
                {
                    retValue += defaultAlphabet[(q + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % q].ToString();
                }
            }

            retValue = AdjustOutput(text, retValue);

            return retValue;
        }

        public string Encode(string input, string key)
        {
            return Vigenere(input, key, true);
        }

        public string Decode(string input, string key)
        {
            return Vigenere(input, key, false);
        }     
    }
}