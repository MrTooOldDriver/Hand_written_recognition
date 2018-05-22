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
            string filePath = @"train-images.idx3-ubyte"; //file path
            FileStream fileStream = new FileStream(filePath, FileMode.Open); //Setup FileStream
            BinaryReader binaryReader = new BinaryReader(fileStream); //Setup BytereaderStream
           
            //Starting Read Byte

            int magNumber = binaryReader.ReadInt32(); 
            int imgNumber = binaryReader.ReadInt32();
            int rowNumber = binaryReader.ReadInt32();
            int colNumber = binaryReader.ReadInt32();

            //Reverse Byte
 
            magNumber = ConvertBytes(magNumber);
            imgNumber = ConvertBytes(imgNumber);
            rowNumber = ConvertBytes(rowNumber);
            colNumber = ConvertBytes(colNumber);

            //Get total pix number
            int pixNumber = rowNumber * colNumber;

            //Test function
            //string r = "mag: " + magNumber.ToString() + "# img:" + imgNumber.ToString() + "# row:" + rowNumber.ToString() + "# col:" + colNumber.ToString() +"# pixnumber:" + pixNumber.ToString();
            //MessageBox.Show(r);


            byte[] pixByte = new byte[pixNumber];
            
            //Read bytes into ArrayList
            for (int counter=0; counter < pixNumber; counter++)
            {
                pixByte[counter] = binaryReader.ReadByte();
            }

            return pixByte;

        }

      
        public int ConvertBytes(int input)
        {
            //Reberse Bytes
            byte[] inputByte = BitConverter.GetBytes(input);
            Array.Reverse(inputByte);
            return BitConverter.ToInt32(inputByte, 0);
        }
    }
}
