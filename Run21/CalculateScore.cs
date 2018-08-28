using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections;
using Run21.UserControls;
using System.Collections.Generic;

namespace Snap21
{
    public static class CalculateScore
    {

        public static int GetScore(List<SlotControl> slots)
        {
            int totalScore = 0;
            foreach (var slot in slots)
            {
                if (slot.Hand.Total == 20)
                {
                    //25 pt bonus for a 20
                    totalScore += 25;

                }

                if (slot.Hand.Total == 21)
                {
                    //100 pt bonus for a 21
                    totalScore += 25;

                }



            }

            return 0;
        }



    }
}
