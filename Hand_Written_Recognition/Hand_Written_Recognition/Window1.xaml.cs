namespace Hand_Written_Recognition
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    ///     Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private DatabaseReader databaseReader = new DatabaseReader(); // Object Database reader

        private readonly NewDatabaseReader newDatabase = new NewDatabaseReader();

        public Window1()
        {
            this.InitializeComponent();
        }

        public double[] CoodCheck(int NumberOfPix, int mag)
        {
            // Coordinate starting point
            double x = 50;
            double y = 50;

            x = x + NumberOfPix % 28 * mag;
            y = y + NumberOfPix / 28 * mag;

            // MessageBox.Show("x=" + x + ",y=" + y); //debug function
            var re = new double[2];
            re[0] = x;
            re[1] = y;

            return re;
        }

        private void Drawit(byte[] vs)
        {
            // Draw out the image from the MINST database
            this.Can.Children.Clear();
            var mag = 10; // Scale Factor of image
            this.Can.Margin = new Thickness(0, 0, 0, 0); // Create new canvas object

            for (var count = 0; count < vs.Length - 1; count++)
            {
                // display each pixs
                var r = new Rectangle();
                var pixinforReverse = Convert.ToByte(255 - vs[count]); // RGB convert
                r.Fill = new SolidColorBrush(Color.FromRgb(pixinforReverse, pixinforReverse, pixinforReverse));

                // Test Function
                // r.Stroke = new SolidColorBrush(Colors.IndianRed);
                // r.StrokeDashCap = PenLineCap.Square;
                // Test Function
                r.Width = mag;
                r.Height = mag;

                var db = this.CoodCheck(count, mag); // coordinate Check and calculation of picture

                var x = db[0];
                var y = db[1];

                r.SetValue(Canvas.LeftProperty, x);
                r.SetValue(Canvas.TopProperty, y);
                this.Can.Children.Add(r); // draw picture

                // MessageBox.Show("run" + count); //debug funciton
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var drawing = new Drawing(); // For future 

            // MessageBox.Show(databaseReader.Database()); //debug function
            var vs = this.newDatabase.readBytes(); // Get data from database
            this.Drawit(vs); // draw it out

            // MainWindow mainWindow = new MainWindow();

            // mainWindow.ListBox.ItemsSource = vs;
            // mainWindow.Show();
            var vs_Position = vs.Length;
            this.itemLable.Content = vs[vs_Position - 1];
        }


        private Network Network = new Network();
        private void NetworkTest_Click(object sender, RoutedEventArgs e)
        {
            this.Network.NetworkStartPoint();
        }
    }
}