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

namespace Hand_Written_Recognition
{
    class DatabaseReader
    {
        public void Database()
        {
            StreamReader reader = new StreamReader("train-images.idx3-ubyte");
            string line = reader.ReadToEnd();
            MessageBox.Show(line);
        }
    }
}
