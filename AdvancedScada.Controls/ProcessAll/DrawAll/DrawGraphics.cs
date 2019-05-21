using AdvancedScada.Controls.Enum;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AdvancedScada.Controls.ProcessAll.DrawAll
{
    internal class DrawGraphics
    {
        public DrawGraphics()
        {
        }

        internal void method_0(Graphics graphics_0, Rectangle rectangle_0, int int_0, Color color_0, Color color_1, int int_1, Color color_2, int int_2, Color color_3, Color color_4, int int_3, Color color_5, DAS_BorderGradientStyle das_BorderGradientStyle_0, int int_4, float float_0, float float_1, float float_2, float float_3)
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
            if ((int_3 + int_0 + int_1 + int_2) * 2 >= rectangle_0.Width || (int_3 + int_0 + int_1 + int_2) * 2 >= rectangle_0.Height)
            {
                return;
            }
            Rectangle rectangle = new Rectangle(rectangle_0.Left + int_3, rectangle_0.Top + int_3, rectangle_0.Width - 2 * int_3, rectangle_0.Height - 2 * int_3);
            Rectangle rectangle1 = new Rectangle(rectangle_0.Left + int_3 + int_0, rectangle_0.Top + int_3 + int_0, rectangle_0.Width - 2 * (int_3 + int_0), rectangle_0.Height - 2 * (int_3 + int_0));
            Rectangle rectangle2 = new Rectangle(rectangle_0.Left + int_3 + int_0 + int_1, rectangle_0.Top + int_3 + int_0 + int_1, rectangle_0.Width - 2 * (int_3 + int_0 + int_1), rectangle_0.Height - 2 * (int_3 + int_0 + int_1));
            Rectangle rectangle3 = new Rectangle(rectangle_0.Left + int_3 + int_0 + int_1 + int_2, rectangle_0.Top + int_3 + int_0 + int_1 + int_2, rectangle_0.Width - 2 * (int_3 + int_0 + int_1 + int_2), rectangle_0.Height - 2 * (int_3 + int_0 + int_1 + int_2));
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
                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddPolygon(left);
                if (int_0 > 0)
                {
                    Region region1 = new Region(rectangle);
                    region1.Exclude(rectangle1);
                    SolidBrush solidBrush1 = new SolidBrush(color_1);
                    Region region2 = region1.Clone();
                    region2.Intersect(graphicsPath);
                    graphics_0.FillRegion(solidBrush1, region2);
                    solidBrush1.Dispose();
                    region2.Dispose();
                    SolidBrush solidBrush2 = new SolidBrush(color_0);
                    Region region3 = region1.Clone();
                    region3.Exclude(graphicsPath);
                    graphics_0.FillRegion(solidBrush2, region3);
                    solidBrush2.Dispose();
                    region3.Dispose();
                    region1.Dispose();
                }
                if (int_1 > 0)
                {
                    Region region4 = new Region(rectangle1);
                    region4.Exclude(rectangle2);
                    SolidBrush solidBrush3 = new SolidBrush(color_2);
                    graphics_0.FillRegion(solidBrush3, region4);
                    Pen pen1 = new Pen(solidBrush3);
                    graphics_0.DrawRectangle(pen1, rectangle1);
                    graphics_0.DrawRectangle(pen1, rectangle2);
                    pen1.Dispose();
                    solidBrush3.Dispose();
                    region4.Dispose();
                }
                if (int_2 > 0)
                {
                    Region region5 = new Region(rectangle2);
                    region5.Exclude(rectangle3);
                    SolidBrush solidBrush4 = new SolidBrush(color_3);
                    Region region6 = region5.Clone();
                    region6.Intersect(graphicsPath);
                    graphics_0.FillRegion(solidBrush4, region6);
                    solidBrush4.Dispose();
                    region6.Dispose();
                    SolidBrush solidBrush5 = new SolidBrush(color_4);
                    Region region7 = region5.Clone();
                    region7.Exclude(graphicsPath);
                    graphics_0.FillRegion(solidBrush5, region7);
                    solidBrush5.Dispose();
                    region7.Dispose();
                    region5.Dispose();
                }
                graphicsPath.Dispose();
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
                            double int4 = 3.14159265358979 * (double)int_4 / 180;
                            GraphicsPath graphicsPath1 = new GraphicsPath();
                            point = new Point[] { new Point(rectangle.Left - 1, rectangle.Top - 1), new Point(rectangle.Left + rectangle.Width + 1, rectangle.Top - 1), new Point(rectangle.Left + rectangle.Width + 1, rectangle.Top + rectangle.Height + 1), new Point(rectangle.Left - 1, rectangle.Top + rectangle.Height + 1) };
                            graphicsPath1.AddPolygon(point);
                            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath1)
                            {
                                SurroundColors = new Color[] { color_0 }
                            };
                            PointF x = new PointF()
                            {
                                X = (float)rectangle.Left + (float)rectangle.Width / 2f,
                                Y = (float)rectangle.Top + (float)rectangle.Height / 2f
                            };
                            if (Math.Abs(Math.Sin(int4)) < 1E-10)
                            {
                                single = 0f;
                                height = (float)(Math.Cos(int4) * (double)(rectangle.Width - int_0) / 2);
                            }
                            else if (Math.Abs(Math.Cos(int4)) >= 1E-10)
                            {
                                height = (float)((double)(rectangle.Height - int_0) / (2 * Math.Tan(int4)));
                                single = (float)(Math.Tan(int4) * (double)(rectangle.Width - int_0) / 2);
                                height = (Math.Cos(int4) >= 0 ? Math.Abs(height) : -Math.Abs(height));
                                single = (Math.Sin(int4) >= 0 ? Math.Abs(single) : -Math.Abs(single));
                                if (height < -((float)(rectangle.Width - int_0) / 2f))
                                {
                                    height = -((float)(rectangle.Width - int_0) / 2f);
                                }
                                else if (height > (float)(rectangle.Width - int_0) / 2f)
                                {
                                    height = (float)(rectangle.Width - int_0) / 2f;
                                }
                                if (single < -((float)(rectangle.Height - int_0) / 2f))
                                {
                                    single = -((float)(rectangle.Height - int_0) / 2f);
                                }
                                else if (single > (float)(rectangle.Height - int_0) / 2f)
                                {
                                    single = (float)(rectangle.Height - int_0) / 2f;
                                }
                            }
                            else
                            {
                                height = 0f;
                                single = (float)(Math.Sin(int4) * (double)(rectangle.Height - int_0) / 2);
                            }
                            x.X = x.X + height;
                            x.Y = x.Y + single;
                            if (flag)
                            {
                                pathGradientBrush.Blend = blend;
                            }
                            pathGradientBrush.CenterPoint = x;
                            pathGradientBrush.CenterColor = color_1;
                            Region region8 = new Region(rectangle);
                            region8.Exclude(rectangle1);
                            graphics_0.FillRegion(pathGradientBrush, region8);
                            pathGradientBrush.Dispose();
                            region8.Dispose();
                        }
                        if (int_1 > 0)
                        {
                            Region region9 = new Region(rectangle1);
                            region9.Exclude(rectangle2);
                            SolidBrush solidBrush6 = new SolidBrush(color_2);
                            graphics_0.FillRegion(solidBrush6, region9);
                            Pen pen2 = new Pen(solidBrush6);
                            graphics_0.DrawRectangle(pen2, rectangle1);
                            graphics_0.DrawRectangle(pen2, rectangle2);
                            pen2.Dispose();
                            solidBrush6.Dispose();
                            region9.Dispose();
                        }
                        if (int_2 > 0)
                        {
                            double num = 3.14159265358979 * (double)int_4 / 180 + 3.14159265358979;
                            GraphicsPath graphicsPath2 = new GraphicsPath();
                            point = new Point[] { new Point(rectangle2.Left, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top + rectangle2.Height), new Point(rectangle2.Left, rectangle2.Top + rectangle2.Height) };
                            graphicsPath2.AddPolygon(point);
                            PathGradientBrush color4 = new PathGradientBrush(graphicsPath2)
                            {
                                SurroundColors = new Color[] { color_3 }
                            };
                            PointF y = new PointF()
                            {
                                X = (float)rectangle2.Left + (float)rectangle2.Width / 2f,
                                Y = (float)rectangle2.Top + (float)rectangle2.Height / 2f
                            };
                            if (Math.Abs(Math.Sin(num)) < 1E-10)
                            {
                                height1 = 0f;
                                width = (float)(Math.Cos(num) * (double)(rectangle2.Width - int_2) / 2);
                            }
                            else if (Math.Abs(Math.Cos(num)) >= 1E-10)
                            {
                                width = (float)((double)(rectangle2.Height - int_2) / (2 * Math.Tan(num)));
                                height1 = (float)(Math.Tan(num) * (double)(rectangle2.Width - int_2) / 2);
                                width = (Math.Cos(num) >= 0 ? Math.Abs(width) : -Math.Abs(width));
                                height1 = (Math.Sin(num) >= 0 ? Math.Abs(height1) : -Math.Abs(height1));
                                if (width < -((float)(rectangle2.Width - int_2) / 2f))
                                {
                                    width = -((float)(rectangle2.Width - int_2) / 2f);
                                }
                                else if (width > (float)(rectangle2.Width - int_2) / 2f)
                                {
                                    width = (float)(rectangle2.Width - int_2) / 2f;
                                }
                                if (height1 < -((float)(rectangle2.Height - int_2) / 2f))
                                {
                                    height1 = -((float)(rectangle2.Height - int_2) / 2f);
                                }
                                else if (height1 > (float)(rectangle2.Height - int_2) / 2f)
                                {
                                    height1 = (float)(rectangle2.Height - int_2) / 2f;
                                }
                            }
                            else
                            {
                                width = 0f;
                                height1 = (float)(Math.Sin(num) * (double)(rectangle2.Height - int_2) / 2);
                            }
                            y.X = y.X + width;
                            y.Y = y.Y + height1;
                            if (flag)
                            {
                                color4.Blend = blend;
                            }
                            color4.CenterPoint = y;
                            color4.CenterColor = color_4;
                            Region region10 = new Region(rectangle2);
                            region10.Exclude(rectangle3);
                            graphics_0.FillRegion(color4, region10);
                            color4.Dispose();
                            region10.Dispose();
                            if (int_3 > 0)
                            {
                                solidBrush = new SolidBrush(color_5);
                                region = new Region(rectangle_0);
                                region.Exclude(rectangle);
                                graphics_0.FillRegion(solidBrush, region);
                                pen = new Pen(solidBrush, (float)int_3);
                                graphics_0.DrawRectangle(pen, rectangle_0);
                                graphics_0.DrawRectangle(pen, rectangle);
                                pen.Dispose();
                                solidBrush.Dispose();
                                region.Dispose();
                            }
                            return;
                        }
                        else
                        {
                            if (int_3 > 0)
                            {
                                solidBrush = new SolidBrush(color_5);
                                region = new Region(rectangle_0);
                                region.Exclude(rectangle);
                                graphics_0.FillRegion(solidBrush, region);
                                pen = new Pen(solidBrush, (float)int_3);
                                graphics_0.DrawRectangle(pen, rectangle_0);
                                graphics_0.DrawRectangle(pen, rectangle);
                                pen.Dispose();
                                solidBrush.Dispose();
                                region.Dispose();
                            }
                            return;
                        }
                    }
                    else
                    {
                        if (int_3 > 0)
                        {
                            solidBrush = new SolidBrush(color_5);
                            region = new Region(rectangle_0);
                            region.Exclude(rectangle);
                            graphics_0.FillRegion(solidBrush, region);
                            pen = new Pen(solidBrush, (float)int_3);
                            graphics_0.DrawRectangle(pen, rectangle_0);
                            graphics_0.DrawRectangle(pen, rectangle);
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
                    LinearGradientBrush linearGradientBrush1 = new LinearGradientBrush(rectangle4, color_0, color_1, (float)int_4);
                    if (flag1)
                    {
                        linearGradientBrush1.Blend = float0;
                    }
                    Region region11 = new Region(rectangle);
                    region11.Exclude(rectangle1);
                    graphics_0.FillRegion(linearGradientBrush1, region11);
                    linearGradientBrush1.Dispose();
                    region11.Dispose();
                }
                if (int_1 > 0)
                {
                    Region region12 = new Region(rectangle1);
                    region12.Exclude(rectangle2);
                    SolidBrush solidBrush7 = new SolidBrush(color_2);
                    graphics_0.FillRegion(solidBrush7, region12);
                    Pen pen3 = new Pen(solidBrush7);
                    graphics_0.DrawRectangle(pen3, rectangle1);
                    graphics_0.DrawRectangle(pen3, rectangle2);
                    pen3.Dispose();
                    solidBrush7.Dispose();
                    region12.Dispose();
                }
                if (int_2 > 0)
                {
                    linearGradientBrush = (das_BorderGradientStyle_0 != DAS_BorderGradientStyle.BGS_Linear ? new LinearGradientBrush(rectangle2, color_3, color_4, (float)(int_4 + 180)) : new LinearGradientBrush(rectangle2, color_4, color_3, (float)int_4));
                    if (flag1)
                    {
                        linearGradientBrush.Blend = float0;
                    }
                    Region region13 = new Region(rectangle2);
                    region13.Exclude(rectangle3);
                    graphics_0.FillRegion(linearGradientBrush, region13);
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
                if (int_0 > 0)
                {
                    blend1.Factors[1] = float_0;
                    blend1.Positions[1] = 1f - float_0;
                    GraphicsPath graphicsPath3 = new GraphicsPath();
                    point = new Point[] { new Point(rectangle.Left, rectangle.Top), new Point(rectangle.Left + rectangle.Width, rectangle.Top), new Point(rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height), new Point(rectangle.Left, rectangle.Top + rectangle.Height) };
                    graphicsPath3.AddPolygon(point);
                    PathGradientBrush pathGradientBrush1 = new PathGradientBrush(graphicsPath3)
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
                    Region region14 = new Region(rectangle);
                    region14.Exclude(rectangle1);
                    graphics_0.FillRegion(pathGradientBrush1, region14);
                    pathGradientBrush1.Dispose();
                    region14.Dispose();
                }
                if (int_1 > 0)
                {
                    Region region15 = new Region(rectangle1);
                    region15.Exclude(rectangle2);
                    SolidBrush solidBrush8 = new SolidBrush(color_2);
                    graphics_0.FillRegion(solidBrush8, region15);
                    Pen pen4 = new Pen(solidBrush8);
                    graphics_0.DrawRectangle(pen4, rectangle1);
                    graphics_0.DrawRectangle(pen4, rectangle2);
                    pen4.Dispose();
                    solidBrush8.Dispose();
                    region15.Dispose();
                }
                if (int_2 > 0)
                {
                    blend1.Factors[1] = 1f - float_0;
                    blend1.Positions[1] = float_0;
                    GraphicsPath graphicsPath4 = new GraphicsPath();
                    point = new Point[] { new Point(rectangle2.Left, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top + rectangle2.Height), new Point(rectangle2.Left, rectangle2.Top + rectangle2.Height) };
                    graphicsPath4.AddPolygon(point);
                    PathGradientBrush pathGradientBrush2 = new PathGradientBrush(graphicsPath4)
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
                    Region region16 = new Region(rectangle2);
                    region16.Exclude(rectangle3);
                    graphics_0.FillRegion(pathGradientBrush2, region16);
                    pathGradientBrush2.Dispose();
                    region16.Dispose();
                }
            }
            if (int_3 > 0)
            {
                solidBrush = new SolidBrush(color_5);
                region = new Region(rectangle_0);
                region.Exclude(rectangle);
                graphics_0.FillRegion(solidBrush, region);
                pen = new Pen(solidBrush, (float)int_3);
                graphics_0.DrawRectangle(pen, rectangle_0);
                graphics_0.DrawRectangle(pen, rectangle);
                pen.Dispose();
                solidBrush.Dispose();
                region.Dispose();
            }
        }

        internal void method_1(Graphics graphics_0, Rectangle rectangle_0, int int_0, int int_1, Color color_0, Color color_1, int int_2, Color color_2, int int_3, Color color_3, Color color_4, int int_4, Color color_5, DAS_BorderGradientStyle das_BorderGradientStyle_0, long long_0, float float_0, float float_1, float float_2, float float_3)
        {
            LinearGradientBrush linearGradientBrush;
            float height;
            float single;
            float width;
            float height1;
            Point[] point;
            Rectangle rectangle = new Rectangle(rectangle_0.Left + int_4, rectangle_0.Top + int_4, rectangle_0.Width - 2 * int_4, rectangle_0.Height - 2 * int_4);
            Rectangle rectangle1 = new Rectangle(rectangle_0.Left + int_4 + int_1, rectangle_0.Top + int_4 + int_1, rectangle_0.Width - 2 * (int_4 + int_1), rectangle_0.Height - 2 * (int_4 + int_1));
            Rectangle rectangle2 = new Rectangle(rectangle_0.Left + int_4 + int_1 + int_2, rectangle_0.Top + int_4 + int_1 + int_2, rectangle_0.Width - 2 * (int_4 + int_1 + int_2), rectangle_0.Height - 2 * (int_4 + int_1 + int_2));
            Rectangle rectangle3 = new Rectangle(rectangle_0.Left + int_4 + int_1 + int_2 + int_3, rectangle_0.Top + int_4 + int_1 + int_2 + int_3, rectangle_0.Width - 2 * (int_4 + int_1 + int_2 + int_3), rectangle_0.Height - 2 * (int_4 + int_1 + int_2 + int_3));
            int int0 = int_0;
            GraphicsPath graphicsPath = new GraphicsPath();
            this.method_3(graphicsPath, rectangle, int0);
            int0 = int_0 - int_1;
            GraphicsPath graphicsPath1 = new GraphicsPath();
            this.method_3(graphicsPath1, rectangle1, int0);
            int0 = int_0 - int_1 - int_2;
            GraphicsPath graphicsPath2 = new GraphicsPath();
            this.method_3(graphicsPath2, rectangle2, int0);
            int0 = int_0 - int_1 - int_2 - int_3;
            GraphicsPath graphicsPath3 = new GraphicsPath();
            this.method_3(graphicsPath3, rectangle3, int0);
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
                if (int_1 > 0)
                {
                    Region region = new Region(graphicsPath);
                    region.Exclude(graphicsPath1);
                    SolidBrush solidBrush = new SolidBrush(color_1);
                    Region region1 = region.Clone();
                    region1.Intersect(graphicsPath4);
                    graphics_0.FillRegion(solidBrush, region1);
                    graphics_0.SetClip(graphicsPath4);
                    Pen pen = new Pen(solidBrush);
                    graphics_0.DrawPath(pen, graphicsPath);
                    graphics_0.DrawPath(pen, graphicsPath1);
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
                    graphics_0.DrawPath(pen1, graphicsPath);
                    graphics_0.DrawPath(pen1, graphicsPath1);
                    pen1.Dispose();
                    graphics_0.ResetClip();
                    solidBrush1.Dispose();
                    region2.Dispose();
                    region.Dispose();
                }
                if (int_2 > 0)
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
                if (int_3 > 0)
                {
                    Region region4 = new Region(graphicsPath2);
                    region4.Exclude(graphicsPath3);
                    SolidBrush solidBrush3 = new SolidBrush(color_3);
                    Region region5 = region4.Clone();
                    region5.Intersect(graphicsPath4);
                    graphics_0.FillRegion(solidBrush3, region5);
                    graphics_0.SetClip(graphicsPath4);
                    Pen pen3 = new Pen(solidBrush3);
                    graphics_0.DrawPath(pen3, graphicsPath2);
                    graphics_0.DrawPath(pen3, graphicsPath3);
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
                    graphics_0.DrawPath(pen4, graphicsPath2);
                    graphics_0.DrawPath(pen4, graphicsPath3);
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
                        if (int_1 > 0)
                        {
                            double long0 = 3.14159265358979 * (double)long_0 / 180;
                            GraphicsPath graphicsPath5 = new GraphicsPath();
                            point = new Point[] { new Point(rectangle.Left - 1, rectangle.Top - 1), new Point(rectangle.Left + rectangle.Width + 1, rectangle.Top - 1), new Point(rectangle.Left + rectangle.Width + 1, rectangle.Top + rectangle.Height + 1), new Point(rectangle.Left - 1, rectangle.Top + rectangle.Height + 1) };
                            graphicsPath5.AddPolygon(point);
                            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath5)
                            {
                                SurroundColors = new Color[] { color_0 }
                            };
                            PointF x = new PointF()
                            {
                                X = (float)rectangle.Left + (float)rectangle.Width / 2f,
                                Y = (float)rectangle.Top + (float)rectangle.Height / 2f
                            };
                            if (Math.Abs(Math.Sin(long0)) < 1E-10)
                            {
                                single = 0f;
                                height = (float)(Math.Cos(long0) * (double)(rectangle.Width - int_1) / 2);
                            }
                            else if (Math.Abs(Math.Cos(long0)) >= 1E-10)
                            {
                                height = (float)((double)(rectangle.Height - int_1) / (2 * Math.Tan(long0)));
                                single = (float)(Math.Tan(long0) * (double)(rectangle.Width - int_1) / 2);
                                height = (Math.Cos(long0) >= 0 ? Math.Abs(height) : -Math.Abs(height));
                                single = (Math.Sin(long0) >= 0 ? Math.Abs(single) : -Math.Abs(single));
                                if (height < -((float)(rectangle.Width - int_1) / 2f))
                                {
                                    height = -((float)(rectangle.Width - int_1) / 2f);
                                }
                                else if (height > (float)(rectangle.Width - int_1) / 2f)
                                {
                                    height = (float)(rectangle.Width - int_1) / 2f;
                                }
                                if (single < -((float)(rectangle.Height - int_1) / 2f))
                                {
                                    single = -((float)(rectangle.Height - int_1) / 2f);
                                }
                                else if (single > (float)(rectangle.Height - int_1) / 2f)
                                {
                                    single = (float)(rectangle.Height - int_1) / 2f;
                                }
                            }
                            else
                            {
                                height = 0f;
                                single = (float)(Math.Sin(long0) * (double)(rectangle.Height - int_1) / 2);
                            }
                            x.X = x.X + height;
                            x.Y = x.Y + single;
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
                            graphics_0.DrawPath(pen5, graphicsPath1);
                            pen5.Dispose();
                            pathGradientBrush.Dispose();
                            region7.Dispose();
                            region8.Dispose();
                        }
                        if (int_2 > 0)
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
                        if (int_3 > 0)
                        {
                            double num = 3.14159265358979 * (double)long_0 / 180 + 3.14159265358979;
                            GraphicsPath graphicsPath6 = new GraphicsPath();
                            point = new Point[] { new Point(rectangle2.Left, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top), new Point(rectangle2.Left + rectangle2.Width, rectangle2.Top + rectangle2.Height), new Point(rectangle2.Left, rectangle2.Top + rectangle2.Height) };
                            graphicsPath6.AddPolygon(point);
                            PathGradientBrush color4 = new PathGradientBrush(graphicsPath6)
                            {
                                SurroundColors = new Color[] { color_3 }
                            };
                            PointF y = new PointF()
                            {
                                X = (float)rectangle2.Left + (float)rectangle2.Width / 2f,
                                Y = (float)rectangle2.Top + (float)rectangle2.Height / 2f
                            };
                            if (Math.Abs(Math.Sin(num)) < 1E-10)
                            {
                                height1 = 0f;
                                width = (float)(Math.Cos(num) * (double)(rectangle2.Width - int_3) / 2);
                            }
                            else if (Math.Abs(Math.Cos(num)) >= 1E-10)
                            {
                                width = (float)((double)(rectangle2.Height - int_3) / (2 * Math.Tan(num)));
                                height1 = (float)(Math.Tan(num) * (double)(rectangle2.Width - int_3) / 2);
                                width = (Math.Cos(num) >= 0 ? Math.Abs(width) : -Math.Abs(width));
                                height1 = (Math.Sin(num) >= 0 ? Math.Abs(height1) : -Math.Abs(height1));
                                if (width < -((float)(rectangle2.Width - int_3) / 2f))
                                {
                                    width = -((float)(rectangle2.Width - int_3) / 2f);
                                }
                                else if (width > (float)(rectangle2.Width - int_3) / 2f)
                                {
                                    width = (float)(rectangle2.Width - int_3) / 2f;
                                }
                                if (height1 < -((float)(rectangle2.Height - int_3) / 2f))
                                {
                                    height1 = -((float)(rectangle2.Height - int_3) / 2f);
                                }
                                else if (height1 > (float)(rectangle2.Height - int_3) / 2f)
                                {
                                    height1 = (float)(rectangle2.Height - int_3) / 2f;
                                }
                            }
                            else
                            {
                                width = 0f;
                                height1 = (float)(Math.Sin(num) * (double)(rectangle2.Height - int_3) / 2);
                            }
                            y.X = y.X + width;
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
                if (int_1 > 0)
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
                if (int_2 > 0)
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
                if (int_3 > 0)
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
                if (int_1 > 0)
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
                if (int_2 > 0)
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
                if (int_3 > 0)
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
            if (int_4 > 0)
            {
                SolidBrush solidBrush8 = new SolidBrush(color_5);
                GraphicsPath graphicsPath7 = new GraphicsPath();
                this.method_3(graphicsPath7, rectangle_0, int_0);
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

        internal void method_2(Graphics graphics_0, Rectangle rectangle_0, DAS_BorderStyle das_BorderStyle_0, GraphicsPath graphicsPath_0, Color color_0, Color color_1, DAS_BkGradientStyle das_BkGradientStyle_0, int int_0, float float_0, int int_1, float float_1)
        {
            float height;
            float single;
            if (das_BkGradientStyle_0 != DAS_BkGradientStyle.BKGS_Polygon)
            {
                if (das_BkGradientStyle_0 != DAS_BkGradientStyle.BKGS_Sphere)
                {
                    if (das_BkGradientStyle_0 != DAS_BkGradientStyle.BKGS_Linear)
                    {
                        if (das_BkGradientStyle_0 != DAS_BkGradientStyle.BKGS_Linear2)
                        {
                            if (das_BkGradientStyle_0 == DAS_BkGradientStyle.BKGS_Shine)
                            {
                                Blend blend = new Blend()
                                {
                                    Factors = new float[3],
                                    Positions = new float[3]
                                };
                                blend.Factors[0] = 0f;
                                blend.Positions[0] = 0f;
                                blend.Factors[1] = float_0;
                                blend.Positions[1] = 1f - float_0;
                                blend.Factors[2] = 1f;
                                blend.Positions[2] = 1f;
                                double int0 = 3.14159265358979 * (double)int_0 / 180;
                                GraphicsPath graphicsPath = new GraphicsPath();
                                Rectangle rectangle = new Rectangle(rectangle_0.Left - 1, rectangle_0.Top - 1, rectangle_0.Width + 2, rectangle_0.Height + 2);
                                if (das_BorderStyle_0 == DAS_BorderStyle.BS_Rect)
                                {
                                    graphicsPath.AddRectangle(rectangle);
                                }
                                else if (das_BorderStyle_0 != DAS_BorderStyle.BS_RoundRect)
                                {
                                    graphicsPath.AddEllipse(rectangle);
                                }
                                else
                                {
                                    this.method_3(graphicsPath, rectangle, int_1);
                                }
                                PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath)
                                {
                                    SurroundColors = new Color[] { color_0 }
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
                                x.X = x.X + height * float_1;
                                x.Y = x.Y + single * float_1;
                                pathGradientBrush.Blend = blend;
                                pathGradientBrush.CenterPoint = x;
                                pathGradientBrush.CenterColor = color_1;
                                if (graphicsPath_0 != null)
                                {
                                    graphics_0.FillPath(pathGradientBrush, graphicsPath_0);
                                }
                                else
                                {
                                    graphics_0.FillRectangle(pathGradientBrush, rectangle_0);
                                }
                                pathGradientBrush.Dispose();
                            }
                            return;
                        }
                    }
                    Blend float0 = new Blend();
                    if (das_BkGradientStyle_0 != DAS_BkGradientStyle.BKGS_Linear)
                    {
                        float0.Factors = new float[5];
                        float0.Positions = new float[5];
                        float0.Factors[0] = 0f;
                        float0.Positions[0] = 0f;
                        float0.Factors[1] = float_0;
                        float0.Positions[1] = 0.5f * (1f - float_0);
                        float0.Factors[2] = 1f;
                        float0.Positions[2] = 0.5f;
                        float0.Factors[3] = float_0;
                        float0.Positions[3] = 0.5f + 0.5f * float_0;
                        float0.Factors[4] = 0f;
                        float0.Positions[4] = 1f;
                    }
                    else
                    {
                        float0.Factors = new float[3];
                        float0.Positions = new float[3];
                        float0.Factors[0] = 0f;
                        float0.Positions[0] = 0f;
                        float0.Factors[1] = float_0;
                        float0.Positions[1] = 0.5f * (1f - float_0);
                        float0.Factors[2] = 1f;
                        float0.Positions[2] = 1f;
                    }
                    Rectangle rectangle1 = new Rectangle(rectangle_0.Left - 1, rectangle_0.Top - 1, rectangle_0.Width + 2, rectangle_0.Height + 2);
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle1, color_0, color_1, (float)int_0)
                    {
                        Blend = float0
                    };
                    if (graphicsPath_0 != null)
                    {
                        graphics_0.FillPath(linearGradientBrush, graphicsPath_0);
                    }
                    else
                    {
                        graphics_0.FillRectangle(linearGradientBrush, rectangle_0);
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
            blend1.Factors[1] = float_0;
            blend1.Positions[1] = 1f - float_0;
            GraphicsPath graphicsPath1 = new GraphicsPath();
            if (das_BkGradientStyle_0 != DAS_BkGradientStyle.BKGS_Polygon)
            {
                RectangleF rectangleF = new RectangleF((float)rectangle_0.Left - 0.415f * (float)rectangle_0.Width / 2f, (float)rectangle_0.Top - 0.415f * (float)rectangle_0.Height / 2f, 1.415f * (float)rectangle_0.Width, 1.415f * (float)rectangle_0.Height);
                graphicsPath1.AddEllipse(rectangleF);
            }
            else
            {
                Point[] point = new Point[] { new Point(rectangle_0.Left, rectangle_0.Top), new Point(rectangle_0.Left + rectangle_0.Width, rectangle_0.Top), new Point(rectangle_0.Left + rectangle_0.Width, rectangle_0.Top + rectangle_0.Height), new Point(rectangle_0.Left, rectangle_0.Top + rectangle_0.Height) };
                graphicsPath1.AddPolygon(point);
            }
            PathGradientBrush pathGradientBrush1 = new PathGradientBrush(graphicsPath1)
            {
                SurroundColors = new Color[] { color_0 },
                Blend = blend1,
                CenterColor = color_1
            };
            if (graphicsPath_0 != null)
            {
                graphics_0.FillPath(pathGradientBrush1, graphicsPath_0);
            }
            else
            {
                graphics_0.FillRectangle(pathGradientBrush1, rectangle_0);
            }
            pathGradientBrush1.Dispose();
        }

        internal void method_3(GraphicsPath graphicsPath_0, Rectangle rectangle_0, int int_0)
        {
            int int0 = int_0;
            int left = rectangle_0.Left;
            int top = rectangle_0.Top;
            int width = rectangle_0.Width - 1;
            int height = rectangle_0.Height - 1;
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

        internal void method_4(Graphics graphics_0, Rectangle rectangle_0, GraphicsPath graphicsPath_0, Color color_0, int int_0, float float_0)
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
