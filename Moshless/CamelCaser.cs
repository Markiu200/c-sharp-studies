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

            string[] words = str.Trim().Split(' ');
            char[] buffor = new char[str.Length];
            int i = 0;

            foreach (string word in words)
            {
                bool capitalize = true;
                foreach (char c in word)
                {
                    if (capitalize && Char.IsLetter(c))
                    {
                        buffor[i++] = Char.ToUpper(c);
                        capitalize = false;
                    }
                    else
                    {
                        buffor[i++] = c;
                    }
                }
            }
            return new string(buffor);
        }
    }
}
