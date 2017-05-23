using System.Data.Entity;
using System.Linq;
using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;
using BarCrawler.ViewModels;


namespace BarCrawler.DataAccessLogic.Repositories
{
    /// <summary>
    /// The BarRepository contains functions to store, edit and get the correct bars from the database.
    /// </summary>
    /// <seealso cref="BarCrawler.DataAccessLogic.Repositories.GenericRepository{BarCrawler.Models.BarModel}" />
    /// <seealso cref="BarCrawler.DataAccessLogic.Repositories.Interface.IBarRepository" />
    public class BarRepository : GenericRepository<BarModel>, IBarRepository
    {

        /// <summary>
        /// The table for all the bars.
        /// </summary>
        private DbSet<BarModel> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="BarRepository" /> class.
        /// </summary>
        /// <param name="receivedContext">The received context.</param>
        /// <remarks>
        /// The received context is passed on to the base class.
        /// </remarks>
        /// <seealso cref="BarCrawlerContext"/>
        public BarRepository(BarCrawlerContext receivedContext) : base(receivedContext)
        {
            _dbSet = receivedContext.BarModels;
        }


        /// <summary>
        /// Gets the specific bar profile through a BarID.
        /// </summary>
        /// <param name="id">The Bar identifier.</param>
        /// <returns>Returns the <see cref="BarModel" /> with the correct attributes.</returns>
        /// <seealso cref="BarModel" />
        public BarModel GetProfile(int? id)
        {
            return (_dbSet.Include(d => d.Drinks)
                .Include(e => e.Events)
                .Include(f => f.Feeds)
                .Include(p => p.Pictures)
                .SingleOrDefault(x => x.BarID == id));
        }

        /// <summary>
        /// Gets the specific bar profile through a BarID when the bar needs to be edit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the <see cref="BarModel" /> with the correct attributes.
        /// </returns>
        /// <seealso cref="BarModel" />
        public BarModel GetEditInfo(int? id)
        {
            return _context.Set<BarModel>().Include(p => p.BarProfilePicture).SingleOrDefault(x => x.BarID == id);
        }

        /// <summary>
        /// Change the bar profiles properties through the <see cref="EditViewModel" />
        /// </summary>
        /// <param name="editviewmodel">The <see cref="EditViewModel" /> to take data from.</param>
        /// <param name="bar">The <see cref="BarModel"/> to edit info in.</param>
        /// <seealso cref="BarModel" />
        public void EditInfo(EditViewModel editviewmodel, BarModel bar)
        {
            bar.Address1 = editviewmodel.Address1;
            bar.Address2 = editviewmodel.Address2;
            bar.PhoneNumber = editviewmodel.PhoneNumber;
            bar.Zipcode = editviewmodel.Zipcode;
            bar.Description = editviewmodel.Description;
            bar.StreetNumber = editviewmodel.StreetNumber;
            bar.City = editviewmodel.City;
            bar.Faculty = editviewmodel.Faculty;
            MarkAsDirty(bar);
        }


        /// <summary>
        /// Gets the BarModel depending on the user id.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// Returns the <see cref="BarModel" /> with the correct attributes.
        /// </returns>
        /// <seealso cref="BarModel" />
        public BarModel GetByUserID(string userId)
        {
            return _context.Set<BarModel>().SingleOrDefault(x => x.userID == userId);
        }


        /// <summary>
        /// Create the bar thorugh <see cref="BarModel" /> and properties through the <see cref="BigRegisterViewModel" /> by a user <see cref="ApplicationUser" />
        /// </summary>
        /// <param name="bar">The bar to create.</param>
        /// <param name="model">The <see cref="BarModel" /> to take data from.</param>
        /// <param name="user">The <see cref="ApplicationUser" /> to take data from.</param>
        /// <seealso cref="BarModel" />
        /// <seealso cref="BigRegisterViewModel" />
        /// <seealso cref="ApplicationUser"/>
        public void CreateAndAddBar(ref BarModel bar, ref BigRegisterViewModel model, ref ApplicationUser user)
        {
            bar.Address1 = model.BarModel.Address1;
            bar.Address2 = model.BarModel.Address2;
            bar.PhoneNumber = model.BarModel.PhoneNumber;
            bar.Zipcode = model.BarModel.Zipcode;
            bar.BarName = model.BarModel.BarName;
            bar.Description = model.BarModel.Description;
            bar.StreetNumber = model.BarModel.StreetNumber;
            bar.City = model.BarModel.City;
            bar.userID = user.Id;
            bar.Email = model.BarModel.Email;
            bar.Faculty = model.BarModel.Faculty;
            bar.OpenTime = model.BarModel.OpenTime;
            bar.CloseTime = model.BarModel.CloseTime;
            Add(bar);
        }
    }
}
