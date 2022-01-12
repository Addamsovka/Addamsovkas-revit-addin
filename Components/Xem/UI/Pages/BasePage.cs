#region Namespaces
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Xem.Animation;
#endregion

namespace Xem
{
    /// <summary>
    /// A base page for all pages to gain base functionality
    /// </summary>
    public class BasePage<VM> : Page where VM : BaseViewModel, new()
    {
        #region Protected Members
        /// <summary>
        /// Represents Viewmodel of this page
        /// </summary>
        protected VM viewModel;
        #endregion

        #region Public Properties

        /// <summary>
        /// The animation the play when the page first loaded.
        /// </summary>
        public PageAnimationEnum PageLoadAnimation { get; set; } = PageAnimationEnum.SlideAndFadeFromRight;


        /// <summary>
        /// The animation the play when the page is unloaded.
        /// </summary>
        public PageAnimationEnum PageUnloadAmination { get; set; } = PageAnimationEnum.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time to amimation take to complete.
        /// </summary>
        public float AnimationDuration { get; set; } = 1.6f;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BasePage()
        {
            // When Animating in, hide to begin with
            if (this.PageLoadAnimation != PageAnimationEnum.NoneAnimation)
                this.Visibility = Visibility.Collapsed;

            // Listen out for the the page loaded
            this.Loaded += BasePage_Loaded;

            // Create and attach view model to the page
            this.viewModel = new VM();
            this.DataContext = viewModel;
        }
        #endregion


        #region Animation methods

        /// <summary>
        /// When the page is loaded perform all required animations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            await AnimateIn();
        }

        /// <summary>
        /// Animate page In
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimationEnum.NoneAnimation)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimationEnum.SlideAndFadeFromRight:

                    // Run Animation
                    await this.SlideAndFadeInFromRight(this.AnimationDuration);

                    break;
            }
        }
        public async Task AnimateOut()
        {
            if (this.PageUnloadAmination == PageAnimationEnum.NoneAnimation)
                return;

            switch (this.PageUnloadAmination)
            {
                case PageAnimationEnum.SlideAndFadeOutToLeft:

                    // Run Animation
                    await this.SlideAndFadeOutToLeft(this.AnimationDuration);

                    break;
            }
        }
        #endregion

    }
}
