using System;
using System.Text.RegularExpressions;

namespace Rocket.Parser.Extensions
{
    /// <summary>
    /// Хелпер для облегчения работы со строками.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Получает подстроку на основании исходной строки.
        /// </summary>
        /// <param name="source">Исходная строка.</param>
        /// <param name="startString">Строка после которой надо получить подстроку.</param>
        /// <param name="endString">Строка перед которой надо завершить получение подстроки.</param>
        /// <param name="regExpr">Использовать регулярное выражение</param>
        /// <returns>Подстрока.</returns>
        public static string GetSubstring(this string source, string startString, string endString, bool regExpr = true)
        {
            if (endString == null)
            {
                throw new ArgumentNullException(nameof(endString));
            }

            int startIndex = 0;
            if (!string.IsNullOrEmpty(startString))
            {
                startIndex = source.IndexOf(startString, StringComparison.Ordinal) + startString.Length;
                if (startIndex < 0) startIndex = 0;
            }

            int endIndex = source.Length;
            if (!string.IsNullOrEmpty(endString))
            {
                endIndex = source.IndexOf(endString, startIndex, StringComparison.Ordinal);
                if (endIndex < 0) endIndex = source.Length;
            }

            string currentDetailsPane = source.Substring(startIndex, endIndex - startIndex);

            if (regExpr) return Regex.Replace(currentDetailsPane, @"[ \t\n\r\f\v]", string.Empty);
            return Regex.Replace(currentDetailsPane, @"[\t\n\r\f\v]", "");
        }
    }
}
