using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Questions.Library
{
    public class Question1
    {
        public static string RemoveCharacterAndSpaces(string value)
        {
            value = Regex.Replace(value.Trim().ToLower(), "@s", "");
            value = Regex.Replace(value, @"\p{P}|\s+", "", RegexOptions.CultureInvariant);

            return value;
        }


        public static string InGenericSort(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "Value cannot be null";

            value = RemoveCharacterAndSpaces(value);

            char temp = '0';

            var arr = value.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] > arr[i])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            string tempWord = string.Empty;
            for (int i = 0; i < arr.Length; i++)
                tempWord = tempWord + arr[i];

            return tempWord;
        }

        public static bool DoesNotContainPunctuations(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            else
                return value.Any(char.IsPunctuation) ? false : true;
        }

        public static bool DoesNotContainWhiteSpaces(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            else
                return !string.IsNullOrWhiteSpace(value) ? true : false;
        }

        public static string BuildInLibrary(string value)
        {
            value = RemoveCharacterAndSpaces(value);

            var k = value.ToCharArray();
            Array.Sort<char>(k);
            return new string(k);
        }
    }
}
