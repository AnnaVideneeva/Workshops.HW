using System;
using System.Collections.Generic;
using Bogus;
using Rocket.BL.Common.Models.ReleaseList;

namespace Rocket.BL.Tests.ReleaseList.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о музыкальных треках,
    /// в моделях домена
    /// </summary>
    public class FakeMusicTrackData
    {
        /// <summary>
        /// Возвращает генератор данных о музыкальных треках
        /// </summary>
        public Faker<MusicTrack> MusicTrackFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных музыкальных треках
        /// </summary>
        public List<MusicTrack> MusicTrack { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о музыкальных треках
        /// </summary>
        public FakeMusicTrackData()
        {
            MusicTrackFaker = new Faker<MusicTrack>()
                .RuleFor(m => m.Id, f => f.IndexFaker)
                //.RuleFor(m => m.Number, f => f.IndexVariable++)
                .RuleFor(m => m.Title, f => string.Join(" ", f.Lorem.Words(2)))
                .RuleFor(m => m.Duration, f => f.Date.Timespan(new TimeSpan(1, 0, 0)));

            MusicTrack = new List<MusicTrack>();
        }

        /// <summary>
        /// Генерирует и возвращает коллекцию музыкальных треков в заданном количестве
        /// начиная с заданного номера музыкального трека
        /// </summary>
        /// <param name="count">Количество музыкальных треков</param>
        /// <param name="startMusicTrackNumber">Начальный номер музыкального трека</param>
        /// <returns>Коллекция музыкальных треков</returns>
        public List<MusicTrack> Generate(int count, int startMusicTrackNumber = 1)
        {
            //MusicTrackFaker.RuleFor(m => m.Number, startMusicTrackNumber++);
            var musicTrack = MusicTrackFaker.Generate(count);
            MusicTrack.AddRange(musicTrack);
            return musicTrack;
        }
    }
}