using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Drawing;

namespace Hand_Written_Recognition
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseReader databaseReader = new DatabaseReader();
            Drawing drawing = new Drawing();
            //MessageBox.Show(databaseReader.Database());

            byte[] vs = databaseReader.pixInfrom();

            Drawit(vs);

            
           

        }

        

        private void Drawit(byte[] vs)
        {
            //int mag = 1;
            //byte pixInfo= 0;
            //var brush = new SolidColorBrush(Color.FromRgb(pixInfo, pixInfo, pixInfo));
            Can.Margin = new Thickness(0, 0, 0, 0);
            //Rectangle r = new Rectangle();
            for (int count=0; count< vs.Length; count++)
            {

                Rectangle r = new Rectangle();
                r.Fill = new SolidColorBrush(Color.FromRgb(vs[count], vs[count], vs[count]));
                r.Stroke = new SolidColorBrush(Colors.Red);
                r.Width = 8;
                r.Height = 8;
                double[] db = CoodCheck(count);
                double x = db[0];
                double y = db[1];
                r.SetValue(Canvas.LeftProperty, x);
                r.SetValue(Canvas.TopProperty, y);
                Can.Children.Add(r);
                //MessageBox.Show("run" + count);
            }
   
        }

        public double[] CoodCheck(int NumberOfPix)
        {
            double x = 50;
            double y = 50;

            x = x + ((NumberOfPix % 28) * (8));
            y = y + ((NumberOfPix / 28)*  (8));
            //MessageBox.Show("x=" + x + ",y=" + y);
            double[] re = new double[2];
            re[0] = x;
            re[1] = y;
            
            return re;
        }
    }
}
