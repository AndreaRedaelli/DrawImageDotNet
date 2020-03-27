using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

class Program
{
    // path file
    static readonly string PathFile = @"c:\file.bmp";
    // path legend file
    static readonly string LegendFilePath = @"c:\Legend.png";
    // position Legend
    static readonly float Xlegend = 220;
    static readonly float Ylegend = 10;
    // dimension image
    static readonly int Height = 500;
    static readonly int Width = 500;

    /// <summary>
    /// create or overwrite file
    /// </summary>
    private static void CreateFile()
    {
        // create or overwrite file
        FileStream f = File.Create(PathFile);
        f.Close();
    }

    static void Main(string[] args)
    {
        try
        {
            CreateFile();
            // create image
            Bitmap bitmap = new Bitmap(Height, Width, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            //retrieve legend file
            Image legend = new Bitmap(LegendFilePath);
            // put the legend inside the file
            PointF pos = new PointF(Xlegend, Ylegend);
            g.DrawImage(legend, pos);

            //draw the main rectangle
            Pen mainPen = new Pen(Color.Black, 1f);
            Rectangle mainBar = new Rectangle(10, 250, 485, 40);
            g.DrawRectangle(mainPen, mainBar);

            // draw inside
            Pen anotherPen = new Pen(Color.Red, 1f);
            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Red);
            // pay attention, the Y and Width must be the same for the purpose of draw inside the rectangle
            Rectangle anotherRectangle = new Rectangle(30, 250, 10, 40);
            g.DrawRectangle(anotherPen, anotherRectangle);
            g.FillRectangle(blueBrush, anotherRectangle);
            //save all
            bitmap.Save(PathFile);

        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
