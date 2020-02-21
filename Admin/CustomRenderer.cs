#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Forms.Gauge;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AManager
{
    public partial class CustomRenderer : IRadialGaugeRenderer
    {
        #region Varaibles
        /// </summary>
        /// Gets the radial gauge
        /// </summary>
        private RadialGauge m_RadialGauge;

        /// <summary>
        /// Used to set bounds for the Font
        /// </summary>
        Single fontBoundY1, fontBoundY2;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the Radial gauge
        /// </summary>
        internal RadialGauge RadialGauge
        {
            get
            {
                return m_RadialGauge;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor of the Renderer class
        /// </summary>
        /// <param name="radialGauge"></param>
        public CustomRenderer(RadialGauge radialGauge)
        {
            m_RadialGauge = radialGauge;

        }
        #endregion

        /// <summary>
        /// Used to calculate the text bounds 
        /// </summary>
        /// <param name="e">Paintevent arguement</param>
        /// <param name="m_font">Font used in Radial gauge</param>
        public void AdjustFontBounds(Graphics g, Font m_font)
        {
            //find upper and lower bounds for numeric characters
            Int32 c1;
            Int32 c2;
            Boolean boundFound;
            Bitmap b;
            SolidBrush backBrush = new SolidBrush(Color.White);
            SolidBrush foreBrush = new SolidBrush(Color.Black);
            SizeF boundingBox;

            boundingBox = g.MeasureString("0123456789", m_font, -1, StringFormat.GenericTypographic);
            b = new Bitmap((Int32)(boundingBox.Width), (Int32)(boundingBox.Height));
            g = Graphics.FromImage(b);
            g.FillRectangle(backBrush, 0.0F, 0.0F, boundingBox.Width, boundingBox.Height);
            g.DrawString("0123456789", m_font, foreBrush, 0.0F, 0.0F, StringFormat.GenericTypographic);

            fontBoundY1 = 0;
            fontBoundY2 = 0;
            c1 = 0;
            boundFound = false;
            while ((c1 < b.Height) && (!boundFound))
            {
                c2 = 0;
                while ((c2 < b.Width) && (!boundFound))
                {
                    if (b.GetPixel(c2, c1) != backBrush.Color)
                    {
                        fontBoundY1 = c1;
                        boundFound = true;
                    }
                    c2++;
                }
                c1++;
            }

            c1 = b.Height - 1;
            boundFound = false;
            while ((0 < c1) && (!boundFound))
            {
                c2 = 0;
                while ((c2 < b.Width) && (!boundFound))
                {
                    if (b.GetPixel(c2, c1) != backBrush.Color)
                    {
                        fontBoundY2 = c1;
                        boundFound = true;
                    }
                    c2++;
                }
                c1--;
            }
        }

        /// <summary>
        /// Method used to draw outer arc.
        /// </summary>
        /// <param name="e">Paintevent arguement</param>
        /// <param name="m_GaugeArcStart">Arc start position</param>
        /// <param name="m_GaugeArcEnd">Arc end position</param>
        /// <param name="m_Center">Center point for gauge</param>
        public void DrawOuterArc(System.Drawing.Graphics e, int m_GaugeArcStart, int m_GaugeArcEnd, System.Drawing.Point m_Center, int GaugeRadius)
        {
            e.SmoothingMode = SmoothingMode.AntiAlias;
            e.PixelOffsetMode = PixelOffsetMode.HighQuality;
            GraphicsPath pth = new GraphicsPath();
            Color c = this.RadialGauge.Parent != null ? this.RadialGauge.Parent.BackColor : Color.Empty;
            Rectangle r = new Rectangle(0, 0, this.RadialGauge.Width, this.RadialGauge.Height);
            System.Drawing.Drawing2D.GraphicsPath basePath = new System.Drawing.Drawing2D.GraphicsPath();

            int x = this.RadialGauge.Width;
            int y = this.RadialGauge.Height;

            //Define rectangles inside which we will draw circles.

            Rectangle rect = new Rectangle(0 + 10, 0 + 10, (int)x - 20, (int)y - 20);
            Rectangle rectrim = new Rectangle(0 + 23, 0 + 23, (int)x - 46, (int)y - 46);
            Rectangle rectinner = new Rectangle(0 + 40, 0 + 40, (int)x - 80, (int)y - 80);

            if (GaugeRadius > 0)
            {
                e.DrawArc(new Pen(this.RadialGauge.GaugeArcColor, 7), new Rectangle(m_Center.X - GaugeRadius, m_Center.Y - GaugeRadius,
                   2 * GaugeRadius, 2 * GaugeRadius), m_GaugeArcStart, m_GaugeArcEnd );
            }
        }

        /// <summary>
        /// Method used to draw customization needle.
        /// </summary>
        /// <param name="graphics">Graphics</param>
        /// <param name="needle">Needle used in the gauge</param>
        /// <param name="m_gaugeArcStart">Arc start position</param>
        /// <param name="m_gaugeArcEnd">Arc end position</param>
        /// <param name="m_NeedleRadius">Needle radius</param>
        /// <param name="m_NeedleWidth">Needle width</param>
        /// <param name="m_center">Center point of the gauge</param>
        public void DrawMultipleNeedle(System.Drawing.Graphics Graphics, Needle Needle, int GaugeArcStart, int GaugeArcEnd, int NeedleRadius, int NeedleWidth, System.Drawing.Point Center)
        {
        }

        /// <summary>
        /// Method used to draw needle
        /// </summary>
        /// <param name="graphics">Graphics</param>
        /// <param name="m_GaugeArcStart">Arc start position</param>
        /// <param name="m_GaugeArcEnd">Arc end position</param>
        /// <param name="m_NeedleRadius">Needle radius</param>
        /// <param name="m_NeedleWidth">Needle width</param>
        /// <param name="m_Center">Center point of the gauge</param>
        public void DrawNeedle(System.Drawing.Graphics Graphics, int ArcStart, int ArcEnd, int NeedleRadius, int NeedleWidth, System.Drawing.Point Center)
        {
        }

        /// <summary>
        /// Used to draw the  label of the gauge
        /// </summary>
        /// <param name="e">paint event arguement</param>
        /// <param name="m_Center">Center point of the gauge</param>
        public void DrawGaugeLabel(Graphics e, Point Center, int GaugeRadius)
        {
            string additionalString = string.Empty;
            if (RadialGauge.GaugeLabel == "Student Present")
            {
                //additionalString = string.Empty;
                //Image newImage = Image.FromFile(@"E:\Project_2\Alog\Admin\1_food.png");
                //e.DrawImage(newImage, new Point(Center.X - 35, Center.Y - 55));
            }
            SolidBrush br = new SolidBrush(this.RadialGauge.GaugeLableColor);
            SizeF s = e.MeasureString(RadialGauge.GaugeLabel, RadialGauge.GaugeLableFont);
            e.DrawString(RadialGauge.GaugeLabel, RadialGauge.GaugeLableFont, br,
                new Point((int)((Center.X) - (s.Width / 2)), (int)(Center.Y + GaugeRadius / 2) + 15));
            using (Font f = new Font(RadialGauge.GaugeValueFont.Name, RadialGauge.GaugeValueFont.Size + 4, FontStyle.Bold))
            {
                s = e.MeasureString(RadialGauge.Value.ToString() + additionalString, RadialGauge.GaugeValueFont);
                Point p = new Point((int)((Center.X) - (s.Width / 2)), (int)(Center.Y +GaugeRadius / 5));
                // Create rectangle for region.
                Rectangle excludeRect = new Rectangle(p.X - 3, (p.Y - 4) + 30, 32, 30);

                // Create region for exclusion.
                Region excludeRegion = new Region(excludeRect);

                // Set clipping region to exclude region.
                e.ExcludeClip(excludeRegion);

                // Fill large rectangle to show clipping region.
                br = new SolidBrush(this.RadialGauge.GaugeValueColor);
                e.DrawString(RadialGauge.Value.ToString() + additionalString, f, br, p);

            }
            br.Dispose();
        }

         /// <summary>
        /// Used to draw the ranges for the Gauge
        /// </summary>
        /// <param name="gr">Graphics</param>
        /// <param name="gp">Graphics path</param>
        /// <param name="m_GaugeArcStart">Start poistion of the arc</param>
        /// <param name="m_GaugeArcEnd">End position of the arc</param>
        /// <param name="m_GaugeArcRadius">Radius of the arc</param>
        /// <param name="m_Center">Center of the gauge</param>
        public void DrawRanges(Graphics gr, GraphicsPath gp, Int32 m_GaugeArcStart, Int32 m_GaugeArcEnd, Int32 m_GaugeArcRadius, Point m_Center)
        {
            Single rangeStartAngle;
            Single rangeSweepAngle;

            foreach (Syncfusion.Windows.Forms.Gauge.Range ptrRange in RadialGauge.Ranges)
            {
                if (ptrRange.EndValue > ptrRange.StartValue)
                {
                    rangeStartAngle = m_GaugeArcStart + (ptrRange.StartValue - RadialGauge.MinimumValue) * m_GaugeArcEnd / (RadialGauge.MaximumValue - RadialGauge.MinimumValue);
                    rangeSweepAngle = (ptrRange.EndValue - ptrRange.StartValue) * m_GaugeArcEnd / (RadialGauge.MaximumValue - RadialGauge.MinimumValue);
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    int m_GaugeArcRadius1 = m_GaugeArcRadius + RadialGauge.MajorTickMarkHeight;
                    gr.DrawArc(new Pen(ptrRange.Color, ptrRange.Height), new Rectangle(m_Center.X - m_GaugeArcRadius1, m_Center.Y - m_GaugeArcRadius1, 2 * m_GaugeArcRadius1, 2 * m_GaugeArcRadius1), rangeStartAngle, rangeSweepAngle);
                }
            }
        }

        /// <summary>
        /// Used to draw the tick marks of the gauge
        /// </summary>
        /// <param name="graphics">Graphics</param>
        /// <param name="gp">Graphics Path</param>
        /// <param name="m_GaugeArcRadius">Radius of the arc</param>
        /// <param name="m_GaugeArcStart">Start poistion of the arc</param>
        /// <param name="m_GaugeArcEnd">End position of the arc</param>
        /// <param name="m_MajorTickMarkWidth">Tick mark width</param>
        /// <param name="m_Center">Center of the gauge</param>
        public void DrawTickMarks(Graphics graphics, GraphicsPath gp, Int32 m_GaugeArcRadius, Int32 m_GaugeArcStart, Int32 m_GaugeArcEnd, Int32 m_MajorTickMarkWidth, Point m_Center, int m_ScaleNumbersRadius)
        {
        }

        public void UpdateRenderer(System.Windows.Forms.PaintEventArgs e)
        {
            int Archradius = (int)(RadialGauge.Width / 2.2) ; //80
            Point loc = new Point((RadialGauge.Width / 2), RadialGauge.Height / 2);
            AdjustFontBounds(e.Graphics, RadialGauge.Font);
            DrawOuterArc(e.Graphics, 135, 270, loc, Archradius);
            DrawGaugeLabel(e.Graphics, loc, RadialGauge.Width / 2);
            DrawRanges(e.Graphics, new System.Drawing.Drawing2D.GraphicsPath(), 135, 270, Archradius, loc);
        }

        public void DrawCircle(Graphics graphics, Point m_Center, int gaugeRadius, int startAngle, int sweepAngle, float arcThickness, Color arcColor, Color fillColor)
        {
            
        }
    }

}
