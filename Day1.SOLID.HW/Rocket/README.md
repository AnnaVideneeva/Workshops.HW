* Rocket.Web - Presentation Layer
* Rocket.Bl - Business Logic Layer (содержит реализацию сервисов)
* Rocket.Bl.Common - общая часть для бизнес-логики (содержит настройки маппингов, доменные модели, интерфейсы сервисов бизнес-логики)
* Rocket.DAL - Data Access Layer. Реализации контекстов, репозиториев и конфигурирование схемы базы.
* Rocket.DAL.Common - общая часть для DAL. Содержит модели уровня данных, интерфейсы репозиториев, интерфейс для UnitOfWork

* Rocket.BL.Tests - unit-tests для сервисов BLL
* Rocket.Acceptance.Tests - спецификации наших фичей (SpecFlow)