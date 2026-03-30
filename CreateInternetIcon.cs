using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace frmdnschange
{
    /// <summary>
    /// Create internet-related icons
    /// </summary>
    public class CreateInternetIcon
    {
        /// <summary>
        /// Create an icon representing internet/network
        /// </summary>
        public static void CreateNetworkIcon(string outputPath, int size = 64)
        {
            Bitmap bitmap = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                int margin = size / 8;
                int innerSize = size - (margin * 2);

                // Draw globe/network
                using (Pen pen = new Pen(Color.FromArgb(0, 120, 215), 2))
                {
                    // Draw circles
                    g.DrawEllipse(pen, margin, margin, innerSize, innerSize);
                    g.DrawEllipse(pen, margin + innerSize / 4, margin + innerSize / 4,
                        innerSize / 2, innerSize / 2);

                    // Draw cross lines
                    g.DrawLine(pen, margin + innerSize / 2, margin,
                        margin + innerSize / 2, margin + innerSize);
                    g.DrawLine(pen, margin, margin + innerSize / 2,
                        margin + innerSize, margin + innerSize / 2);
                }

                // Draw nodes
                int nodeSize = 4;
                using (Brush brush = new SolidBrush(Color.FromArgb(0, 120, 215)))
                {
                    g.FillEllipse(brush, margin + innerSize / 2 - nodeSize / 2, margin - nodeSize / 2, nodeSize, nodeSize);
                    g.FillEllipse(brush, margin + innerSize - nodeSize / 2, margin + innerSize / 2 - nodeSize / 2, nodeSize, nodeSize);
                    g.FillEllipse(brush, margin + innerSize / 2 - nodeSize / 2, margin + innerSize - nodeSize / 2, nodeSize, nodeSize);
                    g.FillEllipse(brush, margin - nodeSize / 2, margin + innerSize / 2 - nodeSize / 2, nodeSize, nodeSize);
                }
            }

            IconGenerator.GenerateIcon(bitmap, outputPath);
            bitmap.Dispose();
        }

        /// <summary>
        /// Create an icon with globe and shield (internet protection)
        /// </summary>
        public static void CreateProtectionIcon(string outputPath, int size = 64)
        {
            Bitmap bitmap = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                int margin = size / 6;
                int globeSize = size - (margin * 2);

                // Draw globe
                using (Pen pen = new Pen(Color.FromArgb(150, 150, 150), 1))
                {
                    g.DrawEllipse(pen, margin, margin, globeSize, globeSize);
                }

                // Draw shield on globe
                int shieldSize = size / 3;
                int shieldX = margin + globeSize / 2 - shieldSize / 2;
                int shieldY = margin + globeSize / 2;

                using (Pen pen = new Pen(Color.FromArgb(0, 120, 215), 2))
                {
                    g.DrawRectangle(pen, shieldX, shieldY, shieldSize, shieldSize / 2);
                    g.DrawLine(pen, shieldX, shieldY + shieldSize / 2,
                        shieldX + shieldSize / 2, shieldY + shieldSize);
                    g.DrawLine(pen, shieldX + shieldSize / 2, shieldY + shieldSize,
                        shieldX + shieldSize, shieldY + shieldSize / 2);
                }

                using (Brush brush = new SolidBrush(Color.FromArgb(0, 120, 215)))
                {
                    g.FillRectangle(brush, shieldX + 2, shieldY + 2, shieldSize - 4, shieldSize / 2 - 4);
                }
            }

            IconGenerator.GenerateIcon(bitmap, outputPath);
            bitmap.Dispose();
        }
    }
}
