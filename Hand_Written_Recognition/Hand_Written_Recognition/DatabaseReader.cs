using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hand_Written_Recognition.Properties;


namespace Hand_Written_Recognition
{
    class DatabaseReader
    {
        public byte[] pixInfrom()
        {
            string filePath = @"train-images.idx3-ubyte";
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            PixelFormat pixelFormat = new PixelFormat();
            pixelFormat = PixelFormats.Bgr32; 
            //BitmapPalette bitmapPalette = new BitmapPalette(colors);

            List<Color> colors = new List<Color>();
            colors.Add(Colors.Black);
            colors.Add(Colors.White);

            BitmapPalette bitmapPalette = new BitmapPalette(colors);

            int magNumber = binaryReader.ReadInt32();
            int imgNumber = binaryReader.ReadInt32();
            int rowNumber = binaryReader.ReadInt32();
            int colNumber = binaryReader.ReadInt32();
 

            //byte[] image = binaryReader.ReadBytes(50);
            magNumber = ConvertBytes(magNumber);
            imgNumber = ConvertBytes(imgNumber);
            rowNumber = ConvertBytes(rowNumber);
            colNumber = ConvertBytes(colNumber);

            int pixNumber = rowNumber * colNumber;

            string r = "mag: " + magNumber.ToString() + "# img:" + imgNumber.ToString() + "# row:" + rowNumber.ToString() + "# col:" + colNumber.ToString() +"# pixnumber:" + pixNumber.ToString();

            //int pixNumber = rowNumber * colNumber;

            byte[] pixByte = new byte[pixNumber];
            

            for (int counter=0; counter < pixNumber; counter++)
            {
                pixByte[counter] = binaryReader.ReadByte();
            }

            return pixByte;


        }

      
        public int ConvertBytes(int input)
        {
            byte[] inputByte = BitConverter.GetBytes(input);
            Array.Reverse(inputByte);
            return BitConverter.ToInt32(inputByte, 0);
        }
    }
}
