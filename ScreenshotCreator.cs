using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ArduinoManagementSystem.Components.SystemController.Control;

namespace ArduinoManagementSystem
{
    public static class ScreenshotCreator
    {
        public static BitmapImage TakeImageFrom(UIElement source)
        {
            BitmapImage bitImg = new BitmapImage();

            bitImg.BeginInit();

            MemoryStream ms = new MemoryStream(GetJpgImage(source, 1, 100));

            bitImg.StreamSource = ms;
            
            bitImg.EndInit();


           return bitImg;
        }

        public static DrawingImage TakeImageFromSource(UIElement source)
        {
            GeometryDrawing geometryDrawing = new GeometryDrawing
                                                  {
                                                      Geometry = new RectangleGeometry
                                                          (
                                                          new Rect(0, 0, 912, 467)
                                                          ),
                                                      Brush = new VisualBrush(source)
                                                                  {
                                                                      Stretch = Stretch.None,
                                                                      AlignmentY = AlignmentY.Bottom
                                                                  }
                                                  };
            return new DrawingImage(geometryDrawing);
        }


        ///
        /// Gets a JPG "screenshot" of the current UIElement
        ///
        /// UIElement to screenshot
        /// Scale to render the screenshot
        /// JPG Quality
        /// Byte array of JPG data
        private static byte[] GetJpgImage(UIElement source, double scale, int quality)
        {
            //var aaa = source as UserControl;
            //var bbb = aaa.Width;
            //double actualHeight = 700;
            //double actualWidth = 1200;
            //source.Measure(new Size(912, 467));
            //source.Arrange(new Rect(new Size(912, 467)));
            
            
            double actualHeight = source.RenderSize.Height;
            double actualWidth = source.RenderSize.Width;
            
            double renderHeight = actualHeight * scale;
            double renderWidth = actualWidth * scale;

            var renderTarget = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
            var sourceBrush = new VisualBrush(source);

            var drawingVisual = new DrawingVisual();
            var drawingContext = drawingVisual.RenderOpen();

            using (drawingContext)
            {
                drawingContext.PushTransform(new ScaleTransform(scale, scale));
                drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(actualWidth, actualHeight)));
            }

            renderTarget.Render(drawingVisual);

            //Viewbox viewbox = new Viewbox();

            //viewbox.Child = CloneObject(source);
            //viewbox.Measure(new Size(912, 467));
            //viewbox.Arrange(new Rect(0, 0, 912, 467));
            //viewbox.UpdateLayout();
            //var renderTarget = new RenderTargetBitmap(912, 467, 96, 96, PixelFormats.Pbgra32);
            //renderTarget.Render(viewbox);

 
            var jpgEncoder = new JpegBitmapEncoder {QualityLevel = quality};
            jpgEncoder.Frames.Add(BitmapFrame.Create(renderTarget));

            Byte[] _imageArray;

            using (var outputStream = new MemoryStream())
            {
                jpgEncoder.Save(outputStream);
                _imageArray = outputStream.ToArray();
            }

            return _imageArray;
        }

        private static T XamlClone<T>(T source)
        {
            string savedObject = System.Windows.Markup.XamlWriter.Save(source);

            // Load the XamlObject
            StringReader stringReader = new StringReader(savedObject);
            System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(stringReader);
            T target = (T)System.Windows.Markup.XamlReader.Load(xmlReader);
            return target;
        }

        private static T CloneObject<T>(T source)
        {
            Type t = source.GetType();
            PropertyInfo[] properties = t.GetProperties();
            Object p = t.InvokeMember("", BindingFlags.CreateInstance, null, source, null);

            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    pi.SetValue(p, pi.GetValue(source, null), null);
                }
            }

            return (T)p;
        }

    }
}
