using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using toolkit = Microsoft.Phone.Controls;
using System.IO;
using System.Xml;
using System.Windows.Markup;
using Snap21;

namespace Run21.UserControls
{
    public partial class CardControl : UserControl
    {
        
        public Card Card
        {
            get { return (Card)GetValue(CardProperty); }
            set { SetValue(CardProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Card.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardProperty =
            DependencyProperty.Register("Card", typeof(Card), typeof(CardControl), new PropertyMetadata(null, OnCardChanged));


        private static void OnCardChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                
                return;
            }
            
            CardControl c = d as CardControl;
            // c.cardValue.Text = c.Card.Value.ToString();

            

            var resource = Application.GetResourceStream(c.Card.XamlLocation);
            if (resource == null)
            {
                resource = Application.GetResourceStream(new Uri(@"/Run21;component/UserControls/Cards/12C.xaml", UriKind.Relative));
            }


            using (StreamReader reader = new StreamReader(resource.Stream))
            {
                c.cardContent.Content = (Canvas)XamlReader.Load(reader.ReadToEnd());
            }

            var backresource = Application.GetResourceStream(new Uri(@"/Run21;component/UserControls/Cards/redback.xaml", UriKind.Relative));
            if (backresource == null)
            {
                backresource = Application.GetResourceStream(new Uri(@"/Run21;component/UserControls/Cards/12C.xaml", UriKind.Relative));
            }


            using (StreamReader reader = new StreamReader(backresource.Stream))
            {
                c.backContent.Content = (Canvas)XamlReader.Load(reader.ReadToEnd());
            }

          



        }

        private bool _front = true;
        private Storyboard _sb = new Storyboard();
        private TimeSpan _tsLastFrame = new TimeSpan();


        public CardControl()
        {
            InitializeComponent();

            InitializeCard();
            //    this.btnRotate.Click += new RoutedEventHandler(btnRotate_Click);
        }

        public void FlipCard()
        {
            if (_front)
            {
                _sb.Pause();
                _sb.AutoReverse = false;
                _sb.Begin();
                _front = false;
            }
            else
            {
                _sb.Pause();
                _sb.AutoReverse = true;
                _sb.Seek(_tsLastFrame);
                _sb.Resume();

                _front = true;
            }

          

       
        }

      

        public void InitializeCard()
        {

            TransformGroup transforms = new TransformGroup();
            ScaleTransform scale = new ScaleTransform();

            transforms.Children.Add(scale);
            this.screens.RenderTransform = transforms;

            Storyboard sbForward = new Storyboard();
            AnimateFlip(_sb, scale, out _tsLastFrame);

            if (!this.LayoutRoot.Resources.Contains("Animation"))
                this.LayoutRoot.Resources.Add("Animation", _sb);

            // valueBlock.Text = card.Value.ToString();

            ScaleTransform t = new ScaleTransform();
            t.ScaleX = .75;
            t.ScaleY = .75;



        }

        private TimeSpan AnimateFlip(Storyboard sb, ScaleTransform scale,
out TimeSpan tsLastFrame)
        {
            double speed = 4;
            double flipRotation = 0;
            double flipped = 2;
            tsLastFrame = new TimeSpan();
            TimeSpan tsSideFlipped = new TimeSpan();

            int frames = 1;
            DoubleAnimationUsingKeyFrames daX =
            new DoubleAnimationUsingKeyFrames();
            tsLastFrame = new TimeSpan();
            while (flipRotation != flipped * 180)
            {
                flipRotation += speed;
                double flipRadian = flipRotation * (Math.PI / 180);
                double size = Math.Cos(flipRadian);
                double scalar = (1 / (1 / size));

                DiscreteDoubleKeyFrame ddkfX = new DiscreteDoubleKeyFrame();
                ddkfX.Value = (size * scalar);

                tsLastFrame = TimeSpan.FromMilliseconds(frames * 7);

                //the first time we flip to negative capture the 
                //tsLastFrame so we know when we will need to
                //visualize the flip side
                flipped = (size < 0) ? +1 : +0;
                if (flipped == 1 && tsSideFlipped.Ticks == 0)
                {
                    tsSideFlipped = tsLastFrame;
                }

                ddkfX.KeyTime = KeyTime.FromTimeSpan(tsLastFrame);

                //add the DiscreteDoubleKeyFrame to the 
                //DoubleAnimationUsingKeyFrames
                daX.KeyFrames.Add(ddkfX);

                flipRotation %= 360;
                frames++;
            }

            Storyboard.SetTarget(daX, scale);
            Storyboard.SetTargetProperty(daX, new PropertyPath("(ScaleX)"));
            sb.Children.Add(daX);

            VisualizeSide(sb, tsSideFlipped, 0, TimeSpan.FromMilliseconds
                ((tsSideFlipped.Milliseconds + 100)),
                back.Opacity, this.back);
            VisualizeSide(sb, TimeSpan.FromMilliseconds((
                tsSideFlipped.Milliseconds - 100)), front.Opacity,
                tsSideFlipped, 0, this.front);
            back.Opacity = 0;
            return tsLastFrame;
        }

        private static KeySpline DefineKeySpline(double cp1X, double cp1Y, double cp2X, double cp2Y)
        {
            KeySpline ksStart = new KeySpline();
            ksStart.ControlPoint1 = new Point(cp1X, cp1Y);
            ksStart.ControlPoint2 = new Point(cp2X, cp2Y);
            return ksStart;
        }

        private void VisualizeSide(Storyboard sb, TimeSpan tsStart, double opacityStart, TimeSpan tsEnd, double opacityEnd, UIElement side)
        {
            DoubleAnimationUsingKeyFrames daOpacity = new DoubleAnimationUsingKeyFrames();
            SplineDoubleKeyFrame sdkfStart = new SplineDoubleKeyFrame();
            sdkfStart.Value = opacityStart;
            sdkfStart.KeyTime = tsStart;
            sdkfStart.KeySpline = DefineKeySpline(0, 0, 1, 1);
            daOpacity.KeyFrames.Add(sdkfStart);

            SplineDoubleKeyFrame sdkfEnd = new SplineDoubleKeyFrame();
            sdkfEnd.Value = opacityEnd;
            sdkfEnd.KeyTime = tsEnd;
            sdkfEnd.KeySpline = DefineKeySpline(0, 0, 1, 1);
            daOpacity.KeyFrames.Add(sdkfEnd);

            Storyboard.SetTarget(daOpacity, side);
            Storyboard.SetTargetProperty(daOpacity, new PropertyPath("(UIElement.Opacity)"));

            sb.Children.Add(daOpacity);
        }

        
        private static SplineDoubleKeyFrame CreateDoubleAnimation(ref Storyboard sb,
     TranslateTransform translation, PropertyPath property)
        {
            DoubleAnimationUsingKeyFrames da = new DoubleAnimationUsingKeyFrames();
            da.SetValue(NameProperty, string.Concat("da_", property));

            SplineDoubleKeyFrame sdkf = new SplineDoubleKeyFrame();
            sdkf.SetValue(NameProperty, string.Concat("sdkf_", property));

            sdkf.Value = 0;
            sdkf.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.25));

            //define the KeySpline
            KeySpline ksX = new KeySpline();
            ksX.ControlPoint1 = new Point(1.0, 0.25);
            ksX.ControlPoint2 = new Point(0.75, 1.0);
            sdkf.KeySpline = ksX;

            //add the SplineDoubleKeyFrame to the DoubleAnimationUsingKeyFrames
            da.KeyFrames.Add(sdkf);

            //define which TranslateTransform property will be targeted by the DoubleAnimation
            Storyboard.SetTarget(da, translation);
            Storyboard.SetTargetProperty(da, property);
            sb.Children.Add(da);
            return sdkf;
        }

        public void AttachEvent()
        {
            var gestureListener = toolkit.GestureService.GetGestureListener(this);
            gestureListener.Tap -= new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);


        }

        private void GestureListener_Tap(object sender, toolkit.GestureEventArgs e)
        {
            FlipCard();

        }

        
       

    }
}
