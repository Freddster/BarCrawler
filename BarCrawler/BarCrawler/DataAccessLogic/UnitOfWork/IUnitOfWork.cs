using System;
using BarCrawler.DataAccessLogic.Repositories.Interface;

namespace BarCrawler.DataAccessLogic.UnitOfWork
{
    /// <summary>
    /// IUnitOfWork interface to implement UnitOfWork
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the bar repository.
        /// </summary>
        /// <value>
        /// The bar repository.
        /// </value>
        /// <seealso cref="IBarRepository"/>
        IBarRepository BarRepository { get; }
        /// <summary>
        /// Gets the bar profil picture repository.
        /// </summary>
        /// <value>
        /// The bar profil picture repository.
        /// </value>
        /// <seealso cref="IBarProfilePictureRepository"/>
        IBarProfilePictureRepository BarProfilePictureRepository { get; }
        /// <summary>
        /// Gets the cover picture repository.
        /// </summary>
        /// <value>
        /// The cover picture repository.
        /// </value>
        /// <seealso cref="ICoverPictureRepository"/>
        ICoverPictureRepository CoverPictureRepository { get; }
        /// <summary>
        /// Gets the drink repository.
        /// </summary>
        /// <value>
        /// The drink repository.
        /// </value>
        /// <seealso cref="IDrinkRepository"/>
        IDrinkRepository DrinkRepository { get; }
        /// <summary>
        /// Gets the event repository.
        /// </summary>
        /// <value>
        /// The event repository.
        /// </value>
        /// <seealso cref="IEventRepository"/>
        IEventRepository EventRepository { get; }
        /// <summary>
        /// Gets the feed repository.
        /// </summary>
        /// <value>
        /// The feed repository.
        /// </value>
        /// <seealso cref="IFeedRepository"/>
        IFeedRepository FeedRepository { get; }
        /// <summary>
        /// Gets the picture repository.
        /// </summary>
        /// <value>
        /// The picture repository.
        /// </value>
        /// <seealso cref="IPictureRepository"/>
        IPictureRepository PictureRepository { get; }


        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
    }
}