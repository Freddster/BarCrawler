using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    /// <summary>
    /// Interface for Bar repositoiry to implement.
    /// </summary>
    /// <seealso cref="BarModel" />
    /// <seealso cref="BarRepository"/>
    public interface IBarRepository : IRepository<BarModel>
    {
        /// <summary>
        /// Gets the bar profile with the correct bar model, events, feeds and drinks.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns the <see cref="BarModel"/> with the correct attributes.</returns>
        /// <seealso cref="BarModel"/>
        BarModel GetProfile(int? id);

        /// <summary>
        /// Gets the bar profile information to edit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns the <see cref="BarModel"/> with the correct attributes.</returns>
        /// <seealso cref="BarModel"/>
        BarModel GetEditInfo(int? id);

        /// <summary>
        /// Gets a viewmodel with the new information and a <see cref="BarModel"/> to put the new information into.
        /// </summary>
        /// <param name="editviewmodel">The <see cref="EditViewModel"/> to take data from.</param>
        /// <param name="bar">The bar to edit info in.</param>
        /// <seealso cref="BarModel"/>
        void EditInfo(EditViewModel editviewmodel, BarModel bar);

        /// <summary>
        /// Gets the BarModel depending on the user id.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns the <see cref="BarModel"/> with the correct attributes.</returns>
        /// <seealso cref="BarModel"/>
        BarModel GetByUserID(string userId);

        /// <summary>
        /// Creates a bar depending on the data received in the <see cref="BigRegisterViewModel"/> and the ApplicationUser.
        /// </summary>
        /// <param name="bar">The bar to create.</param>
        /// <param name="model">The <see cref="BarModel"/> to take data from.</param>
        /// <param name="user">The <see cref="ApplicationUser"/> to take data from.</param>
        /// <seealso cref="BarModel"/>
        /// <seealso cref="BigRegisterViewModel"/>
        void CreateAndAddBar(ref BarModel bar, ref BigRegisterViewModel model, ref ApplicationUser user);
    }
}
