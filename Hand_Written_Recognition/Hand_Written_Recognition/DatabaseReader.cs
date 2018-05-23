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

        byte[] pix { get; set; }
        public long imageStreamPos { get; set; }
        int lable { get; set; }
        int lableStreamPos { get; set; }

        public byte[] pixInfrom(long startPosition)
        {
            string filePath = @"train-images.idx3-ubyte"; //file path
            FileStream fileStream = new FileStream(filePath, FileMode.Open); //Setup FileStream
            BinaryReader binaryReader = new BinaryReader(fileStream); //Setup BytereaderStream
            fileStream.Seek(800,0);
            
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
            string r = "mag: " + magNumber.ToString() + "# img:" + imgNumber.ToString() + "# row:" + rowNumber.ToString() + "# col:" + colNumber.ToString() + "# pixnumber:" + pixNumber.ToString();
            MessageBox.Show(r);


            byte[] pixByte = new byte[pixNumber];
            
            //Read bytes into ArrayList
            for (int counter=0; counter < pixNumber; counter++)
            {
                pixByte[counter] = binaryReader.ReadByte();
            }

            imageStreamPos = fileStream.Position;
            fileStream.Close();
            MessageBox.Show(imageStreamPos.ToString());
            return pixByte;

        }

        public int lableInform(int numberOrder)
        {
            string filePath = @"train-labels.idx1-ubyte";
            FileStream lableStream = new FileStream(filePath, FileMode.Open); //Setup FileStream
            BinaryReader lableVinaryReader = new BinaryReader(lableStream); //Setup BytereaderStream       

            int magNumber = lableVinaryReader.ReadInt32();
            int itemNumber = lableVinaryReader.ReadInt32();

            magNumber = ConvertBytes(magNumber);
            itemNumber = ConvertBytes(itemNumber);

            byte by = lableVinaryReader.ReadByte();
            MessageBox.Show("magNumber="+magNumber+"# itemNumber=" + itemNumber);

            lableStream.Close();
            return by;
        }
      
        public int ConvertBytes(int input)
        {
            //Reverse Bytes
            byte[] inputByte = BitConverter.GetBytes(input);
            Array.Reverse(inputByte);
            return BitConverter.ToInt32(inputByte, 0);
        }
    }

    class NewDatabaseReader
    {
        public long imageStreamLocation;
        public long lableStreamLocation;

        public byte[] readBytes()
        {
            string imagePath = @"train-images.idx3-ubyte";
            string lablePath = @"train-labels.idx3-ubyte";
            FileStream imageStream = new FileStream(imagePath,FileMode.Open);
            FileStream lableStream = new FileStream(lablePath,FileMode.Open);
            BinaryReader imageReader = new BinaryReader(imageStream);
            BinaryReader lableReader = new BinaryReader(lableStream);

            if (imageStream.Position == 0)
            {

            }
            else
            {

            }

            if (lableStream.Position == 0)
            {

            }
            else
            {

            }

        }

        public int convertByte(int inputInt)
        {
            byte[] inputByte = BitConverter.GetBytes(inputInt);
            Array.Reverse(inputByte);
            return BitConverter.ToInt32(inputByte, 0);
        }

    }
}
