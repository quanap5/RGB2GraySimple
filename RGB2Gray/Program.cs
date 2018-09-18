using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGB2Gray
{
    class Program
    {
        static void Main(string[] args)
        {
            string bmstr = @"C:\Users\admin\source\repos\RGB2Gray\test.jpg";
            string graystr = @"C:\Users\admin\source\repos\RGB2Gray\RGB2Gray.jpg";

            Bitmap sourcebm = null;
            Bitmap graybm = null;

            try
            {
                sourcebm = new Bitmap(bmstr);
                graybm = Convert2Grayscale(sourcebm);
                graybm.Save(graystr);
                Console.WriteLine("Convert RGB to Gray sucessfully");


            }
            catch (Exception e)
            {

                Console.WriteLine("Error message" + e.Message);
            }
            finally
            {
                if (sourcebm != null)
                {
                    sourcebm.Dispose();
                }
                if (graybm != null)
                {
                    graybm.Dispose();
                }
            }

            Console.ReadLine();

        }

        public static Bitmap Convert2Grayscale(Bitmap source)
        {
            Bitmap bm = new Bitmap(source.Width, source.Height);
            for (int indexY = 0; indexY < bm.Height; indexY++)
            {
                for (int indexX = 0; indexX < bm.Width; indexX++)
                {
                    Color c = source.GetPixel(indexX, indexY);
                    int average = (Convert.ToInt32(c.R) + Convert.ToInt32(c.G) + Convert.ToInt32(c.B)) / 3;
                    bm.SetPixel(indexX, indexY, Color.FromArgb(average, average, average));

                }
            }
            return bm;

        }
    }
}
