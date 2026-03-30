using System;
using System.Drawing;

namespace frmdnschange
{
    /// <summary>
    /// Make icon utilities
    /// </summary>
    public class MakeIcon
    {
        /// <summary>
        /// Create an icon with a shield symbol for the DNS tool
        /// </summary>
        public static void CreateShieldIcon(string outputPath, int size = 64)
        {
            Bitmap bitmap = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Draw a shield shape
                int padding = size / 8;
                int shieldLeft = padding;
                int shieldTop = padding;
                int shieldWidth = size - (padding * 2);
                int shieldHeight = size - (padding * 2);

                // Shield outline
                using (Pen pen = new Pen(Color.FromArgb(0, 120, 215), 2))
                {
                    g.DrawRectangle(pen, shieldLeft, shieldTop, shieldWidth, shieldHeight / 2);
                    g.DrawLine(pen, shieldLeft, shieldTop + shieldHeight / 2, 
                        shieldLeft + shieldWidth / 2, shieldTop + shieldHeight);
                    g.DrawLine(pen, shieldLeft + shieldWidth / 2, shieldTop + shieldHeight,
                        shieldLeft + shieldWidth, shieldTop + shieldHeight / 2);
                }

                // Fill shield
                using (Brush brush = new SolidBrush(Color.FromArgb(0, 120, 215)))
                {
                    g.FillRectangle(brush, shieldLeft + 2, shieldTop + 2, shieldWidth - 4, shieldHeight / 2 - 4);
                }
            }

            IconGenerator.GenerateIcon(bitmap, outputPath);
            bitmap.Dispose();
        }

        /// <summary>
        /// Create a simple icon with initials
        /// </summary>
        public static void CreateInitialIcon(string initials, string outputPath, int size = 64)
        {
            Bitmap bitmap = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Background gradient
                using (Brush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    new Point(0, 0), new Point(size, size),
                    Color.FromArgb(0, 120, 215), Color.FromArgb(0, 90, 180)))
                {
                    g.FillRectangle(brush, 0, 0, size, size);
                }

                // Draw text
                using (Font font = new Font("Arial", size / 3, FontStyle.Bold))
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    g.DrawString(initials, font, Brushes.White, 
                        new RectangleF(0, 0, size, size), sf);
                }
            }

            IconGenerator.GenerateIcon(bitmap, outputPath);
            bitmap.Dispose();
        }
    }
}
