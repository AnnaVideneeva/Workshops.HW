namespace Rocket.DAL.Common.Enums
{
    /// <summary>
    /// Описывает перечисление типов релизов
    /// для целей нотификации
    /// </summary>
    public enum ReleaseType
    {
        /// <summary>
        /// Релиз фильма
        /// </summary>
        Film = 1,

        /// <summary>
        /// Музыкальный релиз
        /// </summary>
        Music = 2,

        /// <summary>
        /// Релиз серии сериала
        /// </summary>
        TVSeriesEpisode = 3
    }
}
