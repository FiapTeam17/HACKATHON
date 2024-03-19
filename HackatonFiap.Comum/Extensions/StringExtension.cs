using System.Text;

namespace HackatonFiap.Comum.Extensions
{
    public static class StringExtension
    {
        public static string ToProperCase(this string str)
        {
            var chars = str.ToCharArray();
            if (chars.Length > 0)
            {
                chars[0] = char.ToUpper(chars[0]);
                var builder = new StringBuilder();
                for (var i = 0; i < chars.Length; i++)
                {
                    if ((chars[i]) == '-')
                    {
                        i = i + 1;
                        builder.Append(char.ToUpper(chars[i]));
                    }
                    else
                    {
                        builder.Append(chars[i]);
                    }
                }
                return builder.ToString();
            }
            return str;
        }

        public static string Dasherize(this string str)
        {
            var chars = str.ToCharArray();
            if (chars.Length > 0)
            {
                var builder = new StringBuilder();
                for (var i = 0; i < chars.Length; i++)
                {
                    if (char.IsUpper(chars[i]))
                    {
                        var hashedString = (i > 0) ? $"-{char.ToLower(chars[i])}" : $"{char.ToLower(chars[i])}";
                        builder.Append(hashedString);
                    }
                    else
                    {
                        builder.Append(chars[i]);
                    }
                }
                return builder.ToString();
            }
            return str;
        }

        public static string RemoveAcentosCaracteresEspeciais(string str)
        {

            string[] acentos = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            string[] semAcento = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

            for (int i = 0; i < acentos.Length; i++)
            {
                str = str.Replace(acentos[i], semAcento[i]);
            }

            string[] caracteresEspeciais = { "\\.", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°" };

            for (int i = 0; i < caracteresEspeciais.Length; i++)
            {
                str = str.Replace(caracteresEspeciais[i], "");
            }

            return str;
        }

        public static string Base64Decode(this string base64Encoded)
        {
            if (string.IsNullOrEmpty(base64Encoded))
                return string.Empty;

            byte[] data = Convert.FromBase64String(base64Encoded);

            return Encoding.ASCII.GetString(data);
        }

        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = Encoding.ASCII.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
