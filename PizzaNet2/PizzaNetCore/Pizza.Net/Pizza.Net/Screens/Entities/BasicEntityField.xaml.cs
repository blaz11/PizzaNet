using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Pizza.Net.Screens.Entities
{
    public partial class BasicEntityField : UserControl
    {
        private DoubleAnimation _marqueeAnimation;
        private bool _animating;

        public BasicEntityField()
        {
            InitializeComponent();
        }

        private void MouseEnteredMarqueeHitbox(object sender, MouseEventArgs e)
        {
            StartMarqueeAnimation();
        }

        private void MouseLeftMarqueeHitbox(object sender, MouseEventArgs e)
        {
            StopMarqueeAnimation();
        }

        private void StartMarqueeAnimation()
        {
            if (!_animating && TextDoesNotFit())
            {
                _marqueeAnimation = new DoubleAnimation();
                _marqueeAnimation.From = 0;
                _marqueeAnimation.To = -MarqueeCanvas.ActualWidth;
                _marqueeAnimation.RepeatBehavior = RepeatBehavior.Forever;
                _marqueeAnimation.Duration = new Duration(TimeSpan.FromSeconds(3));
                MarqueeBlock.BeginAnimation(Canvas.LeftProperty, _marqueeAnimation);
                _animating = true;
            }
        }

        private bool TextDoesNotFit()
        {
            var formattedText = new FormattedText(
                MarqueeBlock.Text,
                CultureInfo.CurrentUICulture,
                FlowDirection.LeftToRight,
                new Typeface(MarqueeBlock.FontFamily, MarqueeBlock.FontStyle, MarqueeBlock.FontWeight, MarqueeBlock.FontStretch),
                MarqueeBlock.FontSize,
                Brushes.Black);
            return formattedText.Width > MarqueeCanvas.ActualWidth;
        }

        private void StopMarqueeAnimation()
        {
            _animating = false;
            MarqueeBlock.BeginAnimation(Canvas.LeftProperty, null);
        }
    }
}