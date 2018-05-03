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
        public string Database()
        {
            string filePath = @"train-images.idx3-ubyte";
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fileStream);

            int magNumber = binaryReader.ReadInt32();
            int imgNumber = binaryReader.ReadInt32();
            int rowNumber = binaryReader.ReadInt32();
            int colNumber = binaryReader.ReadInt32();

            //byte[] image = binaryReader.ReadBytes(50);
            magNumber = ConvertBytes(magNumber);
            imgNumber = ConvertBytes(imgNumber);
            rowNumber = ConvertBytes(rowNumber);
            colNumber = ConvertBytes(colNumber);

            string r = "mag: " + magNumber.ToString()+ "# img:" + imgNumber.ToString()+ "# row:"+ rowNumber.ToString() + "# col:" + colNumber.ToString();

            fileStream.Close();


            return r;

            //train - images.idx3 - ubyte

        }

      
        public int ConvertBytes(int input)
        {
            byte[] inputByte = BitConverter.GetBytes(input);
            Array.Reverse(inputByte);
            return BitConverter.ToInt32(inputByte, 0);
        }
    }
}
