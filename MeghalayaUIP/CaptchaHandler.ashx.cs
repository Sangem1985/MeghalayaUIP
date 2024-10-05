using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MeghalayaUIP
{
    /// <summary>
    /// Summary description for CaptchaHandler
    /// </summary>
    public class CaptchaHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            using (Bitmap b = new Bitmap(101, 40, PixelFormat.Format32bppArgb))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    Rectangle rect = new Rectangle(0, 0, 100, 39);
                    g.FillRectangle(Brushes.BurlyWood, rect);

                    // Create string to draw.
                    Random r = new Random();
                    int startIndex = r.Next(1, 5);
                    int length = r.Next(5, 5);
                    String drawString = Guid.NewGuid().ToString().Replace("-", "0").Substring(startIndex, length);
                    drawString = context.Request.QueryString["query"].ToString();
                    // Create font and brush.
                    Font drawFont = new Font("Arial", 16, FontStyle.Italic | FontStyle.Strikeout);
                    using (SolidBrush drawBrush = new SolidBrush(Color.Blue))
                    {
                        // Create point for upper-left corner of drawing.
                        PointF drawPoint = new PointF(10, 10);

                        // Draw string to screen.
                        g.DrawRectangle(new Pen(Color.Blue, 0), rect);
                        g.DrawString(drawString, drawFont, drawBrush, drawPoint);
                    }
                    b.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                    context.Response.ContentType = "image/jpeg";
                    context.Response.End();
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}