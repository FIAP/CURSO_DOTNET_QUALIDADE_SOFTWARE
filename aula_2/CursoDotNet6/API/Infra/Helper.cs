using System.Globalization;
using System.Text;

namespace API.Infra
{
    public static class Helper
    {
        public static string GenerateSlug(string str)
        {
            // Define os caracteres especiais que devem ser removidos
            var specialCharacters = new char[]
            {
            '¹', '²', '³', '£', '¢', '¬', 'º', '¨', '\"', '\'', '.', ',', '-', ':',
            '(', ')', 'ª', '|', '\\', '°', '_', '@', '#', '!', '$', '%', '&', '*',
            ';', '/', '<', '>', '?', '[', ']', '{', '}', '=', '+', '§', '´', '`',
            '^', '~'
            };

            // Remove os caracteres especiais
            foreach (var character in specialCharacters)
            {
                str = str.Replace(character.ToString(), "");
            }

            // Remove os acentos
            str = RemoveDiacritics(str);

            // Substitui espaços em branco por hífens e converte para letras minúsculas
            str = str.Trim().ToLower().Replace(" ", "-");

            // Remove caracteres repetidos
           // str = RemoveDuplicateCharacters(str);

            return str;
        }

        private static string RemoveDiacritics(string text)
        {
            // Converte os caracteres acentuados para suas formas não acentuadas
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }       
    }
}
