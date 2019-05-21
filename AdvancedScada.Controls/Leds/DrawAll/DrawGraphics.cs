using AdvancedScada.Controls.Enum;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AdvancedScada.Controls.Leds.DrawAll
{
    public class DrawGraphics
    {
        public DrawGraphics()
        {
        }

        public void SetRect(Graphics g, Rectangle rec_width, int m_OuterBorderLength, Color m_OuterBorderDarkColor, Color m_OuterBorderLightColor, int m_MiddleBorderLength, Color m_MiddleBorderColor, int m_InnerBorderLength, Color m_InnerBorderDarkColor, Color m_InnerBorderLightColor, int m_BorderExteriorLength, Color m_BorderExteriorColor, DAS_BorderGradientStyle m_BorderGradientType, int m_BorderGradientAngle, float m_BorderGradientRate, float m_BorderGradientLightPos1, float m_BorderGradientLightPos2, float m_BorderLightIntermediateBrightness)
        {
            LinearGradientBrush linearGradientBrush;
            float height;
            float single;
            float width;
            float height1;
            SolidBrush solidBrush;
            Region region;
            Pen pen;
            Point[] point;
            if ((m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength) * 2 >= rec_width.Width || (m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength) * 2 >= rec_width.Height)
            {
                return;
            }
            Rectangle rectangle = new Rectangle(rec_width.Left + m_BorderExteriorLength, rec_width.Top + m_BorderExteriorLength, rec_width.Width - 2 * m_BorderExteriorLength, rec_width.Height - 2 * m_BorderExteriorLength);
            Rectangle rectangle1 = new Rectangle(rec_width.Left + m_BorderExteriorLength + m_OuterBorderLength, rec_width.Top + m_BorderExteriorLength + m_OuterBorderLength, rec_width.Width - 2 * (m_BorderExteriorLength + m_OuterBorderLength), rec_width.Height - 2 * (m_BorderExteriorLength + m_OuterBorderLength));
            Rectangle rectangle2 = new Rectangle(rec_width.Left + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength, rec_width.Top + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength, rec_width.Width - 2 * (m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength), rec_width.Height - 2 * (m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength));
            Rectangle rectangle3 = new Rectangle(rec_width.Left + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength, rec_width.Top + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength, rec_width.Width - 2 * (m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength), rec_width.Height - 2 * (m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength));
            if (m_BorderGradientType == DAS_BorderGradientStyle.BGS_Flat)
            {
                PointF[] left = new PointF[5];
                left[0].X = (float)rectangle.Left;
                left[0].Y = (float)rectangle.Top;
                left[1].X = (float)rectangle.Left;
                left[1].Y = (float)(rectangle.Top + rectangle.Height);
                if (rectangle.Width < rectangle.Height)
                {
                    left[2].X = (float)rectangle.Left + (float)rectangle.Width / 2f;
                    left[2].Y = (float)(rectangle.Top + rectangle.Height) - (float)rectangle.Width / 2f;
                    left[3].X = (float)rectangle.Left + (float)rectangle.Width / 2f;
                    left[3].Y = (float)rectangle.Top + (float)rectangle.Width / 2f;
                }
                else
                {
                    left[2].X = (float)rectangle.Left + (float)rectangle.Height / 2f;
                    left[2].Y = (float)rectangle.Top + (float)rectangle.Height / 2f;
                    left[3].X = (float)(rectangle.Left + rectangle.Width) - (float)rectangle.Height / 2f;
                    left[3].Y = (float)rectangle.Top + (float)rectangle.Height / 2f;
                }
                left[4].X = (float)(rectangle.Left + rectangle.Width);
                left[4].Y = (float)rectangle.Top;
                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddPolygon(left);
                if (m_OuterBorderLength > 0)
                {
                    Region region1 = new Region(rectangle);
                    region1.Exclude(rectangle1);
                    SolidBrush solidBrush1 = new SolidBrush(m_OuterBorderLightColor);
                    Region region2 = region1.Clone();
                    region2.Intersect(graphicsPath);
                    g.FillRegion(solidBrush1, region2);
                    solidBrush1.Dispose();
                    region2.Dispose();
                    SolidBrush solidBrush2 = new SolidBrush(m_OuterBorderDarkColor);
                    Region region3 = region1.Clone();
                    region3.Exclude(graphicsPath);
                    g.FillRegion(solidBrush2, region3);
                    solidBrush2.Dispose();
                    region3.Dispose();
                    region1.Dispose();
                }
                if (m_MiddleBorderLength > 0)
                {
                    Region region4 = new Region(rectangle1);
                    region4.Exclude(rectangle2);
                    SolidBrush solidBrush3 = new SolidBrush(m_MiddleBorderColor);
                    g.FillRegion(solidBrush3, region4);
                    Pen pen1 = new Pen(solidBrush3);
                    g.DrawRectangle(pen1, rectangle1);
                    g.DrawRectangle(pen1, rectangle2);
                    pen1.Dispose();
                    solidBrush3.Dispose();
                    region4.Dispose();
                }
                if (m_InnerBorderLength > 0)
                {
                    Region region5 = new Region(rectangle2);
                    region5.Exclude(rectangle3);
                    SolidBrush solidBrush4 = new SolidBrush(m_InnerBorderDarkColor);
                    Region region6 = region5.Clone();
                    region6.Intersect(graphicsPath);
                    g.FillRegion(solidBrush4, region6);
                    solidBrush4.Dispose();
                    region6.Dispose();
                    SolidBrush solidBrush5 = new SolidBrush(m_InnerBorderLightColor);
                    Region region7 = region5.Clone();
                    region7.Exclude(graphicsPath);
                    g.FillRegion(solidBrush5, region7);
                    solidBrush5.Dispose();
                    region7.Dispose();
                    region5.Dispose();
                }
                graphicsPath.Dispose();
            }
            else if (m_BorderGradientType != DAS_BorderGradientStyle.BGS_Ring)
            {
                if (m_BorderGradientType != DAS_BorderGradientStyle.BGS_Linear)
                {
                    if (m_BorderGradientType == DAS_BorderGradientStyle.BGS_Linear2)
                    {
                        goto Label2;
                    }
                    if (m_BorderGradientType == DAS_BorderGradientStyle.BGS_Path)
                    {
                        Blend blend = new Blend();
                        bool flag = false;
                        if ((double)m_BorderGradientRate < 0.49999999999 || (double)m_BorderGradientRate > 0.5000000000001)
                        {
                            flag = true;
                            blend.Factors = new float[3];
                            blend.Positions = new float[3];
                            blend.Factors[0] = 0f;
                            blend.Positions[0] = 0f;
                            blend.Factors[1] = m_BorderGradientRate;
                            blend.Positions[1] = 1f - m_BorderGradientRate;
                            blend.Factors[2] = 1f;
                            blend.Positions[2] = 1f;
                        }
                        if (m_OuterBorderLength > 0)
                        {
                            double int4 = 3.14159265358979 * (double)m_BorderGradientAngle / 180;
                            GraphicsPath graphicsPath1 = new GraphicsPath();
                            point = new Point[] { new Point(rectangle.Left - 1, rectangle.Top - 1), new Point(rectangle.Left + rectangle.Width + 1, rectangle.Top - 1), new Point(rectangle.Left + rectangle.Width + 1, rectangle.Top + rectangle.Height + 1), new Point(rectangle.Left - 1, rectangle.Top + rectangle.Height + 1) };
                            graphicsPath1.AddPolygon(point);
                            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath1)
                            {
                                SurroundColors = new Color[] { m_OuterBorderDarkColor }
                            };
                            PointF x = new PointF()
                            {
                                X = (float)rectangle.Left + (float)rectangle.Width / 2f,
                                Y = (float)rectangle.Top + (float)rectangle.Height / 2f
                            };
                            if (Math.Abs(Math.Sin(int4)) < 1E-10)
                            {
                                single = 0f;
                                height = (float)(Math.Cos(int4) * (double)(rectangle.Width - m_OuterBorderLength) / 2);
                            }
                            else if (Math.Abs(Math.Cos(int4)) >= 1E-10)
                            {
                                height = (float)((double)(rectangle.Height - m_OuterBorderLength) / (2 * Math.Tan(int4)));
                                single = (float)(Math.Tan(int4) * (double)(rectangle.Width - m_OuterBorderLength) / 2);
                                height = (Math.Cos(int4) >= 0 ? Math.Abs(height) : -Math.Abs(height));
                                single = (Math.Sin(int4) >= 0 ? Math.Abs(single) : -Math.Abs(single));
                                if (height < -((float)(rectangle.Width - m_OuterBorderLength) / 2f))
                                {
                                    height = -((float)(rectangle.Width - m_OuterBorderLength) / 2f);
                                }
                                else if (height > (float)(rectangle.Width - m_OuterBorderLength) / 2f)
                                {
                                    height = (float)(rectangle.Width - m_OuterBorderLength) / 2f;
                                }
                                if (single < -((float)(rectangle.Height - m_OuterBorderLength) / 2f))
                                {
                                    single = -((float)(rectangle.Height - m_OuterBorderLength) / 2f);
                                }
                                else if (single > (float)(rectangle.Height - m_OuterBorderLength) / 2f)
                                {
                                    single = (float)(rectangle.Height - m_OuterBorderLength) / 2f;
                                }
                            }
                            else
                            {
                                height = 0f;
                                single = (float)(Math.Sin(int4) * (double)(rectangle.Height - m_OuterBorderLength) / 2);
                            }
                            x.X = x.X + height;
                            x.Y = x.Y + single;
                            if (flag)
                            {
                                pathGradientBrush.Blend = blend;
                            }
                            pathGradientBrush.CenterPoint = x;
                            pathGradientBrush.CenterColor = m_OuterBorderLightColor;
                            Region region8 = new Region(rectangle);
                            region8.Exclude(rectangle1);
                            g.FillRegion(pathGradientBrush, region8);
                            pathGradientBrush.Dispose();
                            region8.Dispose();
                        }
                        if (m_MiddleBorderLength > 0)
                        {
                            Region region9 = new Region(rectangle1);
                            region9.Exclude(rectangle2);
                            SolidBrush solidBrush6 = new SolidBrush(m_MiddleBorderColor);
                            g.FillRegion(solidBrush6, region9);
                            Pen pen2 = new Pen(solidBrush6);
                            g.DrawRectangle(pen2, rectangle1);
                            g.DrawRectangle(pen2, rectangle2);
                            pen2.Dispose();
                            solidBrush6.Dispose();
                            region9.Dispose();
                        }
                        if (m_InnerBorderLength > 0)
                        {
                            double num = 3.14159265358979 * (double)m_BorderGradientAngle / 180 + 3.14159265358979;
                            GraphicsPath graphicsPath2 = new GraphicsPath();
                            point = new Point[] { new Point(rectangle2.Left, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top + rectangle2.Height), new Point(rectangle2.Left, rectangle2.Top + rectangle2.Height) };
                            graphicsPath2.AddPolygon(point);
                            PathGradientBrush color4 = new PathGradientBrush(graphicsPath2)
                            {
                                SurroundColors = new Color[] { m_InnerBorderDarkColor }
                            };
                            PointF y = new PointF()
                            {
                                X = (float)rectangle2.Left + (float)rectangle2.Width / 2f,
                                Y = (float)rectangle2.Top + (float)rectangle2.Height / 2f
                            };
                            if (Math.Abs(Math.Sin(num)) < 1E-10)
                            {
                                height1 = 0f;
                                width = (float)(Math.Cos(num) * (double)(rectangle2.Width - m_InnerBorderLength) / 2);
                            }
                            else if (Math.Abs(Math.Cos(num)) >= 1E-10)
                            {
                                width = (float)((double)(rectangle2.Height - m_InnerBorderLength) / (2 * Math.Tan(num)));
                                height1 = (float)(Math.Tan(num) * (double)(rectangle2.Width - m_InnerBorderLength) / 2);
                                width = (Math.Cos(num) >= 0 ? Math.Abs(width) : -Math.Abs(width));
                                height1 = (Math.Sin(num) >= 0 ? Math.Abs(height1) : -Math.Abs(height1));
                                if (width < -((float)(rectangle2.Width - m_InnerBorderLength) / 2f))
                                {
                                    width = -((float)(rectangle2.Width - m_InnerBorderLength) / 2f);
                                }
                                else if (width > (float)(rectangle2.Width - m_InnerBorderLength) / 2f)
                                {
                                    width = (float)(rectangle2.Width - m_InnerBorderLength) / 2f;
                                }
                                if (height1 < -((float)(rectangle2.Height - m_InnerBorderLength) / 2f))
                                {
                                    height1 = -((float)(rectangle2.Height - m_InnerBorderLength) / 2f);
                                }
                                else if (height1 > (float)(rectangle2.Height - m_InnerBorderLength) / 2f)
                                {
                                    height1 = (float)(rectangle2.Height - m_InnerBorderLength) / 2f;
                                }
                            }
                            else
                            {
                                width = 0f;
                                height1 = (float)(Math.Sin(num) * (double)(rectangle2.Height - m_InnerBorderLength) / 2);
                            }
                            y.X = y.X + width;
                            y.Y = y.Y + height1;
                            if (flag)
                            {
                                color4.Blend = blend;
                            }
                            color4.CenterPoint = y;
                            color4.CenterColor = m_InnerBorderLightColor;
                            Region region10 = new Region(rectangle2);
                            region10.Exclude(rectangle3);
                            g.FillRegion(color4, region10);
                            color4.Dispose();
                            region10.Dispose();
                            if (m_BorderExteriorLength > 0)
                            {
                                solidBrush = new SolidBrush(m_BorderExteriorColor);
                                region = new Region(rec_width);
                                region.Exclude(rectangle);
                                g.FillRegion(solidBrush, region);
                                pen = new Pen(solidBrush, (float)m_BorderExteriorLength);
                                g.DrawRectangle(pen, rec_width);
                                g.DrawRectangle(pen, rectangle);
                                pen.Dispose();
                                solidBrush.Dispose();
                                region.Dispose();
                            }
                            return;
                        }
                        else
                        {
                            if (m_BorderExteriorLength > 0)
                            {
                                solidBrush = new SolidBrush(m_BorderExteriorColor);
                                region = new Region(rec_width);
                                region.Exclude(rectangle);
                                g.FillRegion(solidBrush, region);
                                pen = new Pen(solidBrush, (float)m_BorderExteriorLength);
                                g.DrawRectangle(pen, rec_width);
                                g.DrawRectangle(pen, rectangle);
                                pen.Dispose();
                                solidBrush.Dispose();
                                region.Dispose();
                            }
                            return;
                        }
                    }
                    else
                    {
                        if (m_BorderExteriorLength > 0)
                        {
                            solidBrush = new SolidBrush(m_BorderExteriorColor);
                            region = new Region(rec_width);
                            region.Exclude(rectangle);
                            g.FillRegion(solidBrush, region);
                            pen = new Pen(solidBrush, (float)m_BorderExteriorLength);
                            g.DrawRectangle(pen, rec_width);
                            g.DrawRectangle(pen, rectangle);
                            pen.Dispose();
                            solidBrush.Dispose();
                            region.Dispose();
                        }
                        return;
                    }
                }
            Label2:
                Blend float0 = new Blend();
                bool flag1 = false;
                float float3 = 0f;
                if (m_BorderLightIntermediateBrightness >= 0f && (double)m_BorderLightIntermediateBrightness <= 1)
                {
                    float3 = m_BorderLightIntermediateBrightness;
                }
                if (m_BorderGradientLightPos1 > 0f && (double)m_BorderGradientLightPos1 < 1)
                {
                    flag1 = true;
                    if (m_BorderGradientLightPos2 <= 0f || (double)m_BorderGradientLightPos2 > 1)
                    {
                        float0.Factors = new float[5];
                        float0.Positions = new float[5];
                        float0.Factors[0] = 0f;
                        float0.Positions[0] = 0f;
                        float0.Factors[1] = m_BorderGradientRate;
                        float0.Positions[1] = m_BorderGradientLightPos1 * (1f - m_BorderGradientRate);
                        float0.Factors[2] = 1f;
                        float0.Positions[2] = m_BorderGradientLightPos1;
                        float0.Factors[3] = m_BorderGradientRate;
                        float0.Positions[3] = (1f - m_BorderGradientLightPos1) * m_BorderGradientRate + m_BorderGradientLightPos1;
                        float0.Factors[4] = 0f;
                        float0.Positions[4] = 1f;
                    }
                    else
                    {
                        float0.Factors = new float[9];
                        float0.Positions = new float[9];
                        if (m_BorderGradientLightPos1 <= m_BorderGradientLightPos2)
                        {
                            float0.Factors[0] = 0f;
                            float0.Positions[0] = 0f;
                            float0.Factors[1] = m_BorderGradientRate;
                            float0.Positions[1] = m_BorderGradientLightPos1 * (1f - m_BorderGradientRate);
                            float0.Factors[2] = 1f;
                            float0.Positions[2] = m_BorderGradientLightPos1;
                            float0.Factors[3] = (1f - float3) * m_BorderGradientRate + float3;
                            float0.Positions[3] = m_BorderGradientLightPos1 + (m_BorderGradientLightPos2 - m_BorderGradientLightPos1) / 2f * m_BorderGradientRate;
                            float0.Factors[4] = float3;
                            float0.Positions[4] = (m_BorderGradientLightPos1 + m_BorderGradientLightPos2) / 2f;
                            float0.Factors[5] = (1f - float3) * m_BorderGradientRate + float3;
                            float0.Positions[5] = (m_BorderGradientLightPos1 + m_BorderGradientLightPos2) / 2f + (m_BorderGradientLightPos2 - m_BorderGradientLightPos1) / 2f * (1f - m_BorderGradientRate);
                            float0.Factors[6] = 1f;
                            float0.Positions[6] = m_BorderGradientLightPos2;
                            float0.Factors[7] = m_BorderGradientRate;
                            float0.Positions[7] = m_BorderGradientLightPos2 + (1f - m_BorderGradientLightPos2) * m_BorderGradientRate;
                            float0.Factors[8] = 0f;
                            float0.Positions[8] = 1f;
                            if (m_BorderGradientLightPos1 == m_BorderGradientLightPos2)
                            {
                                float0.Factors[3] = 1f;
                                float0.Factors[4] = 1f;
                                float0.Factors[5] = 1f;
                            }
                            if (m_BorderGradientLightPos2 == 1f)
                            {
                                float0.Factors[7] = 1f;
                                float0.Factors[8] = 1f;
                            }
                        }
                        else
                        {
                            float0.Factors[0] = 0f;
                            float0.Positions[0] = 0f;
                            float0.Factors[1] = m_BorderGradientRate;
                            float0.Positions[1] = m_BorderGradientLightPos2 * (1f - m_BorderGradientRate);
                            float0.Factors[2] = 1f;
                            float0.Positions[2] = m_BorderGradientLightPos2;
                            float0.Factors[3] = (1f - float3) * m_BorderGradientRate + float3;
                            float0.Positions[3] = m_BorderGradientLightPos2 + (m_BorderGradientLightPos1 - m_BorderGradientLightPos2) / 2f * m_BorderGradientRate;
                            float0.Factors[4] = float3;
                            float0.Positions[4] = (m_BorderGradientLightPos1 + m_BorderGradientLightPos2) / 2f;
                            float0.Factors[5] = (1f - float3) * m_BorderGradientRate + float3;
                            float0.Positions[5] = (m_BorderGradientLightPos1 + m_BorderGradientLightPos2) / 2f + (m_BorderGradientLightPos1 - m_BorderGradientLightPos2) / 2f * (1f - m_BorderGradientRate);
                            float0.Factors[6] = 1f;
                            float0.Positions[6] = m_BorderGradientLightPos1;
                            float0.Factors[7] = m_BorderGradientRate;
                            float0.Positions[7] = m_BorderGradientLightPos1 + (1f - m_BorderGradientLightPos1) * m_BorderGradientRate;
                            float0.Factors[8] = 0f;
                            float0.Positions[8] = 1f;
                        }
                    }
                }
                else if ((double)m_BorderGradientRate < 0.49999999999 || (double)m_BorderGradientRate > 0.5000000000001)
                {
                    flag1 = true;
                    float0.Factors = new float[3];
                    float0.Positions = new float[3];
                    float0.Factors[0] = 0f;
                    float0.Positions[0] = 0f;
                    float0.Factors[1] = m_BorderGradientRate;
                    float0.Positions[1] = 1f - m_BorderGradientRate;
                    float0.Factors[2] = 1f;
                    float0.Positions[2] = 1f;
                }
                if (m_OuterBorderLength > 0)
                {
                    Rectangle rectangle4 = new Rectangle(rectangle.Left - 1, rectangle.Top - 1, rectangle.Width + 2, rectangle.Height + 2);
                    LinearGradientBrush linearGradientBrush1 = new LinearGradientBrush(rectangle4, m_OuterBorderDarkColor, m_OuterBorderLightColor, (float)m_BorderGradientAngle);
                    if (flag1)
                    {
                        linearGradientBrush1.Blend = float0;
                    }
                    Region region11 = new Region(rectangle);
                    region11.Exclude(rectangle1);
                    g.FillRegion(linearGradientBrush1, region11);
                    linearGradientBrush1.Dispose();
                    region11.Dispose();
                }
                if (m_MiddleBorderLength > 0)
                {
                    Region region12 = new Region(rectangle1);
                    region12.Exclude(rectangle2);
                    SolidBrush solidBrush7 = new SolidBrush(m_MiddleBorderColor);
                    g.FillRegion(solidBrush7, region12);
                    Pen pen3 = new Pen(solidBrush7);
                    g.DrawRectangle(pen3, rectangle1);
                    g.DrawRectangle(pen3, rectangle2);
                    pen3.Dispose();
                    solidBrush7.Dispose();
                    region12.Dispose();
                }
                if (m_InnerBorderLength > 0)
                {
                    linearGradientBrush = (m_BorderGradientType != DAS_BorderGradientStyle.BGS_Linear ? new LinearGradientBrush(rectangle2, m_InnerBorderDarkColor, m_InnerBorderLightColor, (float)(m_BorderGradientAngle + 180)) : new LinearGradientBrush(rectangle2, m_InnerBorderLightColor, m_InnerBorderDarkColor, (float)m_BorderGradientAngle));
                    if (flag1)
                    {
                        linearGradientBrush.Blend = float0;
                    }
                    Region region13 = new Region(rectangle2);
                    region13.Exclude(rectangle3);
                    g.FillRegion(linearGradientBrush, region13);
                    linearGradientBrush.Dispose();
                    region13.Dispose();
                }
            }
            else
            {
                Blend blend1 = new Blend()
                {
                    Factors = new float[3],
                    Positions = new float[3]
                };
                blend1.Factors[0] = 0f;
                blend1.Positions[0] = 0f;
                blend1.Factors[2] = 1f;
                blend1.Positions[2] = 1f;
                if (m_OuterBorderLength > 0)
                {
                    blend1.Factors[1] = m_BorderGradientRate;
                    blend1.Positions[1] = 1f - m_BorderGradientRate;
                    GraphicsPath graphicsPath3 = new GraphicsPath();
                    point = new Point[] { new Point(rectangle.Left, rectangle.Top), new Point(rectangle.Left + rectangle.Width, rectangle.Top), new Point(rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height), new Point(rectangle.Left, rectangle.Top + rectangle.Height) };
                    graphicsPath3.AddPolygon(point);
                    PathGradientBrush pathGradientBrush1 = new PathGradientBrush(graphicsPath3)
                    {
                        SurroundColors = new Color[] { m_OuterBorderDarkColor },
                        CenterColor = m_OuterBorderLightColor
                    };
                    PointF pointF = new PointF()
                    {
                        X = (float)rectangle1.Width / (float)rectangle.Width,
                        Y = (float)rectangle1.Height / (float)rectangle.Height
                    };
                    pathGradientBrush1.FocusScales = pointF;
                    Region region14 = new Region(rectangle);
                    region14.Exclude(rectangle1);
                    g.FillRegion(pathGradientBrush1, region14);
                    pathGradientBrush1.Dispose();
                    region14.Dispose();
                }
                if (m_MiddleBorderLength > 0)
                {
                    Region region15 = new Region(rectangle1);
                    region15.Exclude(rectangle2);
                    SolidBrush solidBrush8 = new SolidBrush(m_MiddleBorderColor);
                    g.FillRegion(solidBrush8, region15);
                    Pen pen4 = new Pen(solidBrush8);
                    g.DrawRectangle(pen4, rectangle1);
                    g.DrawRectangle(pen4, rectangle2);
                    pen4.Dispose();
                    solidBrush8.Dispose();
                    region15.Dispose();
                }
                if (m_InnerBorderLength > 0)
                {
                    blend1.Factors[1] = 1f - m_BorderGradientRate;
                    blend1.Positions[1] = m_BorderGradientRate;
                    GraphicsPath graphicsPath4 = new GraphicsPath();
                    point = new Point[] { new Point(rectangle2.Left, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top + rectangle2.Height), new Point(rectangle2.Left, rectangle2.Top + rectangle2.Height) };
                    graphicsPath4.AddPolygon(point);
                    PathGradientBrush pathGradientBrush2 = new PathGradientBrush(graphicsPath4)
                    {
                        SurroundColors = new Color[] { m_InnerBorderLightColor },
                        Blend = blend1,
                        CenterColor = m_InnerBorderDarkColor
                    };
                    PointF pointF1 = new PointF()
                    {
                        X = (float)rectangle3.Width / (float)rectangle2.Width,
                        Y = (float)rectangle3.Height / (float)rectangle2.Height
                    };
                    pathGradientBrush2.FocusScales = pointF1;
                    Region region16 = new Region(rectangle2);
                    region16.Exclude(rectangle3);
                    g.FillRegion(pathGradientBrush2, region16);
                    pathGradientBrush2.Dispose();
                    region16.Dispose();
                }
            }
            if (m_BorderExteriorLength > 0)
            {
                solidBrush = new SolidBrush(m_BorderExteriorColor);
                region = new Region(rec_width);
                region.Exclude(rectangle);
                g.FillRegion(solidBrush, region);
                pen = new Pen(solidBrush, (float)m_BorderExteriorLength);
                g.DrawRectangle(pen, rec_width);
                g.DrawRectangle(pen, rectangle);
                pen.Dispose();
                solidBrush.Dispose();
                region.Dispose();
            }
        }

        public void SetCircle(Graphics graphics_0, Rectangle rec, int int_0, Color color_0, Color color_1, int int_1, Color color_2, int int_2, Color color_3, Color color_4, int int_3, Color color_5, DAS_BorderGradientStyle das_BorderGradientStyle_0, long long_0, float float_0, float float_1, float float_2, float float_3)
        {
            LinearGradientBrush linearGradientBrush;
            Rectangle rectangle = new Rectangle(rec.Left + int_3, rec.Top + int_3, rec.Width - 2 * int_3, rec.Height - 2 * int_3);
            Rectangle rectangle1 = new Rectangle(rec.Left + int_3 + int_0, rec.Top + int_3 + int_0, rec.Width - 2 * (int_3 + int_0), rec.Height - 2 * (int_3 + int_0));
            Rectangle rectangle2 = new Rectangle(rec.Left + int_3 + int_0 + int_1, rec.Top + int_3 + int_0 + int_1, rec.Width - 2 * (int_3 + int_0 + int_1), rec.Height - 2 * (int_3 + int_0 + int_1));
            Rectangle rectangle3 = new Rectangle(rec.Left + int_3 + int_0 + int_1 + int_2, rec.Top + int_3 + int_0 + int_1 + int_2, rec.Width - 2 * (int_3 + int_0 + int_1 + int_2), rec.Height - 2 * (int_3 + int_0 + int_1 + int_2));
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(rectangle);
            GraphicsPath graphicsPath1 = new GraphicsPath();
            graphicsPath1.AddEllipse(rectangle1);
            GraphicsPath graphicsPath2 = new GraphicsPath();
            graphicsPath2.AddEllipse(rectangle2);
            GraphicsPath graphicsPath3 = new GraphicsPath();
            graphicsPath3.AddEllipse(rectangle3);
            if (das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_Flat)
            {
                PointF[] left = new PointF[5];
                left[0].X = (float)rectangle.Left;
                left[0].Y = (float)rectangle.Top;
                left[1].X = (float)rectangle.Left;
                left[1].Y = (float)(rectangle.Top + rectangle.Height);
                if (rectangle.Width < rectangle.Height)
                {
                    left[2].X = (float)rectangle.Left + (float)rectangle.Width / 2f;
                    left[2].Y = (float)(rectangle.Top + rectangle.Height) - (float)rectangle.Width / 2f;
                    left[3].X = (float)rectangle.Left + (float)rectangle.Width / 2f;
                    left[3].Y = (float)rectangle.Top + (float)rectangle.Width / 2f;
                }
                else
                {
                    left[2].X = (float)rectangle.Left + (float)rectangle.Height / 2f;
                    left[2].Y = (float)rectangle.Top + (float)rectangle.Height / 2f;
                    left[3].X = (float)(rectangle.Left + rectangle.Width) - (float)rectangle.Height / 2f;
                    left[3].Y = (float)rectangle.Top + (float)rectangle.Height / 2f;
                }
                left[4].X = (float)(rectangle.Left + rectangle.Width);
                left[4].Y = (float)rectangle.Top;
                GraphicsPath graphicsPath4 = new GraphicsPath();
                graphicsPath4.AddPolygon(left);
                if (int_0 > 0)
                {
                    Region region = new Region(graphicsPath);
                    region.Exclude(graphicsPath1);
                    SolidBrush solidBrush = new SolidBrush(color_1);
                    Region region1 = region.Clone();
                    region1.Intersect(graphicsPath4);
                    graphics_0.FillRegion(solidBrush, region1);
                    graphics_0.SetClip(graphicsPath4);
                    Pen pen = new Pen(solidBrush);
                    graphics_0.DrawEllipse(pen, rectangle);
                    graphics_0.DrawEllipse(pen, rectangle2);
                    pen.Dispose();
                    graphics_0.ResetClip();
                    solidBrush.Dispose();
                    region1.Dispose();
                    SolidBrush solidBrush1 = new SolidBrush(color_0);
                    Region region2 = region.Clone();
                    region2.Exclude(graphicsPath4);
                    graphics_0.FillRegion(solidBrush1, region2);
                    graphics_0.SetClip(graphicsPath4, CombineMode.Exclude);
                    Pen pen1 = new Pen(solidBrush1);
                    graphics_0.DrawEllipse(pen1, rectangle);
                    graphics_0.DrawEllipse(pen1, rectangle2);
                    pen1.Dispose();
                    graphics_0.ResetClip();
                    solidBrush1.Dispose();
                    region2.Dispose();
                    region.Dispose();
                }
                if (int_1 > 0)
                {
                    Region region3 = new Region(graphicsPath1);
                    region3.Exclude(graphicsPath2);
                    SolidBrush solidBrush2 = new SolidBrush(color_2);
                    graphics_0.FillRegion(solidBrush2, region3);
                    Pen pen2 = new Pen(solidBrush2);
                    graphics_0.DrawPath(pen2, graphicsPath1);
                    graphics_0.DrawPath(pen2, graphicsPath2);
                    pen2.Dispose();
                    solidBrush2.Dispose();
                    region3.Dispose();
                }
                if (int_2 > 0)
                {
                    Region region4 = new Region(graphicsPath2);
                    region4.Exclude(graphicsPath3);
                    SolidBrush solidBrush3 = new SolidBrush(color_3);
                    Region region5 = region4.Clone();
                    region5.Intersect(graphicsPath4);
                    graphics_0.FillRegion(solidBrush3, region5);
                    graphics_0.SetClip(graphicsPath4);
                    Pen pen3 = new Pen(solidBrush3);
                    graphics_0.DrawEllipse(pen3, rectangle2);
                    graphics_0.DrawEllipse(pen3, rectangle3);
                    pen3.Dispose();
                    graphics_0.ResetClip();
                    solidBrush3.Dispose();
                    region5.Dispose();
                    SolidBrush solidBrush4 = new SolidBrush(color_4);
                    Region region6 = region4.Clone();
                    region6.Exclude(graphicsPath4);
                    graphics_0.FillRegion(solidBrush4, region6);
                    graphics_0.SetClip(graphicsPath4, CombineMode.Exclude);
                    Pen pen4 = new Pen(solidBrush4);
                    graphics_0.DrawEllipse(pen4, rectangle2);
                    graphics_0.DrawEllipse(pen4, rectangle3);
                    pen4.Dispose();
                    graphics_0.ResetClip();
                    solidBrush4.Dispose();
                    region6.Dispose();
                    region4.Dispose();
                }
                graphicsPath4.Dispose();
            }
            else if (das_BorderGradientStyle_0 != DAS_BorderGradientStyle.BGS_Ring)
            {
                if (das_BorderGradientStyle_0 != DAS_BorderGradientStyle.BGS_Linear)
                {
                    if (das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_Linear2)
                    {
                        goto Label2;
                    }
                    if (das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_Path)
                    {
                        Blend blend = new Blend();
                        bool flag = false;
                        if ((double)float_0 < 0.49999999999 || (double)float_0 > 0.5000000000001)
                        {
                            flag = true;
                            blend.Factors = new float[3];
                            blend.Positions = new float[3];
                            blend.Factors[0] = 0f;
                            blend.Positions[0] = 0f;
                            blend.Factors[1] = float_0;
                            blend.Positions[1] = 1f - float_0;
                            blend.Factors[2] = 1f;
                            blend.Positions[2] = 1f;
                        }
                        if (int_0 > 0)
                        {
                            double long0 = 3.14159265358979 * (double)long_0 / 180;
                            GraphicsPath graphicsPath5 = new GraphicsPath();
                            graphicsPath5.AddEllipse(rectangle);
                            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath5)
                            {
                                SurroundColors = new Color[] { color_0 }
                            };
                            PointF x = new PointF()
                            {
                                X = (float)rectangle.Left + (float)rectangle.Width / 2f,
                                Y = (float)rectangle.Top + (float)rectangle.Height / 2f
                            };
                            float width = (float)((double)((float)rectangle.Width - (float)int_0 * float_1) * Math.Cos(long0) / 2);
                            float height = (float)((double)((float)rectangle.Height - (float)int_0 * float_1) * Math.Sin(long0) / 2);
                            x.X = x.X + width;
                            x.Y = x.Y + height;
                            if (flag)
                            {
                                pathGradientBrush.Blend = blend;
                            }
                            pathGradientBrush.CenterPoint = x;
                            pathGradientBrush.CenterColor = color_1;
                            Region region7 = new Region(graphicsPath);
                            Region region8 = new Region(graphicsPath1);
                            region7.Exclude(region8);
                            graphics_0.FillRegion(pathGradientBrush, region7);
                            Pen pen5 = new Pen(color_0);
                            graphics_0.DrawPath(pen5, graphicsPath);
                            pen5.Dispose();
                            pathGradientBrush.Dispose();
                            region7.Dispose();
                            region8.Dispose();
                        }
                        if (int_1 > 0)
                        {
                            Region region9 = new Region(graphicsPath1);
                            region9.Exclude(graphicsPath2);
                            SolidBrush solidBrush5 = new SolidBrush(color_2);
                            graphics_0.FillRegion(solidBrush5, region9);
                            Pen pen6 = new Pen(solidBrush5);
                            graphics_0.DrawPath(pen6, graphicsPath1);
                            graphics_0.DrawPath(pen6, graphicsPath2);
                            pen6.Dispose();
                            solidBrush5.Dispose();
                            region9.Dispose();
                        }
                        if (int_2 > 0)
                        {
                            double num = 3.14159265358979 * (double)long_0 / 180 + 3.14159265358979;
                            GraphicsPath graphicsPath6 = new GraphicsPath();
                            graphicsPath6.AddEllipse(rectangle2);
                            PathGradientBrush color4 = new PathGradientBrush(graphicsPath6)
                            {
                                SurroundColors = new Color[] { color_3 }
                            };
                            PointF y = new PointF()
                            {
                                X = (float)rectangle2.Left + (float)rectangle2.Width / 2f,
                                Y = (float)rectangle2.Top + (float)rectangle2.Height / 2f
                            };
                            float single = (float)((double)((float)rectangle2.Width - (float)int_2 * (1f - float_1)) * Math.Cos(num) / 2);
                            float height1 = (float)((double)((float)rectangle2.Height - (float)int_2 * (1f - float_1)) * Math.Sin(num) / 2);
                            y.X = y.X + single;
                            y.Y = y.Y + height1;
                            if (flag)
                            {
                                color4.Blend = blend;
                            }
                            color4.CenterPoint = y;
                            color4.CenterColor = color_4;
                            Region region10 = new Region(graphicsPath2);
                            Region region11 = new Region(graphicsPath3);
                            region10.Exclude(region11);
                            graphics_0.FillRegion(color4, region10);
                            Pen pen7 = new Pen(color_3);
                            graphics_0.DrawPath(pen7, graphicsPath2);
                            graphics_0.DrawPath(pen7, graphicsPath3);
                            pen7.Dispose();
                            color4.Dispose();
                            region10.Dispose();
                            region11.Dispose();
                            goto Label0;
                        }
                        else
                        {
                            goto Label0;
                        }
                    }
                    else
                    {
                        goto Label0;
                    }
                }
            Label2:
                Blend float0 = new Blend();
                bool flag1 = false;
                float float3 = 0f;
                if (float_3 >= 0f && (double)float_3 <= 1)
                {
                    float3 = float_3;
                }
                if (float_1 > 0f && (double)float_1 < 1)
                {
                    flag1 = true;
                    if (float_2 <= 0f || (double)float_2 > 1)
                    {
                        float0.Factors = new float[5];
                        float0.Positions = new float[5];
                        float0.Factors[0] = 0f;
                        float0.Positions[0] = 0f;
                        float0.Factors[1] = float_0;
                        float0.Positions[1] = float_1 * (1f - float_0);
                        float0.Factors[2] = 1f;
                        float0.Positions[2] = float_1;
                        float0.Factors[3] = float_0;
                        float0.Positions[3] = (1f - float_1) * float_0 + float_1;
                        float0.Factors[4] = 0f;
                        float0.Positions[4] = 1f;
                    }
                    else
                    {
                        float0.Factors = new float[9];
                        float0.Positions = new float[9];
                        if (float_1 <= float_2)
                        {
                            float0.Factors[0] = 0f;
                            float0.Positions[0] = 0f;
                            float0.Factors[1] = float_0;
                            float0.Positions[1] = float_1 * (1f - float_0);
                            float0.Factors[2] = 1f;
                            float0.Positions[2] = float_1;
                            float0.Factors[3] = (1f - float3) * float_0 + float3;
                            float0.Positions[3] = float_1 + (float_2 - float_1) / 2f * float_0;
                            float0.Factors[4] = float3;
                            float0.Positions[4] = (float_1 + float_2) / 2f;
                            float0.Factors[5] = (1f - float3) * float_0 + float3;
                            float0.Positions[5] = (float_1 + float_2) / 2f + (float_2 - float_1) / 2f * (1f - float_0);
                            float0.Factors[6] = 1f;
                            float0.Positions[6] = float_2;
                            float0.Factors[7] = float_0;
                            float0.Positions[7] = float_2 + (1f - float_2) * float_0;
                            float0.Factors[8] = 0f;
                            float0.Positions[8] = 1f;
                            if (float_1 == float_2)
                            {
                                float0.Factors[3] = 1f;
                                float0.Factors[4] = 1f;
                                float0.Factors[5] = 1f;
                            }
                            if (float_2 == 1f)
                            {
                                float0.Factors[7] = 1f;
                                float0.Factors[8] = 1f;
                            }
                        }
                        else
                        {
                            float0.Factors[0] = 0f;
                            float0.Positions[0] = 0f;
                            float0.Factors[1] = float_0;
                            float0.Positions[1] = float_2 * (1f - float_0);
                            float0.Factors[2] = 1f;
                            float0.Positions[2] = float_2;
                            float0.Factors[3] = (1f - float3) * float_0 + float3;
                            float0.Positions[3] = float_2 + (float_1 - float_2) / 2f * float_0;
                            float0.Factors[4] = float3;
                            float0.Positions[4] = (float_1 + float_2) / 2f;
                            float0.Factors[5] = (1f - float3) * float_0 + float3;
                            float0.Positions[5] = (float_1 + float_2) / 2f + (float_1 - float_2) / 2f * (1f - float_0);
                            float0.Factors[6] = 1f;
                            float0.Positions[6] = float_1;
                            float0.Factors[7] = float_0;
                            float0.Positions[7] = float_1 + (1f - float_1) * float_0;
                            float0.Factors[8] = 0f;
                            float0.Positions[8] = 1f;
                        }
                    }
                }
                else if ((double)float_0 < 0.49999999999 || (double)float_0 > 0.5000000000001)
                {
                    flag1 = true;
                    float0.Factors = new float[3];
                    float0.Positions = new float[3];
                    float0.Factors[0] = 0f;
                    float0.Positions[0] = 0f;
                    float0.Factors[1] = float_0;
                    float0.Positions[1] = 1f - float_0;
                    float0.Factors[2] = 1f;
                    float0.Positions[2] = 1f;
                }
                if (int_0 > 0)
                {
                    Rectangle rectangle4 = new Rectangle(rectangle.Left - 1, rectangle.Top - 1, rectangle.Width + 2, rectangle.Height + 2);
                    LinearGradientBrush linearGradientBrush1 = new LinearGradientBrush(rectangle4, color_0, color_1, (float)long_0);
                    if (flag1)
                    {
                        linearGradientBrush1.Blend = float0;
                    }
                    Region region12 = new Region(graphicsPath);
                    Region region13 = new Region(graphicsPath1);
                    region12.Exclude(region13);
                    graphics_0.FillRegion(linearGradientBrush1, region12);
                    Pen pen8 = new Pen(linearGradientBrush1);
                    graphics_0.DrawPath(pen8, graphicsPath);
                    graphics_0.DrawPath(pen8, graphicsPath1);
                    pen8.Dispose();
                    linearGradientBrush1.Dispose();
                    region12.Dispose();
                    region13.Dispose();
                }
                if (int_1 > 0)
                {
                    Region region14 = new Region(graphicsPath1);
                    region14.Exclude(graphicsPath2);
                    SolidBrush solidBrush6 = new SolidBrush(color_2);
                    graphics_0.FillRegion(solidBrush6, region14);
                    Pen pen9 = new Pen(solidBrush6);
                    graphics_0.DrawPath(pen9, graphicsPath1);
                    graphics_0.DrawPath(pen9, graphicsPath2);
                    pen9.Dispose();
                    solidBrush6.Dispose();
                    region14.Dispose();
                }
                if (int_2 > 0)
                {
                    linearGradientBrush = (das_BorderGradientStyle_0 != DAS_BorderGradientStyle.BGS_Linear ? new LinearGradientBrush(rectangle2, color_3, color_4, (float)(long_0 + (long)180)) : new LinearGradientBrush(rectangle2, color_4, color_3, (float)long_0));
                    if (flag1)
                    {
                        linearGradientBrush.Blend = float0;
                    }
                    Region region15 = new Region(graphicsPath2);
                    Region region16 = new Region(graphicsPath3);
                    region15.Exclude(region16);
                    graphics_0.FillRegion(linearGradientBrush, region15);
                    Pen pen10 = new Pen(linearGradientBrush);
                    graphics_0.DrawPath(pen10, graphicsPath2);
                    graphics_0.DrawPath(pen10, graphicsPath3);
                    pen10.Dispose();
                    linearGradientBrush.Dispose();
                    region15.Dispose();
                    region16.Dispose();
                }
            }
            else
            {
                Blend blend1 = new Blend()
                {
                    Factors = new float[3],
                    Positions = new float[3]
                };
                blend1.Factors[0] = 0f;
                blend1.Positions[0] = 0f;
                blend1.Factors[2] = 1f;
                blend1.Positions[2] = 1f;
                if (int_0 > 0)
                {
                    blend1.Factors[1] = float_0;
                    blend1.Positions[1] = 1f - float_0;
                    PathGradientBrush pathGradientBrush1 = new PathGradientBrush(graphicsPath)
                    {
                        SurroundColors = new Color[] { color_0 },
                        CenterColor = color_1
                    };
                    PointF pointF = new PointF()
                    {
                        X = (float)rectangle1.Width / (float)rectangle.Width,
                        Y = (float)rectangle1.Height / (float)rectangle.Height
                    };
                    pathGradientBrush1.FocusScales = pointF;
                    Region region17 = new Region(graphicsPath);
                    Region region18 = new Region(graphicsPath1);
                    region17.Exclude(region18);
                    graphics_0.FillRegion(pathGradientBrush1, region17);
                    Pen pen11 = new Pen(color_0);
                    graphics_0.DrawPath(pen11, graphicsPath);
                    pen11.Dispose();
                    pathGradientBrush1.Dispose();
                    region17.Dispose();
                    region18.Dispose();
                }
                if (int_1 > 0)
                {
                    Region region19 = new Region(graphicsPath1);
                    region19.Exclude(graphicsPath2);
                    SolidBrush solidBrush7 = new SolidBrush(color_2);
                    graphics_0.FillRegion(solidBrush7, region19);
                    Pen pen12 = new Pen(solidBrush7);
                    graphics_0.DrawPath(pen12, graphicsPath1);
                    graphics_0.DrawPath(pen12, graphicsPath2);
                    pen12.Dispose();
                    solidBrush7.Dispose();
                    region19.Dispose();
                }
                if (int_2 > 0)
                {
                    blend1.Factors[1] = 1f - float_0;
                    blend1.Positions[1] = float_0;
                    PathGradientBrush pathGradientBrush2 = new PathGradientBrush(graphicsPath2)
                    {
                        SurroundColors = new Color[] { color_4 },
                        Blend = blend1,
                        CenterColor = color_3
                    };
                    PointF pointF1 = new PointF()
                    {
                        X = (float)rectangle3.Width / (float)rectangle2.Width,
                        Y = (float)rectangle3.Height / (float)rectangle2.Height
                    };
                    pathGradientBrush2.FocusScales = pointF1;
                    Region region20 = new Region(graphicsPath2);
                    Region region21 = new Region(graphicsPath3);
                    region20.Exclude(region21);
                    graphics_0.FillRegion(pathGradientBrush2, region20);
                    Pen pen13 = new Pen(color_3);
                    graphics_0.DrawPath(pen13, graphicsPath3);
                    pen13.Dispose();
                    pathGradientBrush2.Dispose();
                    region20.Dispose();
                    region21.Dispose();
                }
            }
        Label0:
            if (int_3 > 0)
            {
                SolidBrush solidBrush8 = new SolidBrush(color_5);
                GraphicsPath graphicsPath7 = new GraphicsPath();
                graphicsPath7.AddEllipse(rec);
                Region region22 = new Region(graphicsPath7);
                region22.Exclude(graphicsPath);
                graphics_0.FillRegion(solidBrush8, region22);
                Pen pen14 = new Pen(solidBrush8);
                graphics_0.DrawPath(pen14, graphicsPath7);
                graphics_0.DrawPath(pen14, graphicsPath);
                pen14.Dispose();
                solidBrush8.Dispose();
                region22.Dispose();
                graphicsPath7.Dispose();
            }
            graphicsPath3.Dispose();
            graphicsPath2.Dispose();
            graphicsPath.Dispose();
        }

        public void SetRoundRect2(Graphics g, Rectangle rec_width, int m_RoundRadius, int m_OuterBorderLength, Color m_OuterBorderDarkColor, Color m_OuterBorderLightColor, int m_MiddleBorderLength, Color m_MiddleBorderColor, int m_InnerBorderLength, Color m_InnerBorderDarkColor, Color m_InnerBorderLightColor, int m_BorderExteriorLength, Color m_BorderExteriorColor, DAS_BorderGradientStyle m_BorderGradientType, long m_BorderGradientAngle, float m_BorderGradientRate, float m_BorderGradientLightPos1, float m_BorderGradientLightPos2, float m_BorderLightIntermediateBrightness)
        {
            LinearGradientBrush linearGradientBrush;
            float height;
            float single;
            float width;
            float height1;
            Point[] point;
            Rectangle rectangle = new Rectangle(rec_width.Left + m_BorderExteriorLength, rec_width.Top + m_BorderExteriorLength, rec_width.Width - 2 * m_BorderExteriorLength, rec_width.Height - 2 * m_BorderExteriorLength);
            Rectangle rectangle1 = new Rectangle(rec_width.Left + m_BorderExteriorLength + m_OuterBorderLength, rec_width.Top + m_BorderExteriorLength + m_OuterBorderLength, rec_width.Width - 2 * (m_BorderExteriorLength + m_OuterBorderLength), rec_width.Height - 2 * (m_BorderExteriorLength + m_OuterBorderLength));
            Rectangle rectangle2 = new Rectangle(rec_width.Left + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength, rec_width.Top + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength, rec_width.Width - 2 * (m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength), rec_width.Height - 2 * (m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength));
            Rectangle rectangle3 = new Rectangle(rec_width.Left + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength, rec_width.Top + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength, rec_width.Width - 2 * (m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength), rec_width.Height - 2 * (m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength));
            int int0 = m_RoundRadius - m_BorderExteriorLength;
            GraphicsPath graphicsPath = new GraphicsPath();
            this.SetRoundRect(graphicsPath, rectangle, int0);
            int0 = m_RoundRadius - m_BorderExteriorLength - m_OuterBorderLength;
            GraphicsPath graphicsPath1 = new GraphicsPath();
            this.SetRoundRect(graphicsPath1, rectangle1, int0);
            int0 = m_RoundRadius - m_BorderExteriorLength - m_OuterBorderLength - m_MiddleBorderLength;
            GraphicsPath graphicsPath2 = new GraphicsPath();
            this.SetRoundRect(graphicsPath2, rectangle2, int0);
            int0 = m_RoundRadius - m_BorderExteriorLength - m_OuterBorderLength - m_MiddleBorderLength - m_InnerBorderLength;
            GraphicsPath graphicsPath3 = new GraphicsPath();
            this.SetRoundRect(graphicsPath3, rectangle3, int0);
            if (m_BorderGradientType == DAS_BorderGradientStyle.BGS_Flat)
            {
                PointF[] left = new PointF[5];
                left[0].X = (float)rectangle.Left;
                left[0].Y = (float)rectangle.Top;
                left[1].X = (float)rectangle.Left;
                left[1].Y = (float)(rectangle.Top + rectangle.Height);
                if (rectangle.Width < rectangle.Height)
                {
                    left[2].X = (float)rectangle.Left + (float)rectangle.Width / 2f;
                    left[2].Y = (float)(rectangle.Top + rectangle.Height) - (float)rectangle.Width / 2f;
                    left[3].X = (float)rectangle.Left + (float)rectangle.Width / 2f;
                    left[3].Y = (float)rectangle.Top + (float)rectangle.Width / 2f;
                }
                else
                {
                    left[2].X = (float)rectangle.Left + (float)rectangle.Height / 2f;
                    left[2].Y = (float)rectangle.Top + (float)rectangle.Height / 2f;
                    left[3].X = (float)(rectangle.Left + rectangle.Width) - (float)rectangle.Height / 2f;
                    left[3].Y = (float)rectangle.Top + (float)rectangle.Height / 2f;
                }
                left[4].X = (float)(rectangle.Left + rectangle.Width);
                left[4].Y = (float)rectangle.Top;
                GraphicsPath graphicsPath4 = new GraphicsPath();
                graphicsPath4.AddPolygon(left);
                if (m_OuterBorderLength > 0)
                {
                    Region region = new Region(graphicsPath);
                    region.Exclude(graphicsPath1);
                    SolidBrush solidBrush = new SolidBrush(m_OuterBorderLightColor);
                    Region region1 = region.Clone();
                    region1.Intersect(graphicsPath4);
                    g.FillRegion(solidBrush, region1);
                    g.SetClip(graphicsPath4);
                    Pen pen = new Pen(solidBrush);
                    g.DrawPath(pen, graphicsPath);
                    g.DrawPath(pen, graphicsPath1);
                    pen.Dispose();
                    g.ResetClip();
                    solidBrush.Dispose();
                    region1.Dispose();
                    SolidBrush solidBrush1 = new SolidBrush(m_OuterBorderDarkColor);
                    Region region2 = region.Clone();
                    region2.Exclude(graphicsPath4);
                    g.FillRegion(solidBrush1, region2);
                    g.SetClip(graphicsPath4, CombineMode.Exclude);
                    Pen pen1 = new Pen(solidBrush1);
                    g.DrawPath(pen1, graphicsPath);
                    g.DrawPath(pen1, graphicsPath1);
                    pen1.Dispose();
                    g.ResetClip();
                    solidBrush1.Dispose();
                    region2.Dispose();
                    region.Dispose();
                }
                if (m_MiddleBorderLength > 0)
                {
                    Region region3 = new Region(graphicsPath1);
                    region3.Exclude(graphicsPath2);
                    SolidBrush solidBrush2 = new SolidBrush(m_MiddleBorderColor);
                    g.FillRegion(solidBrush2, region3);
                    Pen pen2 = new Pen(solidBrush2);
                    g.DrawPath(pen2, graphicsPath1);
                    g.DrawPath(pen2, graphicsPath2);
                    pen2.Dispose();
                    solidBrush2.Dispose();
                    region3.Dispose();
                }
                if (m_InnerBorderLength > 0)
                {
                    Region region4 = new Region(graphicsPath2);
                    region4.Exclude(graphicsPath3);
                    SolidBrush solidBrush3 = new SolidBrush(m_InnerBorderDarkColor);
                    Region region5 = region4.Clone();
                    region5.Intersect(graphicsPath4);
                    g.FillRegion(solidBrush3, region5);
                    g.SetClip(graphicsPath4);
                    Pen pen3 = new Pen(solidBrush3);
                    g.DrawPath(pen3, graphicsPath2);
                    g.DrawPath(pen3, graphicsPath3);
                    pen3.Dispose();
                    g.ResetClip();
                    solidBrush3.Dispose();
                    region5.Dispose();
                    SolidBrush solidBrush4 = new SolidBrush(m_InnerBorderLightColor);
                    Region region6 = region4.Clone();
                    region6.Exclude(graphicsPath4);
                    g.FillRegion(solidBrush4, region6);
                    g.SetClip(graphicsPath4, CombineMode.Exclude);
                    Pen pen4 = new Pen(solidBrush4);
                    g.DrawPath(pen4, graphicsPath2);
                    g.DrawPath(pen4, graphicsPath3);
                    pen4.Dispose();
                    g.ResetClip();
                    solidBrush4.Dispose();
                    region6.Dispose();
                    region4.Dispose();
                }
                graphicsPath4.Dispose();
            }
            else if (m_BorderGradientType != DAS_BorderGradientStyle.BGS_Ring)
            {
                if (m_BorderGradientType != DAS_BorderGradientStyle.BGS_Linear)
                {
                    if (m_BorderGradientType == DAS_BorderGradientStyle.BGS_Linear2)
                    {
                        goto Label2;
                    }
                    if (m_BorderGradientType == DAS_BorderGradientStyle.BGS_Path)
                    {
                        Blend blend = new Blend();
                        bool flag = false;
                        if ((double)m_BorderGradientRate < 0.49999999999 || (double)m_BorderGradientRate > 0.5000000000001)
                        {
                            flag = true;
                            blend.Factors = new float[3];
                            blend.Positions = new float[3];
                            blend.Factors[0] = 0f;
                            blend.Positions[0] = 0f;
                            blend.Factors[1] = m_BorderGradientRate;
                            blend.Positions[1] = 1f - m_BorderGradientRate;
                            blend.Factors[2] = 1f;
                            blend.Positions[2] = 1f;
                        }
                        if (m_OuterBorderLength > 0)
                        {
                            double long0 = 3.14159265358979 * (double)m_BorderGradientAngle / 180;
                            GraphicsPath graphicsPath5 = new GraphicsPath();
                            point = new Point[] { new Point(rectangle.Left - 1, rectangle.Top - 1), new Point(rectangle.Left + rectangle.Width + 1, rectangle.Top - 1), new Point(rectangle.Left + rectangle.Width + 1, rectangle.Top + rectangle.Height + 1), new Point(rectangle.Left - 1, rectangle.Top + rectangle.Height + 1) };
                            graphicsPath5.AddPolygon(point);
                            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath5)
                            {
                                SurroundColors = new Color[] { m_OuterBorderDarkColor }
                            };
                            PointF x = new PointF()
                            {
                                X = (float)rectangle.Left + (float)rectangle.Width / 2f,
                                Y = (float)rectangle.Top + (float)rectangle.Height / 2f
                            };
                            if (Math.Abs(Math.Sin(long0)) < 1E-10)
                            {
                                single = 0f;
                                height = (float)(Math.Cos(long0) * (double)(rectangle.Width - m_OuterBorderLength) / 2);
                            }
                            else if (Math.Abs(Math.Cos(long0)) >= 1E-10)
                            {
                                height = (float)((double)(rectangle.Height - m_OuterBorderLength) / (2 * Math.Tan(long0)));
                                single = (float)(Math.Tan(long0) * (double)(rectangle.Width - m_OuterBorderLength) / 2);
                                height = (Math.Cos(long0) >= 0 ? Math.Abs(height) : -Math.Abs(height));
                                single = (Math.Sin(long0) >= 0 ? Math.Abs(single) : -Math.Abs(single));
                                if (height < -((float)(rectangle.Width - m_OuterBorderLength) / 2f))
                                {
                                    height = -((float)(rectangle.Width - m_OuterBorderLength) / 2f);
                                }
                                else if (height > (float)(rectangle.Width - m_OuterBorderLength) / 2f)
                                {
                                    height = (float)(rectangle.Width - m_OuterBorderLength) / 2f;
                                }
                                if (single < -((float)(rectangle.Height - m_OuterBorderLength) / 2f))
                                {
                                    single = -((float)(rectangle.Height - m_OuterBorderLength) / 2f);
                                }
                                else if (single > (float)(rectangle.Height - m_OuterBorderLength) / 2f)
                                {
                                    single = (float)(rectangle.Height - m_OuterBorderLength) / 2f;
                                }
                            }
                            else
                            {
                                height = 0f;
                                single = (float)(Math.Sin(long0) * (double)(rectangle.Height - m_OuterBorderLength) / 2);
                            }
                            x.X = x.X + height;
                            x.Y = x.Y + single;
                            if (flag)
                            {
                                pathGradientBrush.Blend = blend;
                            }
                            pathGradientBrush.CenterPoint = x;
                            pathGradientBrush.CenterColor = m_OuterBorderLightColor;
                            Region region7 = new Region(graphicsPath);
                            Region region8 = new Region(graphicsPath1);
                            region7.Exclude(region8);
                            g.FillRegion(pathGradientBrush, region7);
                            Pen pen5 = new Pen(m_OuterBorderDarkColor);
                            g.DrawPath(pen5, graphicsPath);
                            g.DrawPath(pen5, graphicsPath1);
                            pen5.Dispose();
                            pathGradientBrush.Dispose();
                            region7.Dispose();
                            region8.Dispose();
                        }
                        if (m_MiddleBorderLength > 0)
                        {
                            Region region9 = new Region(graphicsPath1);
                            region9.Exclude(graphicsPath2);
                            SolidBrush solidBrush5 = new SolidBrush(m_MiddleBorderColor);
                            g.FillRegion(solidBrush5, region9);
                            Pen pen6 = new Pen(solidBrush5);
                            g.DrawPath(pen6, graphicsPath1);
                            g.DrawPath(pen6, graphicsPath2);
                            pen6.Dispose();
                            solidBrush5.Dispose();
                            region9.Dispose();
                        }
                        if (m_InnerBorderLength > 0)
                        {
                            double num = 3.14159265358979 * (double)m_BorderGradientAngle / 180 + 3.14159265358979;
                            GraphicsPath graphicsPath6 = new GraphicsPath();
                            point = new Point[] { new Point(rectangle2.Left, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top + rectangle2.Height), new Point(rectangle2.Left, rectangle2.Top + rectangle2.Height) };
                            graphicsPath6.AddPolygon(point);
                            PathGradientBrush color4 = new PathGradientBrush(graphicsPath6)
                            {
                                SurroundColors = new Color[] { m_InnerBorderDarkColor }
                            };
                            PointF y = new PointF()
                            {
                                X = (float)rectangle2.Left + (float)rectangle2.Width / 2f,
                                Y = (float)rectangle2.Top + (float)rectangle2.Height / 2f
                            };
                            if (Math.Abs(Math.Sin(num)) < 1E-10)
                            {
                                height1 = 0f;
                                width = (float)(Math.Cos(num) * (double)(rectangle2.Width - m_InnerBorderLength) / 2);
                            }
                            else if (Math.Abs(Math.Cos(num)) >= 1E-10)
                            {
                                width = (float)((double)(rectangle2.Height - m_InnerBorderLength) / (2 * Math.Tan(num)));
                                height1 = (float)(Math.Tan(num) * (double)(rectangle2.Width - m_InnerBorderLength) / 2);
                                width = (Math.Cos(num) >= 0 ? Math.Abs(width) : -Math.Abs(width));
                                height1 = (Math.Sin(num) >= 0 ? Math.Abs(height1) : -Math.Abs(height1));
                                if (width < -((float)(rectangle2.Width - m_InnerBorderLength) / 2f))
                                {
                                    width = -((float)(rectangle2.Width - m_InnerBorderLength) / 2f);
                                }
                                else if (width > (float)(rectangle2.Width - m_InnerBorderLength) / 2f)
                                {
                                    width = (float)(rectangle2.Width - m_InnerBorderLength) / 2f;
                                }
                                if (height1 < -((float)(rectangle2.Height - m_InnerBorderLength) / 2f))
                                {
                                    height1 = -((float)(rectangle2.Height - m_InnerBorderLength) / 2f);
                                }
                                else if (height1 > (float)(rectangle2.Height - m_InnerBorderLength) / 2f)
                                {
                                    height1 = (float)(rectangle2.Height - m_InnerBorderLength) / 2f;
                                }
                            }
                            else
                            {
                                width = 0f;
                                height1 = (float)(Math.Sin(num) * (double)(rectangle2.Height - m_InnerBorderLength) / 2);
                            }
                            y.X = y.X + width;
                            y.Y = y.Y + height1;
                            if (flag)
                            {
                                color4.Blend = blend;
                            }
                            color4.CenterPoint = y;
                            color4.CenterColor = m_InnerBorderLightColor;
                            Region region10 = new Region(graphicsPath2);
                            Region region11 = new Region(graphicsPath3);
                            region10.Exclude(region11);
                            g.FillRegion(color4, region10);
                            Pen pen7 = new Pen(m_InnerBorderDarkColor);
                            g.DrawPath(pen7, graphicsPath2);
                            g.DrawPath(pen7, graphicsPath3);
                            pen7.Dispose();
                            color4.Dispose();
                            region10.Dispose();
                            region11.Dispose();
                            goto Label0;
                        }
                        else
                        {
                            goto Label0;
                        }
                    }
                    else
                    {
                        goto Label0;
                    }
                }
            Label2:
                Blend float0 = new Blend();
                bool flag1 = false;
                float float3 = 0f;
                if (m_BorderLightIntermediateBrightness >= 0f && (double)m_BorderLightIntermediateBrightness <= 1)
                {
                    float3 = m_BorderLightIntermediateBrightness;
                }
                if (m_BorderGradientLightPos1 > 0f && (double)m_BorderGradientLightPos1 < 1)
                {
                    flag1 = true;
                    if (m_BorderGradientLightPos2 <= 0f || (double)m_BorderGradientLightPos2 > 1)
                    {
                        float0.Factors = new float[5];
                        float0.Positions = new float[5];
                        float0.Factors[0] = 0f;
                        float0.Positions[0] = 0f;
                        float0.Factors[1] = m_BorderGradientRate;
                        float0.Positions[1] = m_BorderGradientLightPos1 * (1f - m_BorderGradientRate);
                        float0.Factors[2] = 1f;
                        float0.Positions[2] = m_BorderGradientLightPos1;
                        float0.Factors[3] = m_BorderGradientRate;
                        float0.Positions[3] = (1f - m_BorderGradientLightPos1) * m_BorderGradientRate + m_BorderGradientLightPos1;
                        float0.Factors[4] = 0f;
                        float0.Positions[4] = 1f;
                    }
                    else
                    {
                        float0.Factors = new float[9];
                        float0.Positions = new float[9];
                        if (m_BorderGradientLightPos1 <= m_BorderGradientLightPos2)
                        {
                            float0.Factors[0] = 0f;
                            float0.Positions[0] = 0f;
                            float0.Factors[1] = m_BorderGradientRate;
                            float0.Positions[1] = m_BorderGradientLightPos1 * (1f - m_BorderGradientRate);
                            float0.Factors[2] = 1f;
                            float0.Positions[2] = m_BorderGradientLightPos1;
                            float0.Factors[3] = (1f - float3) * m_BorderGradientRate + float3;
                            float0.Positions[3] = m_BorderGradientLightPos1 + (m_BorderGradientLightPos2 - m_BorderGradientLightPos1) / 2f * m_BorderGradientRate;
                            float0.Factors[4] = float3;
                            float0.Positions[4] = (m_BorderGradientLightPos1 + m_BorderGradientLightPos2) / 2f;
                            float0.Factors[5] = (1f - float3) * m_BorderGradientRate + float3;
                            float0.Positions[5] = (m_BorderGradientLightPos1 + m_BorderGradientLightPos2) / 2f + (m_BorderGradientLightPos2 - m_BorderGradientLightPos1) / 2f * (1f - m_BorderGradientRate);
                            float0.Factors[6] = 1f;
                            float0.Positions[6] = m_BorderGradientLightPos2;
                            float0.Factors[7] = m_BorderGradientRate;
                            float0.Positions[7] = m_BorderGradientLightPos2 + (1f - m_BorderGradientLightPos2) * m_BorderGradientRate;
                            float0.Factors[8] = 0f;
                            float0.Positions[8] = 1f;
                            if (m_BorderGradientLightPos1 == m_BorderGradientLightPos2)
                            {
                                float0.Factors[3] = 1f;
                                float0.Factors[4] = 1f;
                                float0.Factors[5] = 1f;
                            }
                            if (m_BorderGradientLightPos2 == 1f)
                            {
                                float0.Factors[7] = 1f;
                                float0.Factors[8] = 1f;
                            }
                        }
                        else
                        {
                            float0.Factors[0] = 0f;
                            float0.Positions[0] = 0f;
                            float0.Factors[1] = m_BorderGradientRate;
                            float0.Positions[1] = m_BorderGradientLightPos2 * (1f - m_BorderGradientRate);
                            float0.Factors[2] = 1f;
                            float0.Positions[2] = m_BorderGradientLightPos2;
                            float0.Factors[3] = (1f - float3) * m_BorderGradientRate + float3;
                            float0.Positions[3] = m_BorderGradientLightPos2 + (m_BorderGradientLightPos1 - m_BorderGradientLightPos2) / 2f * m_BorderGradientRate;
                            float0.Factors[4] = float3;
                            float0.Positions[4] = (m_BorderGradientLightPos1 + m_BorderGradientLightPos2) / 2f;
                            float0.Factors[5] = (1f - float3) * m_BorderGradientRate + float3;
                            float0.Positions[5] = (m_BorderGradientLightPos1 + m_BorderGradientLightPos2) / 2f + (m_BorderGradientLightPos1 - m_BorderGradientLightPos2) / 2f * (1f - m_BorderGradientRate);
                            float0.Factors[6] = 1f;
                            float0.Positions[6] = m_BorderGradientLightPos1;
                            float0.Factors[7] = m_BorderGradientRate;
                            float0.Positions[7] = m_BorderGradientLightPos1 + (1f - m_BorderGradientLightPos1) * m_BorderGradientRate;
                            float0.Factors[8] = 0f;
                            float0.Positions[8] = 1f;
                        }
                    }
                }
                else if ((double)m_BorderGradientRate < 0.49999999999 || (double)m_BorderGradientRate > 0.5000000000001)
                {
                    flag1 = true;
                    float0.Factors = new float[3];
                    float0.Positions = new float[3];
                    float0.Factors[0] = 0f;
                    float0.Positions[0] = 0f;
                    float0.Factors[1] = m_BorderGradientRate;
                    float0.Positions[1] = 1f - m_BorderGradientRate;
                    float0.Factors[2] = 1f;
                    float0.Positions[2] = 1f;
                }
                if (m_OuterBorderLength > 0)
                {
                    Rectangle rectangle4 = new Rectangle(rectangle.Left - 1, rectangle.Top - 1, rectangle.Width + 2, rectangle.Height + 2);
                    LinearGradientBrush linearGradientBrush1 = new LinearGradientBrush(rectangle4, m_OuterBorderDarkColor, m_OuterBorderLightColor, (float)m_BorderGradientAngle);
                    if (flag1)
                    {
                        linearGradientBrush1.Blend = float0;
                    }
                    Region region12 = new Region(graphicsPath);
                    Region region13 = new Region(graphicsPath1);
                    region12.Exclude(region13);
                    g.FillRegion(linearGradientBrush1, region12);
                    Pen pen8 = new Pen(linearGradientBrush1);
                    g.DrawPath(pen8, graphicsPath);
                    g.DrawPath(pen8, graphicsPath1);
                    pen8.Dispose();
                    linearGradientBrush1.Dispose();
                    region12.Dispose();
                    region13.Dispose();
                }
                if (m_MiddleBorderLength > 0)
                {
                    Region region14 = new Region(graphicsPath1);
                    region14.Exclude(graphicsPath2);
                    SolidBrush solidBrush6 = new SolidBrush(m_MiddleBorderColor);
                    g.FillRegion(solidBrush6, region14);
                    Pen pen9 = new Pen(solidBrush6);
                    g.DrawPath(pen9, graphicsPath1);
                    g.DrawPath(pen9, graphicsPath2);
                    pen9.Dispose();
                    solidBrush6.Dispose();
                    region14.Dispose();
                }
                if (m_InnerBorderLength > 0)
                {
                    linearGradientBrush = (m_BorderGradientType != DAS_BorderGradientStyle.BGS_Linear ? new LinearGradientBrush(rectangle2, m_InnerBorderDarkColor, m_InnerBorderLightColor, (float)(m_BorderGradientAngle + (long)180)) : new LinearGradientBrush(rectangle2, m_InnerBorderLightColor, m_InnerBorderDarkColor, (float)m_BorderGradientAngle));
                    if (flag1)
                    {
                        linearGradientBrush.Blend = float0;
                    }
                    Region region15 = new Region(graphicsPath2);
                    Region region16 = new Region(graphicsPath3);
                    region15.Exclude(region16);
                    g.FillRegion(linearGradientBrush, region15);
                    Pen pen10 = new Pen(linearGradientBrush);
                    g.DrawPath(pen10, graphicsPath2);
                    g.DrawPath(pen10, graphicsPath3);
                    pen10.Dispose();
                    linearGradientBrush.Dispose();
                    region15.Dispose();
                    region16.Dispose();
                }
            }
            else
            {
                Blend blend1 = new Blend()
                {
                    Factors = new float[3],
                    Positions = new float[3]
                };
                blend1.Factors[0] = 0f;
                blend1.Positions[0] = 0f;
                blend1.Factors[2] = 1f;
                blend1.Positions[2] = 1f;
                if (m_OuterBorderLength > 0)
                {
                    blend1.Factors[1] = m_BorderGradientRate;
                    blend1.Positions[1] = 1f - m_BorderGradientRate;
                    PathGradientBrush pathGradientBrush1 = new PathGradientBrush(graphicsPath)
                    {
                        SurroundColors = new Color[] { m_OuterBorderDarkColor },
                        CenterColor = m_OuterBorderLightColor
                    };
                    PointF pointF = new PointF()
                    {
                        X = (float)rectangle1.Width / (float)rectangle.Width,
                        Y = (float)rectangle1.Height / (float)rectangle.Height
                    };
                    pathGradientBrush1.FocusScales = pointF;
                    Region region17 = new Region(graphicsPath);
                    Region region18 = new Region(graphicsPath1);
                    region17.Exclude(region18);
                    g.FillRegion(pathGradientBrush1, region17);
                    Pen pen11 = new Pen(m_OuterBorderDarkColor);
                    g.DrawPath(pen11, graphicsPath);
                    pen11.Dispose();
                    pathGradientBrush1.Dispose();
                    region17.Dispose();
                    region18.Dispose();
                }
                if (m_MiddleBorderLength > 0)
                {
                    Region region19 = new Region(graphicsPath1);
                    region19.Exclude(graphicsPath2);
                    SolidBrush solidBrush7 = new SolidBrush(m_MiddleBorderColor);
                    g.FillRegion(solidBrush7, region19);
                    Pen pen12 = new Pen(solidBrush7);
                    g.DrawPath(pen12, graphicsPath1);
                    g.DrawPath(pen12, graphicsPath2);
                    pen12.Dispose();
                    solidBrush7.Dispose();
                    region19.Dispose();
                }
                if (m_InnerBorderLength > 0)
                {
                    blend1.Factors[1] = 1f - m_BorderGradientRate;
                    blend1.Positions[1] = m_BorderGradientRate;
                    PathGradientBrush pathGradientBrush2 = new PathGradientBrush(graphicsPath2)
                    {
                        SurroundColors = new Color[] { m_InnerBorderLightColor },
                        Blend = blend1,
                        CenterColor = m_InnerBorderDarkColor
                    };
                    PointF pointF1 = new PointF()
                    {
                        X = (float)rectangle3.Width / (float)rectangle2.Width,
                        Y = (float)rectangle3.Height / (float)rectangle2.Height
                    };
                    pathGradientBrush2.FocusScales = pointF1;
                    Region region20 = new Region(graphicsPath2);
                    Region region21 = new Region(graphicsPath3);
                    region20.Exclude(region21);
                    g.FillRegion(pathGradientBrush2, region20);
                    Pen pen13 = new Pen(m_InnerBorderDarkColor);
                    g.DrawPath(pen13, graphicsPath3);
                    pen13.Dispose();
                    pathGradientBrush2.Dispose();
                    region20.Dispose();
                    region21.Dispose();
                }
            }
        Label0:
            if (m_BorderExteriorLength > 0)
            {
                SolidBrush solidBrush8 = new SolidBrush(m_BorderExteriorColor);
                GraphicsPath graphicsPath7 = new GraphicsPath();
                this.SetRoundRect(graphicsPath7, rec_width, m_RoundRadius);
                Region region22 = new Region(graphicsPath7);
                region22.Exclude(graphicsPath);
                g.FillRegion(solidBrush8, region22);
                Pen pen14 = new Pen(solidBrush8);
                g.DrawPath(pen14, graphicsPath7);
                g.DrawPath(pen14, graphicsPath);
                pen14.Dispose();
                solidBrush8.Dispose();
                region22.Dispose();
                graphicsPath7.Dispose();
            }
            graphicsPath3.Dispose();
            graphicsPath2.Dispose();
            graphicsPath.Dispose();
        }

        public void SetValue(Graphics g, Rectangle rectangle_0, DAS_ShapeStyle m_Shape, GraphicsPath graphicsPath_0, Color m_OffColor, Color m_OffGradientColor, DAS_BkGradientStyle m_GradientType, int m_GradientAngle, float m_GradientRate, int m_RoundRadius, int m_ArrowWidth, float m_ShinePosition)
        {
            RectangleF rectangleF;
            float height;
            float single;
            if (m_GradientType != DAS_BkGradientStyle.BKGS_Polygon && m_GradientType != DAS_BkGradientStyle.BKGS_Sphere)
            {
                if (m_GradientType != DAS_BkGradientStyle.BKGS_Sphere2)
                {
                    if (m_GradientType != DAS_BkGradientStyle.BKGS_Linear)
                    {
                        if (m_GradientType != DAS_BkGradientStyle.BKGS_Linear2)
                        {
                            if (m_GradientType == DAS_BkGradientStyle.BKGS_Shine)
                            {
                                Blend blend = new Blend()
                                {
                                    Factors = new float[3],
                                    Positions = new float[3]
                                };
                                blend.Factors[0] = 0f;
                                blend.Positions[0] = 0f;
                                blend.Factors[1] = m_GradientRate;
                                blend.Positions[1] = 1f - m_GradientRate;
                                blend.Factors[2] = 1f;
                                blend.Positions[2] = 1f;
                                double int0 = 3.14159265358979 * (double)m_GradientAngle / 180;
                                GraphicsPath graphicsPath = new GraphicsPath();
                                Rectangle rectangle = new Rectangle(rectangle_0.Left - 1, rectangle_0.Top - 1, rectangle_0.Width + 2, rectangle_0.Height + 2);
                                if (m_Shape == DAS_ShapeStyle.SS_Rect)
                                {
                                    graphicsPath.AddRectangle(rectangle);
                                }
                                else if (m_Shape == DAS_ShapeStyle.SS_RoundRect)
                                {
                                    this.SetRoundRect(graphicsPath, rectangle, m_RoundRadius);
                                }
                                else if (m_Shape != DAS_ShapeStyle.SS_Circle)
                                {
                                    graphicsPath = (GraphicsPath)graphicsPath_0.Clone();
                                }
                                else
                                {
                                    graphicsPath.AddEllipse(rectangle);
                                }
                                PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath)
                                {
                                    SurroundColors = new Color[] { m_OffColor }
                                };
                                PointF x = new PointF()
                                {
                                    X = (float)rectangle_0.Left + (float)rectangle_0.Width / 2f,
                                    Y = (float)rectangle_0.Top + (float)rectangle_0.Height / 2f
                                };
                                if (Math.Abs(Math.Sin(int0)) < 1E-10)
                                {
                                    single = 0f;
                                    height = (float)(Math.Cos(int0) * (double)rectangle_0.Width / 2);
                                }
                                else if (Math.Abs(Math.Cos(int0)) >= 1E-10)
                                {
                                    height = (float)((double)rectangle_0.Height / (2 * Math.Tan(int0)));
                                    single = (float)(Math.Tan(int0) * (double)rectangle_0.Width / 2);
                                    height = (Math.Cos(int0) >= 0 ? Math.Abs(height) : -Math.Abs(height));
                                    single = (Math.Sin(int0) >= 0 ? Math.Abs(single) : -Math.Abs(single));
                                    if (height < -((float)rectangle_0.Width / 2f))
                                    {
                                        height = -((float)rectangle_0.Width / 2f);
                                    }
                                    else if (height > (float)rectangle_0.Width / 2f)
                                    {
                                        height = (float)rectangle_0.Width / 2f;
                                    }
                                    if (single < -((float)rectangle_0.Height / 2f))
                                    {
                                        single = -((float)rectangle_0.Height / 2f);
                                    }
                                    else if (single > (float)rectangle_0.Height / 2f)
                                    {
                                        single = (float)rectangle_0.Height / 2f;
                                    }
                                }
                                else
                                {
                                    height = 0f;
                                    single = (float)(Math.Sin(int0) * (double)rectangle_0.Height / 2);
                                }
                                if (m_Shape == DAS_ShapeStyle.SS_Circle)
                                {
                                    height = (float)((double)rectangle_0.Width * Math.Cos(int0) / 2);
                                    single = (float)((double)rectangle_0.Height * Math.Sin(int0) / 2);
                                }
                                x.X = x.X + height * m_ShinePosition;
                                x.Y = x.Y + single * m_ShinePosition;
                                pathGradientBrush.Blend = blend;
                                pathGradientBrush.CenterPoint = x;
                                pathGradientBrush.CenterColor = m_OffGradientColor;
                                if (graphicsPath_0 != null)
                                {
                                    g.FillPath(pathGradientBrush, graphicsPath_0);
                                }
                                else if (m_Shape != DAS_ShapeStyle.SS_Circle)
                                {
                                    g.FillRectangle(pathGradientBrush, rectangle_0);
                                }
                                else
                                {
                                    g.FillEllipse(pathGradientBrush, rectangle);
                                }
                                pathGradientBrush.Dispose();
                            }
                            return;
                        }
                    }
                    Blend float0 = new Blend();
                    if (m_GradientType != DAS_BkGradientStyle.BKGS_Linear)
                    {
                        float0.Factors = new float[5];
                        float0.Positions = new float[5];
                        float0.Factors[0] = 0f;
                        float0.Positions[0] = 0f;
                        float0.Factors[1] = m_GradientRate;
                        float0.Positions[1] = 0.5f * (1f - m_GradientRate);
                        float0.Factors[2] = 1f;
                        float0.Positions[2] = 0.5f;
                        float0.Factors[3] = m_GradientRate;
                        float0.Positions[3] = 0.5f + 0.5f * m_GradientRate;
                        float0.Factors[4] = 0f;
                        float0.Positions[4] = 1f;
                    }
                    else
                    {
                        float0.Factors = new float[3];
                        float0.Positions = new float[3];
                        float0.Factors[0] = 0f;
                        float0.Positions[0] = 0f;
                        float0.Factors[1] = m_GradientRate;
                        float0.Positions[1] = 0.5f * (1f - m_GradientRate);
                        float0.Factors[2] = 1f;
                        float0.Positions[2] = 1f;
                    }
                    Rectangle rectangle1 = new Rectangle(rectangle_0.Left - 1, rectangle_0.Top - 1, rectangle_0.Width + 2, rectangle_0.Height + 2);
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle1, m_OffColor, m_OffGradientColor, (float)m_GradientAngle)
                    {
                        Blend = float0
                    };
                    if (graphicsPath_0 != null)
                    {
                        g.FillPath(linearGradientBrush, graphicsPath_0);
                    }
                    else
                    {
                        g.FillRectangle(linearGradientBrush, rectangle_0);
                    }
                    linearGradientBrush.Dispose();
                    return;
                }
            }
            Blend blend1 = new Blend()
            {
                Factors = new float[3],
                Positions = new float[3]
            };
            blend1.Factors[0] = 0f;
            blend1.Positions[0] = 0f;
            blend1.Factors[2] = 1f;
            blend1.Positions[2] = 1f;
            blend1.Factors[1] = m_GradientRate;
            blend1.Positions[1] = 1f - m_GradientRate;
            GraphicsPath graphicsPath1 = new GraphicsPath();
            if (m_GradientType != DAS_BkGradientStyle.BKGS_Polygon)
            {
                rectangleF = (m_Shape == DAS_ShapeStyle.SS_Circle ? new RectangleF((float)(rectangle_0.Left - 1), (float)(rectangle_0.Top - 1), (float)(rectangle_0.Width + 2), (float)(rectangle_0.Height + 2)) : new RectangleF((float)rectangle_0.Left - 0.415f * (float)rectangle_0.Width / 2f, (float)rectangle_0.Top - 0.415f * (float)rectangle_0.Height / 2f, 1.415f * (float)rectangle_0.Width, 1.415f * (float)rectangle_0.Height));
                graphicsPath1.AddEllipse(rectangleF);
            }
            else
            {
                Point[] point = new Point[] { new Point(rectangle_0.Left, rectangle_0.Top), new Point(rectangle_0.Left + rectangle_0.Width, rectangle_0.Top), new Point(rectangle_0.Left + rectangle_0.Width, rectangle_0.Top + rectangle_0.Height), new Point(rectangle_0.Left, rectangle_0.Top + rectangle_0.Height) };
                graphicsPath1.AddPolygon(point);
            }
            PathGradientBrush pathGradientBrush1 = new PathGradientBrush(graphicsPath1)
            {
                SurroundColors = new Color[] { m_OffColor },
                Blend = blend1,
                CenterColor = m_OffGradientColor
            };
            if (m_GradientType == DAS_BkGradientStyle.BKGS_Sphere2)
            {
                PointF width = new PointF();
                if (rectangle_0.Width <= rectangle_0.Height)
                {
                    width.X = 0f;
                    width.Y = (float)(rectangle_0.Height - rectangle_0.Width) / (float)rectangle_0.Height;
                }
                else
                {
                    width.X = (float)(rectangle_0.Width - rectangle_0.Height) / (float)rectangle_0.Width;
                    width.Y = 0f;
                }
                pathGradientBrush1.FocusScales = width;
            }
            if (graphicsPath_0 != null)
            {
                g.FillPath(pathGradientBrush1, graphicsPath_0);
            }
            else
            {
                g.FillRectangle(pathGradientBrush1, rectangle_0);
            }
            pathGradientBrush1.Dispose();
        }

        public void SetRoundRect(GraphicsPath graphicsPath_0, Rectangle rec, int m_RoundRadius)
        {
            int int0 = m_RoundRadius;
            int left = rec.Left;
            int top = rec.Top;
            int width = rec.Width - 1;
            int height = rec.Height - 1;
            if (2 * int0 > width)
            {
                int0 = width / 2;
            }
            if (2 * int0 > height)
            {
                int0 = height / 2;
            }
            if (int0 <= 0)
            {
                graphicsPath_0.AddLine(left, top, left + width, top);
                graphicsPath_0.AddLine(left + width, top, left + width, top + height);
                graphicsPath_0.AddLine(left + width, top + height, left, top + height);
                graphicsPath_0.AddLine(left, top + height, left, top);
            }
            else
            {
                graphicsPath_0.AddLine(left + int0, top, left + width - int0, top);
                graphicsPath_0.AddArc(left + width - 2 * int0, top, 2 * int0, 2 * int0, 270f, 90f);
                graphicsPath_0.AddLine(left + width, top + int0, left + width, top + height - int0);
                graphicsPath_0.AddArc(left + width - 2 * int0, top + height - 2 * int0, 2 * int0, 2 * int0, 0f, 90f);
                graphicsPath_0.AddLine(left + width - int0, top + height, left + int0, top + height);
                graphicsPath_0.AddArc(left, top + height - 2 * int0, 2 * int0, 2 * int0, 90f, 90f);
                graphicsPath_0.AddLine(left, top + height - int0, left, top + int0);
                graphicsPath_0.AddArc(left, top, 2 * int0, 2 * int0, 180f, 90f);
            }
            graphicsPath_0.CloseFigure();
        }

        public void SetArrow(Graphics g, Rectangle rec_width, DAS_ShapeStyle m_Shape, int m_RoundRadius, int m_ArrowWidth, int m_OuterBorderLength, Color m_OuterBorderDarkColor, Color m_OuterBorderLightColor, int m_MiddleBorderLength, Color m_MiddleBorderColor, int m_InnerBorderLength, Color m_InnerBorderDarkColor, Color m_InnerBorderLightColor, int m_BorderExteriorLength, Color m_BorderExteriorColor, DAS_BorderGradientStyle m_BorderGradientType, long m_BorderGradientAngle, float m_BorderGradientRate, float m_BorderGradientLightPos1, float m_BorderGradientLightPos2, float m_BorderLightIntermediateBrightness)
        {
            LinearGradientBrush linearGradientBrush;
            float height;
            float single;
            float width;
            float height1;
            Point[] point;
            if (m_Shape == DAS_ShapeStyle.SS_Rect)
            {
                this.SetRect(g, rec_width, m_OuterBorderLength, m_OuterBorderDarkColor, m_OuterBorderLightColor, m_MiddleBorderLength, m_MiddleBorderColor, m_InnerBorderLength, m_InnerBorderDarkColor, m_InnerBorderLightColor, m_BorderExteriorLength, m_BorderExteriorColor, m_BorderGradientType, (int)m_BorderGradientAngle, m_BorderGradientRate, m_BorderGradientLightPos1, m_BorderGradientLightPos2, m_BorderLightIntermediateBrightness);
                return;
            }
            if (m_Shape == DAS_ShapeStyle.SS_RoundRect)
            {
                this.SetRoundRect2(g, rec_width, m_RoundRadius, m_OuterBorderLength, m_OuterBorderDarkColor, m_OuterBorderLightColor, m_MiddleBorderLength, m_MiddleBorderColor, m_InnerBorderLength, m_InnerBorderDarkColor, m_InnerBorderLightColor, m_BorderExteriorLength, m_BorderExteriorColor, m_BorderGradientType, m_BorderGradientAngle, m_BorderGradientRate, m_BorderGradientLightPos1, m_BorderGradientLightPos2, m_BorderLightIntermediateBrightness);
                return;
            }
            if (m_Shape == DAS_ShapeStyle.SS_Circle)
            {
                this.SetCircle(g, rec_width, m_OuterBorderLength, m_OuterBorderDarkColor, m_OuterBorderLightColor, m_MiddleBorderLength, m_MiddleBorderColor, m_InnerBorderLength, m_InnerBorderDarkColor, m_InnerBorderLightColor, m_BorderExteriorLength, m_BorderExteriorColor, m_BorderGradientType, m_BorderGradientAngle, m_BorderGradientRate, m_BorderGradientLightPos1, m_BorderGradientLightPos2, m_BorderLightIntermediateBrightness);
                return;
            }
            Rectangle rectangle = new Rectangle(rec_width.Left + m_BorderExteriorLength, rec_width.Top + m_BorderExteriorLength, rec_width.Width - 2 * m_BorderExteriorLength, rec_width.Height - 2 * m_BorderExteriorLength);
            Rectangle rectangle1 = new Rectangle(rec_width.Left + m_BorderExteriorLength + m_OuterBorderLength, rec_width.Top + m_BorderExteriorLength + m_OuterBorderLength, rec_width.Width - 2 * (m_BorderExteriorLength + m_OuterBorderLength), rec_width.Height - 2 * (m_BorderExteriorLength + m_OuterBorderLength));
            Rectangle rectangle2 = new Rectangle(rec_width.Left + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength, rec_width.Top + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength, rec_width.Width - 2 * (m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength), rec_width.Height - 2 * (m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength));
            Rectangle rectangle3 = new Rectangle(rec_width.Left + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength, rec_width.Top + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength, rec_width.Width - 2 * (m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength), rec_width.Height - 2 * (m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength));
            int int1 = m_ArrowWidth + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength;
            GraphicsPath graphicsPath = new GraphicsPath();
            this.method_6(graphicsPath, rec_width, m_Shape, int1, m_BorderExteriorLength);
            GraphicsPath graphicsPath1 = new GraphicsPath();
            this.method_6(graphicsPath1, rec_width, m_Shape, int1, m_BorderExteriorLength + m_OuterBorderLength);
            GraphicsPath graphicsPath2 = new GraphicsPath();
            this.method_6(graphicsPath2, rec_width, m_Shape, int1, m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength);
            GraphicsPath graphicsPath3 = new GraphicsPath();
            this.method_6(graphicsPath3, rec_width, m_Shape, int1, m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength);
            if (m_BorderGradientType == DAS_BorderGradientStyle.BGS_Flat)
            {
                PointF[] left = new PointF[5];
                left[0].X = (float)rectangle.Left;
                left[0].Y = (float)rectangle.Top;
                left[1].X = (float)rectangle.Left;
                left[1].Y = (float)(rectangle.Top + rectangle.Height);
                if (rectangle.Width < rectangle.Height)
                {
                    left[2].X = (float)rectangle.Left + (float)rectangle.Width / 2f;
                    left[2].Y = (float)(rectangle.Top + rectangle.Height) - (float)rectangle.Width / 2f;
                    left[3].X = (float)rectangle.Left + (float)rectangle.Width / 2f;
                    left[3].Y = (float)rectangle.Top + (float)rectangle.Width / 2f;
                }
                else
                {
                    left[2].X = (float)rectangle.Left + (float)rectangle.Height / 2f;
                    left[2].Y = (float)rectangle.Top + (float)rectangle.Height / 2f;
                    left[3].X = (float)(rectangle.Left + rectangle.Width) - (float)rectangle.Height / 2f;
                    left[3].Y = (float)rectangle.Top + (float)rectangle.Height / 2f;
                }
                left[4].X = (float)(rectangle.Left + rectangle.Width);
                left[4].Y = (float)rectangle.Top;
                GraphicsPath graphicsPath4 = new GraphicsPath();
                graphicsPath4.AddPolygon(left);
                if (m_OuterBorderLength > 0)
                {
                    Region region = new Region(graphicsPath);
                    region.Exclude(graphicsPath1);
                    SolidBrush solidBrush = new SolidBrush(m_OuterBorderLightColor);
                    Region region1 = region.Clone();
                    region1.Intersect(graphicsPath4);
                    g.FillRegion(solidBrush, region1);
                    g.SetClip(graphicsPath4);
                    Pen pen = new Pen(solidBrush);
                    g.DrawPath(pen, graphicsPath);
                    g.DrawPath(pen, graphicsPath1);
                    pen.Dispose();
                    g.ResetClip();
                    solidBrush.Dispose();
                    region1.Dispose();
                    SolidBrush solidBrush1 = new SolidBrush(m_OuterBorderDarkColor);
                    Region region2 = region.Clone();
                    region2.Exclude(graphicsPath4);
                    g.FillRegion(solidBrush1, region2);
                    g.SetClip(graphicsPath4, CombineMode.Exclude);
                    Pen pen1 = new Pen(solidBrush1);
                    g.DrawPath(pen1, graphicsPath);
                    g.DrawPath(pen1, graphicsPath1);
                    pen1.Dispose();
                    g.ResetClip();
                    solidBrush1.Dispose();
                    region2.Dispose();
                    region.Dispose();
                }
                if (m_MiddleBorderLength > 0)
                {
                    Region region3 = new Region(graphicsPath1);
                    region3.Exclude(graphicsPath2);
                    SolidBrush solidBrush2 = new SolidBrush(m_MiddleBorderColor);
                    g.FillRegion(solidBrush2, region3);
                    Pen pen2 = new Pen(solidBrush2);
                    g.DrawPath(pen2, graphicsPath1);
                    g.DrawPath(pen2, graphicsPath2);
                    pen2.Dispose();
                    solidBrush2.Dispose();
                    region3.Dispose();
                }
                if (m_InnerBorderLength > 0)
                {
                    Region region4 = new Region(graphicsPath2);
                    region4.Exclude(graphicsPath3);
                    SolidBrush solidBrush3 = new SolidBrush(m_InnerBorderDarkColor);
                    Region region5 = region4.Clone();
                    region5.Intersect(graphicsPath4);
                    g.FillRegion(solidBrush3, region5);
                    g.SetClip(graphicsPath4);
                    Pen pen3 = new Pen(solidBrush3);
                    g.DrawPath(pen3, graphicsPath2);
                    g.DrawPath(pen3, graphicsPath3);
                    pen3.Dispose();
                    g.ResetClip();
                    solidBrush3.Dispose();
                    region5.Dispose();
                    SolidBrush solidBrush4 = new SolidBrush(m_InnerBorderLightColor);
                    Region region6 = region4.Clone();
                    region6.Exclude(graphicsPath4);
                    g.FillRegion(solidBrush4, region6);
                    g.SetClip(graphicsPath4, CombineMode.Exclude);
                    Pen pen4 = new Pen(solidBrush4);
                    g.DrawPath(pen4, graphicsPath2);
                    g.DrawPath(pen4, graphicsPath3);
                    pen4.Dispose();
                    g.ResetClip();
                    solidBrush4.Dispose();
                    region6.Dispose();
                    region4.Dispose();
                }
                graphicsPath4.Dispose();
            }
            else if (m_BorderGradientType != DAS_BorderGradientStyle.BGS_Ring)
            {
                if (m_BorderGradientType != DAS_BorderGradientStyle.BGS_Linear)
                {
                    if (m_BorderGradientType == DAS_BorderGradientStyle.BGS_Linear2)
                    {
                        goto Label2;
                    }
                    if (m_BorderGradientType == DAS_BorderGradientStyle.BGS_Path)
                    {
                        Blend blend = new Blend();
                        bool flag = false;
                        if ((double)m_BorderGradientRate < 0.49999999999 || (double)m_BorderGradientRate > 0.5000000000001)
                        {
                            flag = true;
                            blend.Factors = new float[3];
                            blend.Positions = new float[3];
                            blend.Factors[0] = 0f;
                            blend.Positions[0] = 0f;
                            blend.Factors[1] = m_BorderGradientRate;
                            blend.Positions[1] = 1f - m_BorderGradientRate;
                            blend.Factors[2] = 1f;
                            blend.Positions[2] = 1f;
                        }
                        if (m_OuterBorderLength > 0)
                        {
                            double long0 = 3.14159265358979 * (double)m_BorderGradientAngle / 180;
                            GraphicsPath graphicsPath5 = new GraphicsPath();
                            point = new Point[] { new Point(rectangle.Left - 1, rectangle.Top - 1), new Point(rectangle.Left + rectangle.Width + 1, rectangle.Top - 1), new Point(rectangle.Left + rectangle.Width + 1, rectangle.Top + rectangle.Height + 1), new Point(rectangle.Left - 1, rectangle.Top + rectangle.Height + 1) };
                            graphicsPath5.AddPolygon(point);
                            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath5)
                            {
                                SurroundColors = new Color[] { m_OuterBorderDarkColor }
                            };
                            PointF x = new PointF()
                            {
                                X = (float)rectangle.Left + (float)rectangle.Width / 2f,
                                Y = (float)rectangle.Top + (float)rectangle.Height / 2f
                            };
                            if (Math.Abs(Math.Sin(long0)) < 1E-10)
                            {
                                single = 0f;
                                height = (float)(Math.Cos(long0) * (double)(rectangle.Width - m_OuterBorderLength) / 2);
                            }
                            else if (Math.Abs(Math.Cos(long0)) >= 1E-10)
                            {
                                height = (float)((double)(rectangle.Height - m_OuterBorderLength) / (2 * Math.Tan(long0)));
                                single = (float)(Math.Tan(long0) * (double)(rectangle.Width - m_OuterBorderLength) / 2);
                                height = (Math.Cos(long0) >= 0 ? Math.Abs(height) : -Math.Abs(height));
                                single = (Math.Sin(long0) >= 0 ? Math.Abs(single) : -Math.Abs(single));
                                if (height < -((float)(rectangle.Width - m_OuterBorderLength) / 2f))
                                {
                                    height = -((float)(rectangle.Width - m_OuterBorderLength) / 2f);
                                }
                                else if (height > (float)(rectangle.Width - m_OuterBorderLength) / 2f)
                                {
                                    height = (float)(rectangle.Width - m_OuterBorderLength) / 2f;
                                }
                                if (single < -((float)(rectangle.Height - m_OuterBorderLength) / 2f))
                                {
                                    single = -((float)(rectangle.Height - m_OuterBorderLength) / 2f);
                                }
                                else if (single > (float)(rectangle.Height - m_OuterBorderLength) / 2f)
                                {
                                    single = (float)(rectangle.Height - m_OuterBorderLength) / 2f;
                                }
                            }
                            else
                            {
                                height = 0f;
                                single = (float)(Math.Sin(long0) * (double)(rectangle.Height - m_OuterBorderLength) / 2);
                            }
                            x.X = x.X + height * m_BorderGradientLightPos1;
                            x.Y = x.Y + single * m_BorderGradientLightPos1;
                            if (flag)
                            {
                                pathGradientBrush.Blend = blend;
                            }
                            pathGradientBrush.CenterPoint = x;
                            pathGradientBrush.CenterColor = m_OuterBorderLightColor;
                            Region region7 = new Region(graphicsPath);
                            Region region8 = new Region(graphicsPath1);
                            region7.Exclude(region8);
                            g.FillRegion(pathGradientBrush, region7);
                            Pen pen5 = new Pen(m_OuterBorderDarkColor);
                            g.DrawPath(pen5, graphicsPath);
                            g.DrawPath(pen5, graphicsPath1);
                            pen5.Dispose();
                            pathGradientBrush.Dispose();
                            region7.Dispose();
                            region8.Dispose();
                        }
                        if (m_MiddleBorderLength > 0)
                        {
                            Region region9 = new Region(graphicsPath1);
                            region9.Exclude(graphicsPath2);
                            SolidBrush solidBrush5 = new SolidBrush(m_MiddleBorderColor);
                            g.FillRegion(solidBrush5, region9);
                            Pen pen6 = new Pen(solidBrush5);
                            g.DrawPath(pen6, graphicsPath1);
                            g.DrawPath(pen6, graphicsPath2);
                            pen6.Dispose();
                            solidBrush5.Dispose();
                            region9.Dispose();
                        }
                        if (m_InnerBorderLength > 0)
                        {
                            double num = 3.14159265358979 * (double)m_BorderGradientAngle / 180 + 3.14159265358979;
                            GraphicsPath graphicsPath6 = new GraphicsPath();
                            point = new Point[] { new Point(rectangle2.Left, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top + rectangle2.Height), new Point(rectangle2.Left, rectangle2.Top + rectangle2.Height) };
                            graphicsPath6.AddPolygon(point);
                            PathGradientBrush color4 = new PathGradientBrush(graphicsPath6)
                            {
                                SurroundColors = new Color[] { m_InnerBorderDarkColor }
                            };
                            PointF y = new PointF()
                            {
                                X = (float)rectangle2.Left + (float)rectangle2.Width / 2f,
                                Y = (float)rectangle2.Top + (float)rectangle2.Height / 2f
                            };
                            if (Math.Abs(Math.Sin(num)) < 1E-10)
                            {
                                height1 = 0f;
                                width = (float)(Math.Cos(num) * (double)(rectangle2.Width - m_InnerBorderLength) / 2);
                            }
                            else if (Math.Abs(Math.Cos(num)) >= 1E-10)
                            {
                                width = (float)((double)(rectangle2.Height - m_InnerBorderLength) / (2 * Math.Tan(num)));
                                height1 = (float)(Math.Tan(num) * (double)(rectangle2.Width - m_InnerBorderLength) / 2);
                                width = (Math.Cos(num) >= 0 ? Math.Abs(width) : -Math.Abs(width));
                                height1 = (Math.Sin(num) >= 0 ? Math.Abs(height1) : -Math.Abs(height1));
                                if (width < -((float)(rectangle2.Width - m_InnerBorderLength) / 2f))
                                {
                                    width = -((float)(rectangle2.Width - m_InnerBorderLength) / 2f);
                                }
                                else if (width > (float)(rectangle2.Width - m_InnerBorderLength) / 2f)
                                {
                                    width = (float)(rectangle2.Width - m_InnerBorderLength) / 2f;
                                }
                                if (height1 < -((float)(rectangle2.Height - m_InnerBorderLength) / 2f))
                                {
                                    height1 = -((float)(rectangle2.Height - m_InnerBorderLength) / 2f);
                                }
                                else if (height1 > (float)(rectangle2.Height - m_InnerBorderLength) / 2f)
                                {
                                    height1 = (float)(rectangle2.Height - m_InnerBorderLength) / 2f;
                                }
                            }
                            else
                            {
                                width = 0f;
                                height1 = (float)(Math.Sin(num) * (double)(rectangle2.Height - m_InnerBorderLength) / 2);
                            }
                            y.X = y.X + width * m_BorderGradientLightPos1;
                            y.Y = y.Y + height1 * m_BorderGradientLightPos1;
                            if (flag)
                            {
                                color4.Blend = blend;
                            }
                            color4.CenterPoint = y;
                            color4.CenterColor = m_InnerBorderLightColor;
                            Region region10 = new Region(graphicsPath2);
                            Region region11 = new Region(graphicsPath3);
                            region10.Exclude(region11);
                            g.FillRegion(color4, region10);
                            Pen pen7 = new Pen(m_InnerBorderDarkColor);
                            g.DrawPath(pen7, graphicsPath2);
                            g.DrawPath(pen7, graphicsPath3);
                            pen7.Dispose();
                            color4.Dispose();
                            region10.Dispose();
                            region11.Dispose();
                            goto Label0;
                        }
                        else
                        {
                            goto Label0;
                        }
                    }
                    else
                    {
                        goto Label0;
                    }
                }
            Label2:
                Blend float0 = new Blend();
                bool flag1 = false;
                float float3 = 0f;
                if (m_BorderLightIntermediateBrightness >= 0f && (double)m_BorderLightIntermediateBrightness <= 1)
                {
                    float3 = m_BorderLightIntermediateBrightness;
                }
                if (m_BorderGradientLightPos1 > 0f && (double)m_BorderGradientLightPos1 < 1)
                {
                    flag1 = true;
                    if (m_BorderGradientLightPos2 <= 0f || (double)m_BorderGradientLightPos2 > 1)
                    {
                        float0.Factors = new float[5];
                        float0.Positions = new float[5];
                        float0.Factors[0] = 0f;
                        float0.Positions[0] = 0f;
                        float0.Factors[1] = m_BorderGradientRate;
                        float0.Positions[1] = m_BorderGradientLightPos1 * (1f - m_BorderGradientRate);
                        float0.Factors[2] = 1f;
                        float0.Positions[2] = m_BorderGradientLightPos1;
                        float0.Factors[3] = m_BorderGradientRate;
                        float0.Positions[3] = (1f - m_BorderGradientLightPos1) * m_BorderGradientRate + m_BorderGradientLightPos1;
                        float0.Factors[4] = 0f;
                        float0.Positions[4] = 1f;
                    }
                    else
                    {
                        float0.Factors = new float[9];
                        float0.Positions = new float[9];
                        if (m_BorderGradientLightPos1 <= m_BorderGradientLightPos2)
                        {
                            float0.Factors[0] = 0f;
                            float0.Positions[0] = 0f;
                            float0.Factors[1] = m_BorderGradientRate;
                            float0.Positions[1] = m_BorderGradientLightPos1 * (1f - m_BorderGradientRate);
                            float0.Factors[2] = 1f;
                            float0.Positions[2] = m_BorderGradientLightPos1;
                            float0.Factors[3] = (1f - float3) * m_BorderGradientRate + float3;
                            float0.Positions[3] = m_BorderGradientLightPos1 + (m_BorderGradientLightPos2 - m_BorderGradientLightPos1) / 2f * m_BorderGradientRate;
                            float0.Factors[4] = float3;
                            float0.Positions[4] = (m_BorderGradientLightPos1 + m_BorderGradientLightPos2) / 2f;
                            float0.Factors[5] = (1f - float3) * m_BorderGradientRate + float3;
                            float0.Positions[5] = (m_BorderGradientLightPos1 + m_BorderGradientLightPos2) / 2f + (m_BorderGradientLightPos2 - m_BorderGradientLightPos1) / 2f * (1f - m_BorderGradientRate);
                            float0.Factors[6] = 1f;
                            float0.Positions[6] = m_BorderGradientLightPos2;
                            float0.Factors[7] = m_BorderGradientRate;
                            float0.Positions[7] = m_BorderGradientLightPos2 + (1f - m_BorderGradientLightPos2) * m_BorderGradientRate;
                            float0.Factors[8] = 0f;
                            float0.Positions[8] = 1f;
                            if (m_BorderGradientLightPos1 == m_BorderGradientLightPos2)
                            {
                                float0.Factors[3] = 1f;
                                float0.Factors[4] = 1f;
                                float0.Factors[5] = 1f;
                            }
                            if (m_BorderGradientLightPos2 == 1f)
                            {
                                float0.Factors[7] = 1f;
                                float0.Factors[8] = 1f;
                            }
                        }
                        else
                        {
                            float0.Factors[0] = 0f;
                            float0.Positions[0] = 0f;
                            float0.Factors[1] = m_BorderGradientRate;
                            float0.Positions[1] = m_BorderGradientLightPos2 * (1f - m_BorderGradientRate);
                            float0.Factors[2] = 1f;
                            float0.Positions[2] = m_BorderGradientLightPos2;
                            float0.Factors[3] = (1f - float3) * m_BorderGradientRate + float3;
                            float0.Positions[3] = m_BorderGradientLightPos2 + (m_BorderGradientLightPos1 - m_BorderGradientLightPos2) / 2f * m_BorderGradientRate;
                            float0.Factors[4] = float3;
                            float0.Positions[4] = (m_BorderGradientLightPos1 + m_BorderGradientLightPos2) / 2f;
                            float0.Factors[5] = (1f - float3) * m_BorderGradientRate + float3;
                            float0.Positions[5] = (m_BorderGradientLightPos1 + m_BorderGradientLightPos2) / 2f + (m_BorderGradientLightPos1 - m_BorderGradientLightPos2) / 2f * (1f - m_BorderGradientRate);
                            float0.Factors[6] = 1f;
                            float0.Positions[6] = m_BorderGradientLightPos1;
                            float0.Factors[7] = m_BorderGradientRate;
                            float0.Positions[7] = m_BorderGradientLightPos1 + (1f - m_BorderGradientLightPos1) * m_BorderGradientRate;
                            float0.Factors[8] = 0f;
                            float0.Positions[8] = 1f;
                        }
                    }
                }
                else if ((double)m_BorderGradientRate < 0.49999999999 || (double)m_BorderGradientRate > 0.5000000000001)
                {
                    flag1 = true;
                    float0.Factors = new float[3];
                    float0.Positions = new float[3];
                    float0.Factors[0] = 0f;
                    float0.Positions[0] = 0f;
                    float0.Factors[1] = m_BorderGradientRate;
                    float0.Positions[1] = 1f - m_BorderGradientRate;
                    float0.Factors[2] = 1f;
                    float0.Positions[2] = 1f;
                }
                if (m_OuterBorderLength > 0)
                {
                    Rectangle rectangle4 = new Rectangle(rectangle.Left - 1, rectangle.Top - 1, rectangle.Width + 2, rectangle.Height + 2);
                    LinearGradientBrush linearGradientBrush1 = new LinearGradientBrush(rectangle4, m_OuterBorderDarkColor, m_OuterBorderLightColor, (float)m_BorderGradientAngle);
                    if (flag1)
                    {
                        linearGradientBrush1.Blend = float0;
                    }
                    Region region12 = new Region(graphicsPath);
                    Region region13 = new Region(graphicsPath1);
                    region12.Exclude(region13);
                    g.FillRegion(linearGradientBrush1, region12);
                    Pen pen8 = new Pen(linearGradientBrush1);
                    g.DrawPath(pen8, graphicsPath);
                    g.DrawPath(pen8, graphicsPath1);
                    pen8.Dispose();
                    linearGradientBrush1.Dispose();
                    region12.Dispose();
                    region13.Dispose();
                }
                if (m_MiddleBorderLength > 0)
                {
                    Region region14 = new Region(graphicsPath1);
                    region14.Exclude(graphicsPath2);
                    SolidBrush solidBrush6 = new SolidBrush(m_MiddleBorderColor);
                    g.FillRegion(solidBrush6, region14);
                    Pen pen9 = new Pen(solidBrush6);
                    g.DrawPath(pen9, graphicsPath1);
                    g.DrawPath(pen9, graphicsPath2);
                    pen9.Dispose();
                    solidBrush6.Dispose();
                    region14.Dispose();
                }
                if (m_InnerBorderLength > 0)
                {
                    linearGradientBrush = (m_BorderGradientType != DAS_BorderGradientStyle.BGS_Linear ? new LinearGradientBrush(rectangle2, m_InnerBorderDarkColor, m_InnerBorderLightColor, (float)(m_BorderGradientAngle + (long)180)) : new LinearGradientBrush(rectangle2, m_InnerBorderLightColor, m_InnerBorderDarkColor, (float)m_BorderGradientAngle));
                    if (flag1)
                    {
                        linearGradientBrush.Blend = float0;
                    }
                    Region region15 = new Region(graphicsPath2);
                    Region region16 = new Region(graphicsPath3);
                    region15.Exclude(region16);
                    g.FillRegion(linearGradientBrush, region15);
                    Pen pen10 = new Pen(linearGradientBrush);
                    g.DrawPath(pen10, graphicsPath2);
                    g.DrawPath(pen10, graphicsPath3);
                    pen10.Dispose();
                    linearGradientBrush.Dispose();
                    region15.Dispose();
                    region16.Dispose();
                }
            }
            else
            {
                Blend blend1 = new Blend()
                {
                    Factors = new float[3],
                    Positions = new float[3]
                };
                blend1.Factors[0] = 0f;
                blend1.Positions[0] = 0f;
                blend1.Factors[2] = 1f;
                blend1.Positions[2] = 1f;
                if (m_OuterBorderLength > 0)
                {
                    blend1.Factors[1] = m_BorderGradientRate;
                    blend1.Positions[1] = 1f - m_BorderGradientRate;
                    PathGradientBrush pathGradientBrush1 = new PathGradientBrush(graphicsPath)
                    {
                        SurroundColors = new Color[] { m_OuterBorderDarkColor },
                        CenterColor = m_OuterBorderLightColor
                    };
                    PointF pointF = new PointF()
                    {
                        X = (float)rectangle1.Width / (float)rectangle.Width,
                        Y = (float)rectangle1.Height / (float)rectangle.Height
                    };
                    pathGradientBrush1.FocusScales = pointF;
                    Region region17 = new Region(graphicsPath);
                    Region region18 = new Region(graphicsPath1);
                    region17.Exclude(region18);
                    g.FillRegion(pathGradientBrush1, region17);
                    Pen pen11 = new Pen(m_OuterBorderDarkColor);
                    g.DrawPath(pen11, graphicsPath);
                    pen11.Dispose();
                    pathGradientBrush1.Dispose();
                    region17.Dispose();
                    region18.Dispose();
                }
                if (m_MiddleBorderLength > 0)
                {
                    Region region19 = new Region(graphicsPath1);
                    region19.Exclude(graphicsPath2);
                    SolidBrush solidBrush7 = new SolidBrush(m_MiddleBorderColor);
                    g.FillRegion(solidBrush7, region19);
                    Pen pen12 = new Pen(solidBrush7);
                    g.DrawPath(pen12, graphicsPath1);
                    g.DrawPath(pen12, graphicsPath2);
                    pen12.Dispose();
                    solidBrush7.Dispose();
                    region19.Dispose();
                }
                if (m_InnerBorderLength > 0)
                {
                    blend1.Factors[1] = 1f - m_BorderGradientRate;
                    blend1.Positions[1] = m_BorderGradientRate;
                    PathGradientBrush pathGradientBrush2 = new PathGradientBrush(graphicsPath2)
                    {
                        SurroundColors = new Color[] { m_InnerBorderLightColor },
                        Blend = blend1,
                        CenterColor = m_InnerBorderDarkColor
                    };
                    PointF pointF1 = new PointF()
                    {
                        X = (float)rectangle3.Width / (float)rectangle2.Width,
                        Y = (float)rectangle3.Height / (float)rectangle2.Height
                    };
                    pathGradientBrush2.FocusScales = pointF1;
                    Region region20 = new Region(graphicsPath2);
                    Region region21 = new Region(graphicsPath3);
                    region20.Exclude(region21);
                    g.FillRegion(pathGradientBrush2, region20);
                    Pen pen13 = new Pen(m_InnerBorderDarkColor);
                    g.DrawPath(pen13, graphicsPath3);
                    pen13.Dispose();
                    pathGradientBrush2.Dispose();
                    region20.Dispose();
                    region21.Dispose();
                }
            }
        Label0:
            if (m_BorderExteriorLength > 0)
            {
                SolidBrush solidBrush8 = new SolidBrush(m_BorderExteriorColor);
                GraphicsPath graphicsPath7 = new GraphicsPath();
                this.method_6(graphicsPath7, rec_width, m_Shape, m_ArrowWidth + m_BorderExteriorLength + m_OuterBorderLength + m_MiddleBorderLength + m_InnerBorderLength, 0);
                Region region22 = new Region(graphicsPath7);
                region22.Exclude(graphicsPath);
                g.FillRegion(solidBrush8, region22);
                Pen pen14 = new Pen(solidBrush8);
                g.DrawPath(pen14, graphicsPath7);
                g.DrawPath(pen14, graphicsPath);
                pen14.Dispose();
                solidBrush8.Dispose();
                region22.Dispose();
                graphicsPath7.Dispose();
            }
            graphicsPath3.Dispose();
            graphicsPath2.Dispose();
            graphicsPath.Dispose();
        }

        internal void method_6(GraphicsPath graphicsPath_0, Rectangle rectangle_0, DAS_ShapeStyle das_ShapeStyle_0, int int_0, int int_1)
        {
            int int0 = int_0;
            int left = rectangle_0.Left;
            int top = rectangle_0.Top;
            int width = rectangle_0.Width - 1;
            int height = rectangle_0.Height - 1;
            float int1 = 0f;
            float single = 0f;
            if (int0 > width - 2)
            {
                int0 = width - 2;
            }
            if (int0 > height - 2)
            {
                int0 = height - 2;
            }
            if (das_ShapeStyle_0 == DAS_ShapeStyle.SS_Left_Triangle)
            {
                int1 = (float)((double)int_1 * Math.Sqrt((double)(rectangle_0.Width * rectangle_0.Width) + (double)(rectangle_0.Height * rectangle_0.Height) / 4) / ((double)rectangle_0.Height / 2));
                single = (float)((double)(int_1 * rectangle_0.Width) / (Math.Sqrt((double)(rectangle_0.Width * rectangle_0.Width) + (double)(rectangle_0.Height * rectangle_0.Height) / 4) - (double)rectangle_0.Height / 2));
                graphicsPath_0.AddLine((float)left + int1, (float)(top + height / 2), (float)(left + width - int_1), (float)top + single);
                graphicsPath_0.AddLine((float)(left + width - int_1), (float)top + single, (float)(left + width - int_1), (float)(top + height) - single);
                graphicsPath_0.AddLine((float)(left + width - int_1), (float)(top + height) - single, (float)left + int1, (float)(top + height / 2));
            }
            else if (das_ShapeStyle_0 == DAS_ShapeStyle.SS_Right_Triangle)
            {
                int1 = (float)((double)int_1 * Math.Sqrt((double)(rectangle_0.Width * rectangle_0.Width) + (double)(rectangle_0.Height * rectangle_0.Height) / 4) / ((double)rectangle_0.Height / 2));
                single = (float)((double)(int_1 * rectangle_0.Width) / (Math.Sqrt((double)(rectangle_0.Width * rectangle_0.Width) + (double)(rectangle_0.Height * rectangle_0.Height) / 4) - (double)rectangle_0.Height / 2));
                graphicsPath_0.AddLine((float)(left + width) - int1, (float)(top + height / 2), (float)(left + int_1), (float)top + single);
                graphicsPath_0.AddLine((float)(left + int_1), (float)top + single, (float)(left + int_1), (float)(top + height) - single);
                graphicsPath_0.AddLine((float)(left + int_1), (float)(top + height) - single, (float)(left + width) - int1, (float)(top + height / 2));
            }
            else if (das_ShapeStyle_0 == DAS_ShapeStyle.SS_Top_Triangle)
            {
                single = (float)((double)int_1 * Math.Sqrt((double)(rectangle_0.Height * rectangle_0.Height) + (double)(rectangle_0.Width * rectangle_0.Width) / 4) / ((double)rectangle_0.Width / 2));
                int1 = (float)((double)(int_1 * rectangle_0.Height) / (Math.Sqrt((double)(rectangle_0.Height * rectangle_0.Height) + (double)(rectangle_0.Width * rectangle_0.Width) / 4) - (double)rectangle_0.Width / 2));
                graphicsPath_0.AddLine((float)(left + width / 2), (float)top + single, (float)(left + width) - int1, (float)(top + height - int_1));
                graphicsPath_0.AddLine((float)(left + width) - int1, (float)(top + height - int_1), (float)left + int1, (float)(top + height - int_1));
                graphicsPath_0.AddLine((float)left + int1, (float)(top + height - int_1), (float)(left + width / 2), (float)top + single);
            }
            else if (das_ShapeStyle_0 == DAS_ShapeStyle.SS_Bottom_Triangle)
            {
                single = (float)((double)int_1 * Math.Sqrt((double)(rectangle_0.Height * rectangle_0.Height) + (double)(rectangle_0.Width * rectangle_0.Width) / 4) / ((double)rectangle_0.Width / 2));
                int1 = (float)((double)(int_1 * rectangle_0.Height) / (Math.Sqrt((double)(rectangle_0.Height * rectangle_0.Height) + (double)(rectangle_0.Width * rectangle_0.Width) / 4) - (double)rectangle_0.Width / 2));
                graphicsPath_0.AddLine((float)(left + width / 2), (float)(top + height) - single, (float)(left + width) - int1, (float)(top + int_1));
                graphicsPath_0.AddLine((float)(left + width) - int1, (float)(top + int_1), (float)left + int1, (float)(top + int_1));
                graphicsPath_0.AddLine((float)left + int1, (float)(top + int_1), (float)(left + width / 2), (float)(top + height) - single);
            }
            else if (das_ShapeStyle_0 == DAS_ShapeStyle.SS_Diamond)
            {
                int1 = (float)((double)int_1 * Math.Sqrt((double)(rectangle_0.Height * rectangle_0.Height + rectangle_0.Width * rectangle_0.Width) / 4) / ((double)rectangle_0.Height / 2));
                single = (float)((double)int_1 * Math.Sqrt((double)(rectangle_0.Height * rectangle_0.Height + rectangle_0.Width * rectangle_0.Width) / 4) / ((double)rectangle_0.Width / 2));
                graphicsPath_0.AddLine((float)(left + width / 2), (float)top + single, (float)(left + width) - int1, (float)(top + height / 2));
                graphicsPath_0.AddLine((float)(left + width) - int1, (float)(top + height / 2), (float)(left + width / 2), (float)(top + height) - single);
                graphicsPath_0.AddLine((float)(left + width / 2), (float)(top + height) - single, (float)left + int1, (float)(top + height / 2));
                graphicsPath_0.AddLine((float)left + int1, (float)(top + height / 2), (float)(left + width / 2), (float)top + single);
            }
            else if (das_ShapeStyle_0 == DAS_ShapeStyle.SS_Left_Arrow)
            {
                int1 = (float)((double)int_1 * Math.Sqrt((double)(int0 * int0) + (double)(rectangle_0.Height * rectangle_0.Height) / 4) / ((double)rectangle_0.Height / 2));
                single = (float)((double)(int_1 * int0) / (Math.Sqrt((double)(int0 * int0) + (double)(rectangle_0.Height * rectangle_0.Height) / 4) - (double)rectangle_0.Height / 2));
                graphicsPath_0.AddLine((float)left + int1, (float)(top + height / 2), (float)(left + int0 - int_1), (float)top + single);
                graphicsPath_0.AddLine((float)(left + int0 - int_1), (float)top + single, (float)(left + int0 - int_1), (float)(top + (height - int0) / 2 + int_1));
                graphicsPath_0.AddLine(left + int0 - int_1, top + (height - int0) / 2 + int_1, left + width - int_1, top + (height - int0) / 2 + int_1);
                graphicsPath_0.AddLine(left + width - int_1, top + (height - int0) / 2 + int_1, left + width - int_1, top + (height + int0) / 2 - int_1);
                graphicsPath_0.AddLine(left + width - int_1, top + (height + int0) / 2 - int_1, left + int0 - int_1, top + (height + int0) / 2 - int_1);
                graphicsPath_0.AddLine((float)(left + int0 - int_1), (float)(top + (height + int0) / 2 - int_1), (float)(left + int0 - int_1), (float)(top + height) - single);
                graphicsPath_0.AddLine((float)(left + int0 - int_1), (float)(top + height) - single, (float)left + int1, (float)(top + height / 2));
            }
            else if (das_ShapeStyle_0 == DAS_ShapeStyle.SS_Right_Arrow)
            {
                int1 = (float)((double)int_1 * Math.Sqrt((double)(int0 * int0) + (double)(rectangle_0.Height * rectangle_0.Height) / 4) / ((double)rectangle_0.Height / 2));
                single = (float)((double)(int_1 * int0) / (Math.Sqrt((double)(int0 * int0) + (double)(rectangle_0.Height * rectangle_0.Height) / 4) - (double)rectangle_0.Height / 2));
                graphicsPath_0.AddLine((float)(left + width) - int1, (float)(top + height / 2), (float)(left + width - int0 + int_1), (float)top + single);
                graphicsPath_0.AddLine((float)(left + width - int0 + int_1), (float)top + single, (float)(left + width - int0 + int_1), (float)(top + (height - int0) / 2 + int_1));
                graphicsPath_0.AddLine(left + width - int0 + int_1, top + (height - int0) / 2 + int_1, left + int_1, top + (height - int0) / 2 + int_1);
                graphicsPath_0.AddLine(left + int_1, top + (height - int0) / 2 + int_1, left + int_1, top + (height + int0) / 2 - int_1);
                graphicsPath_0.AddLine(left + int_1, top + (height + int0) / 2 - int_1, left + width - int0 + int_1, top + (height + int0) / 2 - int_1);
                graphicsPath_0.AddLine((float)(left + width - int0 + int_1), (float)(top + (height + int0) / 2 - int_1), (float)(left + width - int0 + int_1), (float)(top + height) - single);
                graphicsPath_0.AddLine((float)(left + width - int0 + int_1), (float)(top + height) - single, (float)(left + width) - int1, (float)(top + height / 2));
            }
            else if (das_ShapeStyle_0 == DAS_ShapeStyle.SS_Top_Arrow)
            {
                single = (float)((double)int_1 * Math.Sqrt((double)(int0 * int0) + (double)(rectangle_0.Width * rectangle_0.Width) / 4) / ((double)rectangle_0.Width / 2));
                int1 = (float)((double)(int_1 * int0) / (Math.Sqrt((double)(int0 * int0) + (double)(rectangle_0.Width * rectangle_0.Width) / 4) - (double)rectangle_0.Width / 2));
                graphicsPath_0.AddLine((float)(left + width / 2), (float)top + single, (float)left + int1, (float)(top + int0 - int_1));
                graphicsPath_0.AddLine((float)left + int1, (float)(top + int0 - int_1), (float)(left + (width - int0) / 2 + int_1), (float)(top + int0 - int_1));
                graphicsPath_0.AddLine(left + (width - int0) / 2 + int_1, top + int0 - int_1, left + (width - int0) / 2 + int_1, top + height - int_1);
                graphicsPath_0.AddLine(left + (width - int0) / 2 + int_1, top + height - int_1, left + (width + int0) / 2 - int_1, top + height - int_1);
                graphicsPath_0.AddLine(left + (width + int0) / 2 - int_1, top + height - int_1, left + (width + int0) / 2 - int_1, top + int0 - int_1);
                graphicsPath_0.AddLine((float)(left + (width + int0) / 2 - int_1), (float)(top + int0 - int_1), (float)(left + width) - int1, (float)(top + int0 - int_1));
                graphicsPath_0.AddLine((float)(left + width) - int1, (float)(top + int0 - int_1), (float)(left + width / 2), (float)top + single);
            }
            else if (das_ShapeStyle_0 == DAS_ShapeStyle.SS_Bottom_Arrow)
            {
                single = (float)((double)int_1 * Math.Sqrt((double)(int0 * int0) + (double)(rectangle_0.Width * rectangle_0.Width) / 4) / ((double)rectangle_0.Width / 2));
                int1 = (float)((double)(int_1 * int0) / (Math.Sqrt((double)(int0 * int0) + (double)(rectangle_0.Width * rectangle_0.Width) / 4) - (double)rectangle_0.Width / 2));
                graphicsPath_0.AddLine((float)(left + width / 2), (float)(top + height) - single, (float)left + int1, (float)(top + (height - int0) + int_1));
                graphicsPath_0.AddLine((float)left + int1, (float)(top + (height - int0) + int_1), (float)(left + (width - int0) / 2 + int_1), (float)(top + (height - int0) + int_1));
                graphicsPath_0.AddLine(left + (width - int0) / 2 + int_1, top + (height - int0) + int_1, left + (width - int0) / 2 + int_1, top + int_1);
                graphicsPath_0.AddLine(left + (width - int0) / 2 + int_1, top + int_1, left + (width + int0) / 2 - int_1, top + int_1);
                graphicsPath_0.AddLine(left + (width + int0) / 2 - int_1, top + int_1, left + (width + int0) / 2 - int_1, top + (height - int0) + int_1);
                graphicsPath_0.AddLine((float)(left + (width + int0) / 2 - int_1), (float)(top + (height - int0) + int_1), (float)(left + width) - int1, (float)(top + (height - int0) + int_1));
                graphicsPath_0.AddLine((float)(left + width) - int1, (float)(top + (height - int0) + int_1), (float)(left + width / 2), (float)(top + height) - single);
            }
            graphicsPath_0.CloseFigure();
        }

        internal void method_7(Graphics graphics_0, Rectangle rectangle_0, GraphicsPath graphicsPath_0, Color color_0, int int_0, float float_0)
        {
            graphics_0.TranslateTransform((float)int_0, (float)int_0);
            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath_0);
            Blend blend = new Blend()
            {
                Factors = new float[3],
                Positions = new float[3]
            };
            blend.Factors[0] = 0f;
            blend.Positions[0] = 0f;
            blend.Factors[2] = 1f;
            blend.Positions[2] = 1f;
            blend.Factors[1] = float_0;
            blend.Positions[1] = 1f - float_0;
            pathGradientBrush.SurroundColors = new Color[] { Color.Transparent };
            pathGradientBrush.Blend = blend;
            pathGradientBrush.CenterColor = color_0;
            PointF pointF = new PointF()
            {
                X = (float)(rectangle_0.Width - 2 * int_0) / (float)rectangle_0.Width,
                Y = (float)(rectangle_0.Height - 2 * int_0) / (float)rectangle_0.Height
            };
            pathGradientBrush.FocusScales = pointF;
            graphics_0.FillPath(pathGradientBrush, graphicsPath_0);
            pathGradientBrush.Dispose();
            graphics_0.ResetTransform();
        }
    }
}
