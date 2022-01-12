#region Namespaces
using System;
using System.Windows;
using System.Windows.Media.Animation;
#endregion

namespace Xem.Animation
{
    /// <summary>
    /// Animation helpers for <see cref="Storyboard" />
    /// </summary>
    public static class StoryBoardHelper
    {
        /// <summary>
        /// Adds a slide from right in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRation">The rate of deceleration</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRation = 0.9f)
        {

            var animation = new ThicknessAnimation
            {
                // Aminates margin from right
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRation,
            };

            // Set the target property name
            string targetPropertyName = "Margin";
            Storyboard.SetTargetProperty(animation, new PropertyPath(targetPropertyName));

            // Add to storyboard
            storyboard.Children.Add(animation);

        }

        /// <summary>
        /// Adds a slide to left in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRation">The rate of deceleration</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRation = 0.9f)
        {

            var animation = new ThicknessAnimation
            {
                // Aminates margin from right
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRation,
            };

            // Set the target property name
            string targetPropertyName = "Margin";
            Storyboard.SetTargetProperty(animation, new PropertyPath(targetPropertyName));

            // Add to storyboard
            storyboard.Children.Add(animation);

        }


        /// <summary>
        /// Adds fade in to the animation
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {

            var animation = new DoubleAnimation
            {
                // Aminates margin from right
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0, // invisible
                To = 1, // fully visible
            };

            // Set the target property name
            string targetPropertyName = "Opacity";
            Storyboard.SetTargetProperty(animation, new PropertyPath(targetPropertyName));

            // Add to storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds fade in to the animation
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {

            var animation = new DoubleAnimation
            {
                // Aminates margin from right
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1, // visible
                To = 0, // invisible
            };

            // Set the target property name
            string targetPropertyName = "Opacity";
            Storyboard.SetTargetProperty(animation, new PropertyPath(targetPropertyName));

            // Add to storyboard
            storyboard.Children.Add(animation);
        }
    }


}
