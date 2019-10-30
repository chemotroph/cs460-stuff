using System.Drawing;
using System;
namespace Lab4Learning.Models
{

    public class GradientModel
    {
        private Color[] gradient;
        public GradientModel(string startColor, string endColor, int numColors)
        {
            gradient= new Color[numColors];

           Color Color1 = System.Drawing.ColorTranslator.FromHtml(startColor);
            Color Color2 = System.Drawing.ColorTranslator.FromHtml(endColor);


            HSVcolor start = new HSVcolor(Color1);
            HSVcolor end = new HSVcolor(Color2);


            double hueDifference = start.h-end.h;
            double satDifference = start.s - end.s;
            double valDifference = start.v - end.v;

            double dhue = Math.Abs(hueDifference / numColors);
            double dsat = Math.Abs(satDifference / numColors);
            double dval = Math.Abs(valDifference / numColors);

            double currenth = start.h;
            double currents = start.s;
            double currentv = start.v;

           



            for (int i =0; i<numColors; i++)
            {
                currenth += dhue;
                currents += dsat;
                currentv += dval;

                System.Diagnostics.Debug.WriteLine("ADDING H S V:: " + currenth + " " + currents + " " + currentv);

                gradient[i] = ColorFromHSV(currenth,currents,currentv);

            }



            //turn input to system.drawing.color 

            //turn color to hsv colors

            //determine difference between each property of the colors

            //determine size of steps in interpolation

            //generate list of colors
        }

        public Color[] getGradient()
        {
            return gradient;
        }


        public Color[] OnPost()
        {

            return gradient;
        }


        //taken from lab manual
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = (int)(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = (int)(value);
            int p = (int)(value * (1 - saturation));
            int q = (int)(value * (1 - f * saturation));
            int t = (int)(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }





    }
    public class HSVcolor
    {
        public float h, s, v;

        public HSVcolor(Color myColor)
        {

            h = myColor.GetHue();
            s = myColor.GetSaturation();
            v = myColor.GetBrightness();
            System.Diagnostics.Debug.WriteLine("huedifference HSV::: " + h+" "+s+" "+v);

        }



    }


}
