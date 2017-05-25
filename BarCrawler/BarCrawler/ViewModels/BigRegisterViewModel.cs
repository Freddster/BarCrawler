using BarCrawler.Models;

namespace BarCrawler.ViewModels
{
    /// <summary>
    /// Viewmodel to contain a BarModel and a RegisterViewModel
    /// </summary>
    /// <seealso cref="BarModel"/>
    /// <seealso cref="RegisterViewModel"/>
    public class BigRegisterViewModel
    {
        /// <summary>
        /// Gets or sets the register view model.
        /// </summary>
        /// <value>
        /// The register view model.
        /// </value>
        /// <seealso cref="RegisterViewModel"/>
        public RegisterViewModel RegisterViewModel { get; set; }
        /// <summary>
        /// Gets or sets the bar model.
        /// </summary>
        /// <value>
        /// The bar model.
        /// </value>
        /// <seealso cref="BarModel"/>
        public BarModel BarModel { get; set; }
    }
}