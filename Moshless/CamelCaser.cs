using System.Xml;

namespace Moshless
{
    internal static class CamelCaser
    {
        /// <summary>
        /// Extension method to String, generates camel case version of given String. 
        /// </summary>
        /// <param name="str">String to be camel-cased</param>
        /// <returns>Camel cased string for non-empty strings, or sends input back if it's String.Empty or "". 
        /// Throws ArgumentNullException for null </returns>
        public static String CamelCase(this String? str)
        {
            if (str == null) 
                throw new ArgumentNullException(nameof(str), "Cannot perform CamelCasing on null.");
            if (str == String.Empty) return String.Empty;
            if (str == "") return str;

            char[] buffor = new char[str.Length];
            int len = 0;
            bool whitespace = false;

            foreach (char c in str)
            {
                if (!Char.IsLetterOrDigit(c) && !Char.IsWhiteSpace(c)) continue;

                if (Char.IsWhiteSpace(c)) 
                {
                    if (len == 0) continue;
                    whitespace = true;
                }

                if (Char.IsLetterOrDigit(c))
                {
                    buffor[len++] = whitespace ? Char.ToUpper(c) : Char.ToLower(c);
                    whitespace = false;
                }
            }
            if (buffor[0] == '\0') return "";
            buffor[0] = Char.ToLower(buffor[0]);

            char[] final = new char[len];
            for (int i = 0; i<len; i++)
            {
                final[i] = buffor[i];
            }

            return new string(final);
        }
    }
}
