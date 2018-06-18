using Rocket.DAL.Common.UoW;
using System;

namespace Rocket.BL.Services
{
    public abstract class BaseService : IDisposable
    {
        protected IUnitOfWork _unitOfWork;
        private bool _disposedValue;

        /// <summary>
        /// Инициализирует поле unitOfWork заданным экземпляром
        /// </summary>
        /// <param name="unitOfWork">Экземпляр unit of work</param>
        protected BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        ~BaseService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Освобождает управляемые ресурсы
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Освобождает управляемые ресурсы
        /// </summary>
        /// <param name="disposing">Указывает вызван ли этот метод из метода Dispose() или из финализатора</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    GC.SuppressFinalize(this);
                }

                _unitOfWork?.Dispose();
                _unitOfWork = null;
                _disposedValue = true;
            }
        }
    }
}