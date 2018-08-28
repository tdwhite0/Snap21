using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Run21
{
	public partial class BonusRoundControl : UserControl
	{
        public bool isOpen = true;

		public BonusRoundControl()
		{
			// Required to initialize variables
			InitializeComponent();
		}

        public void ShowSpeedBonus(bool yesno)
        {
            if (yesno == true)
            {
                showSpeedBonusPanel.Visibility = Visibility.Visible;
            }

            if (yesno == false)
            {
                showSpeedBonusPanel.Visibility = Visibility.Collapsed;
            }

        }

       
	}

    

}