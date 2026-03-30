using System;
using System.Drawing;
using System.IO;

namespace frmdnschange
{
    /// <summary>
    /// Icon generator class for creating icon files from images
    /// </summary>
    public class IconGenerator
    {
        /// <summary>
        /// Generate an icon file from a Bitmap
        /// </summary>
        public static void GenerateIcon(Bitmap bitmap, string outputPath)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");

            // Convert bitmap to icon and save
            using (Icon icon = Icon.FromHandle(bitmap.GetHicon()))
            {
                using (FileStream fs = new FileStream(outputPath, FileMode.Create))
                {
                    icon.Save(fs);
                }
            }
        }

        /// <summary>
        /// Create a simple icon with text
        /// </summary>
        public static void CreateTextIcon(string text, string outputPath, int size = 64)
        {
            Bitmap bitmap = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Background color - blue
                g.Clear(Color.FromArgb(0, 120, 215));

                // Draw text
                using (Font font = new Font("Arial", size / 4, FontStyle.Bold))
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    g.DrawString(text, font, Brushes.White, 
                        new RectangleF(0, 0, size, size), sf);
                }
            }

            GenerateIcon(bitmap, outputPath);
            bitmap.Dispose();
        }
    }
}