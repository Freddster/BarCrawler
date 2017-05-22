using System;
using BarCrawler.DataAccessLogic.Repositories.Interface;

namespace BarCrawler.DataAccessLogic.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDrinkRepository DrinkRepository { get; }
        void Save();
    }
}