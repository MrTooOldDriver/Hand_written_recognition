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
            DatabaseReader databaseReader = new DatabaseReader(); //Object Database reader
            Drawing drawing = new Drawing(); //For future 
            //MessageBox.Show(databaseReader.Database()); //debug function

            byte[] vs = databaseReader.pixInfrom(0); //Get data from database
            Drawit(vs); //draw it out

            MainWindow mainWindow = new MainWindow();

            mainWindow.ListBox.ItemsSource = vs;
            mainWindow.Show();

            itemLable.Content = databaseReader.lableInform(8);

        }

        

        private void Drawit(byte[] vs) //Draw out the image from the MINST database
        {
            Can.Children.Clear();
            int mag = 10; //Scale Factor of image
            Can.Margin = new Thickness(0, 0, 0, 0); //Create new canvas object
            
            for (int count=0; count< vs.Length; count++) //display each pixs
            {

                Rectangle r = new Rectangle();
                byte pixinforReverse = Convert.ToByte(255 - vs[count]);//RGB convert
                r.Fill = new SolidColorBrush(Color.FromRgb(pixinforReverse, pixinforReverse, pixinforReverse));

                //Test Function
                //r.Stroke = new SolidColorBrush(Colors.IndianRed);
                //r.StrokeDashCap = PenLineCap.Square;
                //Test Function

                r.Width = mag;
                r.Height = mag;

                double[] db = CoodCheck(count,mag);//coordinate Check and calculation of picture

                double x = db[0];
                double y = db[1];

                r.SetValue(Canvas.LeftProperty, x);
                r.SetValue(Canvas.TopProperty, y);
                Can.Children.Add(r);//draw picture

                //MessageBox.Show("run" + count); //debug funciton
            }
   
        }

        public double[] CoodCheck(int NumberOfPix,int mag) 
        {
            //Coordinate starting point
            double x = 50;
            double y = 50;

            x = x + ((NumberOfPix % 28) * (mag));
            y = y + ((NumberOfPix / 28)*  (mag));

            //MessageBox.Show("x=" + x + ",y=" + y); //debug function

            double[] re = new double[2];
            re[0] = x;
            re[1] = y;
            
            return re;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          DatabaseReader databaseReader = new  DatabaseReader();
          byte[] vs = databaseReader.pixInfrom(databaseReader.imageStreamPos);
          Drawit(vs);
            
        }
    }
}
