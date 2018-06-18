namespace Rocket.BL.Tests.ReleaseList.FakeData
{
    public class FakeDb
    {
        public FakeDb()
        {
            FakePersonTypeEntities = new FakePersonTypeEntities();
            FakePersonEntities = new FakePersonEntities(1000, FakePersonTypeEntities);
            FakeCategoryEntities = new FakeCategoryEntities();
            FakeGenreEntities = new FakeGenreEntities(20, FakeCategoryEntities);
            FakeSeasonEntities = new FakeSeasonEntities();
            FakeEpisodeEntities = new FakeEpisodeEntities();
            FakeTvSeriasEntities = new FakeTvSeriasEntities(100, FakePersonEntities, FakeGenreEntities, FakeSeasonEntities, FakeEpisodeEntities);
            
        }

        public FakeTvSeriasEntities FakeTvSeriasEntities { get; }

        public FakePersonEntities FakePersonEntities { get; }

        public FakePersonTypeEntities FakePersonTypeEntities { get; }

        public FakeGenreEntities FakeGenreEntities { get; }

        public FakeCategoryEntities FakeCategoryEntities { get; }

        public FakeSeasonEntities FakeSeasonEntities { get; }

        public FakeEpisodeEntities FakeEpisodeEntities { get; }
    }
}
