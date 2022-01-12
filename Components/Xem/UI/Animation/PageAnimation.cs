#region Namespaces
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
#endregion

namespace Xem.Animation
{
    #region Enumeration
    /// <summary>
    /// Styles of page animation for apperaing/dissapearing
    /// </summary>
    public enum PageAnimationEnum
    {
        /// <summary>
        /// None animation takes place.
        /// </summary>
        NoneAnimation = 0,

        /// <summary>
        /// The page slides in and fades in from the right
        /// </summary>
        SlideAndFadeFromRight = 1,

        /// <summary>
        /// The page slides out and fades out to the left
        /// </summary>
        SlideAndFadeOutToLeft = 2,
    }
    #endregion

    #region Animation Helpers
    /// <summary>
    /// Helpe to animate pages in specific ways
    /// </summary>
    public static class PageAnimation
    {

        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {

            // Create storyboard
            var storyboard = new Storyboard();

            // Add slide-from-right animation
            storyboard.AddSlideFromRight(seconds, page.WindowWidth);

            // Add slide-fade-in animation
            storyboard.AddFadeIn(seconds);

            // Run animation
            storyboard.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait the animation to finish
            await Task.Delay((int)(seconds * 1000));
        }


        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {

            // Create storyboard
            var storyboard = new Storyboard();

            // Add slide-to-left animation
            storyboard.AddSlideToLeft(seconds, page.WindowWidth / 2);

            // Add slide-fade-in animation
            storyboard.AddFadeOut(seconds);

            // Run animation
            storyboard.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait the animation to finish
            await Task.Delay((int)(seconds * 1000));
        }
    }
    #endregion
}
