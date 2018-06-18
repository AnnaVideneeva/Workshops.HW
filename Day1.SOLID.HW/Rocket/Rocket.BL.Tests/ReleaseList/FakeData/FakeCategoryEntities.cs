using Rocket.DAL.Common.DbModels.Parser;
using System.Collections.Generic;

namespace Rocket.BL.Tests.ReleaseList.FakeData
{
    public class FakeCategoryEntities
    {
        public FakeCategoryEntities()
        {
            CategoryEntities = new List<CategoryEntity>()
            {
                new CategoryEntity()
                {
                    Code = 1,
                    Name = "Сериал",
                    ListGenre = new List<GenreEntity>()
                },
                new CategoryEntity()
                {
                    Code = 2,
                    Name = "Фильм",
                    ListGenre = new List<GenreEntity>()
                },
                new CategoryEntity()
                {
                    Code = 3,
                    Name = "Музыкальный трэк",
                    ListGenre = new List<GenreEntity>()
                },
            };
        }

        public List<CategoryEntity> CategoryEntities { get; }
    }
}
