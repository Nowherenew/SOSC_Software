using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stactistics_And_Optimization_Of_Steel_Cutting__Without_.Net_Framework_
{
    class SteelLengthCalculation
    {
        public SteelLengthCalculation()
        {
            l1 = 0;
            l2 = 0;
            l3 = 0;
            l4 = 0;
            l5 = 0;
            l6 = 0;
            l7 = 0;
        }
        ~SteelLengthCalculation()
        {
        }
        public int l1 { get; set; }
        public int l2 { get; set; }
        public int l3 { get; set; }
        public int l4 { get; set; }
        public int l5 { get; set; }
        public int l6 { get; set; }
        public int l7 { get; set; }
        public double LengthCalculation(string PictureTag)
        {
            double BarLength = 0;
            if (PictureTag == "1")
            {

            }
            else if (PictureTag == "2")
            {

            }
            else if(PictureTag == "3")
            {

            }
            return BarLength;
        }
    }
}
