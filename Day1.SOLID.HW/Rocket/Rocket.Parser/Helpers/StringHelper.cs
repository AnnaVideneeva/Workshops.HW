using System;
using System.Text.RegularExpressions;

namespace Rocket.Parser.Helpers
{
    /// <summary>
    /// Хелпер для облегчения работы со строками.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Получает подстроку на основании исходной строки.
        /// </summary>
        /// <param name="source">Исходная строка.</param>
        /// <param name="startString">Строка после которой надо получить подстроку.</param>
        /// <param name="endString">Строка перед которой надо завершить получение подстроки.</param>
        /// <returns>Подстрока.</returns>
        public static string GetSubstring(string source, string startString, string endString)
        {
            if (endString == null) throw new ArgumentNullException(nameof(endString));

            int startIndex = source.IndexOf(startString, StringComparison.Ordinal) + startString.Length;
            if (startIndex < 0) startIndex = 0;

            int endIndex = source.IndexOf(endString, startIndex, StringComparison.Ordinal);
            if (endIndex < 0) endIndex = source.Length;

            string currentDetailsPane = source.Substring(startIndex, endIndex - startIndex);

            return Regex.Replace(currentDetailsPane, @"[ \t\n\r\f\v]", "");
        }
    }
}
