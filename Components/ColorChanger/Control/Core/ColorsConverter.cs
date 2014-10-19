using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace ArduinoManagementSystem.Components.ColorChanger.Control.Core
{
    public static class ColorsConverter
    {
        public static Color CountToColor(double x, byte alpha, double size)
        {
            double section = size / 7.0;
            byte r;
            byte g;
            byte b;
            if (alpha > 255) alpha = 255;


            if (x >= 0 && x <= section)
            {
                b = (byte)((x / section) * 255.0);
                g = (byte)((x / section) * 255.0);
                r = (byte)((x / section) * 255.0);
                return Color.FromArgb((byte)alpha, r, g, b);
            }



            if (x > section && x <= section * 2)
            {
                b = (byte)(255 - (int)(((x - section) / section) * 255.0));
                g = (byte)(255 - (int)(((x - section) / section) * 255.0));
                r = 255;
                return Color.FromArgb((byte)alpha, r, g, b);
            }

            if (x > section * 2 && x <= section * 3)
            {
                b = 0;
                g = (byte)(((x - section * 2) / section) * 255.0);
                r = 255;
                return Color.FromArgb((byte)alpha, r, g, b);
            }


            if (x > section * 3 && x <= section * 4)
            {
                b = 0;
                g = (byte)255;
                r = (byte)(255 - (int)(((x - section * 3) / section) * 255.0));
                return Color.FromArgb((byte)alpha, r, g, b);
            }


            if (x > section * 4 && x <= section * 5)
            {
                b = (byte)(((x - section * 4) / section) * 255.0);
                g = 255;
                r = 0;
                return Color.FromArgb((byte)alpha, r, g, b);
            }

            if (x > section * 5 && x <= section * 6)
            {
                b = 255;
                g = (byte)(255 - (int)(((x - section * 5) / section) * 255.0));
                r = 0;
                return Color.FromArgb((byte)alpha, r, g, b);
            }


            if (x > section * 6 && x <= section * 7)
            {
                b = 255;
                g = 0;
                r = (byte)(((x - section * 6) / section) * 255.0);
                return Color.FromArgb((byte)alpha, r, g, b);
            }
            return Color.FromArgb(255, 255, 255, 255);
        }
        public static int ColorToCount(Color color, int size)
        {
            double section = size / 7.0;


            if (color.B == 255 && color.G == 0)
            {
                return (int)section * 6 + (int)((color.R / 255.0) * section);
            }

            if (color.R == 255 && color.B == 0)
            {
                return (int)section * 2 + (int)((color.G / 255.0) * section);
            }

            if (color.R == 255)
            {
                return (int)section + ((int)section - (int)((color.G / 255.0) * section));
            }

            if (color.G == 255 && color.B == 0)
            {
                return (int)section * 3 + ((int)section - (int)((color.R / 255.0) * section));
            }

            if (color.G == 255 && color.R == 0)
            {
                return (int)section * 4 + (int)((color.B / 255.0) * section);
            }

            if (color.B == 255 && color.R == 0)
            {
                return (int)section * 5 + ((int)section - (int)((color.G / 255.0) * section));
            }


            if (color.R > 0 && color.R < 255)
            {
                return (int)((color.R / 255.0) * section);
            }
            if (color.G > 0 && color.G < 255)
            {
                return (int)((color.G / 255.0) * section);
            }
            if (color.B > 0 && color.B < 255)
            {
                return (int)((color.B / 255.0) * section);
            }
            //if (color.G == 255 && color.B == 0)
            //{
            //}
            //if (color.R == 0 && color.G == 255)
            //{
            //    return 170 + (int)((color.B / 255.0) * 85.0);
            //}
            //if (color.R == 0 && color.B == 255)
            //{
            //    return 255 + (85 - (int)((color.G / 255.0) * 85.0));
            //}
            //if (color.G == 0 && color.B == 255)
            //{
            //    return 340 + (int)((color.R / 255.0) * 85.0);
            //}
            //if (color.R == 255 && color.G == 0)
            //{
            //    return 425 + (85 - (int)((color.B / 255.0) * 85.0));
            //}
            //if (color.R == 255 )
            //{
            //    return 510 + (int)((color.B / 255.0) * 85.0);
            //}
            return 0;
        }
        public static Color RemoveBlackLigth(Color color)
        {
            return Color.FromArgb(Math.Max(color.R, Math.Max(color.G, color.B)),color.R,color.G,color.B);
        }
    }
}
