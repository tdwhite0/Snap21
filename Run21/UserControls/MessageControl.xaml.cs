using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using toolkit = Microsoft.Phone.Controls;

namespace Run21
{
	public partial class MessageControl : UserControl
	{
		public MessageControl()
		{
			// Required to initialize variables
			InitializeComponent();


              var gestureListener = toolkit.GestureService.GetGestureListener(this);
            gestureListener.Tap += new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);





            //    shownCard.Card = Deck.DrawCards(1).FirstOrDefault() ;
        }


        private void GestureListener_Tap(object sender, toolkit.GestureEventArgs e)
        {
            MessageBox.Show("hey");
        }
	}
}